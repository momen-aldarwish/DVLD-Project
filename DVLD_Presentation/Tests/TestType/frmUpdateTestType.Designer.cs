namespace DVLD_Presentation.TestTypeForms
{
    partial class frmUpdateTestType
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
            Btn_Close = new Button();
            Btn_Save = new Button();
            TB_TestFees = new TextBox();
            TB_TestTypeTitle = new TextBox();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label4 = new Label();
            TB_TestTypeDescription = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.Close_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(433, 480);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(80, 41);
            Btn_Close.TabIndex = 19;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // Btn_Save
            // 
            Btn_Save.Image = Properties.Resources.Save_32;
            Btn_Save.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Save.Location = new Point(533, 480);
            Btn_Save.Name = "Btn_Save";
            Btn_Save.Size = new Size(80, 41);
            Btn_Save.TabIndex = 18;
            Btn_Save.Text = "Save";
            Btn_Save.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Save.UseVisualStyleBackColor = true;
            Btn_Save.Click += Btn_Save_Click;
            // 
            // TB_TestFees
            // 
            TB_TestFees.Location = new Point(355, 420);
            TB_TestFees.Name = "TB_TestFees";
            TB_TestFees.Size = new Size(184, 27);
            TB_TestFees.TabIndex = 15;
            TB_TestFees.TextChanged += TB_TestFees_Changed;
            TB_TestFees.KeyPress += TB_TestFees_KeyPress;
            // 
            // TB_TestTypeTitle
            // 
            TB_TestTypeTitle.Location = new Point(355, 246);
            TB_TestTypeTitle.Multiline = true;
            TB_TestTypeTitle.Name = "TB_TestTypeTitle";
            TB_TestTypeTitle.Size = new Size(184, 83);
            TB_TestTypeTitle.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(188, 420);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 13;
            label3.Text = "Test Fees:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 246);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 12;
            label2.Text = "Test Type Title:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.TestType_5121;
            pictureBox1.Location = new Point(311, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 108);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(275, 163);
            label1.Name = "label1";
            label1.Size = new Size(196, 31);
            label1.TabIndex = 10;
            label1.Text = "Update Test Type";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(188, 347);
            label4.Name = "label4";
            label4.Size = new Size(153, 20);
            label4.TabIndex = 20;
            label4.Text = "Test Type Description:";
            // 
            // TB_TestTypeDescription
            // 
            TB_TestTypeDescription.Location = new Point(355, 347);
            TB_TestTypeDescription.Multiline = true;
            TB_TestTypeDescription.Name = "TB_TestTypeDescription";
            TB_TestTypeDescription.Size = new Size(184, 67);
            TB_TestTypeDescription.TabIndex = 21;
            // 
            // frmUpdateTestType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 561);
            Controls.Add(TB_TestTypeDescription);
            Controls.Add(label4);
            Controls.Add(Btn_Close);
            Controls.Add(Btn_Save);
            Controls.Add(TB_TestFees);
            Controls.Add(TB_TestTypeTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmUpdateTestType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmEdit";
            Load += frmUpdateTestType_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_Close;
        private Button Btn_Save;
        private TextBox TB_TestFees;
        private TextBox TB_TestTypeTitle;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label4;
        private TextBox TB_TestTypeDescription;
    }
}