using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.LocalDrivingLicensce
{
    public partial class frmIssueLicense : Form
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicense = null;
        private int _LDL_ID = 0;

        private clsLicense _License = null;

        public frmIssueLicense(int LDL_ID)
        {
            InitializeComponent();
            _LDL_ID = LDL_ID;
        }

        private void frmIssueLicense_Load(object sender, EventArgs e)
        {
            _LocalDrivingLicense = clsLocalDrivingLicenseApplication.Find(_LDL_ID);

            if (_LocalDrivingLicense is null)
            {
                MessageBox.Show("Local Driving License is not existed to issue!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _License = clsLicense.FindByApplicationID(_LocalDrivingLicense.ApplicationID);
            if (_License is not null)
            {
                TB_Notes.Text = _License.Notes;
            }

            ctrlDrivingLicenseInfo1.LoadData(_LocalDrivingLicense);
        }
    
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (_LocalDrivingLicense is null)
                return;

            if (_License is null)
            {
                _License = new clsLicense(_LocalDrivingLicense);
            }

            _License.Notes = TB_Notes.Text;
            _License.IssueReason = clsLicense.enIssueReason.FirstTime;

            if (_License.Save())
            {
                MessageBox.Show("It's Saved Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("It's not saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
