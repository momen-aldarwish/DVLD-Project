using DVLD_DataAccessLayer.Applications;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime;
using System.Text;

namespace DVLD_BusinessLogicLayer.Applications
{
    public class clsApplication
    {
        public int ApplicationID { get; private set; }
        public int ApplicantPersonID { get; set; }
        private clsPerson _ApplicantPerson;
        public clsPerson ApplicantPerson
        {
            get
            {
                if (ApplicantPersonID <= 0)
                    return null;

                if (_ApplicantPerson == null || _ApplicantPerson.PersonID != ApplicantPersonID)
                    _ApplicantPerson = clsPerson.Find(ApplicantPersonID);

                return _ApplicantPerson;
            }
        }

        public DateTime ApplicationDate { get; set; }
        public clsApplicationType.enApplicationType ApplicationTypeID { get; set; }
        private clsApplicationType _ApplicationType;
        public clsApplicationType ApplicationType
        {
            get
            {
                if (ApplicationTypeID <= 0)
                    return null;

                if (_ApplicationType == null || _ApplicationType.ApplicationTypeID != ApplicationTypeID)
                    _ApplicationType = clsApplicationType.Find(ApplicationTypeID);

                return _ApplicationType;
            }
        }
        public enum enStatus { NotFound = 0, New = 1, Cancelled = 2, Completed = 3 }
        private enStatus _Status;
        public enStatus Status 
        { 
            get
            {
                return _Status;
            }
            set
            {
                if (_Status != value)
                {
                    _Status = value;
                    LastStatusDate = DateTime.Now;
                }
            }
        }
        public string StatusString
        {
            get
            {
                return _StatusStringM(_Status);
            }
        }

        private static string _StatusStringM (enStatus Status)
        {
            switch (Status)
            {
                case enStatus.New:
                    return "New";

                case enStatus.Cancelled:
                    return "Calncelled";

                case enStatus.Completed:
                    return "Completed";

                default:
                    return "Not Found";
            }
        }

        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        private clsUser _ApplicationUser;
        public clsUser ApplicationUser
        {
            get
            {
                if (CreatedByUserID <= 0)
                    return null;

                if (_ApplicationUser == null || _ApplicationUser.UserID != CreatedByUserID)
                    _ApplicationUser = clsUser.Find(CreatedByUserID);

                return _ApplicationUser;
            }
        }

        private enum _enMode { add, update }
        _enMode _Mode;

        public clsApplication ()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            CreatedByUserID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = clsApplicationType.enApplicationType.NewLocal;
            _Status = enStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0.0f;

            _Mode = _enMode.add;
        }

        protected clsApplication (int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate, clsApplicationType.enApplicationType ApplicationTypeID, enStatus Status,
            DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicationPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this._Status = Status;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = _enMode.update;
        }

        protected clsApplication (int ApplicationID)
        {
            clsApplication Application = clsApplication.Find(ApplicationID);
            
            if (Application != null)
            {
                this.ApplicationID = Application.ApplicationID;
                this.ApplicantPersonID = Application.ApplicantPersonID;
                this.ApplicationDate = Application.ApplicationDate;
                this.ApplicationTypeID = Application.ApplicationTypeID;
                this._Status = Application.Status;
                this.LastStatusDate = Application.LastStatusDate;
                this.PaidFees = Application.PaidFees;
                this.CreatedByUserID = Application.CreatedByUserID;

                _Mode = _enMode.update;
            }
            else
            {
                this.ApplicationID = -1;
                ApplicantPersonID = -1;
                CreatedByUserID = -1;
                ApplicationDate = DateTime.Now;
                ApplicationTypeID = clsApplicationType.enApplicationType.NewLocal;
                _Status = enStatus.New;
                LastStatusDate = DateTime.Now;
                PaidFees = 0.0f;

                _Mode = _enMode.add;
            }
        }

        public static clsApplication Find(int ApplicationID)
        {
            if (ApplicationID <= 0)
                return null;

            int ApplicationPersonID = 0, ApplicationTypeID = 0, CreatedByUserID = 0;
            byte Status = 0;
            float PaidFees = 0.0f;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;

            if (clsApplicationAccess.Find (ApplicationID, ref ApplicationPersonID, ref ApplicationDate, ref ApplicationTypeID, ref Status, ref LastStatusDate,
                ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, ApplicationPersonID, ApplicationDate, (clsApplicationType.enApplicationType)ApplicationTypeID,
                    (enStatus)Status, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
                return null;
        }

        public static int AddRetakeApplication (int ApplicantPersonID, int CreatedByUserID)
        {
            clsApplication application = new clsApplication();
            application.ApplicantPersonID = ApplicantPersonID;
            application.ApplicationDate = DateTime.Today;
            application.ApplicationTypeID = clsApplicationType.enApplicationType.ReTakeTest;
            application.Status = clsApplication.enStatus.New;
            application.CreatedByUserID = CreatedByUserID;
            application.PaidFees = application.ApplicationType.ApplicationTypeFees;

            if (application.Save())
                return application.ApplicationID;
            else
                return -1;
        }

        public bool AddInternationalApplication (int ApplicantPersonID, int CreatedByUserID)
        {
            this.ApplicantPersonID = ApplicantPersonID;
            this.CreatedByUserID = CreatedByUserID;
            ApplicationDate = DateTime.Today;
            ApplicationTypeID = clsApplicationType.enApplicationType.NewInternational;
            _Status = enStatus.Completed;
            PaidFees = ApplicationType.ApplicationTypeFees;

            return (Save());
        }

        private bool _Add ()
        {                      
            ApplicationID = clsApplicationAccess.Add(ApplicantPersonID, ApplicationDate, (int)ApplicationTypeID, (byte)Status, LastStatusDate, PaidFees, CreatedByUserID);
            return ApplicationID > 0;
        }

        private bool _Update ()
        {
            return clsApplicationAccess.Update(ApplicationID, (byte)Status, PaidFees, LastStatusDate);
        }

        public bool Save ()
        {
            switch (_Mode)
            {
                case _enMode.add:
                {
                    if (_Add())
                    {
                        _Mode = _enMode.update;
                        return true;
                    }
                    else 
                        return false;
                }
                case _enMode.update:
                    return _Update();
            }
            return false;
        }
    
        public static bool Delete (int ApplicationID)
        {
            return clsApplicationAccess.DeleteApplication(ApplicationID);
        }

        public bool Cancel()
        {
            if (ApplicationID <= 0)
                return false;

            this.Status = enStatus.Cancelled;
            return Save();
        }


    }
}
