namespace DVLD_Presentation.Licenses
{
    partial class frmReplaceDamagedLostLicense
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
            ctrlLicenseInfoWithFilter1 = new DVLD_Presentation.UserControls.License.ctrlLicenseInfoWithFilter();
            groupBox1 = new GroupBox();
            pictureBox7 = new PictureBox();
            label7 = new Label();
            TB_Notes = new TextBox();
            LB_CreatedBy = new Label();
            LB_ApplicationFees = new Label();
            LB_ApplicationDate = new Label();
            LB_OldLicenseID = new Label();
            LB_ReplacementLicenseID = new Label();
            LB_LRApplicationID = new Label();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            GB_ReplaceFor = new GroupBox();
            RB_LostLicense = new RadioButton();
            RB_DamagedLicense = new RadioButton();
            Btn_IssueReplacement = new Button();
            Btn_Close = new Button();
            LLB_ShowLicenseHistory = new LinkLabel();
            LLB_ShowNewLicenseInfo = new LinkLabel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            GB_ReplaceFor.SuspendLayout();
            SuspendLayout();
            // 
            // ctrlLicenseInfoWithFilter1
            // 
            ctrlLicenseInfoWithFilter1.gbFilter = true;
            ctrlLicenseInfoWithFilter1.Location = new Point(12, 2);
            ctrlLicenseInfoWithFilter1.Name = "ctrlLicenseInfoWithFilter1";
            ctrlLicenseInfoWithFilter1.Size = new Size(1037, 469);
            ctrlLicenseInfoWithFilter1.TabIndex = 0;
            ctrlLicenseInfoWithFilter1.OnLicenseSelected += ctrlLicenseInfoWithFilter1_OnLicenseSelected;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox7);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(TB_Notes);
            groupBox1.Controls.Add(LB_CreatedBy);
            groupBox1.Controls.Add(LB_ApplicationFees);
            groupBox1.Controls.Add(LB_ApplicationDate);
            groupBox1.Controls.Add(LB_OldLicenseID);
            groupBox1.Controls.Add(LB_ReplacementLicenseID);
            groupBox1.Controls.Add(LB_LRApplicationID);
            groupBox1.Controls.Add(pictureBox6);
            groupBox1.Controls.Add(pictureBox5);
            groupBox1.Controls.Add(pictureBox4);
            groupBox1.Controls.Add(pictureBox3);
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 477);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1030, 217);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Application Info For License Replacement";
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.Notes_326;
            pictureBox7.Location = new Point(169, 152);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(30, 31);
            pictureBox7.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox7.TabIndex = 20;
            pictureBox7.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(24, 163);
            label7.Name = "label7";
            label7.Size = new Size(55, 20);
            label7.TabIndex = 19;
            label7.Text = "Notes:";
            // 
            // TB_Notes
            // 
            TB_Notes.Location = new Point(221, 160);
            TB_Notes.Multiline = true;
            TB_Notes.Name = "TB_Notes";
            TB_Notes.Size = new Size(561, 46);
            TB_Notes.TabIndex = 18;
            // 
            // LB_CreatedBy
            // 
            LB_CreatedBy.AutoSize = true;
            LB_CreatedBy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_CreatedBy.Location = new Point(749, 126);
            LB_CreatedBy.Name = "LB_CreatedBy";
            LB_CreatedBy.Size = new Size(37, 20);
            LB_CreatedBy.TabIndex = 17;
            LB_CreatedBy.Text = "????";
            // 
            // LB_ApplicationFees
            // 
            LB_ApplicationFees.AutoSize = true;
            LB_ApplicationFees.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_ApplicationFees.Location = new Point(221, 126);
            LB_ApplicationFees.Name = "LB_ApplicationFees";
            LB_ApplicationFees.Size = new Size(37, 20);
            LB_ApplicationFees.TabIndex = 16;
            LB_ApplicationFees.Text = "????";
            // 
            // LB_ApplicationDate
            // 
            LB_ApplicationDate.AutoSize = true;
            LB_ApplicationDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_ApplicationDate.Location = new Point(221, 85);
            LB_ApplicationDate.Name = "LB_ApplicationDate";
            LB_ApplicationDate.Size = new Size(37, 20);
            LB_ApplicationDate.TabIndex = 15;
            LB_ApplicationDate.Text = "????";
            // 
            // LB_OldLicenseID
            // 
            LB_OldLicenseID.AutoSize = true;
            LB_OldLicenseID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_OldLicenseID.Location = new Point(749, 85);
            LB_OldLicenseID.Name = "LB_OldLicenseID";
            LB_OldLicenseID.Size = new Size(37, 20);
            LB_OldLicenseID.TabIndex = 14;
            LB_OldLicenseID.Text = "????";
            // 
            // LB_ReplacementLicenseID
            // 
            LB_ReplacementLicenseID.AutoSize = true;
            LB_ReplacementLicenseID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_ReplacementLicenseID.Location = new Point(749, 44);
            LB_ReplacementLicenseID.Name = "LB_ReplacementLicenseID";
            LB_ReplacementLicenseID.Size = new Size(37, 20);
            LB_ReplacementLicenseID.TabIndex = 13;
            LB_ReplacementLicenseID.Text = "????";
            // 
            // LB_LRApplicationID
            // 
            LB_LRApplicationID.AutoSize = true;
            LB_LRApplicationID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_LRApplicationID.Location = new Point(221, 44);
            LB_LRApplicationID.Name = "LB_LRApplicationID";
            LB_LRApplicationID.Size = new Size(37, 20);
            LB_LRApplicationID.TabIndex = 12;
            LB_LRApplicationID.Text = "????";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.Number_32;
            pictureBox6.Location = new Point(169, 74);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 31);
            pictureBox6.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox6.TabIndex = 11;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.Number_32;
            pictureBox5.Location = new Point(169, 115);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 31);
            pictureBox5.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.Number_32;
            pictureBox4.Location = new Point(695, 33);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 31);
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Number_32;
            pictureBox3.Location = new Point(695, 74);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 31);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Number_32;
            pictureBox2.Location = new Point(695, 115);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Number_32;
            pictureBox1.Location = new Point(169, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(510, 126);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 5;
            label6.Text = "Created By:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(24, 126);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 4;
            label5.Text = "Application Fees:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(24, 85);
            label4.Name = "label4";
            label4.Size = new Size(130, 20);
            label4.TabIndex = 3;
            label4.Text = "Application Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(510, 85);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 2;
            label3.Text = "Old License ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(510, 44);
            label2.Name = "label2";
            label2.Size = new Size(179, 20);
            label2.TabIndex = 1;
            label2.Text = "Replacement License ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 44);
            label1.Name = "label1";
            label1.Size = new Size(139, 20);
            label1.TabIndex = 0;
            label1.Text = "L.R Application ID:";
            // 
            // GB_ReplaceFor
            // 
            GB_ReplaceFor.Controls.Add(RB_LostLicense);
            GB_ReplaceFor.Controls.Add(RB_DamagedLicense);
            GB_ReplaceFor.Location = new Point(654, 12);
            GB_ReplaceFor.Name = "GB_ReplaceFor";
            GB_ReplaceFor.Size = new Size(250, 105);
            GB_ReplaceFor.TabIndex = 0;
            GB_ReplaceFor.TabStop = false;
            GB_ReplaceFor.Text = "Replace For:";
            // 
            // RB_LostLicense
            // 
            RB_LostLicense.AutoSize = true;
            RB_LostLicense.Location = new Point(6, 75);
            RB_LostLicense.Name = "RB_LostLicense";
            RB_LostLicense.Size = new Size(109, 24);
            RB_LostLicense.TabIndex = 1;
            RB_LostLicense.Text = "Lost License";
            RB_LostLicense.UseVisualStyleBackColor = true;
            RB_LostLicense.CheckedChanged += RB_LostLicense_CheckedChanged;
            // 
            // RB_DamagedLicense
            // 
            RB_DamagedLicense.AutoSize = true;
            RB_DamagedLicense.Checked = true;
            RB_DamagedLicense.Location = new Point(6, 26);
            RB_DamagedLicense.Name = "RB_DamagedLicense";
            RB_DamagedLicense.Size = new Size(148, 24);
            RB_DamagedLicense.TabIndex = 0;
            RB_DamagedLicense.TabStop = true;
            RB_DamagedLicense.Text = "Damaged License";
            RB_DamagedLicense.UseVisualStyleBackColor = true;
            RB_DamagedLicense.CheckedChanged += RB_DamagedLicense_CheckedChanged;
            // 
            // Btn_IssueReplacement
            // 
            Btn_IssueReplacement.Image = Properties.Resources.Renew_Driving_License_321;
            Btn_IssueReplacement.ImageAlign = ContentAlignment.MiddleRight;
            Btn_IssueReplacement.Location = new Point(862, 706);
            Btn_IssueReplacement.Name = "Btn_IssueReplacement";
            Btn_IssueReplacement.Size = new Size(180, 48);
            Btn_IssueReplacement.TabIndex = 2;
            Btn_IssueReplacement.Text = "Issue Replacement";
            Btn_IssueReplacement.TextAlign = ContentAlignment.MiddleLeft;
            Btn_IssueReplacement.UseVisualStyleBackColor = true;
            Btn_IssueReplacement.Click += Btn_IssueReplacement_Click;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.cross_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(751, 706);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(95, 48);
            Btn_Close.TabIndex = 3;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // LLB_ShowLicenseHistory
            // 
            LLB_ShowLicenseHistory.AutoSize = true;
            LLB_ShowLicenseHistory.Location = new Point(78, 706);
            LLB_ShowLicenseHistory.Name = "LLB_ShowLicenseHistory";
            LLB_ShowLicenseHistory.Size = new Size(148, 20);
            LLB_ShowLicenseHistory.TabIndex = 4;
            LLB_ShowLicenseHistory.TabStop = true;
            LLB_ShowLicenseHistory.Text = "Show License History";
            LLB_ShowLicenseHistory.LinkClicked += LLB_ShowLicenseHistory_LinkClicked;
            // 
            // LLB_ShowNewLicenseInfo
            // 
            LLB_ShowNewLicenseInfo.AutoSize = true;
            LLB_ShowNewLicenseInfo.Enabled = false;
            LLB_ShowNewLicenseInfo.Location = new Point(243, 706);
            LLB_ShowNewLicenseInfo.Name = "LLB_ShowNewLicenseInfo";
            LLB_ShowNewLicenseInfo.Size = new Size(161, 20);
            LLB_ShowNewLicenseInfo.TabIndex = 5;
            LLB_ShowNewLicenseInfo.TabStop = true;
            LLB_ShowNewLicenseInfo.Text = "Show New License Info";
            LLB_ShowNewLicenseInfo.LinkClicked += LLB_ShowNewLicenseInfo_LinkClicked;
            // 
            // frmReplaceDamagedLostLicense
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 759);
            Controls.Add(LLB_ShowNewLicenseInfo);
            Controls.Add(LLB_ShowLicenseHistory);
            Controls.Add(Btn_Close);
            Controls.Add(Btn_IssueReplacement);
            Controls.Add(GB_ReplaceFor);
            Controls.Add(groupBox1);
            Controls.Add(ctrlLicenseInfoWithFilter1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmReplaceDamagedLostLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Replace Damaged Or Lost License";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            GB_ReplaceFor.ResumeLayout(false);
            GB_ReplaceFor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.License.ctrlLicenseInfoWithFilter ctrlLicenseInfoWithFilter1;
        private GroupBox groupBox1;
        private Label label1;
        private GroupBox GB_ReplaceFor;
        private RadioButton RB_LostLicense;
        private RadioButton RB_DamagedLicense;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label LB_CreatedBy;
        private Label LB_ApplicationFees;
        private Label LB_ApplicationDate;
        private Label LB_OldLicenseID;
        private Label LB_ReplacementLicenseID;
        private Label LB_LRApplicationID;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button Btn_IssueReplacement;
        private Button Btn_Close;
        private LinkLabel LLB_ShowLicenseHistory;
        private LinkLabel LLB_ShowNewLicenseInfo;
        private PictureBox pictureBox7;
        private Label label7;
        private TextBox TB_Notes;
    }
}