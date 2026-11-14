using DVLD_BusinessLogicLayer.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.InternationalDrivingLicense
{
    public partial class frmInternationalLicenseInfo : Form
    {
        private int _IDL_ID;
        public clsInternationalDrivingLicenseApplication InternationalDrivingLicense { get; private set; } = null;

        public frmInternationalLicenseInfo(int IDL_ID)
        {
            InitializeComponent();
            _IDL_ID = IDL_ID;
        }

        public frmInternationalLicenseInfo(clsInternationalDrivingLicenseApplication InternationalDrivingLicense)
        {
            InitializeComponent();
            this.InternationalDrivingLicense = InternationalDrivingLicense;
            _IDL_ID = InternationalDrivingLicense.IL_ID;
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            if (_IDL_ID > 0 && InternationalDrivingLicense is null)
                InternationalDrivingLicense = clsInternationalDrivingLicenseApplication.Find(_IDL_ID);

            ctrlDriverLicenseInternationalInfo1.LoadData(InternationalDrivingLicense);
        }
    }
}
