namespace DVLD_Presentation.ApplicationTypes
{
    partial class frmApplicationTypes
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
            DGV_ApplicationTypes = new DataGridView();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            updateToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            LB_ApplicationTypesCount = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_ApplicationTypes).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Applications_64;
            pictureBox1.Location = new Point(332, 66);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 117);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // DGV_ApplicationTypes
            // 
            DGV_ApplicationTypes.AllowUserToAddRows = false;
            DGV_ApplicationTypes.AllowUserToDeleteRows = false;
            DGV_ApplicationTypes.BackgroundColor = SystemColors.ControlLightLight;
            DGV_ApplicationTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_ApplicationTypes.Location = new Point(12, 274);
            DGV_ApplicationTypes.Name = "DGV_ApplicationTypes";
            DGV_ApplicationTypes.ReadOnly = true;
            DGV_ApplicationTypes.RowHeadersWidth = 51;
            DGV_ApplicationTypes.Size = new Size(776, 231);
            DGV_ApplicationTypes.TabIndex = 1;
            DGV_ApplicationTypes.CellMouseDown += DGV_ApplicationTypes_CellMouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(171, 203);
            label1.Name = "label1";
            label1.Size = new Size(483, 50);
            label1.TabIndex = 2;
            label1.Text = "Manage Application Types";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { updateToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(132, 30);
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Image = Properties.Resources.pencil;
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(131, 26);
            updateToolStripMenuItem.Text = "Update";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 516);
            label2.Name = "label2";
            label2.Size = new Size(192, 20);
            label2.TabIndex = 3;
            label2.Text = "#Application Types Count:";
            // 
            // LB_ApplicationTypesCount
            // 
            LB_ApplicationTypesCount.AutoSize = true;
            LB_ApplicationTypesCount.Location = new Point(221, 516);
            LB_ApplicationTypesCount.Name = "LB_ApplicationTypesCount";
            LB_ApplicationTypesCount.Size = new Size(37, 20);
            LB_ApplicationTypesCount.TabIndex = 4;
            LB_ApplicationTypesCount.Text = "????";
            // 
            // frmApplicationTypes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 551);
            Controls.Add(LB_ApplicationTypesCount);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DGV_ApplicationTypes);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "frmApplicationTypes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApplicationTypes";
            Load += ApplicationTypes_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_ApplicationTypes).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView DGV_ApplicationTypes;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem updateToolStripMenuItem;
        private Label label2;
        private Label LB_ApplicationTypesCount;
    }
}