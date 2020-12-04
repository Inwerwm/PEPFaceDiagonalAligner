using PEPlugin.Pmx;
using PEPlugin.SDX;
using System.Collections.Generic;

namespace FaceDiagonalAligner
{
    class MaterialData : IPXMaterial
    {
        IPXMaterial material;

        public string Name { get => material.Name; set => material.Name = value; }
        public string NameE { get => material.NameE; set => material.NameE = value; }
        public V4 Diffuse { get => material.Diffuse; set => material.Diffuse = value; }
        public V3 Specular { get => material.Specular; set => material.Specular = value; }
        public V3 Ambient { get => material.Ambient; set => material.Ambient = value; }
        public float Power { get => material.Power; set => material.Power = value; }
        public bool BothDraw { get => material.BothDraw; set => material.BothDraw = value; }
        public bool Shadow { get => material.Shadow; set => material.Shadow = value; }
        public bool SelfShadowMap { get => material.SelfShadowMap; set => material.SelfShadowMap = value; }
        public bool SelfShadow { get => material.SelfShadow; set => material.SelfShadow = value; }
        public bool VertexColor { get => material.VertexColor; set => material.VertexColor = value; }
        public PrimitiveType PrimitiveType { get => material.PrimitiveType; set => material.PrimitiveType = value; }
        public bool Edge { get => material.Edge; set => material.Edge = value; }
        public V4 EdgeColor { get => material.EdgeColor; set => material.EdgeColor = value; }
        public float EdgeSize { get => material.EdgeSize; set => material.EdgeSize = value; }
        public string Tex { get => material.Tex; set => material.Tex = value; }
        public string Sphere { get => material.Sphere; set => material.Sphere = value; }
        public SphereType SphereMode { get => material.SphereMode; set => material.SphereMode = value; }
        public string Toon { get => material.Toon; set => material.Toon = value; }
        public string Memo { get => material.Memo; set => material.Memo = value; }

        public IList<IPXFace> Faces => material.Faces;

        public MaterialData(IPXMaterial material)
        {
            this.material = material;
        }

        public object Clone()
        {
            return material.Clone();
        }

        public override string ToString() => material.Name;
    }
}
