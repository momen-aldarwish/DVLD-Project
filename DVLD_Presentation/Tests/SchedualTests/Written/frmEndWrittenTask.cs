using DVLD_BusinessLogicLayer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Tests.SchedualTests.Written
{
    public partial class frmEndWrittenTask : Form
    {
        private int _AppointmentID;
        
        public frmEndWrittenTask(int AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
        }

        private void frmEndWrittenTask_Load(object sender, EventArgs e)
        {
            int taskID = clsTest.GetTestID(_AppointmentID);

            if (taskID > 0)
                ctrlEndTask1.LoadTestData(taskID);
            else 
                ctrlEndTask1.LoadAppointmentData(_AppointmentID);
        }

        private void btn_CLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
