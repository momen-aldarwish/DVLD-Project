namespace DVLD_Presentation.Applications.LocalDrivingLicensce
{
    partial class frmIssueLicense
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
            label1 = new Label();
            TB_Notes = new TextBox();
            Btn_Save = new Button();
            Btn_Close = new Button();
            SuspendLayout();
            // 
            // ctrlDrivingLicenseInfo1
            // 
            ctrlDrivingLicenseInfo1.Location = new Point(2, 3);
            ctrlDrivingLicenseInfo1.Name = "ctrlDrivingLicenseInfo1";
            ctrlDrivingLicenseInfo1.Size = new Size(841, 438);
            ctrlDrivingLicenseInfo1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 458);
            label1.Name = "label1";
            label1.Size = new Size(83, 31);
            label1.TabIndex = 1;
            label1.Text = "Notes:";
            // 
            // TB_Notes
            // 
            TB_Notes.Location = new Point(115, 464);
            TB_Notes.Multiline = true;
            TB_Notes.Name = "TB_Notes";
            TB_Notes.Size = new Size(719, 104);
            TB_Notes.TabIndex = 2;
            // 
            // Btn_Save
            // 
            Btn_Save.Image = Properties.Resources.Save_32;
            Btn_Save.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Save.Location = new Point(714, 601);
            Btn_Save.Name = "Btn_Save";
            Btn_Save.Size = new Size(85, 46);
            Btn_Save.TabIndex = 3;
            Btn_Save.Text = "Save";
            Btn_Save.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Save.UseVisualStyleBackColor = true;
            Btn_Save.Click += Btn_Save_Click;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.cross_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(607, 601);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(89, 46);
            Btn_Close.TabIndex = 4;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // frmIssueLicense
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 659);
            Controls.Add(Btn_Close);
            Controls.Add(Btn_Save);
            Controls.Add(TB_Notes);
            Controls.Add(label1);
            Controls.Add(ctrlDrivingLicenseInfo1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmIssueLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Issue Local License";
            Load += frmIssueLicense_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Applications.ctrlDrivingLicenseInfo ctrlDrivingLicenseInfo1;
        private Label label1;
        private TextBox TB_Notes;
        private Button Btn_Save;
        private Button Btn_Close;
    }
}