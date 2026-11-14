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
using System.Windows.Forms.VisualStyles;

namespace DVLD_Presentation.UserControls.Applications
{
    public partial class ctrlInternationalApplication : UserControl
    {
        public clsInternationalDrivingLicenseApplication InternationalLicenses = null;

        public clsApplicationType ApplicationType = null;

        public clsLicense LocalLicense = null;

        public ctrlInternationalApplication()
        {
            InitializeComponent();
        }
        
        private void ctrlInternationalApplication_Load(object sender, EventArgs e)
        {
            ApplicationType = clsApplicationType.Find(clsApplicationType.enApplicationType.NewInternational);

        }

        public void LoadData(clsLicense LocalLicense, string UserName)
        {
            if (LocalLicense is null)
            {
                MessageBox.Show("LocalLicense is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ApplicationType is null)
            {
                MessageBox.Show("ApplicationType is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.LocalLicense = LocalLicense;

            LB_ApplicationDate.Text = DateTime.Today.ToShortDateString();
            LB_IssueDate.Text = DateTime.Today.ToShortDateString();
            LB_Fees.Text = ApplicationType.ApplicationTypeFees.ToString();
            LB_LocalLicenseID.Text = LocalLicense.LicenseID.ToString();
            LB_ExpirationDate.Text = DateTime.Today.AddYears(1).ToShortDateString();
            LB_CreatedBy.Text = UserName;
        }

        public void LoadData(clsInternationalDrivingLicenseApplication InternationalDrivingLicense)
        {
            if (InternationalDrivingLicense is null)
            {
                MessageBox.Show("InternationalDrivingLicense is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ApplicationType is null)
            {
                MessageBox.Show("ApplicationType is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.InternationalLicenses = InternationalDrivingLicense;
            this.LocalLicense = InternationalLicenses.LocalLicense;

            LoadData(LocalLicense, InternationalLicenses.ApplicationUser.UserName);

            LB_ILApplicationID.Text = InternationalLicenses.ApplicationID.ToString();
            LB_ILLicenseID.Text = InternationalLicenses.LocalLicense_ID.ToString();
        }
    }
}
