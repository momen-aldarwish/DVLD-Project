namespace DVLD_Presentation.UsersForms
{
    partial class frmFindUser
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
            informationUserView1 = new DVLD_Presentation.UserControls.NewFolder.ctrlInformationUserView();
            CB_Filter = new ComboBox();
            groupBox1 = new GroupBox();
            Btn_AddNew = new Button();
            Btn_Search = new Button();
            TB_Search = new TextBox();
            LLB_EditUser = new LinkLabel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // informationUserView1
            // 
            informationUserView1.BackColor = SystemColors.HighlightText;
            informationUserView1.Location = new Point(0, 109);
            informationUserView1.Name = "informationUserView1";
            informationUserView1.Size = new Size(913, 548);
            informationUserView1.TabIndex = 3;
            // 
            // CB_Filter
            // 
            CB_Filter.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Filter.FormattingEnabled = true;
            CB_Filter.Location = new Point(99, 38);
            CB_Filter.Name = "CB_Filter";
            CB_Filter.Size = new Size(151, 28);
            CB_Filter.TabIndex = 4;
            CB_Filter.SelectedIndexChanged += CB_Filter_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlLightLight;
            groupBox1.Controls.Add(Btn_AddNew);
            groupBox1.Controls.Add(Btn_Search);
            groupBox1.Controls.Add(TB_Search);
            groupBox1.Controls.Add(CB_Filter);
            groupBox1.Location = new Point(1, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(912, 91);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            // 
            // Btn_AddNew
            // 
            Btn_AddNew.Image = Properties.Resources.Add_New_User_32;
            Btn_AddNew.Location = new Point(461, 30);
            Btn_AddNew.Name = "Btn_AddNew";
            Btn_AddNew.Size = new Size(41, 42);
            Btn_AddNew.TabIndex = 8;
            Btn_AddNew.UseVisualStyleBackColor = true;
            Btn_AddNew.Click += Btn_AddNew_Click;
            // 
            // Btn_Search
            // 
            Btn_Search.Image = Properties.Resources.SearchPerson;
            Btn_Search.Location = new Point(414, 30);
            Btn_Search.Name = "Btn_Search";
            Btn_Search.Size = new Size(41, 42);
            Btn_Search.TabIndex = 7;
            Btn_Search.UseVisualStyleBackColor = true;
            Btn_Search.Click += Btn_Search_Click;
            // 
            // TB_Search
            // 
            TB_Search.Location = new Point(269, 39);
            TB_Search.Name = "TB_Search";
            TB_Search.Size = new Size(125, 27);
            TB_Search.TabIndex = 6;
            TB_Search.TextChanged += TB_Search_TextChanged;
            TB_Search.KeyPress += TB_Search_KeyPress;
            // 
            // LLB_EditUser
            // 
            LLB_EditUser.AutoSize = true;
            LLB_EditUser.BackColor = SystemColors.ControlLightLight;
            LLB_EditUser.Location = new Point(704, 490);
            LLB_EditUser.Name = "LLB_EditUser";
            LLB_EditUser.Size = new Size(68, 20);
            LLB_EditUser.TabIndex = 6;
            LLB_EditUser.TabStop = true;
            LLB_EditUser.Text = "Edit User";
            LLB_EditUser.LinkClicked += LLB_EditUser_LinkClicked;
            // 
            // frmFindUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(914, 655);
            Controls.Add(LLB_EditUser);
            Controls.Add(groupBox1);
            Controls.Add(informationUserView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmFindUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Find User";
            Load += frmFindUser_Load;
            Shown += frmFindUser_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private UserControls.NewFolder.ctrlInformationUserView informationUserView1;
        private ComboBox CB_Filter;
        private GroupBox groupBox1;
        private Button Btn_AddNew;
        private Button Btn_Search;
        private TextBox TB_Search;
        private LinkLabel LLB_EditUser;
    }
}