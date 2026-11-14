namespace DVLD_Presentation.UsersForms
{
    partial class frmMoreInfoUser
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
            informationUserView1 = new DVLD_Presentation.UserControls.NewFolder.ctrlInformationUserView();
            SuspendLayout();
            // 
            // informationUserView1
            // 
            informationUserView1.BackColor = SystemColors.HighlightText;
            informationUserView1.Location = new Point(0, 12);
            informationUserView1.Name = "informationUserView1";
            informationUserView1.Size = new Size(920, 552);
            informationUserView1.TabIndex = 0;
            // 
            // frmMoreInfoUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(920, 566);
            Controls.Add(informationUserView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmMoreInfoUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Info";
            FormClosing += MoreInfoUserScreen_FormClosing;
            Load += MoreInfoUserScreen_Load;
            ResumeLayout(false);
        }

        #endregion

        private UserControls.NewFolder.ctrlInformationUserView informationUserView1;
    }
}