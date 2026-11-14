namespace DVLD_Presentation.Tests.SchedualTests.Written
{
    partial class frmWritten
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
            label1 = new Label();
            ctrlDrivingLiceseApplicationInfo1 = new DVLD_Presentation.UserControls.Applications.ctrlDrivingLiceseAppointment();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Written_Test_512;
            pictureBox1.Location = new Point(312, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 153);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(147, 190);
            label1.Name = "label1";
            label1.Size = new Size(535, 54);
            label1.TabIndex = 1;
            label1.Text = "Written Test Appointments";
            // 
            // ctrlDrivingLiceseApplicationInfo1
            // 
            ctrlDrivingLiceseApplicationInfo1.Location = new Point(2, 247);
            ctrlDrivingLiceseApplicationInfo1.Name = "ctrlDrivingLiceseApplicationInfo1";
            ctrlDrivingLiceseApplicationInfo1.Size = new Size(844, 691);
            ctrlDrivingLiceseApplicationInfo1.TabIndex = 2;
            ctrlDrivingLiceseApplicationInfo1.OnAddClick += ctrlDrivingLiceseApplicationInfo1_OnAddClick;
            ctrlDrivingLiceseApplicationInfo1.OnEditClick += ctrlDrivingLiceseApplicationInfo1_OnEditClick;
            ctrlDrivingLiceseApplicationInfo1.OnEndTaskClick += ctrlDrivingLiceseApplicationInfo1_OnEndTaskClick;
            // 
            // frmWritten
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 942);
            Controls.Add(ctrlDrivingLiceseApplicationInfo1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmWritten";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmWritten";
            Load += frmWritten_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private UserControls.Applications.ctrlDrivingLiceseAppointment ctrlDrivingLiceseApplicationInfo1;
    }
}