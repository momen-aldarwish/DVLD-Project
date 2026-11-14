namespace DVLD_Presentation.UsersForms
{
    partial class frmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            pictureBox1 = new PictureBox();
            DGV_Users = new DataGridView();
            Btn_AddNewUser = new Button();
            Btn_Search = new Button();
            label1 = new Label();
            LB_UsersCount = new Label();
            CMS_More = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            addNewContactToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            moreInfoToolStripMenuItem = new ToolStripMenuItem();
            CB_Filter = new ComboBox();
            TB_Search = new TextBox();
            CB_Activity = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Users).BeginInit();
            CMS_More.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(307, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(162, 138);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // DGV_Users
            // 
            DGV_Users.AllowUserToAddRows = false;
            DGV_Users.AllowUserToDeleteRows = false;
            DGV_Users.BackgroundColor = SystemColors.ControlLightLight;
            DGV_Users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Users.Location = new Point(108, 318);
            DGV_Users.Name = "DGV_Users";
            DGV_Users.ReadOnly = true;
            DGV_Users.RowHeadersWidth = 51;
            DGV_Users.Size = new Size(573, 188);
            DGV_Users.TabIndex = 1;
            DGV_Users.CellMouseDown += DGV_Users_CellMouseDown;
            // 
            // Btn_AddNewUser
            // 
            Btn_AddNewUser.BackgroundImageLayout = ImageLayout.Stretch;
            Btn_AddNewUser.Image = (Image)resources.GetObject("Btn_AddNewUser.Image");
            Btn_AddNewUser.Location = new Point(602, 239);
            Btn_AddNewUser.Name = "Btn_AddNewUser";
            Btn_AddNewUser.Size = new Size(79, 72);
            Btn_AddNewUser.TabIndex = 2;
            Btn_AddNewUser.UseVisualStyleBackColor = true;
            Btn_AddNewUser.Click += Btn_AddNewUser_Click;
            // 
            // Btn_Search
            // 
            Btn_Search.BackgroundImageLayout = ImageLayout.Stretch;
            Btn_Search.Image = (Image)resources.GetObject("Btn_Search.Image");
            Btn_Search.Location = new Point(517, 239);
            Btn_Search.Name = "Btn_Search";
            Btn_Search.Size = new Size(79, 72);
            Btn_Search.TabIndex = 3;
            Btn_Search.UseVisualStyleBackColor = true;
            Btn_Search.Click += Btn_Search_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 518);
            label1.Name = "label1";
            label1.Size = new Size(120, 23);
            label1.TabIndex = 4;
            label1.Text = "#Users Count:";
            // 
            // LB_UsersCount
            // 
            LB_UsersCount.AutoSize = true;
            LB_UsersCount.Location = new Point(174, 521);
            LB_UsersCount.Name = "LB_UsersCount";
            LB_UsersCount.Size = new Size(37, 20);
            LB_UsersCount.TabIndex = 5;
            LB_UsersCount.Text = "????";
            // 
            // CMS_More
            // 
            CMS_More.ImageScalingSize = new Size(20, 20);
            CMS_More.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem, addNewContactToolStripMenuItem, searchToolStripMenuItem, moreInfoToolStripMenuItem });
            CMS_More.Name = "CMS_More";
            CMS_More.Size = new Size(178, 134);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Image = (Image)resources.GetObject("editToolStripMenuItem.Image");
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(177, 26);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = (Image)resources.GetObject("deleteToolStripMenuItem.Image");
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(177, 26);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // addNewContactToolStripMenuItem
            // 
            addNewContactToolStripMenuItem.Image = (Image)resources.GetObject("addNewContactToolStripMenuItem.Image");
            addNewContactToolStripMenuItem.Name = "addNewContactToolStripMenuItem";
            addNewContactToolStripMenuItem.Size = new Size(177, 26);
            addNewContactToolStripMenuItem.Text = "Add New User";
            addNewContactToolStripMenuItem.Click += addNewContactToolStripMenuItem_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Image = (Image)resources.GetObject("searchToolStripMenuItem.Image");
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(177, 26);
            searchToolStripMenuItem.Text = "Search";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // moreInfoToolStripMenuItem
            // 
            moreInfoToolStripMenuItem.Image = (Image)resources.GetObject("moreInfoToolStripMenuItem.Image");
            moreInfoToolStripMenuItem.Name = "moreInfoToolStripMenuItem";
            moreInfoToolStripMenuItem.Size = new Size(177, 26);
            moreInfoToolStripMenuItem.Text = "More Info";
            moreInfoToolStripMenuItem.Click += moreInfoToolStripMenuItem_Click;
            // 
            // CB_Filter
            // 
            CB_Filter.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Filter.FormattingEnabled = true;
            CB_Filter.Items.AddRange(new object[] { "None", "User ID", "User Name", "Is Active" });
            CB_Filter.Location = new Point(108, 284);
            CB_Filter.Name = "CB_Filter";
            CB_Filter.Size = new Size(151, 28);
            CB_Filter.TabIndex = 6;
            CB_Filter.SelectedIndexChanged += CB_Filter_SelectedIndexChanged;
            // 
            // TB_Search
            // 
            TB_Search.Location = new Point(265, 284);
            TB_Search.Name = "TB_Search";
            TB_Search.Size = new Size(125, 27);
            TB_Search.TabIndex = 7;
            TB_Search.TextChanged += TB_Search_TextChanged;
            TB_Search.KeyPress += TB_Search_KeyPress;
            // 
            // CB_Activity
            // 
            CB_Activity.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Activity.FormattingEnabled = true;
            CB_Activity.Items.AddRange(new object[] { "All", "Active", "Not Active" });
            CB_Activity.Location = new Point(265, 284);
            CB_Activity.Name = "CB_Activity";
            CB_Activity.Size = new Size(125, 28);
            CB_Activity.TabIndex = 8;
            CB_Activity.SelectedIndexChanged += CB_Activity_SelectedIndexChanged;
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(825, 614);
            Controls.Add(CB_Activity);
            Controls.Add(TB_Search);
            Controls.Add(CB_Filter);
            Controls.Add(LB_UsersCount);
            Controls.Add(label1);
            Controls.Add(Btn_Search);
            Controls.Add(Btn_AddNewUser);
            Controls.Add(DGV_Users);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Users List";
            Load += frmUsers_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Users).EndInit();
            CMS_More.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView DGV_Users;
        private Button Btn_AddNewUser;
        private Button Btn_Search;
        private Label label1;
        private Label LB_UsersCount;
        private ContextMenuStrip CMS_More;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem addNewContactToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem moreInfoToolStripMenuItem;
        private ComboBox CB_Filter;
        private TextBox TB_Search;
        private ComboBox CB_Activity;
    }
}