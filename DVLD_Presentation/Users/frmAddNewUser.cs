using DVLD_BusinessLogicLayer;
using DVLD_Presentation.PeopleForms;
using DVLD_Presentation.UserControls;
using Microsoft.IdentityModel.Tokens.Experimental;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UsersForms
{
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
        }

        private void frmAddNewUser_Shown(object sender, EventArgs e)
        {
            ctrlFindPerson1.FocusFilter();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                if (ctrlFindPerson1.Person is null)
                {
                    MessageBox.Show("The person is not exist!", "Person not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else if (clsUser.GetUserID(ctrlFindPerson1.PersonID) > 0)
                {
                    MessageBox.Show("The person is already user!", "Person already user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }

        }

        private void Btn_Next_Click(object sender, EventArgs e)
        {
            ctrlFindPerson1.Search();
            ctrlFindPerson1.EnabledFilter = false;
            tabControl1.SelectedIndex = 1;
        }

        private void ctrlFindPerson1_OnPersonSelected(int obj)
        {
            if (obj <= 0)
            {
                MessageBox.Show("Person is not Selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlAddUpdateUser1.PersonID = obj;
        }

    }


}
