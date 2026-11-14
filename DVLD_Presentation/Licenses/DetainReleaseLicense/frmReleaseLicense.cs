using DVLD_BusinessLogicLayer.Applications;
using DVLD_DataAccessLayer.Applications;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.ReleaseDetainLicense
{
    public partial class frmReleaseLicense : Form
    {
        public clsDetainedLicense Detain = null;
        private int D_ID;

        public frmReleaseLicense()
        {
            InitializeComponent();
            D_ID = -1;
        }

        public frmReleaseLicense(int D_ID)
        {
            InitializeComponent();
            this.D_ID = D_ID;
        }

        private void frmReleaseLicense_Shown(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.FocusOnFilter();
        }
     
        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            if (D_ID < 0)
                return;

            ctrlLicenseInfoWithFilter1.gbFilter = false;

            Detain = clsDetainedLicense.Find(D_ID);
            if (Detain is null)
            {
                MessageBox.Show("Something wrong happend in database!,\nDetain is not existed!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrlLicenseInfoWithFilter1.LoadData(Detain.License);
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (obj <= 0 || ctrlLicenseInfoWithFilter1.License is null)
            {
                LLB_ShowLicenseHistory.Enabled = false;
                LLB_ShowDetainedLicense.Enabled = false;
                return;
            }
            LLB_ShowLicenseHistory.Enabled = true;

            if (!ctrlLicenseInfoWithFilter1.License.IsDetained)
            {
                MessageBox.Show("This Liecnse is not detained!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Detain is null)
                Detain = clsDetainedLicense.FindByLicenseID(obj);

            if (Detain is null)
            {
                MessageBox.Show("Something wrong happend in database!,\nDetain is not existed!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Btn_Release.Enabled = false;
                return;
            }

            LLB_ShowDetainedLicense.Enabled = true;

            LB_DetainID.Text = Detain.DetainID.ToString();
            LB_DetainDate.Text = Detain.DetainDate.ToShortDateString();
            LB_CreatedBy.Text = Detain.CreatedByUser.UserName;
            LB_LiceseID.Text = Detain.LicenseID.ToString();
            LB_FineFees.Text = Detain.FineFees.ToString();

            if (Detain.IsReleased)
            {
                MessageBox.Show("This detained License is already released", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Btn_Release.Enabled = false;

                LB_ApplicationFees.Text = Detain.ReleaseApplication.PaidFees.ToString();
                LB_TotalFees.Text = (Detain.FineFees + Detain.ReleaseApplication.PaidFees).ToString();
                LB_ApplicationID.Text = Detain.ReleaseApplicationID.ToString();
            }
        }

        private void LLB_ShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ctrlLicenseInfoWithFilter1.License is null)
            {
                MessageBox.Show("License is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LLB_ShowLicenseHistory.Enabled = false;
                return;
            }
            frmHistoryLicenseInfo frm = new frmHistoryLicenseInfo(ctrlLicenseInfoWithFilter1.License.Driver.PersonID);
            frm.ShowDialog();
        }

        private void LLB_ShowDetainedLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Detain is null)
            {
                MessageBox.Show("Detained is not existed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LLB_ShowDetainedLicense.Enabled = false;
                return;
            }

            frmLicenseInfo frm = new frmLicenseInfo(ctrlLicenseInfoWithFilter1.License.LicenseID, false);
            frm.ShowDialog();
        }

        private void Btn_Release_Click(object sender, EventArgs e)
        {
            if (Detain is null)
            {
                MessageBox.Show("Detain is not existed to release!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Detain.ReleaseDetainedLicense(clsGlobal.UserID))
            {
                ctrlLicenseInfoWithFilter1.gbFilter = false;
                MessageBox.Show("Detained License is released successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LB_ApplicationFees.Text = Detain.ReleaseApplication.PaidFees.ToString();
                LB_TotalFees.Text = (Detain.FineFees + Detain.ReleaseApplication.PaidFees).ToString();
                LB_ApplicationID.Text = Detain.ReleaseApplicationID.ToString();

                Btn_Release.Enabled = false;
            }
            else
            {
                MessageBox.Show("Something wrong happend!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
