namespace DVLD_Presentation.Applications.LocalDrivingLicensce
{
    partial class frmShowLocalApplicationDetails
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
            ctrlDrivingLicenseInfo1 = new DVLD_Presentation.UserControls.Applications.ctrlDrivingLicenseInfo();
            Btn_CLose = new Button();
            SuspendLayout();
            // 
            // ctrlDrivingLicenseInfo1
            // 
            ctrlDrivingLicenseInfo1.Location = new Point(2, 4);
            ctrlDrivingLicenseInfo1.Name = "ctrlDrivingLicenseInfo1";
            ctrlDrivingLicenseInfo1.Size = new Size(847, 446);
            ctrlDrivingLicenseInfo1.TabIndex = 0;
            // 
            // Btn_CLose
            // 
            Btn_CLose.Image = Properties.Resources.Close_32;
            Btn_CLose.ImageAlign = ContentAlignment.MiddleRight;
            Btn_CLose.Location = new Point(741, 456);
            Btn_CLose.Name = "Btn_CLose";
            Btn_CLose.Size = new Size(94, 42);
            Btn_CLose.TabIndex = 1;
            Btn_CLose.Text = "Close";
            Btn_CLose.TextAlign = ContentAlignment.MiddleLeft;
            Btn_CLose.UseVisualStyleBackColor = true;
            Btn_CLose.Click += Btn_CLose_Click;
            // 
            // frmShowLocalApplicationDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 502);
            Controls.Add(Btn_CLose);
            Controls.Add(ctrlDrivingLicenseInfo1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmShowLocalApplicationDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Show Local Application Details";
            Load += frmShowLocalApplicationDetails_Load;
            ResumeLayout(false);
        }

        #endregion

        private UserControls.Applications.ctrlDrivingLicenseInfo ctrlDrivingLicenseInfo1;
        private Button Btn_CLose;
    }
}