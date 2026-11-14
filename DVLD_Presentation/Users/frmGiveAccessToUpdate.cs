using DVLD_BusinessLogicLayer;
using DVLD_Presentation.PeopleForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UsersForms
{
    public partial class frmGiveAccessToUpdate : Form
    {
        private clsUser _User;

        public frmGiveAccessToUpdate(int UserID)
        {
            InitializeComponent();

            _User = clsUser.Find(UserID);

            if (_User != null)
                informationView1.LoadData(_User.PersonID);
        }

        private void Btn_Check_Click(object sender, EventArgs e)
        {
            int UserID = -1;

            if ((UserID = clsUser.GetUserID(TB_OldUsername.Text, TB_OldPassword.Text)) > 0)
            {
                frmUpdateUserInfo form = new frmUpdateUserInfo(UserID);

                form.OnDataSent += _Fill_User;

                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username or Password is wrong!", "Wrong password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _Fill_User(int UserID)
        {
            _User = clsUser.Find(UserID);

            if (_User == null)
                return;

            TB_OldUsername.Text = _User.UserName;
            TB_OldPassword.Text = _User.Password;
        }

        private void GiveAccessToUpdateScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnDataSent?.Invoke(_User.UserID);
        }

        public delegate void DataSent(int UserID);

        public event DataSent OnDataSent;
    }
}
