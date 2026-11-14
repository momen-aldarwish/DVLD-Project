namespace DVLD_Presentation.Tests.SchedualTests.Written
{
    partial class frmEndWrittenTask
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
            groupBox1 = new GroupBox();
            btn_CLose = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Written_Test_512;
            pictureBox1.Location = new Point(276, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 157);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ctrlEndTask1
            // 
            ctrlEndTask1.Location = new Point(6, 233);
            ctrlEndTask1.Name = "ctrlEndTask1";
            ctrlEndTask1.Size = new Size(738, 575);
            ctrlEndTask1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(btn_CLose);
            groupBox1.Controls.Add(ctrlEndTask1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(750, 815);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "End Written Task";
            // 
            // btn_CLose
            // 
            btn_CLose.Image = Properties.Resources.Close_32;
            btn_CLose.ImageAlign = ContentAlignment.MiddleRight;
            btn_CLose.Location = new Point(527, 755);
            btn_CLose.Name = "btn_CLose";
            btn_CLose.Size = new Size(94, 46);
            btn_CLose.TabIndex = 0;
            btn_CLose.Text = "Close";
            btn_CLose.TextAlign = ContentAlignment.MiddleLeft;
            btn_CLose.UseVisualStyleBackColor = true;
            btn_CLose.Click += btn_CLose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(220, 176);
            label1.Name = "label1";
            label1.Size = new Size(335, 54);
            label1.TabIndex = 2;
            label1.Text = "End Written Test";
            // 
            // frmEndWrittenTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 833);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmEndWrittenTask";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmEndWrittenTask";
            Load += frmEndWrittenTask_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private UserControls.Schedual_Test.ctrlEndTask ctrlEndTask1;
        private GroupBox groupBox1;
        private Button btn_CLose;
        private Label label1;
    }
}