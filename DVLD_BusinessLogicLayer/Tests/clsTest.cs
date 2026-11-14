using System;
using System.Collections.Generic;
using System.Text;
using DVLD_BusinessLogicLayer.Applications;
using DVLD_DataAccessLayer.Applications;
using DVLD_DataAccessLayer.Tests;

namespace DVLD_BusinessLogicLayer.Tests
{
    public class clsTest
    {
        private enum _enMode { add, update }
        _enMode _Mode;

        public int TestID { get; private set; }
        public int TestAppointmentID { get; set; }
        private clsTestAppointment _TestAppointment = null;
        public clsTestAppointment TestAppointment
        {
            get
            {
                if (TestAppointmentID <= 0)
                    return null;

                if (_TestAppointment is null || _TestAppointment.AppointmentID != TestAppointmentID)
                    _TestAppointment = clsTestAppointment.Find(TestAppointmentID);

                return _TestAppointment;
            }
        }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        private clsUser _User = null;
        public clsUser User
        {
            get
            {
                if (CreatedByUserID <= 0)
                    return null;

                if (_User is null || _User.UserID != CreatedByUserID)
                    _User = clsUser.Find(CreatedByUserID);

                return _User;
            }
        }

        private clsTest (int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = _enMode.update;
        }

        public clsTest ()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;
            this._Mode = _enMode.add;
        }

        public static clsTest Find (int TestID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = string.Empty;

            if (clsTestAccess.GetTest(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else
                return null;
        }

        public static clsTestType.enTestType GetLastPassedTestTypeByLDL_ID (int LDL_ID)
        {
            return (clsTestType.enTestType)clsTestAccess.GetLastTestTypePassed(LDL_ID);
        }

        public static bool GetLastTestTypeAndResult (int LDL_ID, ref clsTestType.enTestType TestTypeID, ref bool Result)
        {
            byte bTestTypeID = 0;

            if (clsTestAccess.GetLastTestTypeAndResultByLocalDrivingLicense(LDL_ID, ref bTestTypeID, ref Result))
            {
                TestTypeID = (clsTestType.enTestType)bTestTypeID;
                return true;
            }
            return false;
        }

        public enum enSaveResult { PrevTestNotPassed, DBError, TestNotExistedToEdit, TestTypePassed, TestAppointmentIsLockedToAddTestOnIt, TestAppointmentNotExisted, SavedSuccessfully}
        private enSaveResult _Add ()
        {
            if (TestAppointment is null)
                return enSaveResult.TestAppointmentNotExisted;

            if (TestAppointment.IsLocked)
                return enSaveResult.TestAppointmentIsLockedToAddTestOnIt;

            if (Convert.ToByte(GetLastPassedTestTypeByLDL_ID(TestAppointment.LDL_ID)) >= Convert.ToByte(TestAppointment.TestTypeID))
                return enSaveResult.TestTypePassed;

            if (Convert.ToByte(GetLastPassedTestTypeByLDL_ID(TestAppointment.LDL_ID)) != Convert.ToByte(TestAppointment.TestTypeID) - 1)
                return enSaveResult.PrevTestNotPassed;

            TestID = clsTestAccess.AddTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);

            return (TestID > 0) ? enSaveResult.SavedSuccessfully : enSaveResult.DBError;
            
        }

        private enSaveResult _Edit ()
        {
            if (TestID <= 0)
                return enSaveResult.TestNotExistedToEdit;

            return (clsTestAccess.Update(TestID, Notes)) ?
                enSaveResult.SavedSuccessfully : enSaveResult.DBError;
        }

        public enSaveResult Save ()
        {
            switch (_Mode)
            {
                case _enMode.add:
                    enSaveResult result = _Add();

                    if (result == enSaveResult.SavedSuccessfully)
                        _Mode = _enMode.update;

                    return result;

                case _enMode.update:

                    return _Edit();
            }
            return enSaveResult.DBError;
        }

        public static bool Delete (int TestID)
        {
            if (TestID <= 0)
                return false;

            return clsTestAccess.Delete(TestID);
        }
    
        public static short TotalTrial (int LDL_ID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAccess.TotalTrial(LDL_ID, (byte)TestTypeID);
        }
        
        public static int GetTestID (int TestAppointmentID)
        {
            return clsTestAccess.GetTestID(TestAppointmentID);
        }
    }
}
