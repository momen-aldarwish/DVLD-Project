using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DVLD_BusinessLogicLayer.Licenses;
using DVLD_BusinessLogicLayer.Tests;

namespace DVLD_Presentation.Tests.SchedualTests.Written
{
    public partial class frmWritten : Form
    {
        private int _LDL_ID;

        public frmWritten(int LDL_ID)
        {
            InitializeComponent();
            _LDL_ID = LDL_ID;
        }

        private void frmWritten_Load(object sender, EventArgs e)
        {
            ctrlDrivingLiceseApplicationInfo1.LoadData(_LDL_ID, clsTestType.enTestType.WrittenTest); ;
        }

        private void ctrlDrivingLiceseApplicationInfo1_OnAddClick(int arg1, clsLicenseClass.enLicenseClass arg2)
        {
            frmAddEditWrittenAppointment frm = new frmAddEditWrittenAppointment(arg1, true);
            frm.ShowDialog();
        }

        private void ctrlDrivingLiceseApplicationInfo1_OnEditClick(int obj)
        {
            frmAddEditWrittenAppointment frm = new frmAddEditWrittenAppointment(obj, false);
            frm.ShowDialog();
        }

        private void ctrlDrivingLiceseApplicationInfo1_OnEndTaskClick(int obj)
        {
            frmEndWrittenTask frm = new frmEndWrittenTask(obj);
            frm.ShowDialog();
        }
    }
}
