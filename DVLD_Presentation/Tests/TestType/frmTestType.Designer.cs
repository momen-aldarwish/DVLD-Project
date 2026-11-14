namespace DVLD_Presentation.TestTypeForms
{
    partial class frmTestType
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
            pictureBox1 = new PictureBox();
            DGV_TestTypes = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            LB_CountTestTypes = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_TestTypes).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.TestType_512;
            pictureBox1.Location = new Point(387, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(152, 129);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // DGV_TestTypes
            // 
            DGV_TestTypes.AllowUserToAddRows = false;
            DGV_TestTypes.AllowUserToDeleteRows = false;
            DGV_TestTypes.BackgroundColor = SystemColors.ControlLightLight;
            DGV_TestTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_TestTypes.Location = new Point(0, 264);
            DGV_TestTypes.Name = "DGV_TestTypes";
            DGV_TestTypes.ReadOnly = true;
            DGV_TestTypes.RowHeadersWidth = 51;
            DGV_TestTypes.Size = new Size(950, 201);
            DGV_TestTypes.TabIndex = 1;
            DGV_TestTypes.CellMouseDown += DGV_TestTypes_CellMouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(332, 187);
            label1.Name = "label1";
            label1.Size = new Size(263, 50);
            label1.TabIndex = 2;
            label1.Text = "Test Type Test";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 486);
            label2.Name = "label2";
            label2.Size = new Size(141, 20);
            label2.TabIndex = 3;
            label2.Text = "#Count Test Types:";
            // 
            // LB_CountTestTypes
            // 
            LB_CountTestTypes.AutoSize = true;
            LB_CountTestTypes.Location = new Point(185, 486);
            LB_CountTestTypes.Name = "LB_CountTestTypes";
            LB_CountTestTypes.Size = new Size(37, 20);
            LB_CountTestTypes.TabIndex = 4;
            LB_CountTestTypes.Text = "????";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(215, 58);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Image = Properties.Resources.pencil;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(214, 26);
            editToolStripMenuItem.Text = "Update";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // frmTestType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 524);
            Controls.Add(LB_CountTestTypes);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DGV_TestTypes);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmTestType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmTestType";
            Load += frmTestType_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_TestTypes).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView DGV_TestTypes;
        private Label label1;
        private Label label2;
        private Label LB_CountTestTypes;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
    }
}