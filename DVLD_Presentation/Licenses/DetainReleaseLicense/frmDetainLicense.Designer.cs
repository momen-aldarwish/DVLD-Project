namespace DVLD_Presentation.Applications.ReleaseDetainLicense
{
    partial class frmDetainLicense
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
            ctrlLicenseInfoWithFilter1 = new DVLD_Presentation.UserControls.License.ctrlLicenseInfoWithFilter();
            groupBox1 = new GroupBox();
            TB_FineFees = new TextBox();
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
            Btn_Detain = new Button();
            Btn_Close = new Button();
            LLB_ShowLicenseHistory = new LinkLabel();
            LLB_ShowDetainedLicense = new LinkLabel();
            errorProvider1 = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // ctrlLicenseInfoWithFilter1
            // 
            ctrlLicenseInfoWithFilter1.gbFilter = true;
            ctrlLicenseInfoWithFilter1.Location = new Point(12, 12);
            ctrlLicenseInfoWithFilter1.Name = "ctrlLicenseInfoWithFilter1";
            ctrlLicenseInfoWithFilter1.Size = new Size(1034, 474);
            ctrlLicenseInfoWithFilter1.TabIndex = 0;
            ctrlLicenseInfoWithFilter1.OnLicenseSelected += ctrlLicenseInfoWithFilter1_OnLicenseSelected;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TB_FineFees);
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
            groupBox1.Location = new Point(12, 492);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1034, 142);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detain Info";
            // 
            // TB_FineFees
            // 
            TB_FineFees.Location = new Point(181, 95);
            TB_FineFees.Name = "TB_FineFees";
            TB_FineFees.Size = new Size(125, 27);
            TB_FineFees.TabIndex = 15;
            TB_FineFees.TextChanged += TB_FineFees_TextChanged;
            TB_FineFees.KeyPress += TB_FineFees_KeyPress;
            TB_FineFees.Validating += TB_FineFees_Validating;
            // 
            // LB_DetainDate
            // 
            LB_DetainDate.AutoSize = true;
            LB_DetainDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_DetainDate.Location = new Point(181, 67);
            LB_DetainDate.Name = "LB_DetainDate";
            LB_DetainDate.Size = new Size(37, 20);
            LB_DetainDate.TabIndex = 14;
            LB_DetainDate.Text = "????";
            // 
            // LB_LiceseID
            // 
            LB_LiceseID.AutoSize = true;
            LB_LiceseID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_LiceseID.Location = new Point(584, 34);
            LB_LiceseID.Name = "LB_LiceseID";
            LB_LiceseID.Size = new Size(37, 20);
            LB_LiceseID.TabIndex = 13;
            LB_LiceseID.Text = "????";
            // 
            // LB_CreatedBy
            // 
            LB_CreatedBy.AutoSize = true;
            LB_CreatedBy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_CreatedBy.Location = new Point(584, 76);
            LB_CreatedBy.Name = "LB_CreatedBy";
            LB_CreatedBy.Size = new Size(37, 20);
            LB_CreatedBy.TabIndex = 12;
            LB_CreatedBy.Text = "????";
            // 
            // LB_DetainID
            // 
            LB_DetainID.AutoSize = true;
            LB_DetainID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_DetainID.Location = new Point(181, 34);
            LB_DetainID.Name = "LB_DetainID";
            LB_DetainID.Size = new Size(37, 20);
            LB_DetainID.TabIndex = 11;
            LB_DetainID.Text = "????";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.Calendar_32;
            pictureBox5.Location = new Point(135, 56);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 31);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.money_32;
            pictureBox4.Location = new Point(135, 91);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 31);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Number_32;
            pictureBox3.Location = new Point(538, 23);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 31);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.User_32__2;
            pictureBox2.Location = new Point(538, 65);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Number_32;
            pictureBox1.Location = new Point(135, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 102);
            label6.Name = "label6";
            label6.Size = new Size(77, 20);
            label6.TabIndex = 5;
            label6.Text = "Fine Fees:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 67);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 4;
            label5.Text = "Detain Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(448, 34);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 3;
            label4.Text = "License ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(448, 76);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 2;
            label3.Text = "Created By:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 34);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 0;
            label1.Text = "Detain ID:";
            // 
            // Btn_Detain
            // 
            Btn_Detain.Image = Properties.Resources.Detain_32;
            Btn_Detain.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Detain.Location = new Point(929, 647);
            Btn_Detain.Name = "Btn_Detain";
            Btn_Detain.Size = new Size(98, 45);
            Btn_Detain.TabIndex = 2;
            Btn_Detain.Text = "Detain";
            Btn_Detain.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Detain.UseVisualStyleBackColor = true;
            Btn_Detain.Click += Btn_Detain_Click;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.Close_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(825, 647);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(98, 45);
            Btn_Close.TabIndex = 3;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // LLB_ShowLicenseHistory
            // 
            LLB_ShowLicenseHistory.AutoSize = true;
            LLB_ShowLicenseHistory.Location = new Point(115, 647);
            LLB_ShowLicenseHistory.Name = "LLB_ShowLicenseHistory";
            LLB_ShowLicenseHistory.Size = new Size(148, 20);
            LLB_ShowLicenseHistory.TabIndex = 4;
            LLB_ShowLicenseHistory.TabStop = true;
            LLB_ShowLicenseHistory.Text = "Show License History";
            LLB_ShowLicenseHistory.LinkClicked += LLB_ShowLicenseHistory_LinkClicked;
            // 
            // LLB_ShowDetainedLicense
            // 
            LLB_ShowDetainedLicense.AutoSize = true;
            LLB_ShowDetainedLicense.Enabled = false;
            LLB_ShowDetainedLicense.Location = new Point(289, 647);
            LLB_ShowDetainedLicense.Name = "LLB_ShowDetainedLicense";
            LLB_ShowDetainedLicense.Size = new Size(162, 20);
            LLB_ShowDetainedLicense.TabIndex = 5;
            LLB_ShowDetainedLicense.TabStop = true;
            LLB_ShowDetainedLicense.Text = "Show Detained License";
            LLB_ShowDetainedLicense.LinkClicked += LLB_ShowDetainedLicense_LinkClicked;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmDetainLicense
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 698);
            Controls.Add(LLB_ShowDetainedLicense);
            Controls.Add(LLB_ShowLicenseHistory);
            Controls.Add(Btn_Close);
            Controls.Add(Btn_Detain);
            Controls.Add(groupBox1);
            Controls.Add(ctrlLicenseInfoWithFilter1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmDetainLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detain License";
            Shown += frmDetainLicense_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.License.ctrlLicenseInfoWithFilter ctrlLicenseInfoWithFilter1;
        private GroupBox groupBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label LB_DetainDate;
        private Label label8;
        private Label LB_LiceseID;
        private Label LB_CreatedBy;
        private Label LB_DetainID;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button Btn_Detain;
        private Button Btn_Close;
        private LinkLabel LLB_ShowLicenseHistory;
        private LinkLabel LLB_ShowDetainedLicense;
        private TextBox TB_FineFees;
        private ErrorProvider errorProvider1;
    }
}