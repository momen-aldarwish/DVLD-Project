using DVLD_BusinessLogicLayer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Tests.SchedualTests.Practical
{
    public partial class frmEndPracticalTask : Form
    {
        private int _TestAppointmentID;

        public frmEndPracticalTask(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
        }

        private void frmEndPracticalTask_Load(object sender, EventArgs e)
        {
            int testID = clsTest.GetTestID(_TestAppointmentID);
            if (testID > 0)
                ctrlEndTask1.LoadTestData(testID);
            else
                ctrlEndTask1.LoadAppointmentData(_TestAppointmentID);

        }
    }
}
