using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Applications;
using DVLD_Presentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls.InternationalLicenses
{
    public partial class ctrlDriverLicenseInternationalInfo : UserControl
    {
        public clsInternationalDrivingLicenseApplication InternationalDrivingLicense { get; private set; } = null;

        public ctrlDriverLicenseInternationalInfo()
        {
            InitializeComponent();
        }

        public void LoadData (int IDL_ID)
        {
            InternationalDrivingLicense = clsInternationalDrivingLicenseApplication.Find(IDL_ID);
            LoadData(InternationalDrivingLicense);
        }

        public void LoadData (clsInternationalDrivingLicenseApplication InternationalDrivingLicense)
        {
            this.InternationalDrivingLicense = InternationalDrivingLicense;
            if (InternationalDrivingLicense is null)
            {
                MessageBox.Show("International Is not existed!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LB_Name.Text = InternationalDrivingLicense.ApplicantPerson.FullName;
            LB_InternaitonalLicenseID.Text = InternationalDrivingLicense.IL_ID.ToString();
            LB_LicenseID.Text = InternationalDrivingLicense.LocalLicense_ID.ToString();
            LB_NationalNo.Text = InternationalDrivingLicense.ApplicantPerson.NationalNo;
            LB_Gendor.Text = (InternationalDrivingLicense.ApplicantPerson.Gender == clsPerson.enGendor.Male) ? "Male" : "Female";
            LB_IssueDate.Text = InternationalDrivingLicense.IssueDate.ToShortDateString();
            LB_ApplicationID.Text = InternationalDrivingLicense.ApplicationID.ToString();
            LB_IsActive.Text = (InternationalDrivingLicense.IsActive) ? "Yes" : "No";
            LB_DateOfBirth.Text = InternationalDrivingLicense.ApplicantPerson.DateOfBirth.ToShortDateString();
            LB_DriverID.Text = InternationalDrivingLicense.DriverID.ToString();
            LB_ExpirationDate.Text = InternationalDrivingLicense.ExpirationDate.ToShortDateString();

            PB_Gendor.Image = (InternationalDrivingLicense.ApplicantPerson.Gender == clsPerson.enGendor.Male) ?
                Resources.Man_32 : Resources.Woman_32;

            if (string.IsNullOrEmpty(InternationalDrivingLicense.ApplicantPerson.ImagePath) || 
                !File.Exists(InternationalDrivingLicense.ApplicantPerson.ImagePath))
                PB_PersonalImage.Image = PB_Gendor.Image;
            else
                PB_PersonalImage.ImageLocation = InternationalDrivingLicense.ApplicantPerson.ImagePath;
        
            
        }
    
    
    }
}
