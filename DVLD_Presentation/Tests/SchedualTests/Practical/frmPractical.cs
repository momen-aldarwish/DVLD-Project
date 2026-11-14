using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Licenses;
using DVLD_BusinessLogicLayer.Tests;

namespace DVLD_Presentation.Tests.SchedualTests.Practical
{
    public partial class frmPractical : Form
    {
        private int _LDL_ID;

        public frmPractical(int LDL_ID)
        {
            InitializeComponent();
            _LDL_ID = LDL_ID;
        }
       
        private void frmPractical_Load(object sender, EventArgs e)
        {
            ctrlDrivingLiceseApplicationInfo1.LoadData(_LDL_ID, clsTestType.enTestType.PracticalTest);
        }

        private void ctrlDrivingLiceseApplicationInfo1_OnAddClick(int arg1, clsLicenseClass.enLicenseClass arg2)
        {
            frmAddEditPracticalAppointment frm = new frmAddEditPracticalAppointment(arg1, true);
            frm.ShowDialog();
        }

        private void ctrlDrivingLiceseApplicationInfo1_OnEditClick(int obj)
        {
            frmAddEditPracticalAppointment frm = new frmAddEditPracticalAppointment(obj, false);
            frm.ShowDialog();
        }

        private void ctrlDrivingLiceseApplicationInfo1_OnEndTaskClick(int obj)
        {
            frmEndPracticalTask frm = new frmEndPracticalTask(obj);
            frm.ShowDialog();
        }

    }
}
