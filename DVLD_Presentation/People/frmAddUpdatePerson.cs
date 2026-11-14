using DVLD_BusinessLogicLayer;
using DVLD_Presentation.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.PeopleForms
{
    public partial class frmAddUpdatePerson : Form
    {
        int PersonID;
        clsPerson Person = null;

        private bool _IsImageChanged = false;

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            this.PersonID = PersonID;

        }

        public frmAddUpdatePerson()
        {
            InitializeComponent();
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            CB_Countries.DataSource = clsCountry.GetAllCountries();
            CB_Countries.DisplayMember = "CountryName";
            CB_Countries.ValueMember = "CountryID";
            CB_Countries.SelectedIndex = clsCountry.Find("Syria").CountryID - 1;

            if (PersonID <= 0)
            {
                //Add Mode
                this.Text = "Add New Person";
                LB_Title.Text = "Add New Person";
                LLB_Remove.Visible = false;
                Person = new clsPerson();
                return;
            }

            //Update Mode
            this.Text = "Update Person";
            LB_Title.Text = "Update Person";
            TB_NationalNo.Enabled = false;
            
            //If you add person it transforms mode directly to update mode, it's not required to reload it again
            if (Person is null)
                Person = clsPerson.Find(PersonID);
            
            if (Person is null)
            {
                MessageBox.Show($"Person ID {PersonID} is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Btn_Save.Enabled = false;
                return;
            }

            TB_FirstName.Text = Person.FirstName;
            TB_SecondName.Text = Person.SecondName;
            TB_ThirdName.Text = Person.ThirdName;
            TB_LastName.Text = Person.LastName;
            TB_NationalNo.Text = Person.NationalNo;
            TB_PhoneNomber.Text = Person.Phone;
            TB_Email.Text = Person.Email;
            TB_Address.Text = Person.Address;

            LB_PersonID.Text = PersonID.ToString();
            CB_Countries.SelectedValue = Person.Country.CountryID;
            DTP_DateOfBirth.Value = Person.DateOfBirth;

            switch (Person.Gender)
            {
                case clsPerson.enGendor.Male:
                    RB_Male.Checked = true;
                    RB_Female.Checked = false;
                    break;

                case clsPerson.enGendor.Female:
                    RB_Male.Checked = false;
                    RB_Female.Checked = true;
                    break;
            }

            if (string.IsNullOrEmpty(Person.ImagePath))
            {
                PB_PersonalImage.Image = (RB_Male.Checked) ? IL_PersonalImageDefault.Images[1] : IL_PersonalImageDefault.Images[2];
                LLB_Remove.Visible = false;
            }
            else
            {
                PB_PersonalImage.ImageLocation = Person.ImagePath;
                LLB_Remove.Visible = true;
            }
           
        }

        private void _HandleImageChange()
        {
            if (!_IsImageChanged || (Person.ImagePath == PB_PersonalImage.ImageLocation))
                return;


            if (string.IsNullOrEmpty(PB_PersonalImage.ImageLocation))
            {
                if (clsUtil.DeleteImage(Person.ImagePath))
                    Person.ImagePath = string.Empty;

                else
                    MessageBox.Show("Error: OldPicture is not deleted.\nIt might be open.", "Image is not deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string SourceFilePath = PB_PersonalImage.ImageLocation;

            if (PB_PersonalImage.Image != null)
            {
                PB_PersonalImage.Image.Dispose();
                PB_PersonalImage.Image = null;
            }

            PB_PersonalImage.ImageLocation = null;

            string OldImage = Person.ImagePath;

            if (clsUtil.CopyImage(SourceFilePath, out string destinationFilePath))
            {
                PB_PersonalImage.ImageLocation = destinationFilePath;
                Person.ImagePath = destinationFilePath;

                clsUtil.DeleteImage(OldImage);
                _IsImageChanged = false;
            }
            else
            {
                MessageBox.Show("Error: Image is not copied.\n it's locked or not exist", "Image is not copied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PB_PersonalImage.ImageLocation = SourceFilePath;
                _IsImageChanged = true;
            }

        }

        private void _LoadDataToPerson()
        {
            Person.FirstName = TB_FirstName.Text.Trim();
            Person.SecondName = TB_SecondName.Text.Trim();
            Person.ThirdName = TB_ThirdName.Text.Trim();
            Person.LastName = TB_LastName.Text.Trim();
            Person.Email = TB_Email.Text.Trim();
            Person.Phone = TB_PhoneNomber.Text.Trim();
            Person.NationalNo = TB_NationalNo.Text.Trim();
            Person.Address = TB_Address.Text.Trim();
            Person.DateOfBirth = DTP_DateOfBirth.Value;

            _HandleImageChange();

            Person.CountryID = Convert.ToInt32(CB_Countries.SelectedValue);
            Person.Gender = (RB_Male.Checked) ? clsPerson.enGendor.Male : clsPerson.enGendor.Female;

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            this.ValidateChildren(ValidationConstraints.Enabled);

            if (clsValidate.HasAnyErrors(this, errorProvider1))
            {
                MessageBox.Show("You have to fill empty fiels they are not allowed null!", "Save Caption",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            _LoadDataToPerson();
            switch (Person.Save())
            {
                case clsPerson.enSaveResult.SavedSuccessfully:
                    MessageBox.Show("Person is saved successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PersonID = Person.PersonID;
                    frmAddUpdatePerson_Load(null, null);
                    break;

                case clsPerson.enSaveResult.NationalNoAlreadyExist:
                    MessageBox.Show("NationalNo is already existed on database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsPerson.enSaveResult.DBError:
                default:
                    MessageBox.Show("Person is not saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            LB_PersonID.Text = Person.PersonID.ToString();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUpdatePersonScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Person is not null)
                OnDataSent?.Invoke(Person.PersonID);
        }

        private void RB_Male_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Male.Checked && string.IsNullOrEmpty(PB_PersonalImage.ImageLocation))
            {
                PB_PersonalImage.Image = IL_PersonalImageDefault.Images[1];
            }
        }

        private void RB_Female_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Female.Checked && string.IsNullOrEmpty(PB_PersonalImage.ImageLocation))
            {
                PB_PersonalImage.Image = IL_PersonalImageDefault.Images[2];
            }
        }

        public delegate void DataSent(int PersonID);

        public event DataSent OnDataSent = null;

        private void LLB_SetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog File = new OpenFileDialog();

            File.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (File.ShowDialog() == DialogResult.OK)
            {
                PB_PersonalImage.ImageLocation = File.FileName;

                LLB_Remove.Visible = true;

                _IsImageChanged = true;
            }

        }

        private void LLB_Remove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PB_PersonalImage.ImageLocation = null;

            PB_PersonalImage.Image = (RB_Male.Checked) ? IL_PersonalImageDefault.Images[1] : IL_PersonalImageDefault.Images[2];

            _IsImageChanged = true;

            LLB_Remove.Visible = false;
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

        private void TB_PhoneNomber_Validating(object sender, CancelEventArgs e)
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
                else if (!clsValidate.PhoneNomber(txt.Text))
                {
                    errorProvider1.SetError(txt, "This number is not valid");
                }
                else
                {
                    // إزالة الخطأ في حال كانت القيمة صحيحة
                    errorProvider1.SetError(txt, "");
                }
            }
        }

        private void TB_Email_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt != null)
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    errorProvider1.SetError(txt, "");
                    return;
                }

                if (!clsValidate.Email(txt.Text))
                    errorProvider1.SetError(txt, "This Email is not valid");

                else
                    errorProvider1.SetError(txt, "");

            }
        }

    }
}
