namespace DVLD_Presentation.Applications.InternationalDrivingLicense
{
    partial class frmInternationalDrivingLicense
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
            pictureBox2 = new PictureBox();
            Btn_AddNewIL = new Button();
            TB_Search = new TextBox();
            CB_Filter = new ComboBox();
            LB_ILCount = new Label();
            lable2 = new Label();
            lable1 = new Label();
            pictureBox1 = new PictureBox();
            DGV_IL = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showPersonDetailsToolStripMenuItem = new ToolStripMenuItem();
            showLicenseDetailsToolStripMenuItem = new ToolStripMenuItem();
            showPersonLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_IL).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.International_322;
            pictureBox2.Location = new Point(584, 67);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // Btn_AddNewIL
            // 
            Btn_AddNewIL.Image = Properties.Resources.add;
            Btn_AddNewIL.Location = new Point(954, 253);
            Btn_AddNewIL.Name = "Btn_AddNewIL";
            Btn_AddNewIL.Size = new Size(63, 71);
            Btn_AddNewIL.TabIndex = 16;
            Btn_AddNewIL.UseVisualStyleBackColor = true;
            Btn_AddNewIL.Click += Btn_AddNewIL_Click;
            // 
            // TB_Search
            // 
            TB_Search.Location = new Point(231, 297);
            TB_Search.Name = "TB_Search";
            TB_Search.Size = new Size(145, 27);
            TB_Search.TabIndex = 15;
            TB_Search.TextChanged += TB_Search_TextChanged;
            TB_Search.KeyPress += TB_Search_KeyPress;
            // 
            // CB_Filter
            // 
            CB_Filter.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Filter.FormattingEnabled = true;
            CB_Filter.Location = new Point(74, 297);
            CB_Filter.Name = "CB_Filter";
            CB_Filter.Size = new Size(151, 28);
            CB_Filter.TabIndex = 14;
            CB_Filter.SelectedValueChanged += CB_Filter_SelectedValueChanged;
            // 
            // LB_ILCount
            // 
            LB_ILCount.AutoSize = true;
            LB_ILCount.Location = new Point(220, 590);
            LB_ILCount.Name = "LB_ILCount";
            LB_ILCount.Size = new Size(30, 20);
            LB_ILCount.TabIndex = 13;
            LB_ILCount.Text = "???";
            // 
            // lable2
            // 
            lable2.AutoSize = true;
            lable2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lable2.Location = new Point(119, 590);
            lable2.Name = "lable2";
            lable2.Size = new Size(81, 20);
            lable2.TabIndex = 12;
            lable2.Text = "#IL Count:";
            // 
            // lable1
            // 
            lable1.AutoSize = true;
            lable1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lable1.ForeColor = Color.Red;
            lable1.Location = new Point(184, 188);
            lable1.Name = "lable1";
            lable1.Size = new Size(691, 46);
            lable1.TabIndex = 11;
            lable1.Text = "International Driving Licensce Application";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Manage_Applications_64;
            pictureBox1.Location = new Point(467, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 133);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // DGV_IL
            // 
            DGV_IL.AllowUserToAddRows = false;
            DGV_IL.AllowUserToDeleteRows = false;
            DGV_IL.BackgroundColor = SystemColors.ControlLightLight;
            DGV_IL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_IL.Location = new Point(2, 332);
            DGV_IL.Name = "DGV_IL";
            DGV_IL.ReadOnly = true;
            DGV_IL.RowHeadersWidth = 51;
            DGV_IL.Size = new Size(1090, 227);
            DGV_IL.TabIndex = 9;
            DGV_IL.CellMouseDown += DGV_IL_CellMouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showPersonDetailsToolStripMenuItem, showLicenseDetailsToolStripMenuItem, showPersonLicenseHistoryToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(269, 82);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            showPersonDetailsToolStripMenuItem.Image = Properties.Resources.PersonDetails_322;
            showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            showPersonDetailsToolStripMenuItem.Size = new Size(268, 26);
            showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            showPersonDetailsToolStripMenuItem.Click += showPersonDetailsToolStripMenuItem_Click;
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            showLicenseDetailsToolStripMenuItem.Image = Properties.Resources.License_View_325;
            showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            showLicenseDetailsToolStripMenuItem.Size = new Size(268, 26);
            showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            showLicenseDetailsToolStripMenuItem.Click += showLicenseDetailsToolStripMenuItem_Click;
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            showPersonLicenseHistoryToolStripMenuItem.Image = Properties.Resources.PersonLicenseHistory_322;
            showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            showPersonLicenseHistoryToolStripMenuItem.Size = new Size(268, 26);
            showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            showPersonLicenseHistoryToolStripMenuItem.Click += showPersonLicenseHistoryToolStripMenuItem_Click;
            // 
            // frmInternationalDrivingLicense
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 626);
            Controls.Add(pictureBox2);
            Controls.Add(Btn_AddNewIL);
            Controls.Add(TB_Search);
            Controls.Add(CB_Filter);
            Controls.Add(LB_ILCount);
            Controls.Add(lable2);
            Controls.Add(lable1);
            Controls.Add(pictureBox1);
            Controls.Add(DGV_IL);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmInternationalDrivingLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "International Applications";
            Load += frmInternationalDrivingLicense_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_IL).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Button Btn_AddNewIL;
        private TextBox TB_Search;
        private ComboBox CB_Filter;
        private Label LB_ILCount;
        private Label lable2;
        private Label lable1;
        private PictureBox pictureBox1;
        private DataGridView DGV_IL;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}