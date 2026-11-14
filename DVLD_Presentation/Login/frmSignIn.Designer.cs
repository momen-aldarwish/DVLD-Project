namespace DVLD_Presentation.UsersForms
{
    partial class frmSignIn
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
            label1 = new Label();
            TB_UserName = new TextBox();
            TB_Password = new TextBox();
            label2 = new Label();
            label3 = new Label();
            CB_Rememberme = new CheckBox();
            Btn_Login = new Button();
            CB_Show = new CheckBox();
            panel1 = new Panel();
            Btn_Close = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(503, 73);
            label1.Name = "label1";
            label1.Size = new Size(182, 81);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // TB_UserName
            // 
            TB_UserName.Location = new Point(520, 201);
            TB_UserName.Name = "TB_UserName";
            TB_UserName.Size = new Size(252, 27);
            TB_UserName.TabIndex = 1;
            // 
            // TB_Password
            // 
            TB_Password.Location = new Point(520, 273);
            TB_Password.Name = "TB_Password";
            TB_Password.PasswordChar = '*';
            TB_Password.Size = new Size(252, 27);
            TB_Password.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(368, 201);
            label2.Name = "label2";
            label2.Size = new Size(132, 31);
            label2.TabIndex = 3;
            label2.Text = "User Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(374, 271);
            label3.Name = "label3";
            label3.Size = new Size(126, 29);
            label3.TabIndex = 4;
            label3.Text = "Password:";
            // 
            // CB_Rememberme
            // 
            CB_Rememberme.AutoSize = true;
            CB_Rememberme.BackColor = Color.Transparent;
            CB_Rememberme.ForeColor = SystemColors.ControlLightLight;
            CB_Rememberme.Location = new Point(577, 331);
            CB_Rememberme.Name = "CB_Rememberme";
            CB_Rememberme.Size = new Size(129, 24);
            CB_Rememberme.TabIndex = 5;
            CB_Rememberme.Text = "Remember me";
            CB_Rememberme.UseVisualStyleBackColor = false;
            // 
            // Btn_Login
            // 
            Btn_Login.BackColor = Color.Transparent;
            Btn_Login.ForeColor = Color.Black;
            Btn_Login.Location = new Point(591, 385);
            Btn_Login.Name = "Btn_Login";
            Btn_Login.Size = new Size(94, 29);
            Btn_Login.TabIndex = 6;
            Btn_Login.Text = "Login";
            Btn_Login.UseVisualStyleBackColor = false;
            Btn_Login.Click += Btn_Login_Click;
            // 
            // CB_Show
            // 
            CB_Show.AutoSize = true;
            CB_Show.BackColor = Color.Transparent;
            CB_Show.ForeColor = SystemColors.ControlLightLight;
            CB_Show.Location = new Point(778, 277);
            CB_Show.Name = "CB_Show";
            CB_Show.Size = new Size(67, 24);
            CB_Show.TabIndex = 7;
            CB_Show.Text = "Show";
            CB_Show.UseVisualStyleBackColor = false;
            CB_Show.CheckedChanged += CB_Show_CheckedChanged;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.IconLogo;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(-2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(371, 604);
            panel1.TabIndex = 8;
            // 
            // Btn_Close
            // 
            Btn_Close.BackColor = SystemColors.ControlDark;
            Btn_Close.FlatStyle = FlatStyle.Popup;
            Btn_Close.Image = Properties.Resources.closeBlack32;
            Btn_Close.Location = new Point(830, 1);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(41, 41);
            Btn_Close.TabIndex = 9;
            Btn_Close.UseVisualStyleBackColor = false;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // frmSignIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(870, 603);
            Controls.Add(Btn_Close);
            Controls.Add(panel1);
            Controls.Add(CB_Show);
            Controls.Add(Btn_Login);
            Controls.Add(CB_Rememberme);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TB_Password);
            Controls.Add(TB_UserName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmSignIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignInScreen";
            Load += frmSignIn_Load;
            Shown += frmSignIn_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TB_UserName;
        private TextBox TB_Password;
        private Label label2;
        private Label label3;
        private CheckBox CB_Rememberme;
        private Button Btn_Login;
        private CheckBox CB_Show;
        private Panel panel1;
        private Button Btn_Close;
    }
}