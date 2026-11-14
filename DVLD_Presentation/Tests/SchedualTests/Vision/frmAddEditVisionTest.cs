using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Tests;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.UserControls.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Tests.SchedualTests.Vision
{
    public partial class frmAddEditVisionTest : Form
    {
        public frmAddEditVisionTest(int ID, bool IsLDL_ID = true)
        {
            InitializeComponent();
            if (IsLDL_ID)
                ctrlAddEditTestAppointment1.LoadDataByLDL_ID(ID, clsTestType.enTestType.VisionTest);
            else
                ctrlAddEditTestAppointment1.LoadDataByAppointmentID(ID);
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
