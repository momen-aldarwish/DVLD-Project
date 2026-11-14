using DVLD_BusinessLogicLayer.Licenses;
using DVLD_BusinessLogicLayer.Tests;
using DVLD_Presentation.Tests.SchedualTests.Vision;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.SchedualTests
{
    public partial class frmVision : Form
    {
        private int _LDL_ID;

        public frmVision(int LDL_ID)
        {
            InitializeComponent();
            _LDL_ID = LDL_ID;
        }

        private void frmVision_Load(object sender, EventArgs e)
        {
            uctrlDrivingLiceseApplicationInfo1.LoadData(_LDL_ID, clsTestType.enTestType.VisionTest);
        }

        private void uctrlDrivingLiceseApplicationInfo1_OnAddClick(int arg1, clsLicenseClass.enLicenseClass arg2)
        {
            frmAddEditVisionTest frm = new frmAddEditVisionTest(arg1, true);
            frm.ShowDialog();
        }

        private void uctrlDrivingLiceseApplicationInfo1_OnEditClick(int obj)
        {
            frmAddEditVisionTest frm = new frmAddEditVisionTest(obj, false);
            frm.ShowDialog();
        }

        private void uctrlDrivingLiceseApplicationInfo1_OnEndTaskClick(int obj)
        {
            frmEndTask frm = new frmEndTask(obj);
            frm.ShowDialog();
        }
    }
}
