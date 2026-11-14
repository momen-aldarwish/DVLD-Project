using DVLD_BusinessLogicLayer.Tests;
using DVLD_Presentation.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Tests.SchedualTests.Vision
{
    public partial class frmEndTask : Form
    {
        private int _TestAppointmentID;

        public frmEndTask(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
        }

        private void frmEndTask_Load (object sender, EventArgs e)
        {
            int testID = clsTest.GetTestID(_TestAppointmentID);
            if (testID > 0)
                ctrlEndTask1.LoadTestData(testID);
            else
                ctrlEndTask1.LoadAppointmentData(_TestAppointmentID);
        }

        private void Btn_Close_Click (object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
