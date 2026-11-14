using DVLD_BusinessLogicLayer;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls.User
{
    public partial class ctrlAddUpdateUser : UserControl
    {
        private enum _enMode { AddNewUser, UpdateUser }
        _enMode _Mode;

        public clsUser User { get; private set; } = null;
        public int PersonID = -1;

        public ctrlAddUpdateUser()
        {
            InitializeComponent();
            _Mode = _enMode.AddNewUser;
        }

        public void LoadUserInfo(int UserID)
        {
            User = clsUser.Find(UserID);

            if (User is not null)
            {
                _Mode = _enMode.UpdateUser;
                CB_IsActive.Checked = User.IsActive;
                PersonID = User.PersonID;
            }
            else
            {
                MessageBox.Show("User is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Btn_Save.Enabled = false;
            }
        }

        private bool _HasErrors(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // 1. إذا كان العنصر نفسه عليه خطأ حالياً في ErrorProvider
                if (!string.IsNullOrEmpty(errorProvider1.GetError(c)))
                    return true;

                // 2. الدخول داخل الـ GroupBoxes والـ Panels لفحص ما بداخلها
                if (c.HasChildren)
                {
                    if (_HasErrors(c))
                        return true;
                }
            }
            return false;
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt != null)
            {
                // التحقق مما إذا كان الحقل فارغاً أو يحتوي على مسافات فقط
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    // إظهار الخطأ بجانب الـ TextBox
                    errorProvider1.SetError(txt, "This Field doesn't allow null");
                }
                else
                {
                    // إزالة الخطأ في حال كانت القيمة صحيحة
                    errorProvider1.SetError(txt, "");
                }
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (TB_Password.Text.Trim() != TB_Confirm.Text.Trim())
            {
                MessageBox.Show("Password and confirm password are not matched!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PersonID <= 0)
            {
                MessageBox.Show("PersonID is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == _enMode.AddNewUser)
                User = new clsUser();
            else if (User is null)
            {
                MessageBox.Show("User is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Btn_Save.Enabled = false;
                return;
            }

            User.UserName = TB_Username.Text.Trim();
            User.Password = TB_Password.Text.Trim();
            User.IsActive = CB_IsActive.Checked;
            User.PersonID = PersonID;

            switch (User.Save())
            {
                case clsUser.enSaveResult.PersonAllreadyUser:
                    MessageBox.Show("Person is already User!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsUser.enSaveResult.PersonIDIsNotExisted:
                    MessageBox.Show($"Person ID {PersonID} is not existed in database!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsUser.enSaveResult.DBError:
                    MessageBox.Show("Something wrong happend from database!, User is not saved, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsUser.enSaveResult.SavedSuccessfully:
                    string mode = "Added";
                    if (_Mode == _enMode.AddNewUser)
                        mode = "Added";
                    else
                        mode = "Update";

                    MessageBox.Show($"User is {mode} successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }
}
