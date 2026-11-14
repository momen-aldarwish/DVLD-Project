namespace DVLD_Presentation.UsersForms
{
    partial class frmUpdateUserInfo
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
            addUpdateUser1 = new DVLD_Presentation.UserControls.User.ctrlAddUpdateUser();
            Btn_Close = new Button();
            SuspendLayout();
            // 
            // addUpdateUser1
            // 
            addUpdateUser1.Location = new Point(170, 29);
            addUpdateUser1.Name = "addUpdateUser1";
            addUpdateUser1.Size = new Size(505, 434);
            addUpdateUser1.TabIndex = 0;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.Close_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(496, 411);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(78, 52);
            Btn_Close.TabIndex = 3;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // frmUpdateUserInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 491);
            Controls.Add(Btn_Close);
            Controls.Add(addUpdateUser1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmUpdateUserInfo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update User Info";
            FormClosing += UpdateUserInfoScreen_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private UserControls.User.ctrlAddUpdateUser addUpdateUser1;
        private Button Btn_Close;
    }
}