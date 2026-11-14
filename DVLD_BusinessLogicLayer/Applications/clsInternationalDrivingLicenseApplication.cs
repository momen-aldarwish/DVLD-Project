using DVLD_BusinessLogicLayer.Licenses;
using DVLD_DataAccessLayer.Applications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DVLD_BusinessLogicLayer.Applications
{
    public class clsInternationalDrivingLicenseApplication : clsApplication
    {
        private enum _enMode { add, update }
        _enMode _Mode;

        public int IL_ID { get; private set; }
        public int LocalLicense_ID { get; private set; }
        public int DriverID { get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool IsActive { get; private set; }

        private clsLicense _LocalLicense = null;
        public clsLicense LocalLicense
        {
            get
            {
                if (LocalLicense_ID <= 0)
                    return null;

                if (_LocalLicense is null)
                    _LocalLicense = clsLicense.Find(LocalLicense_ID);

                return _LocalLicense;
            }
        }

        private clsDrivers _Driver = null;
        public clsDrivers Driver
        {
            get
            {
                if (DriverID <= 0)
                    return null;

                if (_Driver is null)
                    _Driver = clsDrivers.Find(DriverID);

                return _Driver;
            }
        }


        private clsInternationalDrivingLicenseApplication ( int IL_ID, int LocalLicense_ID, int ApplicationID, int DriverID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID ) :
            base (ApplicationID)
        {
            this.IL_ID = IL_ID;
            this.LocalLicense_ID = LocalLicense_ID;
            this.DriverID = DriverID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = _enMode.update;
        }

        public clsInternationalDrivingLicenseApplication(int LocalLicense_ID, int UserID) : base()
        {
            this.LocalLicense_ID = LocalLicense_ID;
            this.CreatedByUserID = UserID;

            this.IssueDate = DateTime.Today;
            this.ExpirationDate = DateTime.Today;

            this.IsActive = true;

            _Mode = _enMode.add;
        }

        public enum enSaveResult { LocalDrivingLicenseNotExist, LocalDrivingLicenseNotClass3_Ordinary_Driving, ThisPersonIsNotSavedAsDriver, LocalDrivingLicenseNotActive, ApplicationNotCreated, ThisLocalAlreadyHasInternationalLicense, DBError, SavedSuccessfully }
        private enSaveResult _Add ()
        {
            if (LocalLicense is null)
                return enSaveResult.LocalDrivingLicenseNotExist;

            if (LocalLicense.LicenseClassID != clsLicenseClass.enLicenseClass.Ordinary_driving)
                return enSaveResult.LocalDrivingLicenseNotClass3_Ordinary_Driving;

            if (!LocalLicense.IsActive)
                return enSaveResult.LocalDrivingLicenseNotActive;

            DriverID = clsDrivers.GetDriverIDByApplicationID(LocalLicense.ApplicationID);
            if (DriverID <= 0)
                return enSaveResult.ThisPersonIsNotSavedAsDriver;

            if (DoesHaveInternationalLicense(LocalLicense_ID))
                return enSaveResult.ThisLocalAlreadyHasInternationalLicense;
            
            if (!AddInternationalApplication(Driver.PersonID, CreatedByUserID))
                return enSaveResult.ApplicationNotCreated;

            IssueDate = DateTime.Today;
            ExpirationDate = IssueDate.AddYears(1);

            IsActive = true;

            IL_ID = clsInternationalDrivingLicenseApplicationsAccess.Add(ApplicationID, DriverID, LocalLicense_ID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);

            if (IL_ID > 0)
            {
                return enSaveResult.SavedSuccessfully;
            }  
            else
            {
                clsApplication.Delete(base.ApplicationID);
                return enSaveResult.DBError;
            }
        }
    
        private enSaveResult _Update ()
        {
            if (IL_ID <= 0)
                return enSaveResult.DBError;

            return (clsInternationalDrivingLicenseApplicationsAccess.Update(IL_ID, IsActive, ExpirationDate)) ? enSaveResult.SavedSuccessfully : enSaveResult.DBError;
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
                    return _Update();
            }
            return enSaveResult.DBError;
        }

        public static clsInternationalDrivingLicenseApplication Find (int IL_ID)
        {
            int LocalLicense_ID = -1, DriverID = -1, ApplicationID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Today, ExpirationDate = DateTime.Today;
            bool IsActive = false;

            bool found = clsInternationalDrivingLicenseApplicationsAccess.FindByIL_ID(IL_ID, ref ApplicationID, ref DriverID, ref LocalLicense_ID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID);

            if (found)
                return new clsInternationalDrivingLicenseApplication(IL_ID, LocalLicense_ID, ApplicationID, DriverID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            else
                return null;
        }
    
        public static clsInternationalDrivingLicenseApplication FindByLocalLicenseID (int LocalLicense_ID)
        {
            int IL_ID = -1, DriverID = -1, ApplicationID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Today, ExpirationDate = DateTime.Today;
            bool IsActive = false;

            bool found = clsInternationalDrivingLicenseApplicationsAccess.FindByLocalLicense_ID(LocalLicense_ID, ref ApplicationID, ref DriverID, ref IL_ID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID);

            if (found)
                return new clsInternationalDrivingLicenseApplication(IL_ID, LocalLicense_ID, ApplicationID, DriverID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            else
                return null;
        }

        public static bool DoesHaveInternationalLicense (int LicenseID)
        {
            return clsInternationalDrivingLicenseApplicationsAccess.IsExistByLocalLicenseID(LicenseID);
        }

        public static DataTable GetAll ()
        {
            return clsInternationalDrivingLicenseApplicationsAccess.GetAll();
        }

        public static DataTable GetAll (int DriverID)
        {
            return clsInternationalDrivingLicenseApplicationsAccess.GetAllForDriver(DriverID);
        }

    }
}
