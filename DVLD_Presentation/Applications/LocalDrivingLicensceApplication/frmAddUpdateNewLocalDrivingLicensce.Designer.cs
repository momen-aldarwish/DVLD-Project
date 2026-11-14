namespace DVLD_Presentation.LocalDrivingLicensce
{
    partial class frmAddUpdateNewLocalDrivingLicensce
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
            tabControl1 = new TabControl();
            TP_PersonInfo = new TabPage();
            Btn_Next = new Button();
            findControl1 = new DVLD_Presentation.UserControls.ctrlFindPerson();
            TP_ApplicationInfo = new TabPage();
            Btn_Close = new Button();
            Btn_Save = new Button();
            CB_LicenseClass = new ComboBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            LB_ApplicationDate = new Label();
            LB_ApplicationFees = new Label();
            LB_CreatedBy = new Label();
            LB_DL_ID = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            LB_Title = new Label();
            tabControl1.SuspendLayout();
            TP_PersonInfo.SuspendLayout();
            TP_ApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TP_PersonInfo);
            tabControl1.Controls.Add(TP_ApplicationInfo);
            tabControl1.Location = new Point(12, 105);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(925, 563);
            tabControl1.TabIndex = 0;
            // 
            // TP_PersonInfo
            // 
            TP_PersonInfo.Controls.Add(Btn_Next);
            TP_PersonInfo.Controls.Add(findControl1);
            TP_PersonInfo.Location = new Point(4, 29);
            TP_PersonInfo.Name = "TP_PersonInfo";
            TP_PersonInfo.Padding = new Padding(3);
            TP_PersonInfo.Size = new Size(917, 530);
            TP_PersonInfo.TabIndex = 0;
            TP_PersonInfo.Text = "Person Info";
            TP_PersonInfo.UseVisualStyleBackColor = true;
            // 
            // Btn_Next
            // 
            Btn_Next.Image = Properties.Resources.Next_321;
            Btn_Next.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Next.Location = new Point(788, 447);
            Btn_Next.Name = "Btn_Next";
            Btn_Next.Size = new Size(90, 46);
            Btn_Next.TabIndex = 1;
            Btn_Next.Text = "Next";
            Btn_Next.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Next.UseVisualStyleBackColor = true;
            Btn_Next.Click += Btn_Next_Click;
            // 
            // findControl1
            // 
            findControl1.Location = new Point(3, 6);
            findControl1.Name = "findControl1";
            findControl1.Size = new Size(907, 518);
            findControl1.TabIndex = 0;
            findControl1.OnPersonSelected += findControl1_OnPersonSelected;
            // 
            // TP_ApplicationInfo
            // 
            TP_ApplicationInfo.Controls.Add(Btn_Close);
            TP_ApplicationInfo.Controls.Add(Btn_Save);
            TP_ApplicationInfo.Controls.Add(CB_LicenseClass);
            TP_ApplicationInfo.Controls.Add(pictureBox5);
            TP_ApplicationInfo.Controls.Add(pictureBox4);
            TP_ApplicationInfo.Controls.Add(pictureBox3);
            TP_ApplicationInfo.Controls.Add(pictureBox2);
            TP_ApplicationInfo.Controls.Add(pictureBox1);
            TP_ApplicationInfo.Controls.Add(LB_ApplicationDate);
            TP_ApplicationInfo.Controls.Add(LB_ApplicationFees);
            TP_ApplicationInfo.Controls.Add(LB_CreatedBy);
            TP_ApplicationInfo.Controls.Add(LB_DL_ID);
            TP_ApplicationInfo.Controls.Add(label6);
            TP_ApplicationInfo.Controls.Add(label5);
            TP_ApplicationInfo.Controls.Add(label4);
            TP_ApplicationInfo.Controls.Add(label3);
            TP_ApplicationInfo.Controls.Add(label2);
            TP_ApplicationInfo.Location = new Point(4, 29);
            TP_ApplicationInfo.Name = "TP_ApplicationInfo";
            TP_ApplicationInfo.Padding = new Padding(3);
            TP_ApplicationInfo.Size = new Size(917, 530);
            TP_ApplicationInfo.TabIndex = 1;
            TP_ApplicationInfo.Text = "Application Info";
            TP_ApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.Close_321;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(703, 451);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(94, 49);
            Btn_Close.TabIndex = 17;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // Btn_Save
            // 
            Btn_Save.Image = Properties.Resources.Save_32;
            Btn_Save.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Save.Location = new Point(803, 451);
            Btn_Save.Name = "Btn_Save";
            Btn_Save.Size = new Size(94, 49);
            Btn_Save.TabIndex = 16;
            Btn_Save.Text = "Save";
            Btn_Save.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Save.UseVisualStyleBackColor = true;
            Btn_Save.Click += Btn_Save_Click;
            // 
            // CB_LicenseClass
            // 
            CB_LicenseClass.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_LicenseClass.FormattingEnabled = true;
            CB_LicenseClass.Location = new Point(419, 235);
            CB_LicenseClass.Name = "CB_LicenseClass";
            CB_LicenseClass.Size = new Size(253, 28);
            CB_LicenseClass.TabIndex = 15;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.Calendar_32;
            pictureBox5.Location = new Point(368, 165);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(35, 32);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 14;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.User_32__2;
            pictureBox4.Location = new Point(368, 363);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(35, 32);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 13;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.License_Type_32;
            pictureBox3.Location = new Point(368, 231);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 32);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.money_32;
            pictureBox2.Location = new Point(368, 297);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Person_323;
            pictureBox1.Location = new Point(368, 99);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // LB_ApplicationDate
            // 
            LB_ApplicationDate.AutoSize = true;
            LB_ApplicationDate.Location = new Point(419, 169);
            LB_ApplicationDate.Name = "LB_ApplicationDate";
            LB_ApplicationDate.Size = new Size(37, 20);
            LB_ApplicationDate.TabIndex = 9;
            LB_ApplicationDate.Text = "????";
            // 
            // LB_ApplicationFees
            // 
            LB_ApplicationFees.AutoSize = true;
            LB_ApplicationFees.Location = new Point(419, 301);
            LB_ApplicationFees.Name = "LB_ApplicationFees";
            LB_ApplicationFees.Size = new Size(37, 20);
            LB_ApplicationFees.TabIndex = 7;
            LB_ApplicationFees.Text = "????";
            // 
            // LB_CreatedBy
            // 
            LB_CreatedBy.AutoSize = true;
            LB_CreatedBy.Location = new Point(419, 367);
            LB_CreatedBy.Name = "LB_CreatedBy";
            LB_CreatedBy.Size = new Size(37, 20);
            LB_CreatedBy.TabIndex = 6;
            LB_CreatedBy.Text = "????";
            // 
            // LB_DL_ID
            // 
            LB_DL_ID.AutoSize = true;
            LB_DL_ID.Location = new Point(419, 103);
            LB_DL_ID.Name = "LB_DL_ID";
            LB_DL_ID.Size = new Size(37, 20);
            LB_DL_ID.TabIndex = 5;
            LB_DL_ID.Text = "????";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(220, 169);
            label6.Name = "label6";
            label6.Size = new Size(130, 20);
            label6.TabIndex = 4;
            label6.Text = "Application Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(220, 235);
            label5.Name = "label5";
            label5.Size = new Size(101, 20);
            label5.TabIndex = 3;
            label5.Text = "License class:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(220, 301);
            label4.Name = "label4";
            label4.Size = new Size(128, 20);
            label4.TabIndex = 2;
            label4.Text = "Application Fees:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(220, 367);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 1;
            label3.Text = "Created By:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(220, 103);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 0;
            label2.Text = "D.L ID:";
            // 
            // LB_Title
            // 
            LB_Title.AutoSize = true;
            LB_Title.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LB_Title.ForeColor = Color.Red;
            LB_Title.Location = new Point(125, 26);
            LB_Title.Name = "LB_Title";
            LB_Title.Size = new Size(679, 54);
            LB_Title.TabIndex = 1;
            LB_Title.Text = "Add New Local License Application";
            // 
            // frmAddUpdateNewLocalDrivingLicensce
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 681);
            Controls.Add(LB_Title);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmAddUpdateNewLocalDrivingLicensce";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New Local Driving Licensce";
            Load += frmAddNewLocalDrivingLicensce_Load;
            tabControl1.ResumeLayout(false);
            TP_PersonInfo.ResumeLayout(false);
            TP_ApplicationInfo.ResumeLayout(false);
            TP_ApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage TP_PersonInfo;
        private TabPage TP_ApplicationInfo;
        private Button Btn_Next;
        private UserControls.ctrlFindPerson findControl1;
        private PictureBox pictureBox1;
        private Label LB_ApplicationDate;
        private Label LB_ApplicationFees;
        private Label LB_CreatedBy;
        private Label LB_DL_ID;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private ComboBox CB_LicenseClass;
        private TabPage tabPage1;
        private Button Btn_Save;
        private Button Btn_Close;
        private Label LB_Title;
    }
}