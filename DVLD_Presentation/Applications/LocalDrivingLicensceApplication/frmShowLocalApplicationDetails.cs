using DVLD_BusinessLogicLayer.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.LocalDrivingLicensce
{
    public partial class frmShowLocalApplicationDetails : Form
    {
        private int _LDL_ID;
        public frmShowLocalApplicationDetails(int LDL_ID)
        {
            InitializeComponent();
            _LDL_ID = LDL_ID;
        }

        private void frmShowLocalApplicationDetails_Load(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicense = clsLocalDrivingLicenseApplication.Find(_LDL_ID);
            if (localDrivingLicense is null)
            {
                MessageBox.Show("Local Driving License is not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlDrivingLicenseInfo1.LoadData(localDrivingLicense);
        }

        private void Btn_CLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    
    }
}
