namespace DVLD_Presentation.Licenses
{
    partial class frmHistoryLicenseInfo
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
            pictureBox1 = new PictureBox();
            ctrlDriverLicenses1 = new DVLD_Presentation.UserControls.License.ctrlDriverLicenses();
            ctrlFindControl1 = new DVLD_Presentation.UserControls.ctrlFindPerson();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.PersonLicenseHistory_512;
            pictureBox1.Location = new Point(2, 166);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(257, 233);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // ctrlDriverLicenses1
            // 
            ctrlDriverLicenses1.Location = new Point(5, 540);
            ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            ctrlDriverLicenses1.Size = new Size(1178, 385);
            ctrlDriverLicenses1.TabIndex = 2;
            // 
            // ctrlFindControl1
            // 
            ctrlFindControl1.Location = new Point(265, 12);
            ctrlFindControl1.Name = "ctrlFindControl1";
            ctrlFindControl1.Size = new Size(911, 522);
            ctrlFindControl1.TabIndex = 3;
            ctrlFindControl1.OnPersonSelected += ctrlFindControl1_OnPersonSelected;
            // 
            // frmHistoryLicenseInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 923);
            Controls.Add(ctrlFindControl1);
            Controls.Add(ctrlDriverLicenses1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmHistoryLicenseInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmHistoryLicenseInfo";
            Load += frmHistoryLicenseInfo_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private UserControls.License.ctrlDriverLicenses ctrlDriverLicenses1;
        private UserControls.ctrlFindPerson ctrlFindControl1;
    }
}