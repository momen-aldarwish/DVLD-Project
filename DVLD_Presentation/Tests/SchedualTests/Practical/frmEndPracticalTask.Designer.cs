namespace DVLD_Presentation.Tests.SchedualTests.Practical
{
    partial class frmEndPracticalTask
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
            ctrlEndTask1 = new DVLD_Presentation.UserControls.Schedual_Test.ctrlEndTask();
            label1 = new Label();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.driving_test_5122;
            pictureBox1.Location = new Point(274, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(152, 126);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ctrlEndTask1
            // 
            ctrlEndTask1.Location = new Point(12, 194);
            ctrlEndTask1.Name = "ctrlEndTask1";
            ctrlEndTask1.Size = new Size(737, 574);
            ctrlEndTask1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(201, 141);
            label1.Name = "label1";
            label1.Size = new Size(333, 50);
            label1.TabIndex = 2;
            label1.Text = "End Practical Task";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(737, 765);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "End Practical Task";
            // 
            // frmEndPracticalTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 778);
            Controls.Add(label1);
            Controls.Add(ctrlEndTask1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmEndPracticalTask";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmEndPracticalTask";
            Load += frmEndPracticalTask_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private UserControls.Schedual_Test.ctrlEndTask ctrlEndTask1;
        private Label label1;
        private GroupBox groupBox1;
    }
}