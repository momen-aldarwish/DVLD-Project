using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Tests;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.Licenses;
using DVLD_Presentation.PeopleForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls.Applications
{
    public partial class ctrlDrivingLicenseInfo : UserControl
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicense = null;

        public ctrlDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadData(clsLocalDrivingLicenseApplication LocalDrivingLicense)
        {
            _LocalDrivingLicense = LocalDrivingLicense;

            if (_LocalDrivingLicense is null)
            {
                clsMessagesBoxes.LocalDrivingLicennseFoundFaild();
                LLB_ViewPersonInfo.Enabled = false;
                return;
            }

            _LoadDataToControl();

            int id = clsDrivers.GetDriverIDByApplicationID(_LocalDrivingLicense.ApplicationID);
            LLB_ShowLicenseInfo.Enabled = (id > 0);

        }

        private void _LoadDataToControl()
        {
            LLB_ViewPersonInfo.Enabled = true;

            LB_DLAppID.Text = _LocalDrivingLicense.LicenseClassID.ToString();
            LB_AppliedForLicense.Text = _LocalDrivingLicense.LicenseClass.ClassName;

            LB_PassedTest.Text = _LocalDrivingLicense.PassedTest.ToString() + "/3";

            LB_ID.Text = _LocalDrivingLicense.LDL_ID.ToString();
            LB_Status.Text = _LocalDrivingLicense.StatusString;
            LB_Fees.Text = _LocalDrivingLicense.ApplicationType.ApplicationTypeFees.ToString();
            LB_Type.Text = _LocalDrivingLicense.ApplicationType.ApplicationTypeTitle;
            LB_Applicant.Text = _LocalDrivingLicense.ApplicantPerson.FullName;

            LB_Date.Text = _LocalDrivingLicense.ApplicationDate.ToString();
            LB_StatusDate.Text = _LocalDrivingLicense.LastStatusDate.ToString();
            LB_CreatedBy.Text = _LocalDrivingLicense.ApplicationUser.UserName;
        }

        private void LLB_ViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonalInfo frm = new frmPersonalInfo(_LocalDrivingLicense.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void LLB_ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_LocalDrivingLicense.LDL_ID);
            frm.ShowDialog();
        }
    }
}
