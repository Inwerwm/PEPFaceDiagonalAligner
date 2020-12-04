using PEPExtensions;
using PEPlugin;
using PEPlugin.Pmx;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FaceDiagonalAligner
{
    public partial class ControlForm : Form
    {
        IPERunArgs Args { get; set; }
        IPXPmx Pmx { get; set; }

        public ControlForm(IPERunArgs args)
        {
            InitializeComponent();
            Args = args;
            LoadPmx();
        }

        /// <summary>
        /// モデルデータの読み込み
        /// </summary>
        public void LoadPmx()
        {
            Pmx = Args.Host.Connector.Pmx.GetCurrentState();

            // 選択位置を保持しながら更新
            // OutOfRange対策付き

            int selectTmp = listBoxSourceMaterial.SelectedIndex;
            listBoxSourceMaterial.Items.Clear();
            listBoxSourceMaterial.Items.AddRange(Pmx.Material.Select(m => new MaterialData(m)).ToArray());
            if (listBoxSourceMaterial.Items.Count > selectTmp)
                listBoxSourceMaterial.SelectedIndex = selectTmp;

            selectTmp = listBoxTargetMaterial.SelectedIndex;
            listBoxTargetMaterial.Items.Clear();
            listBoxTargetMaterial.Items.AddRange(Pmx.Material.Select(m => new MaterialData(m)).ToArray());
            if (listBoxTargetMaterial.Items.Count > selectTmp)
                listBoxTargetMaterial.SelectedIndex = selectTmp;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            var aligner = new DiagonalAligner(Pmx, (IPXMaterial)listBoxSourceMaterial.SelectedItem, (IPXMaterial)listBoxTargetMaterial.SelectedItem);
            aligner.Run();
            Utility.Update(Args.Host.Connector, Pmx, PmxUpdateObject.Face);
            MessageBox.Show("完了");
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            LoadPmx();
        }

        private void ControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // クローズキャンセル
                e.Cancel = true;
                // フォームを非表示設定
                this.Visible = false;
            }
        }
    }
}
