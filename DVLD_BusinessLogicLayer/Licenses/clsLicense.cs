using DVLD_BusinessLogicLayer.Applications;
using DVLD_DataAccessLayer.Applications;
using DVLD_DataAccessLayer.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static DVLD_BusinessLogicLayer.Licenses.clsLicense;

namespace DVLD_BusinessLogicLayer.Licenses
{
    public class clsLicense
    {
        private enum _enMode { add, update}
        private _enMode _Mode;

        public int LicenseID { get; private set; }
        public int ApplicationID { get; private set; }
        public int DriverID { get; private set; }
        public clsLicenseClass.enLicenseClass LicenseClassID { get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string Notes { get; set; }
        public float PaidFees { get; private set; }
        public bool IsActive { get; private set; }
        public enum enIssueReason { None = 0, FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; private set; }
        public bool IsDetained { get { return clsDetainedLicense.IsDetained(LicenseID); } }

        public string IssueReasonString
        {
            get
            {
                switch (IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "First Time";

                    case enIssueReason.Renew:
                        return "Renew";

                    case enIssueReason.ReplacementForDamaged:
                        return "Replacement for damaged";

                    case enIssueReason.ReplacementForLost:
                        return "Replacement for lost";
                    
                    case enIssueReason.None:
                    default:
                        return "None";
                }

            }
        }

        private clsApplication _Application = null;
        public clsApplication Application
        {
            get
            {
                if (ApplicationID <= 0)
                    return null;

                if (_Application is null || _Application.ApplicationID != ApplicationID)
                    return clsApplication.Find(ApplicationID);

                return _Application;
            }
        }

        private clsLicenseClass _LicenseClass = null;
        public clsLicenseClass LicenseClass
        {
            get
            {
                if (LicenseClassID <= 0)
                    return null;

                if (_LicenseClass is null || _LicenseClass.LC_ID != LicenseClassID)
                    return clsLicenseClass.Find(LicenseClassID);

                return _LicenseClass;
            }
        }

        private clsUser _User = null;
        public clsUser Uesr
        {
            get
            {
                if (CreatedByUserID <= 0)
                    return null;

                if (_User is null || _User.UserID != CreatedByUserID)
                    return clsUser.Find(CreatedByUserID);

                return _User;
            }
        }

        private clsDrivers _Driver = null;
        public clsDrivers Driver
        {
            get
            {
                if (DriverID <= 0)
                    return null;

                if (_Driver is null || _Driver.DriverID != DriverID)
                    _Driver = clsDrivers.Find(DriverID);

                return _Driver;
            }
        }

        private clsLocalDrivingLicenseApplication _LocalDrivingLicense = null;

        private clsLicense (int LicenseID, int ApplicationID, int DriverID, clsLicenseClass.enLicenseClass LicenseClassID, 
            DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = _enMode.update;
        }

        public clsLicense (clsLocalDrivingLicenseApplication LocalDrivingLicense)
        {
            _LocalDrivingLicense = LocalDrivingLicense;

            Notes = string.Empty;
            IssueDate = DateTime.Today;
            _Mode = _enMode.add;
            
            if (LocalDrivingLicense is not null)
            {
                ApplicationID = LocalDrivingLicense.ApplicationID;
                LicenseClassID = LocalDrivingLicense.LicenseClassID;
                PaidFees = LocalDrivingLicense.LicenseClass.ClassFees;
                CreatedByUserID = LocalDrivingLicense.CreatedByUserID;
                ExpirationDate = IssueDate.AddYears(LicenseClass.DefaultValdityLength);

                IsActive = true;    
            }
            else
            {
                ApplicationID = -1;
                LicenseClassID = clsLicenseClass.enLicenseClass.None;
                PaidFees = 0.0f;
                CreatedByUserID = -1;

                IsActive = false;
            }
        }

        public clsLicense(int LDL_ID) : this(clsLocalDrivingLicenseApplication.Find(LDL_ID)) { }
       
        private clsLicense ()
        {
            ApplicationID = -1;
            LicenseClassID = clsLicenseClass.enLicenseClass.None;
            PaidFees = 0.0f;
            CreatedByUserID = -1;

            IsActive = false;

            Notes = string.Empty;
            IssueDate = DateTime.Today;
            _Mode = _enMode.add;
        }

        private bool _Add ()
        {
            int driverID = clsDrivers.GetDriverByPersonID(this.Application.ApplicantPersonID);
            if (driverID < 0)
            {
                clsDrivers driver = new clsDrivers();
                driver.PersonID = this.Application.ApplicantPersonID;
                driver.CreatedByUserID = CreatedByUserID;

                if (!driver.Add())
                    return false;

                DriverID = driver.DriverID;
            }
            else
                DriverID = driverID;
           

            LicenseID = clsLicenseAccess.AddNewLicense(ApplicationID, DriverID, (byte)LicenseClassID, IssueDate, ExpirationDate,
                Notes, PaidFees, IsActive, (byte)IssueReason, CreatedByUserID);

            if (LicenseID <= 0)
                return false;

            if (Application.ApplicationTypeID == clsApplicationType.enApplicationType.NewLocal)
            {
                _LocalDrivingLicense.Status = clsLocalDrivingLicenseApplication.enStatus.Completed;

                if (_LocalDrivingLicense.Save())
                {
                    return true;
                }
                clsLicenseAccess.Delete(LicenseID);
                return false;
            }

            return true;
        }

        private bool _Edit ()
        {
            return clsLicenseAccess.UpdateLicense(LicenseID, ExpirationDate, Notes, PaidFees, IsActive, CreatedByUserID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.add:
                    if (_Add())
                    {
                        _Mode = _enMode.update;
                        return true;
                    }
                    return false;

                case _enMode.update:
                    return _Edit();
            }
            return false;
        }

        public static clsLicense GetActiveLicense (int LicenseID)
        {
            int LicenseActiveID = -1;
            int ApplicationID = -1;
            int DriverID = -1;
            byte LicenseClassID = 0;
            DateTime IssueDate = DateTime.Today;
            DateTime ExpirationDate = DateTime.Today;
            string Notes = string.Empty;
            float PaidFees = 0.0f;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            bool found = clsLicenseAccess.GetActiveLicense(LicenseID, ref LicenseActiveID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);

            if (found)
            {
                return new clsLicense(LicenseActiveID, ApplicationID, DriverID, (clsLicenseClass.enLicenseClass)LicenseClassID,
                IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
                return new clsLicense();
        }
       
        public enum enRenewResult { LicenseNotExpiration, ThereisExistedActiveLicense, OldReasonIsStilledActive, ApplicationNotCreated, DBError, SavedSuccessfully }
        
        public clsLicense Renew (ref enRenewResult RenewResult, int UserID, string Notes = "")
        {
            if (ExpirationDate > DateTime.Today)
            {
                RenewResult = enRenewResult.LicenseNotExpiration;
                return null;
            }

            clsLicense activeLicense = GetActiveLicense(LicenseID);
            if (activeLicense is not null)
            {
                RenewResult = enRenewResult.ThereisExistedActiveLicense;
                return activeLicense;
            }
            clsApplication application = new clsApplication();
            clsApplicationType applicationType = clsApplicationType.Find(clsApplicationType.enApplicationType.ReNew);

            application.ApplicantPersonID = Driver.PersonID;
            application.ApplicationDate = DateTime.Today;
            application.ApplicationTypeID = applicationType.ApplicationTypeID;
            application.Status = clsApplication.enStatus.Completed;
            application.PaidFees = applicationType.ApplicationTypeFees;
            application.CreatedByUserID = UserID;

            if (this.Application is not null)
                this.Application.Cancel();

            this.IsActive = false;
            if (!this.Save())
            {
                RenewResult = enRenewResult.OldReasonIsStilledActive;
                return null;
            }

            if (!application.Save())
            {
                RenewResult = enRenewResult.ApplicationNotCreated;
                return null;
            }

            clsLicense renewLicense = new clsLicense();

            renewLicense.ApplicationID = application.ApplicationID;
            renewLicense.DriverID = this.DriverID;
            renewLicense.LicenseClassID = this.LicenseClassID;
            renewLicense.IssueDate = DateTime.Today;
            renewLicense.ExpirationDate = renewLicense.IssueDate.AddYears(LicenseClass.DefaultValdityLength);
            renewLicense.Notes = Notes;
            renewLicense.PaidFees = LicenseClass.ClassFees;
            renewLicense.IsActive = true;
            renewLicense.IssueReason = enIssueReason.Renew;
            renewLicense.CreatedByUserID = UserID;

            RenewResult = (renewLicense.Save()) ? enRenewResult.SavedSuccessfully : enRenewResult.DBError;
            return renewLicense;
        }
    
        public static bool IsExist (int LicenseID)
        {
            return clsLicenseAccess.IsExist(LicenseID);
        }
    
        public static clsLicense FindByApplicationID (int ApplicationID)
        {
            int LicenseID = -1;
            int DriverID = -1;
            byte LicenseClassID = 0;
            DateTime IssueDate = DateTime.Today;
            DateTime ExpirationDate = DateTime.Today;
            string Notes = string.Empty;
            float PaidFees = 0.0f;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            bool found = clsLicenseAccess.FindByApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClassID, 
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);

            if (found)
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, (clsLicenseClass.enLicenseClass)LicenseClassID,
                IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
                return new clsLicense();
        }

        public static clsLicense Find (int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            byte LicenseClassID = 0;
            DateTime IssueDate = DateTime.Today;
            DateTime ExpirationDate = DateTime.Today;
            string Notes = string.Empty;
            float PaidFees = 0.0f;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            bool found = clsLicenseAccess.FindByLicenseID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);

            if (found)
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, (clsLicenseClass.enLicenseClass)LicenseClassID,
                IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
                return null;
        }

        public static clsLicense FindBy_LDL(int LDL_ID)
        {
            int LicenseID = -1;
            int ApplicationID = -1;
            int DriverID = -1;
            byte LicenseClassID = 0;
            DateTime IssueDate = DateTime.Today;
            DateTime ExpirationDate = DateTime.Today;
            string Notes = string.Empty;
            float PaidFees = 0.0f;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            bool found = clsLicenseAccess.FindByLDLApplication_ID(LDL_ID, ref LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);

            if (found)
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, (clsLicenseClass.enLicenseClass)LicenseClassID,
                IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
                return null;
        }

        public static DataTable GetAllDriverLicenses (int PersonID)
        {
            return clsLicenseAccess.GetAllDriverLicenses(PersonID);
        }

        public static DataTable GetAllDriverLicenses (string NationalNo)
        {
            clsPerson person = clsPerson.Find(NationalNo);

            if (person is null)
                return new DataTable();

            return GetAllDriverLicenses(person.PersonID);
        }
        
        public static bool Delete (int LicenseID)
        {
            return clsLicenseAccess.Delete(LicenseID);
        }

        public enum enReplacementResult
        {
            ApplicationNotCreated,
            OldLicenseDeactivateFailed,
            DriverIsNull,
            applicationIsNull,
            ApplicationTypeIsNull,
            NotActive,
            SavedSuccessfully,
            DBError
        }

        public clsLicense ReplacementForDamaged (int userID, string notes, ref enReplacementResult replacementResult)
        {
            clsApplication application = new clsApplication();
            application.ApplicationTypeID = clsApplicationType.enApplicationType.ReplacementDamaged;
            application.CreatedByUserID = userID;

            clsLicense license = new clsLicense();
            license.Notes = notes;
            license.IssueReason = enIssueReason.ReplacementForDamaged;
            license.CreatedByUserID = userID;

            replacementResult = _Replacement(ref application, ref license);
            if (replacementResult == enReplacementResult.SavedSuccessfully)
                return license;
            else
                return null;
        }

        public clsLicense ReplacementForLost (int userID, string notes, ref enReplacementResult replacementResult)
        {
            clsApplication application = new clsApplication();
            application.ApplicationTypeID = clsApplicationType.enApplicationType.ReplacementLost;
            application.CreatedByUserID = userID;

            clsLicense license = new clsLicense();
            license.Notes = notes;
            license.IssueReason = enIssueReason.ReplacementForLost;
            license.CreatedByUserID = userID;

            replacementResult = _Replacement(ref application, ref license);
            if (replacementResult == enReplacementResult.SavedSuccessfully)
                return license;
            else
                return null;
        }

        private enReplacementResult _Replacement(ref clsApplication application, ref clsLicense license)
        {
            if (Driver is null)
                return enReplacementResult.DriverIsNull;
            if (application is null)
                return enReplacementResult.applicationIsNull;
            if (application.ApplicationType is null)
                return enReplacementResult.ApplicationTypeIsNull;
            if (!IsActive)
                return enReplacementResult.NotActive;

            application.ApplicantPersonID = Driver.PersonID;
            application.ApplicationDate = DateTime.Today;
            application.Status = clsApplication.enStatus.Completed;
            application.PaidFees = application.ApplicationType.ApplicationTypeFees;

            if (!application.Save())
                return enReplacementResult.ApplicationNotCreated;

            license.ApplicationID = application.ApplicationID;
            license.DriverID = DriverID;
            license.LicenseClassID = LicenseClassID;
            license.IssueDate = DateTime.Today;
            license.ExpirationDate = license.IssueDate.AddYears(LicenseClass.DefaultValdityLength);
            license.PaidFees = LicenseClass.ClassFees;
            license.IsActive = true;

            if (!license.Save())
            {
                clsApplication.Delete(application.ApplicationID);

                return enReplacementResult.DBError;
            }

            if (!DeactivateLicense())
            {
                Delete(license.LicenseID);
                clsApplication.Delete(application.ApplicationID);
                return enReplacementResult.OldLicenseDeactivateFailed;
            }

            return enReplacementResult.SavedSuccessfully;
        }

        protected bool DeactivateLicense ()
        {
            this.IsActive = false;
            return Save();
        }

        public bool IsLicenseActive ()
        {
            if (!IsActive)
                return false;

            return (this.ExpirationDate >= DateTime.Today);
        }
        
        public static bool IsLicenseActive (int LicenseID)
        {
            clsLicense license = clsLicense.Find(LicenseID);
            return (license is not null) && (license.IsLicenseActive());
        }


    }
}
