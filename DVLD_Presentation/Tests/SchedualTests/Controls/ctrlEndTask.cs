using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Tests;
using DVLD_Presentation.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls.Schedual_Test
{
    public partial class ctrlEndTask : UserControl
    {
        private clsTestAppointment _Appointment = null;
        private clsTest _Test = null;
        public ctrlEndTask()
        {
            InitializeComponent();
            RB_Fail.Checked = true;
            Dtp_Date.Enabled = false;
        }

        public void LoadAppointmentData(int AppointmentID)
        {
            //Add Mode

            _Appointment = clsTestAppointment.Find(AppointmentID);
            if (_Appointment is null)
            {
                Btn_Save.Enabled = false;
                MessageBox.Show($"Appointment ID: {AppointmentID} is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadDataToScreen();
            

            _Test = new clsTest();
            _Test.TestAppointmentID = AppointmentID;
           
        }

        public void LoadTestData(int TestID)
        {
            //Edit Mode
            _Test = clsTest.Find(TestID);
            if (_Test is null)
            {
                Btn_Save.Enabled = false;
                MessageBox.Show($"Test ID {TestID} is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RB_Fail.Enabled = false;
            RB_Pass.Enabled = false;            

            _Appointment = _Test.TestAppointment;
            if (_Appointment is null)
            {
                MessageBox.Show("Appointment is not existed!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadDataToScreen();

            if (_Test.TestResult)
                RB_Pass.Checked = true;
            else
                RB_Fail.Checked = true;

            Tb_Notes.Text = _Test.Notes;
        }

        private void _LoadDataToScreen()
        {
            LB_LDAppID.Text = _Appointment.LDL_ID.ToString();
            LB_DClass.Text = _Appointment.LocalDrivingLicnese.LicenseClass.ClassName;
            LB_Name.Text = _Appointment.LocalDrivingLicnese.ApplicantPerson.FullName;
            LB_Fees.Text = _Appointment.TestType.TestTypeFees.ToString();
            LB_Trial.Text = clsTest.TotalTrial(_Appointment.LDL_ID, _Appointment.TestTypeID).ToString();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            _Test.TestResult = RB_Pass.Checked;
            _Test.Notes = Tb_Notes.Text;
            _Test.TestAppointmentID = _Appointment.AppointmentID;
            _Test.CreatedByUserID = clsGlobal.UserID;

            string passedOrFailed = _Test.TestResult ? "Passed" : "Failed";
            DialogResult result = MessageBox.Show($"Are you sure that this test is {passedOrFailed}?, you can't edit it.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            switch (_Test.Save())
            {
                case clsTest.enSaveResult.SavedSuccessfully:
                    MessageBox.Show("Ended Task Succsufully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RB_Fail.Enabled = false;
                    RB_Pass.Enabled = false;
                    break;

                case clsTest.enSaveResult.TestAppointmentIsLockedToAddTestOnIt:
                    MessageBox.Show("Test Appointment is already locked cant add another test on it!,\nTask is not ended.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsTest.enSaveResult.TestAppointmentNotExisted:
                    MessageBox.Show("Test appointment is not existed to end its task!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsTest.enSaveResult.DBError:
                    MessageBox.Show("Something wrong happend in data base!", "Data Base Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsTest.enSaveResult.TestNotExistedToEdit:
                    MessageBox.Show("There is no Test to edit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsTest.enSaveResult.PrevTestNotPassed:
                    MessageBox.Show("Something wrong happend!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
        }

    }
}
