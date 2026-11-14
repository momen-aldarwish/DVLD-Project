using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Licenses;
using DVLD_DataAccessLayer.Tests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static DVLD_BusinessLogicLayer.Tests.clsTestType;

namespace DVLD_BusinessLogicLayer.Tests
{
    public class clsTestAppointment
    {
        public int AppointmentID { get; private set; }
        public clsTestType.enTestType TestTypeID { get; set; }
        private clsTestType _TestType = null;
        public clsTestType TestType
        {
            get
            {
                if (_TestType == null || _TestType.TestTypeID != TestTypeID)
                    _TestType = clsTestType.Find(TestTypeID);

                return _TestType;
            }
        }
        public int LDL_ID { get; set; }
        private clsLocalDrivingLicenseApplication _LDL = null;
        public clsLocalDrivingLicenseApplication LocalDrivingLicnese
        {
            get
            {
                if (LDL_ID <= 0)
                    return null;

                if (_LDL == null || _LDL.LDL_ID != LDL_ID)
                    _LDL = clsLocalDrivingLicenseApplication.Find(LDL_ID);

                return _LDL;
            }
        }
        public clsApplication Application
        {
            get
            {
                return LocalDrivingLicnese;
            }
        }
        public clsPerson Person
        {
            get
            {
                return LocalDrivingLicnese.ApplicantPerson;
            }
        }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        private clsUser _User = null;
        public clsUser User
        {
            get
            {
                if (CreatedByUserID <= 0)
                    return null;

                if (_User == null || _User.UserID != CreatedByUserID)
                    _User = clsUser.Find(CreatedByUserID);

                return _User;
            }
        }
        public bool IsLocked;
        public int ReTakeApplicationID;

        private enum _enMode { add, edit }
        private _enMode _Mode;

        public clsTestAppointment()
        {
            AppointmentID = -1;
            TestTypeID = clsTestType.enTestType.VisionTest;
            LDL_ID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0.0f;
            CreatedByUserID = -1;
            IsLocked = false;
            ReTakeApplicationID = -1;
            _Mode = _enMode.add;
        }

        private clsTestAppointment(int AppointmentID, clsTestType.enTestType TestTypeID, int LDL_ID, DateTime AppointmentDate,
            float PaidFees, int CreatedByUserID, bool IsLocked, int ReTakeApplicationID)
        {
            this.AppointmentID = AppointmentID;
            this.TestTypeID = TestTypeID;
            this.LDL_ID = LDL_ID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.ReTakeApplicationID = ReTakeApplicationID;
            this._Mode = _enMode.edit;
        }

        public static clsTestAppointment Find(int AppointmentID)
        {
            int LDL_ID = -1, CreatedByUserID = -1;
            float PaidFees = 0.0f;
            bool IsLocked = false;
            DateTime AppointmentDate = DateTime.Now;
            byte TestTypeID = 1;
            int ReTakeApplicationID = -1;

            bool IsFound = clsTestAppointmentAccess.Find(AppointmentID, ref TestTypeID, ref LDL_ID, ref AppointmentDate,
            ref PaidFees, ref CreatedByUserID, ref IsLocked, ref ReTakeApplicationID);

            if (IsFound)
            {
                return new clsTestAppointment(AppointmentID, (clsTestType.enTestType)TestTypeID, LDL_ID,
                    AppointmentDate, PaidFees, CreatedByUserID, IsLocked, ReTakeApplicationID);
            }
            else
                return null;
        }

        public enum enAddTestAppointment
        {
            TestTypeIsPassed = 4,
            RetakeTest = 5,
            NewTest = 6,
            PrevTestIsNotPassed = 7,
            HasActiveAppointment = 8,
            LocalDrivingLicenseNotExisted = 9
        }

        public enAddTestAppointment ValidateAddTestAppointment()
        {
            return ValidateAddTestAppointment(LDL_ID, TestTypeID);
        }


        public static enAddTestAppointment ValidateAddTestAppointment(int LDL_ID, clsTestType.enTestType CurrentTestTypeID)
        {
            if (!clsLocalDrivingLicenseApplication.IsExist(LDL_ID))
                return enAddTestAppointment.LocalDrivingLicenseNotExisted;

            clsTestType.enTestType LastTestType = clsTestType.enTestType.None;
            bool result = false;

            if (!clsTest.GetLastTestTypeAndResult(LDL_ID, ref LastTestType, ref result))
            {
                return (CurrentTestTypeID == enTestType.VisionTest) ? enAddTestAppointment.NewTest : 
                    enAddTestAppointment.PrevTestIsNotPassed;
            }

            if (CurrentTestTypeID == LastTestType)
                return (result) ? enAddTestAppointment.TestTypeIsPassed : enAddTestAppointment.RetakeTest;

            if (CurrentTestTypeID < LastTestType)
                return enAddTestAppointment.TestTypeIsPassed;

            if (((int)CurrentTestTypeID - 1) > (int)LastTestType || !result)
                return enAddTestAppointment.PrevTestIsNotPassed;

            return (result) ? enAddTestAppointment.NewTest : enAddTestAppointment.RetakeTest;
        }

