using DVLD_BusinessLogicLayer.Licenses;
using DVLD_BusinessLogicLayer.Tests;
using DVLD_DataAccessLayer.Applications;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.XPath;

namespace DVLD_BusinessLogicLayer.Applications
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        private enum _enMode { New, Update }
        _enMode _Mode;

        public int LDL_ID { get; private set; }
        public int PassedTest { get; set; }
        public clsLicenseClass.enLicenseClass LicenseClassID { get; set; }
        private clsLicenseClass _LicenseClass = null;
        public clsLicenseClass LicenseClass 
        { 
            get
            {
                if (LicenseClassID <= 0)
                    return null;

                if (_LicenseClass == null || _LicenseClass.LC_ID != LicenseClassID)
                    _LicenseClass = clsLicenseClass.Find(LicenseClassID);

                return _LicenseClass;
            }
        }

        private clsLocalDrivingLicenseApplication (int LDL_ID, int PassedTest, clsLicenseClass.enLicenseClass LicenseClassID, int ApplicationID) 
            : base (ApplicationID)
        {
            this.LDL_ID = LDL_ID;
            this.PassedTest = PassedTest;
            this.LicenseClassID = LicenseClassID;
            _Mode = _enMode.Update;
        }
        
        public clsLocalDrivingLicenseApplication () 
            : base ()
        {
            this.LDL_ID = -1;
            PassedTest = 0;
            LicenseClassID = clsLicenseClass.enLicenseClass.Agricultural;

            _Mode = _enMode.New;
        }

        public static DataTable GetAll()
        {
            return clsLocalDrivingLicenseApplicationsAccess.GetAll();
        }

        public static clsLocalDrivingLicenseApplication Find (int LDL_ID)
        {
            if (LDL_ID <= 0)
                return null;

            int ApplicationID = 0, PassedTest = 0;
            byte LicenseClassID = 0;

            if (clsLocalDrivingLicenseApplicationsAccess.FindByLDL_ID(LDL_ID, ref ApplicationID, ref LicenseClassID, ref PassedTest))
            {
                return new clsLocalDrivingLicenseApplication(LDL_ID, PassedTest, (clsLicenseClass.enLicenseClass)LicenseClassID, ApplicationID);
            }
            else 
                return null;

        }
    
        public static bool IsLicenseClassAppliedOrCompleted (string NationalNo, clsLicenseClass.enLicenseClass LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationsAccess.DoesPersonActiveInLicense(NationalNo, (byte)LicenseClassID);
        }
        
        public clsTestAppointment.enAppointmentStatus AppointmentStatus(clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointment.DoesHaveAppointmnetActive(TestTypeID, LDL_ID, LicenseClassID);
        }

        public bool Save()
        {
            if (!base.Save())
                return false;

            switch (_Mode)
            {
                case _enMode.New:
                    LDL_ID = clsLocalDrivingLicenseApplicationsAccess.Add(ApplicationID, (byte)LicenseClassID);

                    return LDL_ID > 0;

                case _enMode.Update:
                    return clsLocalDrivingLicenseApplicationsAccess.Update(LDL_ID, (byte)LicenseClassID);

            }
            return false;
        }
        
        public enum enDeleteResult { LocalDrivingLicenseNotFound, StatusAcceptionFaild, DoesHaveAppointmentsActive, DeleteFailedFromDB, DeleteCompletedSuccessfully }
        public static enDeleteResult Delete (int LDL_ID)
        {
            clsLocalDrivingLicenseApplication localDrivingLicensce = clsLocalDrivingLicenseApplication.Find(LDL_ID);

            if (localDrivingLicensce == null)
                return enDeleteResult.LocalDrivingLicenseNotFound;

            if (localDrivingLicensce.Status != clsApplication.enStatus.Cancelled)
                return enDeleteResult.StatusAcceptionFaild;

            clsTestAppointment.enAppointmentStatus status = clsTestAppointment.DoesHaveAppointmnetActive(clsTestType.enTestType.VisionTest, LDL_ID, localDrivingLicensce.LicenseClassID);
            if (status == clsTestAppointment.enAppointmentStatus.HasActiveAppointment || status == clsTestAppointment.enAppointmentStatus.HasLockedAppointment)
                return enDeleteResult.DoesHaveAppointmentsActive;

            if (!clsLocalDrivingLicenseApplicationsAccess.Delete(LDL_ID))
                return enDeleteResult.DeleteFailedFromDB;

            if (clsApplication.Delete(localDrivingLicensce.ApplicationID))
                return enDeleteResult.DeleteCompletedSuccessfully;
            else
                return enDeleteResult.DeleteFailedFromDB;
        }
        
        public static enStatus GetStatus (int LDL_ID)
        {
            clsLocalDrivingLicenseApplication localDrivingLicnese = clsLocalDrivingLicenseApplication.Find(LDL_ID);

            if (localDrivingLicnese == null)
                return enStatus.NotFound;

            return localDrivingLicnese.Status;
        }

        public static bool Cancel(int LDL_ID)
        {
            clsLocalDrivingLicenseApplication localDrivingLicense = clsLocalDrivingLicenseApplication.Find(LDL_ID);
            return localDrivingLicense.Cancel();
        }
    
        public static bool IsExist (int LDL_ID)
        {
            if (LDL_ID <= 0)
                return false;

            return clsLocalDrivingLicenseApplicationsAccess.IsExist(LDL_ID);
        }


    }
}
