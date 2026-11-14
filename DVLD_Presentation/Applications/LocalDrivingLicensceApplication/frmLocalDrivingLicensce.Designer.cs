namespace DVLD_Presentation.LocalDrivingLicensce
{
    partial class frmLocalDrivingLicensce
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
            DGV_LDL = new DataGridView();
            pictureBox1 = new PictureBox();
            LB_DrivingLicenseTitle = new Label();
            LB_DL_Count = new Label();
            LB_LDLCount = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showApplicationDetailsToolStripMenuItem = new ToolStripMenuItem();
            fToolStripMenuItem = new ToolStripSeparator();
            updateToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            cancelledToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            schedualTestToolStripMenuItem = new ToolStripMenuItem();
            visionToolStripMenuItem = new ToolStripMenuItem();
            schedualWrittenTestToolStripMenuItem = new ToolStripMenuItem();
            schedualStreetTestToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            IssueDrivingLicensetoolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            ShowLicenseDrivingtoolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            ShowLicenseDrivingHistorytoolStripMenuItem3 = new ToolStripMenuItem();
            CB_Filter = new ComboBox();
            TB_Search = new TextBox();
            Btn_AddNewLDL = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)DGV_LDL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // DGV_LDL
            // 
            DGV_LDL.AllowUserToAddRows = false;
            DGV_LDL.AllowUserToDeleteRows = false;
            DGV_LDL.BackgroundColor = SystemColors.ControlLightLight;
            DGV_LDL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_LDL.Location = new Point(0, 327);
            DGV_LDL.Name = "DGV_LDL";
            DGV_LDL.ReadOnly = true;
            DGV_LDL.RowHeadersWidth = 51;
            DGV_LDL.Size = new Size(1090, 227);
            DGV_LDL.TabIndex = 0;
            DGV_LDL.CellMouseDown += DGV_LDL_CellMouseDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Manage_Applications_64;
            pictureBox1.Location = new Point(465, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 133);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // LB_DrivingLicenseTitle
            // 
            LB_DrivingLicenseTitle.AutoSize = true;
            LB_DrivingLicenseTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_DrivingLicenseTitle.ForeColor = Color.Red;
            LB_DrivingLicenseTitle.Location = new Point(254, 192);
            LB_DrivingLicenseTitle.Name = "LB_DrivingLicenseTitle";
            LB_DrivingLicenseTitle.Size = new Size(579, 46);
            LB_DrivingLicenseTitle.TabIndex = 2;
            LB_DrivingLicenseTitle.Text = "Local Driving Licensce Applications";
            // 
            // LB_DL_Count
            // 
            LB_DL_Count.AutoSize = true;
            LB_DL_Count.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_DL_Count.Location = new Point(117, 585);
            LB_DL_Count.Name = "LB_DL_Count";
            LB_DL_Count.Size = new Size(95, 20);
            LB_DL_Count.TabIndex = 3;
            LB_DL_Count.Text = "#LDL Count:";
            // 
            // LB_LDLCount
            // 
            LB_LDLCount.AutoSize = true;
            LB_LDLCount.Location = new Point(218, 585);
            LB_LDLCount.Name = "LB_LDLCount";
            LB_LDLCount.Size = new Size(30, 20);
            LB_LDLCount.TabIndex = 4;
            LB_LDLCount.Text = "???";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showApplicationDetailsToolStripMenuItem, fToolStripMenuItem, updateToolStripMenuItem, deleteToolStripMenuItem, toolStripSeparator1, cancelledToolStripMenuItem, toolStripSeparator2, schedualTestToolStripMenuItem, toolStripSeparator3, IssueDrivingLicensetoolStripMenuItem1, toolStripSeparator4, ShowLicenseDrivingtoolStripMenuItem, toolStripSeparator5, ShowLicenseDrivingHistorytoolStripMenuItem3 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(297, 248);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            showApplicationDetailsToolStripMenuItem.Image = Properties.Resources.PersonDetails_321;
            showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            showApplicationDetailsToolStripMenuItem.Size = new Size(296, 26);
            showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            showApplicationDetailsToolStripMenuItem.Click += showApplicationDetailsToolStripMenuItem_Click;
            // 
            // fToolStripMenuItem
            // 
            fToolStripMenuItem.Name = "fToolStripMenuItem";
            fToolStripMenuItem.Size = new Size(293, 6);
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Image = Properties.Resources.pencil1;
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(296, 26);
            updateToolStripMenuItem.Text = "Edit";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = Properties.Resources.delete__1_;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(296, 26);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(293, 6);
            // 
            // cancelledToolStripMenuItem
            // 
            cancelledToolStripMenuItem.Image = Properties.Resources.Close_641;
            cancelledToolStripMenuItem.Name = "cancelledToolStripMenuItem";
            cancelledToolStripMenuItem.Size = new Size(296, 26);
            cancelledToolStripMenuItem.Text = "Cancelled";
            cancelledToolStripMenuItem.Click += cancelledToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(293, 6);
            // 
            // schedualTestToolStripMenuItem
            // 
            schedualTestToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { visionToolStripMenuItem, schedualWrittenTestToolStripMenuItem, schedualStreetTestToolStripMenuItem });
            schedualTestToolStripMenuItem.Image = Properties.Resources.Test_321;
            schedualTestToolStripMenuItem.Name = "schedualTestToolStripMenuItem";
            schedualTestToolStripMenuItem.Size = new Size(296, 26);
            schedualTestToolStripMenuItem.Text = "Schedual Test";
            // 
            // visionToolStripMenuItem
            // 
            visionToolStripMenuItem.Image = Properties.Resources.Vision_512;
            visionToolStripMenuItem.Name = "visionToolStripMenuItem";
            visionToolStripMenuItem.Size = new Size(235, 26);
            visionToolStripMenuItem.Text = "Schedual Vision Test";
            visionToolStripMenuItem.Click += visionToolStripMenuItem_Click;
            // 
            // schedualWrittenTestToolStripMenuItem
            // 
            schedualWrittenTestToolStripMenuItem.Image = Properties.Resources.Written_Test_32_Sechdule;
            schedualWrittenTestToolStripMenuItem.Name = "schedualWrittenTestToolStripMenuItem";
            schedualWrittenTestToolStripMenuItem.Size = new Size(235, 26);
            schedualWrittenTestToolStripMenuItem.Text = "Schedual Written Test";
            schedualWrittenTestToolStripMenuItem.Click += schedualWrittenTestToolStripMenuItem_Click;
            // 
            // schedualStreetTestToolStripMenuItem
            // 
            schedualStreetTestToolStripMenuItem.Image = Properties.Resources.Street_Test_32;
            schedualStreetTestToolStripMenuItem.Name = "schedualStreetTestToolStripMenuItem";
            schedualStreetTestToolStripMenuItem.Size = new Size(235, 26);
            schedualStreetTestToolStripMenuItem.Text = "Schedual Street Test";
            schedualStreetTestToolStripMenuItem.Click += schedualStreetTestToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(293, 6);
            // 
            // IssueDrivingLicensetoolStripMenuItem1
            // 
            IssueDrivingLicensetoolStripMenuItem1.Image = Properties.Resources.IssueDrivingLicense_32;
            IssueDrivingLicensetoolStripMenuItem1.Name = "IssueDrivingLicensetoolStripMenuItem1";
            IssueDrivingLicensetoolStripMenuItem1.Size = new Size(296, 26);
            IssueDrivingLicensetoolStripMenuItem1.Text = "Issue Driving License (First Time)";
            IssueDrivingLicensetoolStripMenuItem1.Click += IssueDrivingLicensetoolStripMenuItem1_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(293, 6);
            // 
            // ShowLicenseDrivingtoolStripMenuItem
            // 
            ShowLicenseDrivingtoolStripMenuItem.Image = Properties.Resources.License_View_321;
            ShowLicenseDrivingtoolStripMenuItem.Name = "ShowLicenseDrivingtoolStripMenuItem";
            ShowLicenseDrivingtoolStripMenuItem.Size = new Size(296, 26);
            ShowLicenseDrivingtoolStripMenuItem.Text = "Show License Driving";
            ShowLicenseDrivingtoolStripMenuItem.Click += ShowLicenseDrivingtoolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(293, 6);
            // 
            // ShowLicenseDrivingHistorytoolStripMenuItem3
            // 
            ShowLicenseDrivingHistorytoolStripMenuItem3.Image = Properties.Resources.PersonLicenseHistory_321;
            ShowLicenseDrivingHistorytoolStripMenuItem3.Name = "ShowLicenseDrivingHistorytoolStripMenuItem3";
            ShowLicenseDrivingHistorytoolStripMenuItem3.Size = new Size(296, 26);
            ShowLicenseDrivingHistorytoolStripMenuItem3.Text = "Show License Driving History";
            ShowLicenseDrivingHistorytoolStripMenuItem3.Click += ShowLicenseDrivingHistorytoolStripMenuItem3_Click;
            // 
            // CB_Filter
            // 
            CB_Filter.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Filter.FormattingEnabled = true;
            CB_Filter.Location = new Point(72, 292);
            CB_Filter.Name = "CB_Filter";
            CB_Filter.Size = new Size(151, 28);
            CB_Filter.TabIndex = 5;
            CB_Filter.SelectedIndexChanged += CB_Filter_SelectedIndexChanged;
            // 
            // TB_Search
            // 
            TB_Search.Location = new Point(229, 292);
            TB_Search.Name = "TB_Search";
            TB_Search.Size = new Size(145, 27);
            TB_Search.TabIndex = 6;
            TB_Search.TextChanged += TB_Search_TextChanged;
            TB_Search.KeyPress += TB_Search_KeyPress;
            // 
            // Btn_AddNewLDL
            // 
            Btn_AddNewLDL.Image = Properties.Resources.add;
            Btn_AddNewLDL.Location = new Point(952, 248);
            Btn_AddNewLDL.Name = "Btn_AddNewLDL";
            Btn_AddNewLDL.Size = new Size(63, 71);
            Btn_AddNewLDL.TabIndex = 7;
            Btn_AddNewLDL.UseVisualStyleBackColor = true;
            Btn_AddNewLDL.Click += Btn_AddNewLDL_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Local_321;
            pictureBox2.Location = new Point(582, 62);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // frmLocalDrivingLicensce
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1089, 618);
            Controls.Add(pictureBox2);
            Controls.Add(Btn_AddNewLDL);
            Controls.Add(TB_Search);
            Controls.Add(CB_Filter);
            Controls.Add(LB_LDLCount);
            Controls.Add(LB_DL_Count);
            Controls.Add(LB_DrivingLicenseTitle);
            Controls.Add(pictureBox1);
            Controls.Add(DGV_LDL);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmLocalDrivingLicensce";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Local Driving Licensce Applications";
            Load += LDLApplication_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_LDL).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV_LDL;
        private PictureBox pictureBox1;
        private Label LB_DrivingLicenseTitle;
        private Label LB_DL_Count;
        private Label LB_LDLCount;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ComboBox CB_Filter;
        private TextBox TB_Search;
        private ToolStripMenuItem cancelledToolStripMenuItem;
        private Button Btn_AddNewLDL;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator fToolStripMenuItem;
        private ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem schedualTestToolStripMenuItem;
        private ToolStripMenuItem visionToolStripMenuItem;
        private ToolStripMenuItem schedualWrittenTestToolStripMenuItem;
        private ToolStripMenuItem schedualStreetTestToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem IssueDrivingLicensetoolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem ShowLicenseDrivingtoolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem ShowLicenseDrivingHistorytoolStripMenuItem3;
        private PictureBox pictureBox2;
    }
}