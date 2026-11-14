namespace DVLD_Presentation.UserControls.License
{
    partial class ctrlLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ctrlLicenseInfo1 = new ctrlLicenseInfo();
            GB_Filter = new GroupBox();
            Btn_Filter = new Button();
            TB_Filter = new TextBox();
            label1 = new Label();
            GB_Filter.SuspendLayout();
            SuspendLayout();
            // 
            // ctrlLicenseInfo1
            // 
            ctrlLicenseInfo1.Location = new Point(3, 113);
            ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            ctrlLicenseInfo1.Size = new Size(1030, 360);
            ctrlLicenseInfo1.TabIndex = 0;
            // 
            // GB_Filter
            // 
            GB_Filter.Controls.Add(Btn_Filter);
            GB_Filter.Controls.Add(TB_Filter);
            GB_Filter.Controls.Add(label1);
            GB_Filter.Location = new Point(12, 19);
            GB_Filter.Name = "GB_Filter";
            GB_Filter.Size = new Size(410, 88);
            GB_Filter.TabIndex = 1;
            GB_Filter.TabStop = false;
            GB_Filter.Text = "Filter";
            // 
            // Btn_Filter
            // 
            Btn_Filter.Image = Properties.Resources.License_View_324;
            Btn_Filter.Location = new Point(333, 35);
            Btn_Filter.Name = "Btn_Filter";
            Btn_Filter.Size = new Size(46, 38);
            Btn_Filter.TabIndex = 2;
            Btn_Filter.UseVisualStyleBackColor = true;
            Btn_Filter.Click += Btn_Filter_Click;
            // 
            // TB_Filter
            // 
            TB_Filter.Location = new Point(164, 41);
            TB_Filter.Name = "TB_Filter";
            TB_Filter.Size = new Size(163, 27);
            TB_Filter.TabIndex = 1;
            TB_Filter.TextChanged += TB_Filter_TextChanged;
            TB_Filter.KeyPress += TB_Filter_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(45, 40);
            label1.Name = "label1";
            label1.Size = new Size(113, 28);
            label1.TabIndex = 0;
            label1.Text = "License ID:";
            // 
            // ctrlLicenseInfoWithFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(GB_Filter);
            Controls.Add(ctrlLicenseInfo1);
            Name = "ctrlLicenseInfoWithFilter";
            Size = new Size(1034, 472);
            GB_Filter.ResumeLayout(false);
            GB_Filter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ctrlLicenseInfo ctrlLicenseInfo1;
        private GroupBox GB_Filter;
        private Button Btn_Filter;
        private TextBox TB_Filter;
        private Label label1;
    }
}
