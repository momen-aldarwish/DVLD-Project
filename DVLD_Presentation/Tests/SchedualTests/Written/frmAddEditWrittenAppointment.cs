using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Tests;
namespace DVLD_Presentation.Tests.SchedualTests.Written
{
    public partial class frmAddEditWrittenAppointment : Form
    {
        private int _LDL_ID;
        private int _AppointmentID;
        private bool _AddAppointmentMode;

        public frmAddEditWrittenAppointment(int ID, bool AddAppointment = true)
        {
            InitializeComponent();

            if (AddAppointment)
            {
                _LDL_ID = ID;
            }
            else
            {
                _AppointmentID = ID;
            }

            _AddAppointmentMode = AddAppointment; 
        }
        
        private void frmAddEditWrittenAppointment_Load(object sender, EventArgs e)
        {
            if (_AddAppointmentMode)
                ctrlAddEditTestAppointment1.LoadDataByLDL_ID(_LDL_ID, clsTestType.enTestType.WrittenTest);
            else
                ctrlAddEditTestAppointment1.LoadDataByAppointmentID(_AppointmentID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
