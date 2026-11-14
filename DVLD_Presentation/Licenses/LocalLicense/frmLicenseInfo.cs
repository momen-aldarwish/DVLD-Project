using DVLD_BusinessLogicLayer.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses
{
    public partial class frmLicenseInfo : Form
    {
        private int _ID;

        private clsLicense _License = null;
        private bool _LDLApplication = false;
        public frmLicenseInfo(int ID, bool LDLApplication = true)
        {
            InitializeComponent();
            _ID = ID;
            _LDLApplication = LDLApplication;
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            _License = (_LDLApplication) ? clsLicense.FindBy_LDL(_ID) : clsLicense.Find(_ID);

            if (_License is null)
            {
                MessageBox.Show("License is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlLicenseInfo1.LoadData(_License);
        }


    }
}
