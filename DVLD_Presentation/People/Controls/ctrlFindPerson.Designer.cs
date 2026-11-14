namespace DVLD_Presentation.UserControls
{
    partial class ctrlFindPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlFindPerson));
            GB_Filter = new GroupBox();
            Btn_Add = new Button();
            Btn_Search = new Button();
            TB_Search = new TextBox();
            CB_FilterBy = new ComboBox();
            informationView1 = new DVLD_Presentation.UserControls.PeopleControls.ctrlPersonalInfo();
            GB_Filter.SuspendLayout();
            SuspendLayout();
            // 
            // GB_Filter
            // 
            GB_Filter.BackColor = SystemColors.ControlLightLight;
            GB_Filter.Controls.Add(Btn_Add);
            GB_Filter.Controls.Add(Btn_Search);
            GB_Filter.Controls.Add(TB_Search);
            GB_Filter.Controls.Add(CB_FilterBy);
            GB_Filter.Location = new Point(3, 3);
            GB_Filter.Name = "GB_Filter";
            GB_Filter.Size = new Size(908, 73);
            GB_Filter.TabIndex = 8;
            GB_Filter.TabStop = false;
            GB_Filter.Text = "Filter";
            // 
            // Btn_Add
            // 
            Btn_Add.Image = Properties.Resources.AddPerson_32;
            Btn_Add.Location = new Point(471, 19);
            Btn_Add.Name = "Btn_Add";
            Btn_Add.Size = new Size(46, 42);
            Btn_Add.TabIndex = 4;
            Btn_Add.UseVisualStyleBackColor = true;
            Btn_Add.Click += Btn_Add_Click;
            // 
            // Btn_Search
            // 
            Btn_Search.Image = (Image)resources.GetObject("Btn_Search.Image");
            Btn_Search.Location = new Point(419, 19);
            Btn_Search.Name = "Btn_Search";
            Btn_Search.Size = new Size(46, 42);
            Btn_Search.TabIndex = 3;
            Btn_Search.UseVisualStyleBackColor = true;
            Btn_Search.Click += Btn_Search_Click;
            // 
            // TB_Search
            // 
            TB_Search.Location = new Point(206, 27);
            TB_Search.Name = "TB_Search";
            TB_Search.Size = new Size(194, 27);
            TB_Search.TabIndex = 2;
            TB_Search.TextChanged += TB_Search_TextChanged;
            TB_Search.KeyPress += TB_Search_KeyPress;
            // 
            // CB_FilterBy
            // 
            CB_FilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_FilterBy.FormattingEnabled = true;
            CB_FilterBy.Location = new Point(6, 26);
            CB_FilterBy.Name = "CB_FilterBy";
            CB_FilterBy.Size = new Size(151, 28);
            CB_FilterBy.TabIndex = 1;
            // 
            // informationView1
            // 
            informationView1.AutoSize = true;
            informationView1.BackColor = SystemColors.ControlLightLight;
            informationView1.Location = new Point(3, 78);
            informationView1.Name = "informationView1";
            informationView1.Size = new Size(910, 441);
            informationView1.TabIndex = 6;
            informationView1.Load += informationView1_Load;
            // 
            // ctrlFindControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(GB_Filter);
            Controls.Add(informationView1);
            Name = "ctrlFindControl";
            Size = new Size(913, 518);
            GB_Filter.ResumeLayout(false);
            GB_Filter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox GB_Filter;
        private Button Btn_Add;
        private Button Btn_Search;
        private TextBox TB_Search;
        private ComboBox CB_FilterBy;
        private PeopleControls.ctrlPersonalInfo informationView1;
    }
}
