using DVLD_BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Presentation.PeopleForms
{
    public partial class frmFindPerson : Form
    {
        public frmFindPerson()
        {
            InitializeComponent();
        }
        
        private void frmFindPerson_Shown(object sender, EventArgs e)
        {
            ctrlFindPerson1.FocusFilter();
        }

        private void ctrlFindPerson1_OnPersonSelected(int obj)
        {
            if (obj <= 0)
            {
                MessageBox.Show("Person is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }


}
