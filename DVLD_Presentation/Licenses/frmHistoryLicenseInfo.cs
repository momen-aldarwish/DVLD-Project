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

namespace DVLD_Presentation.Licenses
{
    public partial class frmHistoryLicenseInfo : Form
    {
        private int _PersonID;
        private string _NationalNo;

        public frmHistoryLicenseInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _NationalNo = string.Empty;
        }

        public frmHistoryLicenseInfo(string NationalNo)
        {
            InitializeComponent();
            _NationalNo = NationalNo;
            _PersonID = -1;
        }

        private void frmHistoryLicenseInfo_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_NationalNo))
                ctrlFindControl1.LoadData(_PersonID);
            else
                ctrlFindControl1.LoadData(_NationalNo);

            if (ctrlFindControl1.Person is null)
            {
                MessageBox.Show($"Local Driving License ID {_PersonID} is not existed!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlDriverLicenses1.LoadData(ctrlFindControl1.Person);
        }

        private void ctrlFindControl1_OnPersonSelected(int obj)
        {
            if (obj == -1)
            {
                ctrlFindControl1.EnabledFilter = true;
                ctrlDriverLicenses1.Clear();
            }
            else
            {
                ctrlFindControl1.EnabledFilter = false;
                ctrlDriverLicenses1.LoadData(obj);
            }
        }
    }
}
