using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Tests;

namespace DVLD_Presentation.Tests.SchedualTests.Practical
{
    public partial class frmAddEditPracticalAppointment : Form
    {
        private int _LDL_ID;
        private int _AppointmentID;
        private bool _AddMode;

        public frmAddEditPracticalAppointment(int ID, bool AddMode = true)
        {
            InitializeComponent();

            if (AddMode)
                _LDL_ID = ID;
            else
                _AppointmentID = ID;

            _AddMode = AddMode;
        }

        private void frmAddEditPracticalAppointment_Load(object sender, EventArgs e)
        {
            if (_AddMode)
                ctrlAddEditTestAppointment1.LoadDataByLDL_ID(_LDL_ID, clsTestType.enTestType.PracticalTest);
            else
                ctrlAddEditTestAppointment1.LoadDataByAppointmentID(_AppointmentID);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    
    }
}
