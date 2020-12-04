using KdTree;
using KdTree.Math;
using PEPExtensions;
using PEPlugin.Pmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDiagonalAligner
{
    class DiagonalAligner
    {
        IPXPmx Pmx { get; set; }

        IPXMaterial SourceMaterial { get; set; }
        IPXMaterial TargetMaterial { get; set; }

        public DiagonalAligner(IPXPmx pmx, IPXMaterial sourceMaterial, IPXMaterial targetMaterial)
        {
            Pmx = pmx;
            SourceMaterial = sourceMaterial;
            TargetMaterial = targetMaterial;
        }

        /// <summary>
        /// コレクションからkd木を構築
        /// </summary>
        /// <typeparam name="TKey">座標の型</typeparam>
        /// <typeparam name="TValue">コレクションの要素の型</typeparam>
        /// <param name="dimension">座標の次元数</param>
        /// <param name="math">座標の型の計算用オブジェクト</param>
        /// <param name="values">木を構築するコレクション</param>
        /// <param name="converter">コレクションの各要素から座標を取り出す方法</param>
        /// <returns>構築されたkd木</returns>
        private KdTree<TKey, TValue> MakeTree<TKey,TValue>(int dimension,ITypeMath<TKey> math,IEnumerable<TValue> values,Func<TValue,TKey[]> converter)
        {
            var tree = new KdTree<TKey, TValue>(dimension, math, AddDuplicateBehavior.List);
            foreach (var element in values)
                tree.Add(converter(element), element);
            return tree;
        }

        /// <summary>
        /// 順不同で比較
        /// 各コレクションをSequenceEqualで比較する
        /// </summary>
        /// <typeparam name="T">比較するコレクションの型</typeparam>
        /// <typeparam name="TElement">比較するコレクションの要素の型</typeparam>
        /// <param name="a">比較するコレクション</param>
        /// <param name="b">比較するコレクション</param>
        /// <returns>同じならtrue</returns>
        private bool CombinationCompare<T,TElement>(IEnumerable<T> a, IEnumerable<T> b) where T:IEnumerable<TElement>
        {
            return a.Aggregate(true, (sum, elm) => sum && b.Any(e => e.SequenceEqual(elm)))
                && b.Aggregate(true, (sum, elm) => sum && a.Any(e => e.SequenceEqual(elm)));
        }

        /// <summary>
        /// 面と対面頂点群から面内の頂点情報を取得
        /// </summary>
        /// <param name="face">調査する面</param>
        /// <param name="compareVertices">対面の構成頂点</param>
        /// <returns>面内頂点情報</returns>
        private (IPXVertex outerVertex, IPXVertex diagonalTopVertex, int replaceIndex) getFaceVertexInfo(IPXFace face, IEnumerable<IPXVertex> compareVertices)
        {
            // 最初の頂点が外側頂点
            if (!compareVertices.Contains(face.Vertex1))
                return (face.Vertex1, face.Vertex2, 2);

            // 最初と中間の頂点が対角構成頂点
            if (compareVertices.Contains(face.Vertex2))
                return (face.Vertex3, face.Vertex1, 1);

            // 最初と最後の頂点が対角構成頂点
            return (face.Vertex2, face.Vertex3, 3);
        }

        /// <summary>
        /// 面の対角線を入れ替える
        /// </summary>
        /// <param name="face1">入れ替え面1</param>
        /// <param name="face2">入れ替え面2</param>
        private void ReplaceDiagonal(IPXFace face1,IPXFace face2)
        {
            /* 例:
             * 
             *      A ― B        A ― B
             *      | ／ |   =>   | ＼ |
             *      C ― D        C ― D
             *      
             * (ABC,CAB,BCA) _\ (ADC,CAD,DCA)
             * (DCB,BDC,CBD) ¯/ (DAB,BDA,ABD)
             * 
             * 対角線構成頂点の先頭側と対面の対角線非構成頂点を入れ替え
             * 
             */

            (IPXVertex outerVertex1, IPXVertex diagonalTopVertex1, int replaceIndex1) = getFaceVertexInfo(face1, face2.ToVertices());
            (IPXVertex outerVertex2, IPXVertex diagonalTopVertex2, int replaceIndex2) = getFaceVertexInfo(face2, face1.ToVertices());

            switch (replaceIndex1)
            {
                case 1:
                    face1.Vertex1 = outerVertex2;
                    break;
                case 2:
                    face1.Vertex2 = outerVertex2;
                    break;
                case 3:
                    face1.Vertex3 = outerVertex2;
                    break;
            }

            switch (replaceIndex2)
            {
                case 1:
                    face2.Vertex1 = outerVertex1;
                    break;
                case 2:
                    face2.Vertex2 = outerVertex1;
                    break;
                case 3:
                    face2.Vertex3 = outerVertex1;
                    break;
            }
        }

        public void Run()
        {
            // 材質内の頂点を取得
            var sourceVertices = Utility.GetMaterialVertices(SourceMaterial);
            var targetVertices = Utility.GetMaterialVertices(TargetMaterial);

            // kd木を構築
            var sourceVerticesTree = MakeTree(3, new FloatMath(), sourceVertices, v => v.Position.ToArray());
            var targetVerticesTree = MakeTree(3, new FloatMath(), targetVertices, v => v.Position.ToArray());

            var sourceFaceTree = MakeTree(3, new IntMath(), SourceMaterial.Faces, f => f.ToVertexIndices(Pmx));
            var targetFaceTree = MakeTree(3, new IntMath(), TargetMaterial.Faces, f => f.ToVertexIndices(Pmx));

            // 整列ループ
            // pivotは基準材質側の面
            foreach ((IPXFace Face, bool IsAligned) pivot in SourceMaterial.Faces.Select(f => (f, false)))
            {
                // 現在の面がすでに整列済みであった場合
                if (pivot.IsAligned) 
                    continue;

                // 現在の基準材質側の面の構成頂点それぞれに最も近い編集材質側の頂点を取得
                var nearestNodes = new KdTreeNode<float,IPXVertex>[] {
                    targetVerticesTree.GetNearestNeighbours(pivot.Face.Vertex1.Position.ToArray(),1)[0],
                    targetVerticesTree.GetNearestNeighbours(pivot.Face.Vertex2.Position.ToArray(),1)[0],
                    targetVerticesTree.GetNearestNeighbours(pivot.Face.Vertex3.Position.ToArray(),1)[0],
                };

                // 取得した最近傍頂点が同一位置であるかを調査
                var nearestTargetVertices = nearestNodes.SelectMany(node => node.Duplicate.Prepend(node.Value));
                var isPositionOverlap = CombinationCompare<float[], float>
                    (
                        pivot.Face.ToVertices().Select(vertex => vertex.Position.ToArray()),
                        nearestTargetVertices.Select(vertex => vertex.Position.ToArray())
                    );

                // 全ての頂点が同一位置でないなら対応を取れないので次の面へ
                if (!isPositionOverlap) 
                    continue;

                // 取得した近傍頂点の内少なくとも2点を構成要素としてもつ編集側の面を取得
                var edgeSharingTargetFaces = TargetMaterial.Faces.Where(face =>
                {
                    var vertex1IsContained = nearestTargetVertices.Contains(face.Vertex1);
                    var vertex2IsContained = nearestTargetVertices.Contains(face.Vertex2);
                    var vertex3IsContained = nearestTargetVertices.Contains(face.Vertex3);

                    return (vertex1IsContained && vertex2IsContained) ||
                           (vertex2IsContained && vertex3IsContained) ||
                           (vertex3IsContained && vertex1IsContained) ;
                });

                // 取得した編集側頂点で構成される面が存在すれば対角線は整合しているので次の面へ
                if (edgeSharingTargetFaces.Any(face => nearestTargetVertices.Contains(face.ToVertices())))
                    continue;

                // 辺共有面の構成頂点の内、同一位置頂点として選択されなかった編集側頂点(外側頂点)
                var outerTargetVertices = edgeSharingTargetFaces.Select(face =>
                    !nearestTargetVertices.Contains(face.Vertex1) ? face.Vertex1 :
                    !nearestTargetVertices.Contains(face.Vertex2) ? face.Vertex2 :
                    face.Vertex3
                ).Select((outerVertex, i) => (outerVertex, i));

                // 複数の面に共有されている外側頂点とその面番号のグループ
                var sharedOuterTargetVertexGroups = outerTargetVertices.GroupBy(v => v.outerVertex).Where(group => group.Count() > 1);
                // 想定では上のコレクションは要素数が1のはずなので、1超の要素数を持った場合は例外を投げる
                if (sharedOuterTargetVertexGroups.Count() > 1)
                    throw new InvalidOperationException($"想定外の状況が発生しました：{Environment.NewLine}外側頂点を共有した面のグループが複数得られました。");

                // 対角面を確定
                var diagonalFaces = sharedOuterTargetVertexGroups
                    .SelectMany(group => group.Select(v => v.i))
                    .Select(i => edgeSharingTargetFaces.ElementAt(i));
                // 対角面のためdiagonalFacesの要素数は2のはずなので、異なった場合は例外を投げる
                if(diagonalFaces.Count() != 2)
                    throw new InvalidOperationException($"想定外の状況が発生しました：{Environment.NewLine}確定した対角面コレクションの要素数が2と違います。");

                //対角線を入れ替え
                ReplaceDiagonal(diagonalFaces.First(), diagonalFaces.Last());

                // TODO: ここからpivotの対面を探索し、整列済み面とした方がパフォーマンスが良いと思われる
            }
        }
    }
}
