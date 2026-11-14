namespace DVLD_Presentation.PeopleForms
{
    partial class frmPersonalInfo
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
            ctrlPersonalInfo1 = new DVLD_Presentation.UserControls.PeopleControls.ctrlPersonalInfo();
            Btn_Close = new Button();
            SuspendLayout();
            // 
            // ctrlPersonalInfo1
            // 
            ctrlPersonalInfo1.AutoSize = true;
            ctrlPersonalInfo1.BackColor = SystemColors.ControlLightLight;
            ctrlPersonalInfo1.Location = new Point(2, 2);
            ctrlPersonalInfo1.Name = "ctrlPersonalInfo1";
            ctrlPersonalInfo1.Size = new Size(904, 437);
            ctrlPersonalInfo1.TabIndex = 0;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.Close_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(792, 445);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(89, 43);
            Btn_Close.TabIndex = 7;
            Btn_Close.Text = "Colse";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // frmPersonalInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(906, 490);
            Controls.Add(Btn_Close);
            Controls.Add(ctrlPersonalInfo1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmPersonalInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Personal Info";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.PeopleControls.ctrlPersonalInfo ctrlPersonalInfo1;
        private Button Btn_Close;
    }
}