using DVLD_BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using DVLD_Presentation.HelperClasses;

namespace DVLD_Presentation.UsersForms
{
    public partial class frmSignIn : Form
    {
        public frmSignIn()
        {
            InitializeComponent();
        }

        private void frmSignIn_Shown(object sender, EventArgs e)
        {
            Btn_Login.Focus();
        }
        
        private void frmSignIn_Load(object sender, EventArgs e)
        {
            if (clsGlobal.GetUserNamePasswordFromFile(out string Username, out string password))
            {
                if ((!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(password)))
                {
                    TB_UserName.Text = Username;
                    TB_Password.Text = password;

                    CB_Rememberme.Checked = true;

                }
            }
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if ((clsGlobal.UserID = clsUser.GetUserID(TB_UserName.Text, TB_Password.Text)) > 0)
            {
                ClearFile();
                if (!clsUser.IsUserActive(clsGlobal.UserID))
                {
                    MessageBox.Show("User is not active, Contact with Admins", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (CB_Rememberme.Checked)
                    clsGlobal.SaveUserNamePasswordInFile(TB_UserName.Text, TB_Password.Text);

                frmMainWindow frm = new frmMainWindow(clsGlobal.UserID, TB_UserName.Text, TB_Password.Text);

                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username or Passwrod are wrong,", "Error Loged in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            ClearFile();
            this.Close();
        }

        private void CB_Show_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Show.Checked)
            {
                TB_Password.PasswordChar = '\0';
            }
            else
            {
                TB_Password.PasswordChar = '*';
            }
        }

        private void ClearFile ()
        {
            if (CB_Rememberme.Checked)
                return;

            clsGlobal.Clear();
        }

    }
}
