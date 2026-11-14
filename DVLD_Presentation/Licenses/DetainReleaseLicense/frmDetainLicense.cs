using DVLD_BusinessLogicLayer.Applications;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Presentation.Applications.ReleaseDetainLicense
{
    public partial class frmDetainLicense : Form
    {
        clsDetainedLicense DetainedLicense = null;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Shown(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.FocusOnFilter();
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (obj <= 0 || ctrlLicenseInfoWithFilter1.License is null)
                return;

            LB_DetainDate.Text = DateTime.Today.ToShortDateString();
            LB_CreatedBy.Text = clsGlobal.User.UserName;
            LB_LiceseID.Text = obj.ToString();

            if (ctrlLicenseInfoWithFilter1.License.IsDetained)
            {
                DetainedLicense = clsDetainedLicense.FindByLicenseID(obj);
                Btn_Detain.Enabled = false;
                LB_DetainID.Text = DetainedLicense.DetainID.ToString();
                LB_DetainDate.Text = DetainedLicense.DetainDate.ToShortDateString();
                LB_LiceseID.Text = DetainedLicense.LicenseID.ToString();
                LB_CreatedBy.Text = DetainedLicense.CreatedByUserID.ToString();
                TB_FineFees.Text = DetainedLicense.FineFees.ToString();
                TB_FineFees.Enabled = false;
                LLB_ShowDetainedLicense.Enabled = true;

                MessageBox.Show("this license is already detained!", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Btn_Detain.Enabled = true;
                TB_FineFees.Enabled = true;
                TB_FineFees.Enabled = true;
                LLB_ShowDetainedLicense.Enabled = false;
                TB_FineFees.Focus();
            }
        }

        private void TB_FineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_FineFees.Text))
            {
                // يظهر الأيقونة بجانب التكست بوكس مع رسالة الخطأ عند الوقوف عليها
                errorProvider1.SetError(TB_FineFees, "This field is required!");
            }
            else
            {
                // لإزالة الخطأ فوراً عندما يتم إدخال نص
                errorProvider1.SetError(TB_FineFees, "");
            }
        }

        private void TB_FineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.PressOnlyNombers(e, true);
        }

        private void TB_FineFees_TextChanged(object sender, EventArgs e)
        {
            clsValidate.SanitizeNumericInput(sender, true);
        }

        private void Btn_Detain_Click(object sender, EventArgs e)
        {
            if (clsValidate.HasAnyErrors(this, errorProvider1) || !float.TryParse(TB_FineFees.Text.Trim(), out float Fees))
            {
                errorProvider1.SetError(TB_FineFees, "This is required!");
                MessageBox.Show("Fine Fees is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctrlLicenseInfoWithFilter1.License is null)
            {
                MessageBox.Show("License is not selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlLicenseInfoWithFilter1.gbFilter = false;
            clsDetainedLicense DetainedLicense = new clsDetainedLicense();
            switch (DetainedLicense.AddDetain(ctrlLicenseInfoWithFilter1.License.LicenseID, Fees, clsGlobal.UserID))
            {
                case clsDetainedLicense.enAddDetain.AddedSuccessfully:
                    LLB_ShowDetainedLicense.Enabled = true;
                    this.DetainedLicense = DetainedLicense;
                    LB_DetainID.Text = DetainedLicense.DetainID.ToString();
                    MessageBox.Show($"License ID {ctrlLicenseInfoWithFilter1.License.LicenseID} is Detained Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case clsDetainedLicense.enAddDetain.LicenseIsNotActive:
                    MessageBox.Show("License is not active to detain!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsDetainedLicense.enAddDetain.AlreadyDetained:
                    LLB_ShowDetainedLicense.Enabled = true;
                    this.DetainedLicense = clsDetainedLicense.FindByLicenseID(ctrlLicenseInfoWithFilter1.License.LicenseID);
                    LB_DetainID.Text = this.DetainedLicense.DetainID.ToString();
                    MessageBox.Show("It's already detained!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsDetainedLicense.enAddDetain.InvalidData:
                    MessageBox.Show("Invalid Data or messing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsDetainedLicense.enAddDetain.DBError:
                    MessageBox.Show($"License ID {ctrlLicenseInfoWithFilter1.License.LicenseID} is not Detained Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LLB_ShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ctrlLicenseInfoWithFilter1.License is null)
            {
                MessageBox.Show("There is not License to show up history!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmHistoryLicenseInfo frm = new frmHistoryLicenseInfo(ctrlLicenseInfoWithFilter1.License.Driver.PersonID);
            frm.ShowDialog();
        }

        private void LLB_ShowDetainedLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DetainedLicense is null)
            {
                MessageBox.Show("There is not Detained License to show up!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LLB_ShowDetainedLicense.Enabled = false;
                return;
            }

            frmLicenseInfo frm = new frmLicenseInfo(DetainedLicense.LicenseID, false);
            frm.ShowDialog();
        }

    }
}
