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
using static DVLD_BusinessLogicLayer.Applications.clsApplicationType;

namespace DVLD_Presentation.UserControls.Applications
{
    public partial class ctrlAddEditTestAppointment : UserControl
    {
        public enum enMode { add, edit, readOnly };
        public enMode Mode { get; private set; }

        public enum enAddMode { addNew, addRetake };
        public enAddMode AddMode { get; private set; }

        public clsLocalDrivingLicenseApplication LocalDrivingLicense { get; private set; }
        public clsTestAppointment TestAppointment { get; private set; }
        public clsTestType TestType
        {
            get
            {
                return clsTestType.Find(TestTypeID);
            }
        }
        public clsTestType.enTestType TestTypeID;

        public ctrlAddEditTestAppointment()
        {
            InitializeComponent();
            LocalDrivingLicense = new clsLocalDrivingLicenseApplication();
            TestAppointment = new clsTestAppointment();

            Mode = enMode.add;
            AddMode = enAddMode.addNew;

            Dtp_Date.MinDate = DateTime.Today;
        }

        public void LoadDataByLDL_ID(int LDL_ID, clsTestType.enTestType TestTypeID)
        {
            LocalDrivingLicense = clsLocalDrivingLicenseApplication.Find(LDL_ID);
            if (LocalDrivingLicense is null)
            {
                MessageBox.Show("Local Driving License is not found from DB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TestAppointment = new clsTestAppointment();

            this.TestTypeID = TestTypeID;
            Mode = enMode.add;
            
            AddMode = (clsTestAppointment.ValidateAddTestAppointment(LDL_ID, TestTypeID) == clsTestAppointment.enAddTestAppointment.RetakeTest) ? enAddMode.addRetake : enAddMode.addNew;
            _LoadDataToScreen();
        }

        public void LoadDataByAppointmentID(int AppointmentID)
        {
            TestAppointment = clsTestAppointment.Find(AppointmentID);
            if (TestAppointment is null)
            {
                MessageBox.Show($"AppointmentID {AppointmentID} is not existed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LocalDrivingLicense = clsLocalDrivingLicenseApplication.Find(TestAppointment.LDL_ID);
            if (LocalDrivingLicense is null)
            {
                MessageBox.Show($"LDL_ID is not found in Appointment {AppointmentID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.TestTypeID = TestAppointment.TestTypeID;
            
            Mode = (TestAppointment.IsLocked) ? enMode.readOnly : enMode.edit;
            AddMode = (TestAppointment.ReTakeApplicationID == -1) ? enAddMode.addNew : enAddMode.addRetake;

            _LoadDataToScreen();
        }

        private void _LoadDataToScreen()
        {
            switch (Mode)
            {
                case enMode.add:
                    Dtp_Date.MinDate = DateTime.Today;
                    Dtp_Date.Value = DateTime.Today;

                    LB_IsLocked.Visible = false;
                    Dtp_Date.Enabled = true;
                    break;

                case enMode.edit:
                    Dtp_Date.MinDate = (TestAppointment.AppointmentDate < DateTime.Today) ?
                    TestAppointment.AppointmentDate : DateTime.Today;

                    LB_IsLocked.Visible = false;
                    Dtp_Date.Enabled = true;
                    Dtp_Date.Value = TestAppointment.AppointmentDate;
                    break;

                case enMode.readOnly:
                default:
                    LB_IsLocked.Visible = true;
                    Dtp_Date.Enabled = false;
                    Btn_Save.Enabled = false;
                    break;

            }

            LB_Title.Text = (AddMode == enAddMode.addNew) ?
               "Schedual New Test" : "Schedual Retake Test";

            if (AddMode == enAddMode.addRetake)
            {
                float RetakeFees = clsApplicationType.Find(clsApplicationType.enApplicationType.ReTakeTest).ApplicationTypeFees;
                GB_RetakeTestInfo.Enabled = true;
                LB_RTestAppID.Text = TestAppointment.AppointmentID.ToString();
                LB_RAppFees.Text = RetakeFees.ToString();
                LB_TotalFees.Text = Convert.ToString(TestType.TestTypeFees + RetakeFees);
            }
            else 
                GB_RetakeTestInfo.Enabled = false;

            LB_LDAppID.Text = LocalDrivingLicense.LDL_ID.ToString();
            LB_DClass.Text = LocalDrivingLicense.LicenseClass.ClassName;
            LB_Name.Text = LocalDrivingLicense.ApplicantPerson.FullName;
            LB_Fees.Text = TestType.TestTypeFees.ToString();
            LB_Trial.Text = clsTest.TotalTrial(LocalDrivingLicense.LDL_ID, TestType.TestTypeID).ToString();
        }

        private void _LoadDataToAppointment()
        {
            TestAppointment.TestTypeID = TestTypeID;
            TestAppointment.LDL_ID = LocalDrivingLicense.LDL_ID;
            TestAppointment.PaidFees = TestType.TestTypeFees;
            TestAppointment.CreatedByUserID = clsGlobal.UserID;
            TestAppointment.IsLocked = false;
            TestAppointment.AppointmentDate = Dtp_Date.Value;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (TestAppointment is null)
            {
                MessageBox.Show("Appointment is not valid!.", "Appointment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadDataToAppointment();

            switch (TestAppointment.Save())
            {
                case clsTestAppointment.enSaveResult.SaveSuccessfullty:
                    MessageBox.Show("Appointment Saved successfully.", "Appointment saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mode = enMode.edit;
                    _LoadDataToScreen();
                    break;

                case clsTestAppointment.enSaveResult.DateNotValid:
                    MessageBox.Show($"Date time is invalid!,today is: {DateTime.Now.ToShortDateString()}",
                        "Date Time Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsTestAppointment.enSaveResult.AppointmentLocked:
                    MessageBox.Show("Appointment is locked!.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case clsTestAppointment.enSaveResult.HasActiveAppointment:
                    MessageBox.Show("It already has active appointment!", "Can not add new appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsTestAppointment.enSaveResult.LocalDrivingLicenseNotExisted:
                    MessageBox.Show("There is no local driving license to add appointment on it!", "Can not add new appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsTestAppointment.enSaveResult.PrevTestIsNotPassed:
                    MessageBox.Show("Previous Test is not passed!, Pass it first.", "Can not add new appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsTestAppointment.enSaveResult.TestTypeIsPassed:
                    MessageBox.Show("this test is already passed!", "Can not add new appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsTestAppointment.enSaveResult.DBError:
                default:
                    MessageBox.Show("Something wrong happend from database, Try again", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

    }
}
