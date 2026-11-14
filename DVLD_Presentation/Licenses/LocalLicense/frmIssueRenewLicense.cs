using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Licenses;
using DVLD_Presentation.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses
{
    public partial class frmIssueRenewLicense : Form
    {
        private clsLicense _OldLicense = null;
        private clsLicense _ActiveLicense = null;
        private clsLicense _RenewLicense = null;

        private clsApplicationType _ApplicationType = null;

        public frmIssueRenewLicense()
        {
            InitializeComponent();
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _ApplicationType = clsApplicationType.Find(clsApplicationType.enApplicationType.ReNew);
            _OldLicense = ctrlLicenseInfoWithFilter1.License;

            if (_OldLicense is null)
            {
                //MessageBox.Show($"License ID {obj} is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Btn_Renew.Enabled = false;
                LLB_ShowActiveLicenseInfo.Enabled = false;
                TB_Notes.Enabled = false;

                return;
            }

            _ActiveLicense = clsLicense.GetActiveLicense(obj);
            if (_ActiveLicense is not null)
            {
                MessageBox.Show($"there is License Active!\n License ID for Active License is:  {_ActiveLicense.LicenseID}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LoadApplicationRenewLicenseInfo(_ActiveLicense);
                if (_ActiveLicense.IssueReason == clsLicense.enIssueReason.Renew)
                {
                    LB_RL_ApplicationID.Text = _ActiveLicense.ApplicationID.ToString();
                    LB_RenewLicenseID.Text = _ActiveLicense.LicenseID.ToString();
                }
                TB_Notes.Text = _ActiveLicense.Notes;
                TB_Notes.Enabled = false;

                Btn_Renew.Enabled = false;
                LLB_ShowActiveLicenseInfo.Enabled = true;

                ctrlLicenseInfoWithFilter1.gbFilter = false;
                return;
            }

            
            TB_Notes.Enabled = true;

            LLB_ShowActiveLicenseInfo.Enabled = false;
            Btn_Renew.Enabled = true;
            _LoadApplicationRenewLicenseInfo(_OldLicense);
        }

        private void _LoadApplicationRenewLicenseInfo(clsLicense License)
        {
            if (License is null)
            {
                MessageBox.Show("License is not exist!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LB_ApplicationDate.Text = License.Application.ApplicationDate.ToShortDateString();
            LB_IssueDate.Text = License.IssueDate.ToShortDateString();
            LB_ApplicationFees.Text = _ApplicationType.ApplicationTypeFees.ToString();
            LB_LicenseFees.Text = License.LicenseClass.ClassFees.ToString();
            LB_OldLicenseID.Text = _OldLicense.LicenseID.ToString();
            LB_ExpirationDate.Text = License.ExpirationDate.ToShortDateString();
            LB_CreatedBy.Text = clsGlobal.User.UserName;
            LB_TotalFees.Text = Convert.ToString(License.LicenseClass.ClassFees + _ApplicationType.ApplicationTypeFees);
        }

        private void Btn_Renew_Click(object sender, EventArgs e)
        {
            if (_OldLicense is null || _OldLicense is not null)
            {
                MessageBox.Show("License is not selected to renew it!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Btn_Renew.Enabled = false;
                return;
            }

            if (_ActiveLicense is not null && _ActiveLicense is not null)
            {
                MessageBox.Show("There is an active license for this driver!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Btn_Renew.Enabled = false;
                return;
            }

            clsLicense.enRenewResult reusult = clsLicense.enRenewResult.DBError;
            _RenewLicense = _OldLicense.Renew(ref reusult, clsGlobal.UserID, TB_Notes.Text.Trim());

            switch (reusult)
            {
                case clsLicense.enRenewResult.SavedSuccessfully:
                    MessageBox.Show("License Renewed seccessfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LB_RL_ApplicationID.Text = _RenewLicense.ApplicationID.ToString();
                    LB_RenewLicenseID.Text = _RenewLicense.LicenseID.ToString();
                    Btn_Renew.Enabled = false;
                    ctrlLicenseInfoWithFilter1.gbFilter = false;
                    break;

                case clsLicense.enRenewResult.LicenseNotExpiration:
                    MessageBox.Show("License is not expiration yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsLicense.enRenewResult.ApplicationNotCreated:
                    MessageBox.Show("Some thing wrong happend in application creation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsLicense.enRenewResult.OldReasonIsStilledActive:
                    MessageBox.Show("There is an active License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsLicense.enRenewResult.DBError:
                    MessageBox.Show("Something wrong happend in License creation in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LLB_ShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHistoryLicenseInfo frm = new frmHistoryLicenseInfo(_OldLicense.Driver.PersonID);
            frm.ShowDialog();
        }

        private void LLB_ShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_ActiveLicense is not null)
            {
                frmLicenseInfo frm = new frmLicenseInfo(_ActiveLicense.LicenseID, false);
                frm.ShowDialog();
            }
            else if (_RenewLicense is not null)
            {
                frmLicenseInfo frm = new frmLicenseInfo(_RenewLicense.LicenseID, false);
                frm.ShowDialog();
            }
            
        }
    }
}
