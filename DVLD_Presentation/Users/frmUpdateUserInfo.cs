using DVLD_BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UsersForms
{
    public partial class frmUpdateUserInfo : Form
    {
        private int _UserID;
        private int _PersonID;

        public frmUpdateUserInfo(int UserID)
        {
            InitializeComponent();
            addUpdateUser1.LoadUserInfo (UserID);
            this._UserID = UserID;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateUserInfoScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnDataSent?.Invoke(_UserID);
        }

        public delegate void DataSent(int UserID);

        public event DataSent OnDataSent;

    }
}
