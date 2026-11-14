namespace DVLD_Presentation.UserControls.Applications
{
    partial class ctrlDrivingLiceseAppointment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DGV_Appointments = new DataGridView();
            Btn_AddAppointment = new Button();
            label2 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            endTaskToolStripMenuItem = new ToolStripMenuItem();
            ctrlDrivingLicenseInfo1 = new ctrlDrivingLicenseInfo();
            ((System.ComponentModel.ISupportInitialize)DGV_Appointments).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DGV_Appointments
            // 
            DGV_Appointments.AllowUserToAddRows = false;
            DGV_Appointments.AllowUserToDeleteRows = false;
            DGV_Appointments.BackgroundColor = SystemColors.ControlLightLight;
            DGV_Appointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Appointments.Location = new Point(4, 507);
            DGV_Appointments.Name = "DGV_Appointments";
            DGV_Appointments.ReadOnly = true;
            DGV_Appointments.RowHeadersWidth = 51;
            DGV_Appointments.Size = new Size(835, 180);
            DGV_Appointments.TabIndex = 8;
            DGV_Appointments.CellMouseDown += DGV_Appointments_CellMouseDown;
            // 
            // Btn_AddAppointment
            // 
            Btn_AddAppointment.Image = Properties.Resources.AddAppointment_32;
            Btn_AddAppointment.Location = new Point(779, 456);
            Btn_AddAppointment.Name = "Btn_AddAppointment";
            Btn_AddAppointment.Size = new Size(44, 45);
            Btn_AddAppointment.TabIndex = 7;
            Btn_AddAppointment.UseVisualStyleBackColor = true;
            Btn_AddAppointment.Click += Btn_AddAppointment_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 463);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 6;
            label2.Text = "Appointments:";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, endTaskToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(139, 56);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Image = Properties.Resources.edit_32;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(138, 26);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // endTaskToolStripMenuItem
            // 
            endTaskToolStripMenuItem.Image = Properties.Resources.Test_322;
            endTaskToolStripMenuItem.Name = "endTaskToolStripMenuItem";
            endTaskToolStripMenuItem.Size = new Size(138, 26);
            endTaskToolStripMenuItem.Text = "End Task";
            endTaskToolStripMenuItem.Click += endTaskToolStripMenuItem_Click;
            // 
            // ctrlDrivingLicenseInfo1
            // 
            ctrlDrivingLicenseInfo1.Location = new Point(1, 3);
            ctrlDrivingLicenseInfo1.Name = "ctrlDrivingLicenseInfo1";
            ctrlDrivingLicenseInfo1.Size = new Size(842, 437);
            ctrlDrivingLicenseInfo1.TabIndex = 9;
            // 
            // ctrlDrivingLiceseAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ctrlDrivingLicenseInfo1);
            Controls.Add(DGV_Appointments);
            Controls.Add(Btn_AddAppointment);
            Controls.Add(label2);
            Name = "ctrlDrivingLiceseAppointment";
            Size = new Size(846, 695);
            ((System.ComponentModel.ISupportInitialize)DGV_Appointments).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView DGV_Appointments;
        private Button Btn_AddAppointment;
        private Label label2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem endTaskToolStripMenuItem;
        private ctrlDrivingLicenseInfo ctrlDrivingLicenseInfo1;
    }
}
