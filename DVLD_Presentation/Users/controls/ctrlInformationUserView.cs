using DVLD_BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls.NewFolder
{
    public partial class ctrlInformationUserView : UserControl
    {
        private clsUser _User;

        public ctrlInformationUserView()
        {
            InitializeComponent();
            CB_IsActive.AutoCheck = false;
        }

        private void _UserClear()
        {
            LB_UserID.Text = "????";
            LB_Username.Text = "????";

            CB_IsActive.Checked = false;
        }

        public void Clear()
        {
            IV_PersonInfo.Clear();

            _UserClear();
        }

        private void _LoadUserData(int UserID)
        {
            if (_User != null)
            {
                LB_UserID.Text = _User.UserID.ToString();
                LB_Username.Text = _User.UserName;

                CB_IsActive.Checked = _User.IsActive;
            }
            else
                Clear();
        }
        
        public void LoadData (int UserID)
        {
            _User = clsUser.Find(UserID);
            _LoadUserData(UserID);

            if (_User != null)
                IV_PersonInfo.LoadData(_User.PersonID);
        }
    }
}
