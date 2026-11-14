namespace DVLD_Presentation.ApplicationTypes
{
    partial class frmUpdateApplicationType
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            TB_ApplicationTypeTitle = new TextBox();
            TB_ApplicationFees = new TextBox();
            Btn_Save = new Button();
            errorProvider1 = new ErrorProvider(components);
            Btn_Close = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(96, 159);
            label1.Name = "label1";
            label1.Size = new Size(279, 31);
            label1.TabIndex = 0;
            label1.Text = "Update Application Type";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Application_Types_64;
            pictureBox1.Location = new Point(173, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 108);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 245);
            label2.Name = "label2";
            label2.Size = new Size(157, 20);
            label2.TabIndex = 2;
            label2.Text = "Application Type Title:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 334);
            label3.Name = "label3";
            label3.Size = new Size(122, 20);
            label3.TabIndex = 3;
            label3.Text = "Application Fees:";
            // 
            // TB_ApplicationTypeTitle
            // 
            TB_ApplicationTypeTitle.Location = new Point(223, 245);
            TB_ApplicationTypeTitle.Multiline = true;
            TB_ApplicationTypeTitle.Name = "TB_ApplicationTypeTitle";
            TB_ApplicationTypeTitle.Size = new Size(184, 83);
            TB_ApplicationTypeTitle.TabIndex = 4;
            TB_ApplicationTypeTitle.Validating += text_Validating;
            // 
            // TB_ApplicationFees
            // 
            TB_ApplicationFees.Location = new Point(223, 334);
            TB_ApplicationFees.Name = "TB_ApplicationFees";
            TB_ApplicationFees.Size = new Size(184, 27);
            TB_ApplicationFees.TabIndex = 5;
            TB_ApplicationFees.TextChanged += TB_ApplicationFees_TextChanged;
            TB_ApplicationFees.KeyPress += TB_ApplicationFees_KeyPress;
            TB_ApplicationFees.Validating += text_Validating;
            // 
            // Btn_Save
            // 
            Btn_Save.Image = Properties.Resources.Save_32;
            Btn_Save.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Save.Location = new Point(381, 394);
            Btn_Save.Name = "Btn_Save";
            Btn_Save.Size = new Size(80, 44);
            Btn_Save.TabIndex = 8;
            Btn_Save.Text = "Save";
            Btn_Save.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Save.UseVisualStyleBackColor = true;
            Btn_Save.Click += Btn_Save_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.Close_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(276, 394);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(85, 44);
            Btn_Close.TabIndex = 9;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // frmUpdateApplicationType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(484, 450);
            Controls.Add(Btn_Close);
            Controls.Add(Btn_Save);
            Controls.Add(TB_ApplicationFees);
            Controls.Add(TB_ApplicationTypeTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmUpdateApplicationType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmUpdateApplicationType";
            Load += frmUpdateApplicationType_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private TextBox TB_ApplicationTypeTitle;
        private TextBox TB_ApplicationFees;
        private Button Btn_Save;
        private ErrorProvider errorProvider1;
        private Button Btn_Close;
    }
}