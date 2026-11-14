namespace DVLD_Presentation.Applications.InternationalDrivingLicense
{
    partial class frmAddInternationalDrivingLicense
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
            ctrlLicenseInfoWithFilter1 = new DVLD_Presentation.UserControls.License.ctrlLicenseInfoWithFilter();
            LLB_ShowLicenseInfo = new LinkLabel();
            LLB_ShowLicensesHistory = new LinkLabel();
            ctrlInternationalApplication1 = new DVLD_Presentation.UserControls.Applications.ctrlInternationalApplication();
            Btn_Issue = new Button();
            Btn_Close = new Button();
            SuspendLayout();
            // 
            // ctrlLicenseInfoWithFilter1
            // 
            ctrlLicenseInfoWithFilter1.gbFilter = true;
            ctrlLicenseInfoWithFilter1.Location = new Point(1, 3);
            ctrlLicenseInfoWithFilter1.Name = "ctrlLicenseInfoWithFilter1";
            ctrlLicenseInfoWithFilter1.Size = new Size(1033, 467);
            ctrlLicenseInfoWithFilter1.TabIndex = 0;
            ctrlLicenseInfoWithFilter1.OnLicenseSelected += ctrlLicenseInfoWithFilter1_OnLicenseSelected;
            // 
            // LLB_ShowLicenseInfo
            // 
            LLB_ShowLicenseInfo.AutoSize = true;
            LLB_ShowLicenseInfo.Enabled = false;
            LLB_ShowLicenseInfo.Location = new Point(267, 716);
            LLB_ShowLicenseInfo.Name = "LLB_ShowLicenseInfo";
            LLB_ShowLicenseInfo.Size = new Size(127, 20);
            LLB_ShowLicenseInfo.TabIndex = 1;
            LLB_ShowLicenseInfo.TabStop = true;
            LLB_ShowLicenseInfo.Text = "Show License Info";
            LLB_ShowLicenseInfo.LinkClicked += LLB_ShowLicenseInfo_LinkClicked;
            // 
            // LLB_ShowLicensesHistory
            // 
            LLB_ShowLicensesHistory.AutoSize = true;
            LLB_ShowLicensesHistory.Location = new Point(85, 716);
            LLB_ShowLicensesHistory.Name = "LLB_ShowLicensesHistory";
            LLB_ShowLicensesHistory.Size = new Size(154, 20);
            LLB_ShowLicensesHistory.TabIndex = 2;
            LLB_ShowLicensesHistory.TabStop = true;
            LLB_ShowLicensesHistory.Text = "Show Licenses History";
            LLB_ShowLicensesHistory.LinkClicked += LLB_ShowLicensesHistory_LinkClicked;
            // 
            // ctrlInternationalApplication1
            // 
            ctrlInternationalApplication1.Location = new Point(85, 476);
            ctrlInternationalApplication1.Name = "ctrlInternationalApplication1";
            ctrlInternationalApplication1.Size = new Size(845, 237);
            ctrlInternationalApplication1.TabIndex = 3;
            // 
            // Btn_Issue
            // 
            Btn_Issue.Image = Properties.Resources.International_32;
            Btn_Issue.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Issue.Location = new Point(818, 719);
            Btn_Issue.Name = "Btn_Issue";
            Btn_Issue.Size = new Size(94, 42);
            Btn_Issue.TabIndex = 4;
            Btn_Issue.Text = "Issue";
            Btn_Issue.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Issue.UseVisualStyleBackColor = true;
            Btn_Issue.Click += Btn_Issue_Click;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.Close_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(718, 719);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(94, 42);
            Btn_Close.TabIndex = 5;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // frmAddInternationalDrivingLicense
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 769);
            Controls.Add(Btn_Close);
            Controls.Add(Btn_Issue);
            Controls.Add(ctrlInternationalApplication1);
            Controls.Add(LLB_ShowLicensesHistory);
            Controls.Add(LLB_ShowLicenseInfo);
            Controls.Add(ctrlLicenseInfoWithFilter1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmAddInternationalDrivingLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New International Driving License";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.License.ctrlLicenseInfoWithFilter ctrlLicenseInfoWithFilter1;
        private LinkLabel LLB_ShowLicenseInfo;
        private LinkLabel LLB_ShowLicensesHistory;
        private UserControls.Applications.ctrlInternationalApplication ctrlInternationalApplication1;
        private Button Btn_Issue;
        private Button Btn_Close;
    }
}