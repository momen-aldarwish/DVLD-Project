namespace DVLD_Presentation.UsersForms
{
    partial class frmGiveAccessToUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiveAccessToUpdate));
            informationView1 = new DVLD_Presentation.UserControls.PeopleControls.ctrlPersonalInfo();
            label2 = new Label();
            label3 = new Label();
            TB_OldUsername = new TextBox();
            TB_OldPassword = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            Btn_Check = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // informationView1
            // 
            informationView1.AutoSize = true;
            informationView1.BackColor = SystemColors.ControlLightLight;
            informationView1.Location = new Point(0, 12);
            informationView1.Name = "informationView1";
            informationView1.Size = new Size(904, 446);
            informationView1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.Location = new Point(166, 458);
            label2.Name = "label2";
            label2.Size = new Size(171, 31);
            label2.TabIndex = 2;
            label2.Text = "Old Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlLightLight;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label3.Location = new Point(166, 514);
            label3.Name = "label3";
            label3.Size = new Size(164, 31);
            label3.TabIndex = 3;
            label3.Text = "Old Password:";
            // 
            // TB_OldUsername
            // 
            TB_OldUsername.Location = new Point(377, 464);
            TB_OldUsername.Name = "TB_OldUsername";
            TB_OldUsername.Size = new Size(125, 27);
            TB_OldUsername.TabIndex = 4;
            // 
            // TB_OldPassword
            // 
            TB_OldPassword.Location = new Point(377, 518);
            TB_OldPassword.Name = "TB_OldPassword";
            TB_OldPassword.PasswordChar = '*';
            TB_OldPassword.Size = new Size(125, 27);
            TB_OldPassword.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Image = Properties.Resources.Person_322;
            pictureBox1.Location = new Point(343, 464);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 27);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ControlLightLight;
            pictureBox2.Image = Properties.Resources.Password_32;
            pictureBox2.Location = new Point(343, 518);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(28, 27);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // Btn_Check
            // 
            Btn_Check.Image = (Image)resources.GetObject("Btn_Check.Image");
            Btn_Check.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Check.Location = new Point(532, 485);
            Btn_Check.Name = "Btn_Check";
            Btn_Check.Size = new Size(82, 50);
            Btn_Check.TabIndex = 8;
            Btn_Check.Text = "Check";
            Btn_Check.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Check.UseVisualStyleBackColor = true;
            Btn_Check.Click += Btn_Check_Click;
            // 
            // frmGiveAccessToUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(905, 566);
            Controls.Add(Btn_Check);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(TB_OldPassword);
            Controls.Add(TB_OldUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(informationView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmGiveAccessToUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Update User Access";
            FormClosing += GiveAccessToUpdateScreen_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.PeopleControls.ctrlPersonalInfo informationView1;
        private Label label2;
        private Label label3;
        private TextBox TB_OldUsername;
        private TextBox TB_OldPassword;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button Btn_Check;
    }
}