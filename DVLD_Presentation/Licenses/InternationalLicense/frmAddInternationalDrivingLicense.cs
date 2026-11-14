using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Licenses;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.InternationalDrivingLicense
{
    public partial class frmAddInternationalDrivingLicense : Form
    {
        public clsLicense License = null;
        public clsInternationalDrivingLicenseApplication InternationalDrivingLicense = null;

        public frmAddInternationalDrivingLicense()
        {
            InitializeComponent();
            LLB_ShowLicenseInfo.Enabled = false;
            LLB_ShowLicensesHistory.Enabled = false;
            Btn_Issue.Enabled = false;
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            //obj = -2 means avoiding searching to international license from data base

            if (obj == -1 || (License = clsLicense.Find(obj)) is null)
            {
                MessageBox.Show("License is not existed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Btn_Issue.Enabled = false;
                LLB_ShowLicenseInfo.Enabled = false;
                LLB_ShowLicensesHistory.Enabled = false;
                return;
            }
            
            LLB_ShowLicensesHistory.Enabled = true;

            if (obj != -2)
                InternationalDrivingLicense = clsInternationalDrivingLicenseApplication.FindByLocalLicenseID(obj);
            
            if (InternationalDrivingLicense is not null)
            {
                if (obj != -2)
                    MessageBox.Show("This license is already international!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                LLB_ShowLicenseInfo.Enabled = true;
                Btn_Issue.Enabled = false;

                ctrlInternationalApplication1.LoadData(InternationalDrivingLicense);
                return;
            }
            Btn_Issue.Enabled = true;
            ctrlInternationalApplication1.LoadData(License, clsGlobal.User.UserName);
        }

        private void LLB_ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(InternationalDrivingLicense);
            frm.ShowDialog();
        }

        private void LLB_ShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHistoryLicenseInfo frm = new frmHistoryLicenseInfo(License.Driver.PersonID);
            frm.ShowDialog();
        }

        private void Btn_Issue_Click(object sender, EventArgs e)
        {
            if (InternationalDrivingLicense is not null)
            {
                MessageBox.Show("There is already international license!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure that you want to add international driving license?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            InternationalDrivingLicense = new clsInternationalDrivingLicenseApplication(License.LicenseID, clsGlobal.UserID);

            switch (InternationalDrivingLicense.Save())
            {
                case clsInternationalDrivingLicenseApplication.enSaveResult.SavedSuccessfully:
                    MessageBox.Show("International License is added successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctrlLicenseInfoWithFilter1_OnLicenseSelected(-2);
                    ctrlLicenseInfoWithFilter1.gbFilter = false;
                    break;

                case clsInternationalDrivingLicenseApplication.enSaveResult.ApplicationNotCreated:
                    MessageBox.Show("Something wrong with international application creation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsInternationalDrivingLicenseApplication.enSaveResult.ThisPersonIsNotSavedAsDriver:
                    MessageBox.Show("This person dosen't exist on database as a driver!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsInternationalDrivingLicenseApplication.enSaveResult.LocalDrivingLicenseNotExist:
                    MessageBox.Show("Local License is not found from data base!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsInternationalDrivingLicenseApplication.enSaveResult.LocalDrivingLicenseNotClass3_Ordinary_Driving:
                    MessageBox.Show("Local License is not Class 3: Ordinary Driving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsInternationalDrivingLicenseApplication.enSaveResult.ThisLocalAlreadyHasInternationalLicense:
                    MessageBox.Show("There is already international license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsInternationalDrivingLicenseApplication.enSaveResult.DBError:
                    MessageBox.Show("Something wrong happend from database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
