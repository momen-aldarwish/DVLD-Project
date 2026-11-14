namespace DVLD_Presentation.Applications.ReleaseDetainLicense
{
    partial class frmReleaseLicense
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
            LB_FineFees = new Label();
            LB_DetainDate = new Label();
            LB_LiceseID = new Label();
            LB_CreatedBy = new Label();
            LB_DetainID = new Label();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            LLB_ShowDetainedLicense = new LinkLabel();
            LLB_ShowLicenseHistory = new LinkLabel();
            Btn_Close = new Button();
            Btn_Release = new Button();
            label2 = new Label();
            pictureBox6 = new PictureBox();
            LB_ApplicationFees = new Label();
            LB_TotalFees = new Label();
            pictureBox7 = new PictureBox();
            label8 = new Label();
            LB_ApplicationID = new Label();
            pictureBox8 = new PictureBox();
            label9 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // ctrlLicenseInfoWithFilter1
            // 
            ctrlLicenseInfoWithFilter1.gbFilter = true;
            ctrlLicenseInfoWithFilter1.Location = new Point(1, -4);
            ctrlLicenseInfoWithFilter1.Name = "ctrlLicenseInfoWithFilter1";
            ctrlLicenseInfoWithFilter1.Size = new Size(1036, 473);
            ctrlLicenseInfoWithFilter1.TabIndex = 0;
            ctrlLicenseInfoWithFilter1.OnLicenseSelected += ctrlLicenseInfoWithFilter1_OnLicenseSelected;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LB_ApplicationID);
            groupBox1.Controls.Add(pictureBox8);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(LB_TotalFees);
            groupBox1.Controls.Add(pictureBox7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(LB_ApplicationFees);
            groupBox1.Controls.Add(pictureBox6);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(LB_FineFees);
            groupBox1.Controls.Add(LB_DetainDate);
            groupBox1.Controls.Add(LB_LiceseID);
            groupBox1.Controls.Add(LB_CreatedBy);
            groupBox1.Controls.Add(LB_DetainID);
            groupBox1.Controls.Add(pictureBox5);
            groupBox1.Controls.Add(pictureBox4);
            groupBox1.Controls.Add(pictureBox3);
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 475);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1019, 190);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detained License Info";
            // 
            // LB_FineFees
            // 
            LB_FineFees.AutoSize = true;
            LB_FineFees.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_FineFees.Location = new Point(188, 119);
            LB_FineFees.Name = "LB_FineFees";
            LB_FineFees.Size = new Size(37, 20);
            LB_FineFees.TabIndex = 30;
            LB_FineFees.Text = "????";
            // 
            // LB_DetainDate
            // 
            LB_DetainDate.AutoSize = true;
            LB_DetainDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_DetainDate.Location = new Point(188, 84);
            LB_DetainDate.Name = "LB_DetainDate";
            LB_DetainDate.Size = new Size(37, 20);
            LB_DetainDate.TabIndex = 29;
            LB_DetainDate.Text = "????";
            // 
            // LB_LiceseID
            // 
            LB_LiceseID.AutoSize = true;
            LB_LiceseID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_LiceseID.Location = new Point(635, 51);
            LB_LiceseID.Name = "LB_LiceseID";
            LB_LiceseID.Size = new Size(37, 20);
            LB_LiceseID.TabIndex = 28;
            LB_LiceseID.Text = "????";
            // 
            // LB_CreatedBy
            // 
            LB_CreatedBy.AutoSize = true;
            LB_CreatedBy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_CreatedBy.Location = new Point(635, 84);
            LB_CreatedBy.Name = "LB_CreatedBy";
            LB_CreatedBy.Size = new Size(37, 20);
            LB_CreatedBy.TabIndex = 27;
            LB_CreatedBy.Text = "????";
            // 
            // LB_DetainID
            // 
            LB_DetainID.AutoSize = true;
            LB_DetainID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_DetainID.Location = new Point(188, 51);
            LB_DetainID.Name = "LB_DetainID";
            LB_DetainID.Size = new Size(37, 20);
            LB_DetainID.TabIndex = 26;
            LB_DetainID.Text = "????";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.Calendar_32;
            pictureBox5.Location = new Point(142, 73);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 31);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 25;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.money_32;
            pictureBox4.Location = new Point(142, 108);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 31);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 24;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Number_32;
            pictureBox3.Location = new Point(589, 40);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 31);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 23;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.User_32__2;
            pictureBox2.Location = new Point(589, 73);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 22;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Number_32;
            pictureBox1.Location = new Point(142, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(32, 119);
            label6.Name = "label6";
            label6.Size = new Size(77, 20);
            label6.TabIndex = 20;
            label6.Text = "Fine Fees:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(32, 84);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 19;
            label5.Text = "Detain Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(455, 51);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 18;
            label4.Text = "License ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(455, 84);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 17;
            label3.Text = "Created By:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 51);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 16;
            label1.Text = "Detain ID:";
            // 
            // LLB_ShowDetainedLicense
            // 
            LLB_ShowDetainedLicense.AutoSize = true;
            LLB_ShowDetainedLicense.Enabled = false;
            LLB_ShowDetainedLicense.Location = new Point(250, 671);
            LLB_ShowDetainedLicense.Name = "LLB_ShowDetainedLicense";
            LLB_ShowDetainedLicense.Size = new Size(162, 20);
            LLB_ShowDetainedLicense.TabIndex = 9;
            LLB_ShowDetainedLicense.TabStop = true;
            LLB_ShowDetainedLicense.Text = "Show Detained License";
            LLB_ShowDetainedLicense.LinkClicked += LLB_ShowDetainedLicense_LinkClicked;
            // 
            // LLB_ShowLicenseHistory
            // 
            LLB_ShowLicenseHistory.AutoSize = true;
            LLB_ShowLicenseHistory.Location = new Point(76, 671);
            LLB_ShowLicenseHistory.Name = "LLB_ShowLicenseHistory";
            LLB_ShowLicenseHistory.Size = new Size(148, 20);
            LLB_ShowLicenseHistory.TabIndex = 8;
            LLB_ShowLicenseHistory.TabStop = true;
            LLB_ShowLicenseHistory.Text = "Show License History";
            LLB_ShowLicenseHistory.LinkClicked += LLB_ShowLicenseHistory_LinkClicked;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.Close_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(782, 671);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(98, 45);
            Btn_Close.TabIndex = 7;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // Btn_Release
            // 
            Btn_Release.Image = Properties.Resources.Release_Detained_License_32;
            Btn_Release.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Release.Location = new Point(886, 671);
            Btn_Release.Name = "Btn_Release";
            Btn_Release.Size = new Size(109, 45);
            Btn_Release.TabIndex = 6;
            Btn_Release.Text = "Release";
            Btn_Release.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Release.UseVisualStyleBackColor = true;
            Btn_Release.Click += Btn_Release_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(455, 119);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 31;
            label2.Text = "Application Fees:";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.money_32;
            pictureBox6.Location = new Point(589, 108);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 31);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 32;
            pictureBox6.TabStop = false;
            // 
            // LB_ApplicationFees
            // 
            LB_ApplicationFees.AutoSize = true;
            LB_ApplicationFees.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_ApplicationFees.Location = new Point(635, 119);
            LB_ApplicationFees.Name = "LB_ApplicationFees";
            LB_ApplicationFees.Size = new Size(37, 20);
            LB_ApplicationFees.TabIndex = 33;
            LB_ApplicationFees.Text = "????";
            // 
            // LB_TotalFees
            // 
            LB_TotalFees.AutoSize = true;
            LB_TotalFees.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_TotalFees.Location = new Point(188, 154);
            LB_TotalFees.Name = "LB_TotalFees";
            LB_TotalFees.Size = new Size(37, 20);
            LB_TotalFees.TabIndex = 36;
            LB_TotalFees.Text = "????";
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.money_32;
            pictureBox7.Location = new Point(142, 143);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(30, 31);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 35;
            pictureBox7.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(32, 154);
            label8.Name = "label8";
            label8.Size = new Size(83, 20);
            label8.TabIndex = 34;
            label8.Text = "Total Fees:";
            // 
            // LB_ApplicationID
            // 
            LB_ApplicationID.AutoSize = true;
            LB_ApplicationID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_ApplicationID.Location = new Point(635, 154);
            LB_ApplicationID.Name = "LB_ApplicationID";
            LB_ApplicationID.Size = new Size(37, 20);
            LB_ApplicationID.TabIndex = 39;
            LB_ApplicationID.Text = "????";
            // 
            // pictureBox8
            // 
            pictureBox8.Image = Properties.Resources.Number_32;
            pictureBox8.Location = new Point(589, 143);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(30, 31);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 38;
            pictureBox8.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(455, 154);
            label9.Name = "label9";
            label9.Size = new Size(113, 20);
            label9.TabIndex = 37;
            label9.Text = "Application ID:";
            // 
            // frmReleaseLicense
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 721);
            Controls.Add(LLB_ShowDetainedLicense);
            Controls.Add(LLB_ShowLicenseHistory);
            Controls.Add(Btn_Close);
            Controls.Add(Btn_Release);
            Controls.Add(groupBox1);
            Controls.Add(ctrlLicenseInfoWithFilter1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmReleaseLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Release License";
            Load += frmReleaseLicense_Load;
            Shown += frmReleaseLicense_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.License.ctrlLicenseInfoWithFilter ctrlLicenseInfoWithFilter1;
        private GroupBox groupBox1;
        private Label LB_DetainDate;
        private Label LB_LiceseID;
        private Label LB_CreatedBy;
        private Label LB_DetainID;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label LB_FineFees;
        private LinkLabel LLB_ShowDetainedLicense;
        private LinkLabel LLB_ShowLicenseHistory;
        private Button Btn_Close;
        private Button Btn_Release;
        private Label LB_ApplicationFees;
        private PictureBox pictureBox6;
        private Label label2;
        private Label LB_ApplicationID;
        private PictureBox pictureBox8;
        private Label label9;
        private Label LB_TotalFees;
        private PictureBox pictureBox7;
        private Label label8;
    }
}