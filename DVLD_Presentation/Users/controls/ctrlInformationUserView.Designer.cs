namespace DVLD_Presentation.UserControls.NewFolder
{
    partial class ctrlInformationUserView
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
            IV_PersonInfo = new DVLD_Presentation.UserControls.PeopleControls.ctrlPersonalInfo();
            groupBox1 = new GroupBox();
            CB_IsActive = new CheckBox();
            LB_UserID = new Label();
            LB_Username = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox4 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox5 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // IV_PersonInfo
            // 
            IV_PersonInfo.AutoSize = true;
            IV_PersonInfo.BackColor = SystemColors.ControlLightLight;
            IV_PersonInfo.Location = new Point(3, 3);
            IV_PersonInfo.Name = "IV_PersonInfo";
            IV_PersonInfo.Size = new Size(904, 442);
            IV_PersonInfo.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlLightLight;
            groupBox1.Controls.Add(pictureBox5);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(pictureBox4);
            groupBox1.Controls.Add(CB_IsActive);
            groupBox1.Controls.Add(LB_UserID);
            groupBox1.Controls.Add(LB_Username);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(3, 441);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(904, 99);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "User Info";
            // 
            // CB_IsActive
            // 
            CB_IsActive.AutoSize = true;
            CB_IsActive.Location = new Point(742, 53);
            CB_IsActive.Name = "CB_IsActive";
            CB_IsActive.Size = new Size(18, 17);
            CB_IsActive.TabIndex = 8;
            CB_IsActive.UseVisualStyleBackColor = true;
            // 
            // LB_UserID
            // 
            LB_UserID.AutoSize = true;
            LB_UserID.Location = new Point(529, 50);
            LB_UserID.Name = "LB_UserID";
            LB_UserID.Size = new Size(37, 20);
            LB_UserID.TabIndex = 4;
            LB_UserID.Text = "????";
            // 
            // LB_Username
            // 
            LB_Username.AutoSize = true;
            LB_Username.Location = new Point(195, 50);
            LB_Username.Name = "LB_Username";
            LB_Username.Size = new Size(37, 20);
            LB_Username.TabIndex = 3;
            LB_Username.Text = "????";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlLightLight;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(620, 50);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "Is Active:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(381, 50);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "User ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(28, 50);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.Person_321;
            pictureBox4.Location = new Point(484, 46);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(27, 27);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 31;
            pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.PersonDetails_32;
            pictureBox1.Location = new Point(136, 46);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.active_directory;
            pictureBox5.Location = new Point(699, 46);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(27, 27);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 34;
            pictureBox5.TabStop = false;
            // 
            // InformationUserView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            Controls.Add(groupBox1);
            Controls.Add(IV_PersonInfo);
            Name = "InformationUserView";
            Size = new Size(906, 547);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PeopleControls.ctrlPersonalInfo IV_PersonInfo;
        private GroupBox groupBox1;
        private CheckBox CB_IsActive;
        private Label LB_UserID;
        private Label LB_Username;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox5;
    }
}