        private enSaveResult _Edit()
        {
            if (IsLocked)
                return enSaveResult.AppointmentLocked;

            if (AppointmentDate < DateTime.Today)
                return enSaveResult.DateNotValid;

            return (clsTestAppointmentAccess.Update(AppointmentID, AppointmentDate, PaidFees, IsLocked)) ?
                enSaveResult.SaveSuccessfullty : enSaveResult.DBError;
        }

        private enSaveResult _Add()
        {
            if (AppointmentDate < DateTime.Today)
                return enSaveResult.DateNotValid;

            if (clsTestAppointment.DoesHaveAppointmnetActive(TestTypeID, LDL_ID, LocalDrivingLicnese.LicenseClassID) == enAppointmentStatus.HasActiveAppointment)
                return enSaveResult.HasActiveAppointment;

            int applicationID = -1;
            enAddTestAppointment validateResult = ValidateAddTestAppointment();
            switch (validateResult)
            {
                case enAddTestAppointment.RetakeTest:
                    applicationID = clsApplication.AddRetakeApplication(LocalDrivingLicnese.ApplicantPersonID, CreatedByUserID);
                    if (applicationID <= 0)
                        return enSaveResult.NewApplicationInReTakeTestNotSaved;
                    break;
                
                case enAddTestAppointment.NewTest:
                    applicationID = -1;
                    break;

                default:
                    return (enSaveResult)Convert.ToByte(validateResult);

            }

            AppointmentID = clsTestAppointmentAccess.Add((byte)TestTypeID, LDL_ID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, applicationID);
            return (AppointmentID > 0) ? enSaveResult.SaveSuccessfullty : enSaveResult.DBError;
        }

        public enum enSaveResult { SaveSuccessfullty = 0, DBError = 1, DateNotValid = 2, AppointmentLocked = 3,
        TestTypeIsPassed = 4, RetakeTest = 5, NewTest = 6, PrevTestIsNotPassed = 7, HasActiveAppointment = 8, LocalDrivingLicenseNotExisted = 9, NewApplicationInReTakeTestNotSaved = 10 };
        public enSaveResult Save()
        {
            switch (_Mode)
            {

                case _enMode.add:
                    enSaveResult result = _Add();
                    if (result == enSaveResult.SaveSuccessfullty)
                    {
                        _Mode = _enMode.edit;
                        return enSaveResult.SaveSuccessfullty;
                    }
                    return result;

                case _enMode.edit:
                    return _Edit();
            }
            return enSaveResult.DBError;
        }

        public static DataTable GetAllAppointments ()
        {
            return clsTestAppointmentAccess.GetAllAppointments();
        }
       
        public static DataTable GetAppointmentsByLDL_ID (int LDL_ID)
        {
            return clsTestAppointmentAccess.GetAppointmentTests(LDL_ID);
        }

        public static DataTable GetAppointmentsByTestType_LDL_IDLicenseClass(clsTestType.enTestType TestTypeID, int LDL_ID, clsLicenseClass.enLicenseClass LicenseClassID)
        {
            DataTable dt = GetAppointmentsByLDL_ID(LDL_ID);
            
            clsTestType testtype = clsTestType.Find(TestTypeID);
            clsLicenseClass licenseclass = clsLicenseClass.Find(LicenseClassID);

            if (testtype is null || licenseclass is null || dt.Rows.Count == 0)
                return new DataTable();


            DataRow[] RowsToDelete = dt.Select($"TestTypeTitle <> '{testtype.TestTypeTitle}' or ClassName <> '{licenseclass.ClassName}'");

            foreach (DataRow Row in RowsToDelete)
            {
                dt.Rows.Remove(Row);
            }

            return dt;
        }

        public enum enAppointmentStatus { DoesntHaveAppointments, HasActiveAppointment, HasLockedAppointment, ErrorColumnNotExisted }
        public static enAppointmentStatus DoesHaveAppointmnetActive (clsTestType.enTestType TestType, int LDL_ID, clsLicenseClass.enLicenseClass LicenseClassID)
        {
            DataTable dt = GetAppointmentsByTestType_LDL_IDLicenseClass(TestType, LDL_ID, LicenseClassID);

            if (!dt.Columns.Contains("TestAppointmentID"))
                return enAppointmentStatus.ErrorColumnNotExisted;
            
            if (dt.Rows.Count == 0)
                return enAppointmentStatus.DoesntHaveAppointments;


            int TestAppointmentID = -1;

            foreach (DataRow Row in dt.Rows)
            {
                TestAppointmentID = (int)Row["TestAppointmentID"];
                if (!Is_Locked (TestAppointmentID))
                {
                    return enAppointmentStatus.HasActiveAppointment;
                }
            }

            return enAppointmentStatus.HasLockedAppointment;
        }

        public static bool Is_Locked(int TestAppointmentID)
        {
            return clsTestAppointmentAccess.IsPersonLocked(TestAppointmentID);
        }

        public static bool DeleteAppointment (int AppointmentID)
        {
            return clsTestAppointmentAccess.DeleteAppointment(AppointmentID);
        }

        public enSaveResult Lock ()
        {
            return (clsTestAppointmentAccess.Update(AppointmentID, AppointmentDate, PaidFees, true)) ?
                enSaveResult.SaveSuccessfullty : enSaveResult.DBError;
        }
    
        public static enTestType GetLastActiveAppointment (int LDL_ID)
        {
            return (enTestType)clsTestAppointmentAccess.GetLastActiveAppointment(LDL_ID);
        }


    }
}
