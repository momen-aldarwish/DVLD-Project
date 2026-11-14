namespace DVLD_Presentation.Tests.SchedualTests.Practical
{
    partial class frmAddEditPracticalAppointment
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
            pictureBox1 = new PictureBox();
            ctrlAddEditTestAppointment1 = new DVLD_Presentation.UserControls.Applications.ctrlAddEditTestAppointment();
            groupBox1 = new GroupBox();
            btn_Close = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.driving_test_5121;
            pictureBox1.Location = new Point(198, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(193, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ctrlAddEditTestAppointment1
            // 
            ctrlAddEditTestAppointment1.Location = new Point(6, 192);
            ctrlAddEditTestAppointment1.Name = "ctrlAddEditTestAppointment1";
            ctrlAddEditTestAppointment1.Size = new Size(604, 634);
            ctrlAddEditTestAppointment1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_Close);
            groupBox1.Controls.Add(ctrlAddEditTestAppointment1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(619, 843);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Practical Test";
            // 
            // btn_Close
            // 
            btn_Close.Image = Properties.Resources.Close_32;
            btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            btn_Close.Location = new Point(414, 779);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(94, 43);
            btn_Close.TabIndex = 2;
            btn_Close.Text = "Close";
            btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            btn_Close.UseVisualStyleBackColor = true;
            btn_Close.Click += btn_Close_Click;
            // 
            // frmAddEditPracticalAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 867);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmAddEditPracticalAppointment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddEditPracticalAppointment";
            Load += frmAddEditPracticalAppointment_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private UserControls.Applications.ctrlAddEditTestAppointment ctrlAddEditTestAppointment1;
        private GroupBox groupBox1;
        private Button btn_Close;
    }
}