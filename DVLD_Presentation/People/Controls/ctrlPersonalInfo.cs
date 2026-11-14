using DVLD_BusinessLogicLayer;
using DVLD_Presentation.PeopleForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls.PeopleControls
{
    public partial class ctrlPersonalInfo : UserControl
    {
        public clsPerson Person { get; private set; } = null;

        public int PersonID { get; private set; }
        
        public ctrlPersonalInfo()
        {
            InitializeComponent();

            RB_Male.Checked = true;

            RB_Male.AutoCheck = false;
            RB_Female.AutoCheck = false;

            PersonID = -1;
        }

        public void Clear()
        {
            LB_PersonID.Text = "N/A";

            LB_FirstName.Text = "????";
            LB_SecondName.Text = "????";
            LB_ThirdName.Text = "????";
            LB_LastName.Text = "????";
            LB_NationalNo.Text = "????";
            LB_DateOfBirth.Text = "????";
            LB_PhoneNomber.Text = "????";
            LB_Email.Text = "????";
            LB_Country.Text = "????";
            LB_Address.Text = "????";

            RB_Male.Checked = true;
            RB_Female.Checked = false;

            PB_PersonalImage.Image = IL_PersonalImageDefault.Images[1];
        }

        private void _FillData ()
        {
            if (Person is null)
            {
                Clear();
                return;
            }

            LB_PersonID.Text = Person.PersonID.ToString();
            LB_FirstName.Text = Person.FirstName;
            LB_SecondName.Text = Person.SecondName;

            LB_ThirdName.Text = string.IsNullOrEmpty(Person.ThirdName) ? string.Empty : Person.ThirdName;

            LB_LastName.Text = Person.LastName;
            LB_NationalNo.Text = Person.NationalNo;
            LB_DateOfBirth.Text = Person.DateOfBirth.ToShortDateString();
            LB_PhoneNomber.Text = Person.Phone;

            LB_Email.Text = string.IsNullOrEmpty(Person.Email) ? string.Empty : Person.ThirdName;

            LB_Country.Text = Person.Country.CountryName;
            LB_Address.Text = Person.Address;

            switch (Person.Gender)
            {
                case clsPerson.enGendor.Male:
                    RB_Male.Checked = true;
                    RB_Female.Checked = false;
                    break;

                case clsPerson.enGendor.Female:
                    RB_Female.Checked = true;
                    RB_Male.Checked = false;
                    break;
            }

            if (string.IsNullOrEmpty(Person.ImagePath))
            {
                PB_PersonalImage.Image = (RB_Male.Checked) ? IL_PersonalImageDefault.Images[1] : IL_PersonalImageDefault.Images[2];
            }
            else
                PB_PersonalImage.ImageLocation = Person.ImagePath;
        }

        public void LoadData(int PersonID)
        {
            this.PersonID = PersonID;
            Person = clsPerson.Find(PersonID);
            _FillData();
        }

        public void LoadData(string NationalNo)
        {
            Person = clsPerson.Find(NationalNo);
            PersonID = Person.PersonID;
           
            _FillData();
        }

        private void LLB_Edit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Person == null)
                return;

            frmAddUpdatePerson form = new frmAddUpdatePerson(PersonID);

            form.ShowDialog();

            LoadData(PersonID);
        }

    }
}
