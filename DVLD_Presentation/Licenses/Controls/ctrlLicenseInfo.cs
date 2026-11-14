using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls.License
{
    public partial class ctrlLicenseInfo : UserControl
    {
        public clsLicense License { get; private set; } = null;

        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadData (int LicenseID)
        {
            License = clsLicense.Find(LicenseID);

            LoadData(License);
        }
    
        public void LoadData (clsLicense License)
        {
            this.License = License;

            if (License is null)
            {
                MessageBox.Show("License is not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LB_ClassTitle.Text = License.LicenseClass.ClassName;
            LB_Name.Text = License.Application.ApplicantPerson.FullName;
            LB_LicenseID.Text = License.LicenseID.ToString();
            LB_NationalNo.Text = License.Application.ApplicantPerson.NationalNo;
            LB_IssueDate.Text = License.IssueDate.ToShortDateString();
            LB_IssueReason.Text = License.IssueReasonString;
            LB_Notes.Text = License.Notes;
            LB_IsActive.Text = (License.IsActive) ? "Yes" : "No";
            LB_DateOfBirth.Text = License.Application.ApplicantPerson.DateOfBirth.ToShortDateString();
            LB_DriverID.Text = License.DriverID.ToString();
            LB_ExpirationDate.Text = License.ExpirationDate.ToShortDateString();
            LB_IsDetained.Text = (clsDetainedLicense.IsDetained(License.LicenseID)) ? "Yes" : "No";
            
            if (License.Application.ApplicantPerson.Gender == clsPerson.enGendor.Male)
            {
                LB_Gendor.Text = "Male";
                PB_Gendor.Image = imageList1.Images[0];
            }
            else
            {
                LB_Gendor.Text = "Female";
                PB_Gendor.Image = imageList1.Images[1];
            }

            if (!string.IsNullOrEmpty(License.Application.ApplicantPerson.ImagePath) && Directory.Exists(License.Application.ApplicantPerson.ImagePath))
            {
                PB_PersonalPhoto.ImageLocation = License.Application.ApplicantPerson.ImagePath;
            }
            else
            {
                PB_PersonalPhoto.Image = PB_Gendor.Image;
            }
        }
    
    
    }
}
