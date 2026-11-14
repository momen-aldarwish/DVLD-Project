namespace DVLD_Presentation.UsersForms
{
    partial class frmAddNewUser
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
            ctrlFindPerson1 = new DVLD_Presentation.UserControls.ctrlFindPerson();
            tabControl1 = new TabControl();
            TP_PersonInfo = new TabPage();
            Btn_Next = new Button();
            TP_UserLogin = new TabPage();
            Btn_Close = new Button();
            ctrlAddUpdateUser1 = new DVLD_Presentation.UserControls.User.ctrlAddUpdateUser();
            errorProvider1 = new ErrorProvider(components);
            tabControl1.SuspendLayout();
            TP_PersonInfo.SuspendLayout();
            TP_UserLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // ctrlFindPerson1
            // 
            ctrlFindPerson1.Location = new Point(7, 6);
            ctrlFindPerson1.Name = "ctrlFindPerson1";
            ctrlFindPerson1.Size = new Size(912, 566);
            ctrlFindPerson1.TabIndex = 0;
            ctrlFindPerson1.OnPersonSelected += ctrlFindPerson1_OnPersonSelected;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TP_PersonInfo);
            tabControl1.Controls.Add(TP_UserLogin);
            tabControl1.Location = new Point(3, 41);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(923, 605);
            tabControl1.TabIndex = 1;
            tabControl1.Selecting += tabControl1_Selecting;
            // 
            // TP_PersonInfo
            // 
            TP_PersonInfo.Controls.Add(Btn_Next);
            TP_PersonInfo.Controls.Add(ctrlFindPerson1);
            TP_PersonInfo.Location = new Point(4, 29);
            TP_PersonInfo.Name = "TP_PersonInfo";
            TP_PersonInfo.Padding = new Padding(3);
            TP_PersonInfo.Size = new Size(915, 572);
            TP_PersonInfo.TabIndex = 0;
            TP_PersonInfo.Text = "Person info";
            TP_PersonInfo.UseVisualStyleBackColor = true;
            // 
            // Btn_Next
            // 
            Btn_Next.Image = Properties.Resources.Next_32;
            Btn_Next.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Next.Location = new Point(806, 529);
            Btn_Next.Name = "Btn_Next";
            Btn_Next.Size = new Size(89, 37);
            Btn_Next.TabIndex = 1;
            Btn_Next.Text = "Next";
            Btn_Next.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Next.UseVisualStyleBackColor = true;
            Btn_Next.Click += Btn_Next_Click;
            // 
            // TP_UserLogin
            // 
            TP_UserLogin.Controls.Add(Btn_Close);
            TP_UserLogin.Controls.Add(ctrlAddUpdateUser1);
            TP_UserLogin.Location = new Point(4, 29);
            TP_UserLogin.Name = "TP_UserLogin";
            TP_UserLogin.Padding = new Padding(3);
            TP_UserLogin.Size = new Size(915, 572);
            TP_UserLogin.TabIndex = 1;
            TP_UserLogin.Text = "User Login";
            TP_UserLogin.UseVisualStyleBackColor = true;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.Close_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(509, 460);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(84, 49);
            Btn_Close.TabIndex = 1;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // ctrlAddUpdateUser1
            // 
            ctrlAddUpdateUser1.Location = new Point(183, 79);
            ctrlAddUpdateUser1.Name = "ctrlAddUpdateUser1";
            ctrlAddUpdateUser1.Size = new Size(548, 440);
            ctrlAddUpdateUser1.TabIndex = 2;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAddNewUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(926, 660);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmAddNewUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New User";
            Shown += frmAddNewUser_Shown;
            tabControl1.ResumeLayout(false);
            TP_PersonInfo.ResumeLayout(false);
            TP_UserLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private UserControls.ctrlFindPerson ctrlFindPerson1;
        private TabControl tabControl1;
        private TabPage TP_PersonInfo;
        private TabPage TP_UserLogin;
        private Button Btn_Next;
        private Button Btn_Close;
        private ErrorProvider errorProvider1;
        private UserControls.User.ctrlAddUpdateUser ctrlAddUpdateUser1;
    }
}