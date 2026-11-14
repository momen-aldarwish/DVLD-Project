namespace DVLD_Presentation.Drivers
{
    partial class frmDrivers
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            DGV_Drivers = new DataGridView();
            label1 = new Label();
            LB_Count = new Label();
            CB_FilterBy = new ComboBox();
            TB_Search = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showPersonInfoToolStripMenuItem = new ToolStripMenuItem();
            licenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Drivers).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Driver_Main;
            pictureBox1.Location = new Point(294, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(183, 146);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // DGV_Drivers
            // 
            DGV_Drivers.AllowUserToAddRows = false;
            DGV_Drivers.AllowUserToDeleteRows = false;
            DGV_Drivers.BackgroundColor = SystemColors.ControlLightLight;
            DGV_Drivers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Drivers.Location = new Point(3, 274);
            DGV_Drivers.Name = "DGV_Drivers";
            DGV_Drivers.ReadOnly = true;
            DGV_Drivers.RowHeadersWidth = 51;
            DGV_Drivers.Size = new Size(794, 187);
            DGV_Drivers.TabIndex = 1;
            DGV_Drivers.CellMouseDown += DGV_Drivers_CellMouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 479);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 2;
            label1.Text = "#Count:";
            // 
            // LB_Count
            // 
            LB_Count.AutoSize = true;
            LB_Count.Location = new Point(115, 479);
            LB_Count.Name = "LB_Count";
            LB_Count.Size = new Size(37, 20);
            LB_Count.TabIndex = 3;
            LB_Count.Text = "????";
            // 
            // CB_FilterBy
            // 
            CB_FilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_FilterBy.FormattingEnabled = true;
            CB_FilterBy.Location = new Point(37, 228);
            CB_FilterBy.Name = "CB_FilterBy";
            CB_FilterBy.Size = new Size(151, 28);
            CB_FilterBy.TabIndex = 4;
            CB_FilterBy.SelectedIndexChanged += CB_FilterBy_SelectedIndexChanged;
            // 
            // TB_Search
            // 
            TB_Search.Location = new Point(217, 229);
            TB_Search.Name = "TB_Search";
            TB_Search.Size = new Size(125, 27);
            TB_Search.TabIndex = 5;
            TB_Search.TextChanged += TB_Search_TextChanged;
            TB_Search.KeyPress += TB_Search_KeyPress;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showPersonInfoToolStripMenuItem, licenseHistoryToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(196, 56);
            // 
            // showPersonInfoToolStripMenuItem
            // 
            showPersonInfoToolStripMenuItem.Image = Properties.Resources.PersonDetails_323;
            showPersonInfoToolStripMenuItem.Name = "showPersonInfoToolStripMenuItem";
            showPersonInfoToolStripMenuItem.Size = new Size(195, 26);
            showPersonInfoToolStripMenuItem.Text = "Show Person Info";
            showPersonInfoToolStripMenuItem.Click += showPersonInfoToolStripMenuItem_Click;
            // 
            // licenseHistoryToolStripMenuItem
            // 
            licenseHistoryToolStripMenuItem.Image = Properties.Resources.PersonLicenseHistory_323;
            licenseHistoryToolStripMenuItem.Name = "licenseHistoryToolStripMenuItem";
            licenseHistoryToolStripMenuItem.Size = new Size(195, 26);
            licenseHistoryToolStripMenuItem.Text = "License History";
            licenseHistoryToolStripMenuItem.Click += licenseHistoryToolStripMenuItem_Click;
            // 
            // frmDrivers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 517);
            Controls.Add(TB_Search);
            Controls.Add(CB_FilterBy);
            Controls.Add(LB_Count);
            Controls.Add(label1);
            Controls.Add(DGV_Drivers);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmDrivers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDrivers";
            Load += frmDrivers_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Drivers).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView DGV_Drivers;
        private Label label1;
        private Label LB_Count;
        private ComboBox CB_FilterBy;
        private TextBox TB_Search;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showPersonInfoToolStripMenuItem;
        private ToolStripMenuItem licenseHistoryToolStripMenuItem;
    }
}