namespace DVLD_Presentation.Applications.SchedualTests
{
    partial class frmVision
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
            uctrlDrivingLiceseApplicationInfo1 = new DVLD_Presentation.UserControls.Applications.ctrlDrivingLiceseAppointment();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Vision_5121;
            pictureBox1.Location = new Point(344, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(180, 153);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(225, 212);
            label1.Name = "label1";
            label1.Size = new Size(415, 46);
            label1.TabIndex = 1;
            label1.Text = "Vision Test Appointment";
            // 
            // uctrlDrivingLiceseApplicationInfo1
            // 
            uctrlDrivingLiceseApplicationInfo1.Location = new Point(3, 296);
            uctrlDrivingLiceseApplicationInfo1.Name = "uctrlDrivingLiceseApplicationInfo1";
            uctrlDrivingLiceseApplicationInfo1.Size = new Size(846, 691);
            uctrlDrivingLiceseApplicationInfo1.TabIndex = 2;
            uctrlDrivingLiceseApplicationInfo1.OnAddClick += uctrlDrivingLiceseApplicationInfo1_OnAddClick;
            uctrlDrivingLiceseApplicationInfo1.OnEditClick += uctrlDrivingLiceseApplicationInfo1_OnEditClick;
            uctrlDrivingLiceseApplicationInfo1.OnEndTaskClick += uctrlDrivingLiceseApplicationInfo1_OnEndTaskClick;
            // 
            // frmVision
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 986);
            Controls.Add(uctrlDrivingLiceseApplicationInfo1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmVision";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVision";
            Load += frmVision_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private UserControls.Applications.ctrlDrivingLiceseAppointment uctrlDrivingLiceseApplicationInfo1;
    }
}