using DVLD_BusinessLogicLayer;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.PeopleForms;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UsersForms
{
    public partial class frmFindUser : Form
    {
        enum enFilter { PersonID, NationalNo, UserID, UserName };
        struct stFilterName
        {
            public static string PersonID = "PersonID";
            public static string NationalNo = "NationalNo";
            public static string UserID = "UserID";
            public static string UserName = "UserName";
        }

        bool IsNumber
        {
            get
            {
                if (CB_Filter.SelectedValue is not enFilter)
                    return false;

                switch (CB_Filter.SelectedValue)
                {
                    case enFilter.PersonID:
                    case enFilter.UserID:
                        return true;

                    default:
                        return false;
                }
            }
        }

        private clsUser _User = null;
        private clsPerson _Person = null;

        public frmFindUser()
        {
            InitializeComponent();
        }

        private void frmFindUser_Load(object sender, EventArgs e)
        {
            List<clsUtil.FilterItem<enFilter>> list = new List<clsUtil.FilterItem<enFilter>>()
            {
                new clsUtil.FilterItem<enFilter> (stFilterName.PersonID, enFilter.PersonID),
                new clsUtil.FilterItem<enFilter> (stFilterName.NationalNo, enFilter.NationalNo),
                new clsUtil.FilterItem<enFilter> (stFilterName.UserID, enFilter.UserID),
                new clsUtil.FilterItem<enFilter> (stFilterName.UserName, enFilter.UserName)
            };

            CB_Filter.DataSource = list;
            CB_Filter.DisplayMember = "DisplayText";
            CB_Filter.ValueMember = "Value";

            CB_Filter.SelectedValue = enFilter.NationalNo;
        }

        private void frmFindUser_Shown(object sender, EventArgs e)
        {
            TB_Search.Focus();
        }
        
        private void _GetUserByPerson()
        {
            if (_Person != null)
            {
                int UserID = clsUser.GetUserID(_Person.PersonID);

                if (UserID > 0)
                    _User = clsUser.Find(UserID);
            }
            else
                _User = null;
        }

        private void _SearchByPersonID()
        {
            if (int.TryParse(TB_Search.Text, out int PersonID))
                _Person = clsPerson.Find(PersonID);
            else
                _Person = null;

            _GetUserByPerson();
        }

        private void _SearchByNationalNo()
        {
            _Person = clsPerson.Find(TB_Search.Text);

            _GetUserByPerson();
        }

        private void _SearchByUserID()
        {
            if (int.TryParse(TB_Search.Text, out int UserID))
            {
                _User = clsUser.Find(UserID);

                if (_User != null)
                    _Person = clsPerson.Find(_User.PersonID);
                else
                    _Person = null;
            }
            else
            {
                _Person = null;
                _User = null;
            }

        }

        private void _SearchByUsername()
        {
            _User = clsUser.Find(TB_Search.Text);

            if (_User != null)
                _Person = clsPerson.Find(_User.PersonID);
            else
                _Person = null;
        }

        private void _SearchProces()
        {
            switch (CB_Filter.SelectedValue)
            {
                case enFilter.PersonID:
                    _SearchByPersonID();
                    break;

                case enFilter.NationalNo:
                    _SearchByNationalNo();
                    break;

                case enFilter.UserID:
                    _SearchByUserID();
                    break;

                case enFilter.UserName:
                    _SearchByUsername();
                    break;

            }

            int PersonID = -1, UserID = -1;

            if (_Person != null)
                PersonID = _Person.PersonID;

            if (_User != null)
                UserID = _User.UserID;

            informationUserView1.LoadData(UserID);
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            _SearchProces();
        }

        private void Btn_AddNew_Click(object sender, EventArgs e)
        {
            if (_User == null)
            {
                frmAddNewUser form = new frmAddNewUser();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("This person is already user!", "Person already user", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LLB_EditUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_User != null)
            {
                frmGiveAccessToUpdate form = new frmGiveAccessToUpdate(_User.UserID);

                form.OnDataSent += _Fill_User;

                form.Show();
            }
        }

        private void _Fill_User(int UserID)
        {
            _User = clsUser.Find(UserID);

            if (_User == null)
                return;

            CB_Filter.SelectedIndex = 2;
            TB_Search.Text = _User.UserID.ToString();

            _SearchProces();
        }

        private void CB_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Filter.SelectedValue is not enFilter)
                return;

            TB_Search.Text = string.Empty;
            TB_Search.Focus();
        }

        private void TB_Search_TextChanged(object sender, EventArgs e)
        {
            clsValidate.SanitizeNumericInput(sender, IsNumber);
        }

        private void TB_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                Btn_Search.PerformClick();
                return;
            }

            clsValidate.PressOnlyNombers(e, IsNumber);
        }

    }
}
