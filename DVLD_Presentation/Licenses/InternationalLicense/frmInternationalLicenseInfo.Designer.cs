namespace DVLD_Presentation.Applications.InternationalDrivingLicense
{
    partial class frmInternationalLicenseInfo
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
            ctrlDriverLicenseInternationalInfo1 = new DVLD_Presentation.UserControls.InternationalLicenses.ctrlDriverLicenseInternationalInfo();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ctrlDriverLicenseInternationalInfo1
            // 
            ctrlDriverLicenseInternationalInfo1.Location = new Point(2, 203);
            ctrlDriverLicenseInternationalInfo1.Name = "ctrlDriverLicenseInternationalInfo1";
            ctrlDriverLicenseInternationalInfo1.Size = new Size(967, 358);
            ctrlDriverLicenseInternationalInfo1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(163, 134);
            label1.Name = "label1";
            label1.Size = new Size(630, 54);
            label1.TabIndex = 1;
            label1.Text = "International Driver License Info";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LicenseView_4003;
            pictureBox1.Location = new Point(359, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(159, 119);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // frmInternationalLicenseInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 559);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(ctrlDriverLicenseInternationalInfo1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmInternationalLicenseInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "International License Info";
            Load += frmInternationalLicenseInfo_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.InternationalLicenses.ctrlDriverLicenseInternationalInfo ctrlDriverLicenseInternationalInfo1;
        private Label label1;
        private PictureBox pictureBox1;
    }
}