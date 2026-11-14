namespace DVLD_Presentation.UserControls.User
{
    partial class ctrlAddUpdateUser
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
            pictureBox5 = new PictureBox();
            label6 = new Label();
            CB_IsActive = new CheckBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            TB_Username = new TextBox();
            TB_Password = new TextBox();
            TB_Confirm = new TextBox();
            LB_UserID = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            errorProvider1 = new ErrorProvider(components);
            Btn_Save = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.active_directory;
            pictureBox5.Location = new Point(197, 280);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(27, 27);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 33;
            pictureBox5.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 279);
            label6.Name = "label6";
            label6.Size = new Size(98, 28);
            label6.TabIndex = 32;
            label6.Text = "Is Active:";
            // 
            // CB_IsActive
            // 
            CB_IsActive.AutoSize = true;
            CB_IsActive.ImageAlign = ContentAlignment.MiddleRight;
            CB_IsActive.Location = new Point(249, 289);
            CB_IsActive.Name = "CB_IsActive";
            CB_IsActive.Size = new Size(18, 17);
            CB_IsActive.TabIndex = 31;
            CB_IsActive.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.Person_321;
            pictureBox4.Location = new Point(197, 12);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(27, 27);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 30;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.PersonDetails_32;
            pictureBox3.Location = new Point(197, 82);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(27, 27);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 29;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Password_32;
            pictureBox2.Location = new Point(197, 146);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(27, 27);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 28;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Password_321;
            pictureBox1.Location = new Point(197, 213);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            // 
            // TB_Username
            // 
            TB_Username.Location = new Point(236, 82);
            TB_Username.Name = "TB_Username";
            TB_Username.Size = new Size(125, 27);
            TB_Username.TabIndex = 26;
            TB_Username.Validating += txt_Validating;
            // 
            // TB_Password
            // 
            TB_Password.Location = new Point(236, 146);
            TB_Password.Name = "TB_Password";
            TB_Password.PasswordChar = '*';
            TB_Password.Size = new Size(125, 27);
            TB_Password.TabIndex = 25;
            TB_Password.Validating += txt_Validating;
            // 
            // TB_Confirm
            // 
            TB_Confirm.Location = new Point(236, 213);
            TB_Confirm.Name = "TB_Confirm";
            TB_Confirm.PasswordChar = '*';
            TB_Confirm.Size = new Size(125, 27);
            TB_Confirm.TabIndex = 24;
            TB_Confirm.Validating += txt_Validating;
            // 
            // LB_UserID
            // 
            LB_UserID.AutoSize = true;
            LB_UserID.Location = new Point(236, 11);
            LB_UserID.Name = "LB_UserID";
            LB_UserID.Size = new Size(37, 20);
            LB_UserID.TabIndex = 23;
            LB_UserID.Text = "????";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 78);
            label5.Name = "label5";
            label5.Size = new Size(111, 28);
            label5.TabIndex = 22;
            label5.Text = "Username:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 145);
            label4.Name = "label4";
            label4.Size = new Size(106, 28);
            label4.TabIndex = 21;
            label4.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 212);
            label3.Name = "label3";
            label3.Size = new Size(188, 28);
            label3.TabIndex = 20;
            label3.Text = "Confirm Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(86, 28);
            label2.TabIndex = 19;
            label2.Text = "User ID:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Btn_Save
            // 
            Btn_Save.Image = Properties.Resources.Save_32;
            Btn_Save.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Save.Location = new Point(416, 380);
            Btn_Save.Name = "Btn_Save";
            Btn_Save.Size = new Size(86, 51);
            Btn_Save.TabIndex = 34;
            Btn_Save.Text = "Save";
            Btn_Save.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Save.UseVisualStyleBackColor = true;
            Btn_Save.Click += Btn_Save_Click;
            // 
            // ctrlAddUpdateUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Btn_Save);
            Controls.Add(pictureBox5);
            Controls.Add(label6);
            Controls.Add(CB_IsActive);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(TB_Username);
            Controls.Add(TB_Password);
            Controls.Add(TB_Confirm);
            Controls.Add(LB_UserID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "ctrlAddUpdateUser";
            Size = new Size(505, 434);
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

        private PictureBox pictureBox5;
        private Label label6;
        private CheckBox CB_IsActive;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private TextBox TB_Username;
        private TextBox TB_Password;
        private TextBox TB_Confirm;
        private Label LB_UserID;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ErrorProvider errorProvider1;
        private Button Btn_Save;
    }
}
