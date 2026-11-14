namespace DVLD_Presentation.Tests.SchedualTests.Vision
{
    partial class frmEndTask
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ctrlEndTask1 = new DVLD_Presentation.UserControls.Schedual_Test.ctrlEndTask();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Btn_Close
            // 
            Btn_Close.Image = Properties.Resources.Close_32;
            Btn_Close.ImageAlign = ContentAlignment.MiddleRight;
            Btn_Close.Location = new Point(546, 787);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(94, 50);
            Btn_Close.TabIndex = 9;
            Btn_Close.Text = "Close";
            Btn_Close.TextAlign = ContentAlignment.MiddleLeft;
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += this.Btn_Close_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Vision_512;
            pictureBox1.Location = new Point(269, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(191, 168);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(260, 199);
            label1.Name = "label1";
            label1.Size = new Size(209, 41);
            label1.TabIndex = 1;
            label1.Text = "Schedual Test";
            // 
            // ctrlEndTask1
            // 
            ctrlEndTask1.Location = new Point(25, 266);
            ctrlEndTask1.Name = "ctrlEndTask1";
            ctrlEndTask1.Size = new Size(748, 578);
            ctrlEndTask1.TabIndex = 2;
            // 
            // frmEndTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 847);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(Btn_Close);
            Controls.Add(ctrlEndTask1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmEndTask";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EndTask";
            Load += frmEndTask_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Btn_Close;
        private PictureBox pictureBox1;
        private Label label1;
        private UserControls.Schedual_Test.ctrlEndTask ctrlEndTask1;
    }
}