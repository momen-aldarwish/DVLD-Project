namespace DVLD_Presentation.Tests.SchedualTests.Written
{
    partial class frmAddEditWrittenAppointment
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
            button1 = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Written_Test_512;
            pictureBox1.Location = new Point(205, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(181, 164);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ctrlAddEditTestAppointment1
            // 
            ctrlAddEditTestAppointment1.Location = new Point(12, 191);
            ctrlAddEditTestAppointment1.Name = "ctrlAddEditTestAppointment1";
            ctrlAddEditTestAppointment1.Size = new Size(602, 637);
            ctrlAddEditTestAppointment1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.Close_32;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(409, 781);
            button1.Name = "button1";
            button1.Size = new Size(94, 38);
            button1.TabIndex = 2;
            button1.Text = "Close";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(-1, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(624, 822);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Written Appointment";
            // 
            // frmAddEditWrittenAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 831);
            Controls.Add(button1);
            Controls.Add(ctrlAddEditTestAppointment1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmAddEditWrittenAppointment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddEditWrittenAppointment";
            Load += frmAddEditWrittenAppointment_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private UserControls.Applications.ctrlAddEditTestAppointment ctrlAddEditTestAppointment1;
        private Button button1;
        private GroupBox groupBox1;
    }
}