
namespace FaceDiagonalAligner
{
    partial class ControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSourceMaterial = new System.Windows.Forms.Label();
            this.listBoxSourceMaterial = new System.Windows.Forms.ListBox();
            this.labelTargetMaterial = new System.Windows.Forms.Label();
            this.listBoxTargetMaterial = new System.Windows.Forms.ListBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonReload = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSourceMaterial
            // 
            this.labelSourceMaterial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSourceMaterial.AutoSize = true;
            this.labelSourceMaterial.Location = new System.Drawing.Point(71, 5);
            this.labelSourceMaterial.Name = "labelSourceMaterial";
            this.labelSourceMaterial.Size = new System.Drawing.Size(69, 20);
            this.labelSourceMaterial.TabIndex = 0;
            this.labelSourceMaterial.Text = "基準材質";
            // 
            // listBoxSourceMaterial
            // 
            this.listBoxSourceMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSourceMaterial.FormattingEnabled = true;
            this.listBoxSourceMaterial.ItemHeight = 20;
            this.listBoxSourceMaterial.Location = new System.Drawing.Point(3, 33);
            this.listBoxSourceMaterial.Name = "listBoxSourceMaterial";
            this.listBoxSourceMaterial.Size = new System.Drawing.Size(205, 544);
            this.listBoxSourceMaterial.TabIndex = 1;
            // 
            // labelTargetMaterial
            // 
            this.labelTargetMaterial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTargetMaterial.AutoSize = true;
            this.labelTargetMaterial.Location = new System.Drawing.Point(282, 5);
            this.labelTargetMaterial.Name = "labelTargetMaterial";
            this.labelTargetMaterial.Size = new System.Drawing.Size(69, 20);
            this.labelTargetMaterial.TabIndex = 0;
            this.labelTargetMaterial.Text = "変更材質";
            // 
            // listBoxTargetMaterial
            // 
            this.listBoxTargetMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTargetMaterial.FormattingEnabled = true;
            this.listBoxTargetMaterial.ItemHeight = 20;
            this.listBoxTargetMaterial.Location = new System.Drawing.Point(214, 33);
            this.listBoxTargetMaterial.Name = "listBoxTargetMaterial";
            this.listBoxTargetMaterial.Size = new System.Drawing.Size(206, 544);
            this.listBoxTargetMaterial.TabIndex = 1;
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.buttonRun, 2);
            this.buttonRun.Location = new System.Drawing.Point(3, 586);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(417, 44);
            this.buttonRun.TabIndex = 2;
            this.buttonRun.Text = "実行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonRun, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBoxTargetMaterial, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTargetMaterial, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxSourceMaterial, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSourceMaterial, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonReload, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(423, 683);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // buttonReload
            // 
            this.buttonReload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.buttonReload, 2);
            this.buttonReload.Location = new System.Drawing.Point(3, 636);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(417, 44);
            this.buttonReload.TabIndex = 3;
            this.buttonReload.Text = "再読込";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 707);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSourceMaterial;
        private System.Windows.Forms.ListBox listBoxSourceMaterial;
        private System.Windows.Forms.Label labelTargetMaterial;
        private System.Windows.Forms.ListBox listBoxTargetMaterial;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonReload;
    }
}