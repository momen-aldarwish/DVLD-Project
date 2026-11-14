namespace DVLD_Presentation
{
    partial class frmPeopleWindow
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeopleWindow));
            DGV_GroupOfPeople = new DataGridView();
            Btn_AddNewPerson = new Button();
            Btn_SearchPerson = new Button();
            CMS_More = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            addNewContactToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            moreInfoToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            LB_CountPeople = new Label();
            CB_Filter = new ComboBox();
            TB_Search = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGV_GroupOfPeople).BeginInit();
            CMS_More.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // DGV_GroupOfPeople
            // 
            DGV_GroupOfPeople.AllowUserToAddRows = false;
            DGV_GroupOfPeople.AllowUserToDeleteRows = false;
            DGV_GroupOfPeople.AllowUserToOrderColumns = true;
            DGV_GroupOfPeople.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGV_GroupOfPeople.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGV_GroupOfPeople.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_GroupOfPeople.Location = new Point(86, 256);
            DGV_GroupOfPeople.Name = "DGV_GroupOfPeople";
            DGV_GroupOfPeople.ReadOnly = true;
            DGV_GroupOfPeople.RowHeadersWidth = 51;
            DGV_GroupOfPeople.Size = new Size(1478, 284);
            DGV_GroupOfPeople.TabIndex = 0;
            DGV_GroupOfPeople.CellMouseDown += DGV_GroupOfPeople_CellMouseDown;
            // 
            // Btn_AddNewPerson
            // 
            Btn_AddNewPerson.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_AddNewPerson.Image = (Image)resources.GetObject("Btn_AddNewPerson.Image");
            Btn_AddNewPerson.Location = new Point(1411, 172);
            Btn_AddNewPerson.Name = "Btn_AddNewPerson";
            Btn_AddNewPerson.Size = new Size(94, 78);
            Btn_AddNewPerson.TabIndex = 1;
            Btn_AddNewPerson.UseVisualStyleBackColor = true;
            Btn_AddNewPerson.Click += Btn_AddNewPerson_Click;
            // 
            // Btn_SearchPerson
            // 
            Btn_SearchPerson.Image = (Image)resources.GetObject("Btn_SearchPerson.Image");
            Btn_SearchPerson.Location = new Point(1322, 172);
            Btn_SearchPerson.Name = "Btn_SearchPerson";
            Btn_SearchPerson.Size = new Size(83, 78);
            Btn_SearchPerson.TabIndex = 4;
            Btn_SearchPerson.UseVisualStyleBackColor = true;
            Btn_SearchPerson.Click += Btn_FindPerson_OnClick;
            // 
            // CMS_More
            // 
            CMS_More.ImageScalingSize = new Size(20, 20);
            CMS_More.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem, addNewContactToolStripMenuItem, searchToolStripMenuItem, moreInfoToolStripMenuItem });
            CMS_More.Name = "CMS_More";
            CMS_More.Size = new Size(215, 162);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Image = (Image)resources.GetObject("editToolStripMenuItem.Image");
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(214, 26);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = (Image)resources.GetObject("deleteToolStripMenuItem.Image");
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(214, 26);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // addNewContactToolStripMenuItem
            // 
            addNewContactToolStripMenuItem.Image = (Image)resources.GetObject("addNewContactToolStripMenuItem.Image");
            addNewContactToolStripMenuItem.Name = "addNewContactToolStripMenuItem";
            addNewContactToolStripMenuItem.Size = new Size(214, 26);
            addNewContactToolStripMenuItem.Text = "Add New Person";
            addNewContactToolStripMenuItem.Click += addNewContactToolStripMenuItem_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Image = (Image)resources.GetObject("searchToolStripMenuItem.Image");
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(214, 26);
            searchToolStripMenuItem.Text = "Search";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // moreInfoToolStripMenuItem
            // 
            moreInfoToolStripMenuItem.Image = (Image)resources.GetObject("moreInfoToolStripMenuItem.Image");
            moreInfoToolStripMenuItem.Name = "moreInfoToolStripMenuItem";
            moreInfoToolStripMenuItem.Size = new Size(214, 26);
            moreInfoToolStripMenuItem.Text = "More Info";
            moreInfoToolStripMenuItem.Click += moreInfoToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(694, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(257, 216);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.8F);
            label2.Location = new Point(40, 552);
            label2.Name = "label2";
            label2.Size = new Size(127, 23);
            label2.TabIndex = 6;
            label2.Text = "#People Count:";
            // 
            // LB_CountPeople
            // 
            LB_CountPeople.AutoSize = true;
            LB_CountPeople.Location = new Point(173, 555);
            LB_CountPeople.Name = "LB_CountPeople";
            LB_CountPeople.Size = new Size(17, 20);
            LB_CountPeople.TabIndex = 7;
            LB_CountPeople.Text = "0";
            // 
            // CB_Filter
            // 
            CB_Filter.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Filter.FormattingEnabled = true;
            CB_Filter.Location = new Point(130, 222);
            CB_Filter.Name = "CB_Filter";
            CB_Filter.Size = new Size(151, 28);
            CB_Filter.TabIndex = 8;
            CB_Filter.SelectedIndexChanged += CB_Filter_SelectedIndexChanged;
            // 
            // TB_Search
            // 
            TB_Search.Location = new Point(296, 222);
            TB_Search.Name = "TB_Search";
            TB_Search.Size = new Size(165, 27);
            TB_Search.TabIndex = 9;
            TB_Search.TextChanged += TB_Search_TextChanged;
            TB_Search.KeyPress += TB_Search_KeyPress;
            // 
            // frmPeopleWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1617, 591);
            Controls.Add(TB_Search);
            Controls.Add(CB_Filter);
            Controls.Add(LB_CountPeople);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(Btn_SearchPerson);
            Controls.Add(Btn_AddNewPerson);
            Controls.Add(DGV_GroupOfPeople);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "frmPeopleWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "People List";
            Load += frmPeopleWindow_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_GroupOfPeople).EndInit();
            CMS_More.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV_GroupOfPeople;
        private Button Btn_AddNewPerson;
        private Button Btn_SearchPerson;
        private Label LB_CountPeople;
        private ContextMenuStrip CMS_More;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem addNewContactToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem moreInfoToolStripMenuItem;
        private Label label2;
        private ComboBox CB_Filter;
        private TextBox TB_Search;
    }
}