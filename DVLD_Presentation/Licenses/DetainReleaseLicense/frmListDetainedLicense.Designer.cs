namespace DVLD_Presentation.Applications.ReleaseDetainLicense
{
    partial class frmListDetainedLicense
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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Btn_Detain = new Button();
            Btn_Release = new Button();
            label2 = new Label();
            CB_FilterBy = new ComboBox();
            TB_Search = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showPersonDetailsToolStripMenuItem = new ToolStripMenuItem();
            showLicenseDetaiToolStripMenuItem = new ToolStripMenuItem();
            showLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            releaseToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Detain_512;
            pictureBox1.Location = new Point(474, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(177, 152);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(410, 167);
            label1.Name = "label1";
            label1.Size = new Size(312, 41);
            label1.TabIndex = 1;
            label1.Text = "List Detained License";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 305);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1145, 188);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            // 
            // Btn_Detain
            // 
            Btn_Detain.Image = Properties.Resources.Detain_64;
            Btn_Detain.Location = new Point(1043, 223);
            Btn_Detain.Name = "Btn_Detain";
            Btn_Detain.Size = new Size(94, 76);
            Btn_Detain.TabIndex = 3;
            Btn_Detain.UseVisualStyleBackColor = true;
            Btn_Detain.Click += Btn_Detain_Click;
            // 
            // Btn_Release
            // 
            Btn_Release.Image = Properties.Resources.Release_Detained_License_64;
            Btn_Release.Location = new Point(943, 223);
            Btn_Release.Name = "Btn_Release";
            Btn_Release.Size = new Size(94, 76);
            Btn_Release.TabIndex = 4;
            Btn_Release.UseVisualStyleBackColor = true;
            Btn_Release.Click += Btn_Release_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 274);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 5;
            label2.Text = "Filter By:";
            // 
            // CB_FilterBy
            // 
            CB_FilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_FilterBy.FormattingEnabled = true;
            CB_FilterBy.Location = new Point(105, 271);
            CB_FilterBy.Name = "CB_FilterBy";
            CB_FilterBy.Size = new Size(151, 28);
            CB_FilterBy.TabIndex = 6;
            CB_FilterBy.SelectedIndexChanged += CB_FilterBy_SelectedIndexChanged;
            // 
            // TB_Search
            // 
            TB_Search.Location = new Point(262, 272);
            TB_Search.Name = "TB_Search";
            TB_Search.Size = new Size(125, 27);
            TB_Search.TabIndex = 7;
            TB_Search.TextChanged += TB_Search_TextChanged;
            TB_Search.KeyPress += TB_Search_KeyPress;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showPersonDetailsToolStripMenuItem, showLicenseDetaiToolStripMenuItem, showLicenseHistoryToolStripMenuItem, toolStripSeparator1, releaseToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(222, 114);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            showPersonDetailsToolStripMenuItem.Image = Properties.Resources.PersonDetails_324;
            showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            showPersonDetailsToolStripMenuItem.Size = new Size(221, 26);
            showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            showPersonDetailsToolStripMenuItem.Click += showPersonDetailsToolStripMenuItem_Click;
            // 
            // showLicenseDetaiToolStripMenuItem
            // 
            showLicenseDetaiToolStripMenuItem.Image = Properties.Resources.License_View_329;
            showLicenseDetaiToolStripMenuItem.Name = "showLicenseDetaiToolStripMenuItem";
            showLicenseDetaiToolStripMenuItem.Size = new Size(221, 26);
            showLicenseDetaiToolStripMenuItem.Text = "Show License Details";
            showLicenseDetaiToolStripMenuItem.Click += showLicenseDetaiToolStripMenuItem_Click;
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            showLicenseHistoryToolStripMenuItem.Image = Properties.Resources.PersonLicenseHistory_5121;
            showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            showLicenseHistoryToolStripMenuItem.Size = new Size(221, 26);
            showLicenseHistoryToolStripMenuItem.Text = "Show License History";
            showLicenseHistoryToolStripMenuItem.Click += showLicenseHistoryToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(218, 6);
            // 
            // releaseToolStripMenuItem
            // 
            releaseToolStripMenuItem.Image = Properties.Resources.Release_Detained_License_32;
            releaseToolStripMenuItem.Name = "releaseToolStripMenuItem";
            releaseToolStripMenuItem.Size = new Size(221, 26);
            releaseToolStripMenuItem.Text = "Release";
            releaseToolStripMenuItem.Click += releaseToolStripMenuItem_Click;
            // 
            // frmListDetainedLicense
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 496);
            Controls.Add(TB_Search);
            Controls.Add(CB_FilterBy);
            Controls.Add(label2);
            Controls.Add(Btn_Release);
            Controls.Add(Btn_Detain);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmListDetainedLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "List Detained Licenses";
            Load += frmListDetainedLicense_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private Button Btn_Detain;
        private Button Btn_Release;
        private Label label2;
        private ComboBox CB_FilterBy;
        private TextBox TB_Search;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem releaseToolStripMenuItem;
        private ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private ToolStripMenuItem showLicenseDetaiToolStripMenuItem;
        private ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
    }
}