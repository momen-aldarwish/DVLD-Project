namespace DVLD_Presentation.PeopleForms
{
    partial class frmFindPerson
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
            ctrlFindPerson1 = new DVLD_Presentation.UserControls.ctrlFindPerson();
            Btn_Close = new Button();
            SuspendLayout();
            // 
            // ctrlFindPerson1
            // 
            ctrlFindPerson1.Location = new Point(3, 3);
            ctrlFindPerson1.Name = "ctrlFindPerson1";
            ctrlFindPerson1.Size = new Size(917, 526);
            ctrlFindPerson1.TabIndex = 4;
            ctrlFindPerson1.OnPersonSelected += ctrlFindPerson1_OnPersonSelected;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.Close_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(759, 524);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(89, 41);
            Btn_Close.TabIndex = 6;
            Btn_Close.Text = "Colse";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // frmFindPerson
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(919, 568);
            Controls.Add(Btn_Close);
            Controls.Add(ctrlFindPerson1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmFindPerson";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Find Person";
            Shown += frmFindPerson_Shown;
            ResumeLayout(false);
        }

        #endregion
        private UserControls.ctrlFindPerson ctrlFindPerson1;
        private Button Btn_Close;
    }
}