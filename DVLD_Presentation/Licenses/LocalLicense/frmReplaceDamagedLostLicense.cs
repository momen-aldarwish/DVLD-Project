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
    public partial class frmReplaceDamagedLostLicense : Form
    {
        clsLicense NewLicense = null;

        clsApplicationType _ReplacementForDamaged = null;
        clsApplicationType ReplacementForDamaged
        {
            get
            {
                if (_ReplacementForDamaged is null)
                    _ReplacementForDamaged = clsApplicationType.Find(clsApplicationType.enApplicationType.ReplacementDamaged);

                return _ReplacementForDamaged; 
            }
        }

        clsApplicationType _ReplacementForLost = null;
        clsApplicationType ReplacementForLost
        {
            get
            {
                if (_ReplacementForLost is null)
                    _ReplacementForLost = clsApplicationType.Find(clsApplicationType.enApplicationType.ReplacementLost);

                return _ReplacementForLost;
            }
        }

        public frmReplaceDamagedLostLicense()
        {
            InitializeComponent();
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (obj <= 0 || ctrlLicenseInfoWithFilter1.License is null)
                return;


            LB_ApplicationDate.Text = (DateTime.Today).ToShortDateString();
            LB_ApplicationFees.Text = (RB_DamagedLicense.Checked) ? ReplacementForDamaged.ApplicationTypeFees.ToString() :
                ReplacementForLost.ApplicationTypeFees.ToString();
            LB_OldLicenseID.Text = ctrlLicenseInfoWithFilter1.License.LicenseID.ToString();
            LB_CreatedBy.Text = clsGlobal.User.UserName;
            TB_Notes.Text = ctrlLicenseInfoWithFilter1.License.Notes;

            if (!ctrlLicenseInfoWithFilter1.License.IsLicenseActive())
            {
                MessageBox.Show("This License is not Active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Btn_IssueReplacement.Enabled = false;
                GB_ReplaceFor.Enabled = false;
            }
            else
            {
                Btn_IssueReplacement.Enabled = true;
                GB_ReplaceFor.Enabled = true;
            }
        }

        private void Btn_IssueReplacement_Click(object sender, EventArgs e)
        {
            clsLicense.enReplacementResult result = clsLicense.enReplacementResult.DBError;
            string replacementReasonString = string.Empty;

            if (RB_DamagedLicense.Checked)
            {
                NewLicense = ctrlLicenseInfoWithFilter1.License.ReplacementForDamaged(clsGlobal.UserID, TB_Notes.Text.Trim(), ref result);
                replacementReasonString = "Damaged";
            }
            else
            {
                NewLicense = ctrlLicenseInfoWithFilter1.License.ReplacementForLost(clsGlobal.UserID, TB_Notes.Text.Trim(), ref result);
                replacementReasonString = "Lost";
            }


            switch (result)
            {
                case clsLicense.enReplacementResult.SavedSuccessfully:
                    MessageBox.Show($"replacement {replacementReasonString} License is added successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GB_ReplaceFor.Enabled = false;
                    ctrlLicenseInfoWithFilter1.gbFilter = false;
                    LLB_ShowNewLicenseInfo.Enabled = true;

                    LB_LRApplicationID.Text = NewLicense.ApplicationID.ToString();
                    LB_ReplacementLicenseID.Text = NewLicense.LicenseID.ToString();
                    break;

                case clsLicense.enReplacementResult.applicationIsNull:
                    MessageBox.Show("Application is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsLicense.enReplacementResult.DriverIsNull:
                    MessageBox.Show("Driver is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsLicense.enReplacementResult.ApplicationTypeIsNull:
                    MessageBox.Show("Application Type is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsLicense.enReplacementResult.ApplicationNotCreated:
                    MessageBox.Show("Application is not created!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsLicense.enReplacementResult.NotActive:
                    MessageBox.Show("This License is not Active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case clsLicense.enReplacementResult.OldLicenseDeactivateFailed:
                    MessageBox.Show("Old License Deactivate Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsLicense.enReplacementResult.DBError:
                    MessageBox.Show("Some thing wrong happend in data base!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }


        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LLB_ShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NewLicense is null)
            {
                MessageBox.Show("New License is null!, can't show it's info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LLB_ShowNewLicenseInfo.Enabled = false;
                return;
            }

            frmLicenseInfo frm = new frmLicenseInfo(NewLicense.LicenseID, false);
            frm.ShowDialog();
        }

        private void LLB_ShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ctrlLicenseInfoWithFilter1.License is null)
            {
                MessageBox.Show("License is null, Search on existed License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmHistoryLicenseInfo frm = new frmHistoryLicenseInfo(ctrlLicenseInfoWithFilter1.License.Driver.PersonID);
            frm.ShowDialog();
        }

        private void RB_DamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            LB_ApplicationFees.Text = ReplacementForDamaged.ApplicationTypeFees.ToString();
        }

        private void RB_LostLicense_CheckedChanged(object sender, EventArgs e)
        {
            LB_ApplicationFees.Text = ReplacementForLost.ApplicationTypeFees.ToString();
        }
    }
}
