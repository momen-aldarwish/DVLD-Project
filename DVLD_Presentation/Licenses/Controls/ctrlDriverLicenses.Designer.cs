namespace DVLD_Presentation.UserControls.License
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            TP_Local = new TabPage();
            LB_Local_Records = new Label();
            label3 = new Label();
            DGV_Local = new DataGridView();
            label2 = new Label();
            TP_International = new TabPage();
            LB_International_Count = new Label();
            label5 = new Label();
            DGV_International = new DataGridView();
            label1 = new Label();
            groupBox1 = new GroupBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            licenseInfoToolStripMenuItem1 = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            licenseInfoToolStripMenuItem = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            TP_Local.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Local).BeginInit();
            TP_International.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_International).BeginInit();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(TP_Local);
            tabControl1.Controls.Add(TP_International);
            tabControl1.Location = new Point(16, 32);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(814, 330);
            tabControl1.TabIndex = 0;
            // 
            // TP_Local
            // 
            TP_Local.BackColor = SystemColors.Control;
            TP_Local.Controls.Add(LB_Local_Records);
            TP_Local.Controls.Add(label3);
            TP_Local.Controls.Add(DGV_Local);
            TP_Local.Controls.Add(label2);
            TP_Local.Location = new Point(4, 29);
            TP_Local.Name = "TP_Local";
            TP_Local.Padding = new Padding(3);
            TP_Local.Size = new Size(806, 297);
            TP_Local.TabIndex = 0;
            TP_Local.Text = "Local";
            // 
            // LB_Local_Records
            // 
            LB_Local_Records.AutoSize = true;
            LB_Local_Records.Location = new Point(90, 265);
            LB_Local_Records.Name = "LB_Local_Records";
            LB_Local_Records.Size = new Size(17, 20);
            LB_Local_Records.TabIndex = 5;
            LB_Local_Records.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 265);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 4;
            label3.Text = "#Records:";
            // 
            // DGV_Local
            // 
            DGV_Local.AllowUserToAddRows = false;
            DGV_Local.AllowUserToDeleteRows = false;
            DGV_Local.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGV_Local.BackgroundColor = SystemColors.ControlLightLight;
            DGV_Local.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Local.Location = new Point(0, 63);
            DGV_Local.Name = "DGV_Local";
            DGV_Local.ReadOnly = true;
            DGV_Local.RowHeadersWidth = 51;
            DGV_Local.Size = new Size(800, 188);
            DGV_Local.TabIndex = 3;
            DGV_Local.CellMouseDown += DGV_Local_CellMouseDown;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 21);
            label2.Name = "label2";
            label2.Size = new Size(160, 20);
            label2.TabIndex = 2;
            label2.Text = "Local License History:";
            // 
            // TP_International
            // 
            TP_International.BackColor = SystemColors.Control;
            TP_International.Controls.Add(LB_International_Count);
            TP_International.Controls.Add(label5);
            TP_International.Controls.Add(DGV_International);
            TP_International.Controls.Add(label1);
            TP_International.Location = new Point(4, 29);
            TP_International.Name = "TP_International";
            TP_International.Padding = new Padding(3);
            TP_International.Size = new Size(806, 297);
            TP_International.TabIndex = 1;
            TP_International.Text = "International";
            // 
            // LB_International_Count
            // 
            LB_International_Count.AutoSize = true;
            LB_International_Count.Location = new Point(99, 265);
            LB_International_Count.Name = "LB_International_Count";
            LB_International_Count.Size = new Size(17, 20);
            LB_International_Count.TabIndex = 7;
            LB_International_Count.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 265);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 6;
            label5.Text = "#Records:";
            // 
            // DGV_International
            // 
            DGV_International.AllowUserToAddRows = false;
            DGV_International.AllowUserToDeleteRows = false;
            DGV_International.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGV_International.BackgroundColor = SystemColors.ControlLightLight;
            DGV_International.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_International.Location = new Point(0, 64);
            DGV_International.Name = "DGV_International";
            DGV_International.ReadOnly = true;
            DGV_International.RowHeadersWidth = 51;
            DGV_International.Size = new Size(800, 188);
            DGV_International.TabIndex = 1;
            DGV_International.CellMouseDown += DGV_International_CellMouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 21);
            label1.Name = "label1";
            label1.Size = new Size(215, 20);
            label1.TabIndex = 0;
            label1.Text = "International License History:";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(840, 374);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Driver Licenses";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { licenseInfoToolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(161, 30);
            // 
            // licenseInfoToolStripMenuItem1
            // 
            licenseInfoToolStripMenuItem1.Image = Properties.Resources.License_View_328;
            licenseInfoToolStripMenuItem1.Name = "licenseInfoToolStripMenuItem1";
            licenseInfoToolStripMenuItem1.Size = new Size(160, 26);
            licenseInfoToolStripMenuItem1.Text = "License Info";
            licenseInfoToolStripMenuItem1.Click += licenseInfoToolStripMenuItem1_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { licenseInfoToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(215, 58);
            // 
            // licenseInfoToolStripMenuItem
            // 
            licenseInfoToolStripMenuItem.Image = Properties.Resources.License_View_327;
            licenseInfoToolStripMenuItem.Name = "licenseInfoToolStripMenuItem";
            licenseInfoToolStripMenuItem.Size = new Size(214, 26);
            licenseInfoToolStripMenuItem.Text = "License Info";
            licenseInfoToolStripMenuItem.Click += licenseInfoToolStripMenuItem_Click;
            // 
            // ctrlDriverLicenses
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(groupBox1);
            Name = "ctrlDriverLicenses";
            Size = new Size(848, 385);
            tabControl1.ResumeLayout(false);
            TP_Local.ResumeLayout(false);
            TP_Local.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Local).EndInit();
            TP_International.ResumeLayout(false);
            TP_International.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_International).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage TP_Local;
        private TabPage TP_International;
        private DataGridView DGV_Local;
        private Label label2;
        private DataGridView DGV_International;
        private Label label1;
        private Label LB_Local_Records;
        private Label label3;
        private Label LB_International_Count;
        private Label label5;
        private GroupBox groupBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem licenseInfoToolStripMenuItem1;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem licenseInfoToolStripMenuItem;
    }
}
