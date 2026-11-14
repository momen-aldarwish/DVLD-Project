namespace DVLD_Presentation.Tests.SchedualTests.Vision
{
    partial class frmAddEditVisionTest
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
            groupBox1 = new GroupBox();
            ctrlAddEditTestAppointment1 = new DVLD_Presentation.UserControls.Applications.ctrlAddEditTestAppointment();
            pictureBox1 = new PictureBox();
            Btn_Close = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(ctrlAddEditTestAppointment1);
            groupBox1.Location = new Point(13, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(630, 846);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vision Test";
            // 
            // ctrlAddEditTestAppointment1
            // 
            ctrlAddEditTestAppointment1.Location = new Point(6, 205);
            ctrlAddEditTestAppointment1.Name = "ctrlAddEditTestAppointment1";
            ctrlAddEditTestAppointment1.Size = new Size(618, 630);
            ctrlAddEditTestAppointment1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Vision_512;
            pictureBox1.Location = new Point(194, 50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(197, 149);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.cross_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(267, 878);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(90, 41);
            Btn_Close.TabIndex = 3;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // frmAddEditVisionTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 929);
            Controls.Add(groupBox1);
            Controls.Add(Btn_Close);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmAddEditVisionTest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddVisionTest";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Button Btn_Close;
        private UserControls.Applications.ctrlAddEditTestAppointment ctrlAddEditTestAppointment1;
    }
}