using DVLD_BusinessLogicLayer.Licenses;
using DVLD_DataAccessLayer.Applications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace DVLD_BusinessLogicLayer.Applications
{
    public class clsDetainedLicense
    {
        public int DetainID { get; private set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; private set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }
        public int PersonID { get; private set; }

        private clsLicense _License = null;
        public clsLicense License
        {
            get
            {
                if (LicenseID <= 0)
                    return null;

                if (_License is null)
                    _License = clsLicense.Find(LicenseID);

                return _License;
            }
        }

        private clsUser _CreatedByUser = null;
        public clsUser CreatedByUser
        {
            get
            {
                if (CreatedByUserID <= 0)
                    return null;

                if (_CreatedByUser is null)
                    _CreatedByUser = clsUser.Find(CreatedByUserID);

                return _CreatedByUser;
            }
        }

        private clsUser _ReleasedUser = null;
        public clsUser ReleasedUser
        {
            get
            {
                if (ReleasedByUserID <= 0)
                    return null;

                if (_ReleasedUser is null)
                    _ReleasedUser = clsUser.Find(ReleasedByUserID);

                return _ReleasedUser;
            }
        }

        private clsApplication _ReleaseApplication = null;
        public clsApplication ReleaseApplication
        {
            get
            {
                if (ReleaseApplicationID <= 0)
                    return null;

                if (_ReleaseApplication is null)
                    _ReleaseApplication = clsApplication.Find(ReleaseApplicationID);

                return _ReleaseApplication;
            }
        }

        private clsPerson _Person = null;
        public clsPerson Person
        {
            get
            {
                if (PersonID <= 0)
                    return null;

                if (_Person is null)
                    _Person = clsPerson.Find(PersonID);

                return _Person;
            }
        }

        private clsDetainedLicense (int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased,
            DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID, int PersonID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees    ;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.PersonID = PersonID;
        }
        
        public clsDetainedLicense ()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Today;
            this.FineFees = 0.0f;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.Today;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;
            this.PersonID = -1;
        }

        public static clsDetainedLicense Find (int DetainID)
        {
            int LicenseID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1, PersonID = -1;
            DateTime DetainDate = DateTime.Today, ReleaseDate = DateTime.Today;
            float FineFees = 0.0f;
            bool IsReleased = false;

            bool Found = clsDetainAccess.FindByDetainedID(DetainID, ref LicenseID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID, ref PersonID);

            if (Found)
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees,
                CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID, PersonID);
            else
                return null;
        }

        public static clsDetainedLicense FindByLicenseID (int LicenseID)
        {
            int PersonID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1, DetainID = -1;
            DateTime DetainDate = DateTime.Today, ReleaseDate = DateTime.Today;
            float FineFees = 0.0f;
            bool IsReleased = false;

            bool Found = clsDetainAccess.FindLastDetainedByLicenseID(LicenseID, ref PersonID, ref DetainID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID);

            if (Found)
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees,
                CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID, PersonID);
            else
                return null;
        }

        public enum enAddDetain { AddedSuccessfully, LicenseIsNotActive, AlreadyDetained, InvalidData, DBError }
        public enAddDetain AddDetain (int LicenseID, float FineFees, int CreatedByUserID)
        {
            if (!clsLicense.IsLicenseActive(LicenseID))
                return enAddDetain.LicenseIsNotActive;

            if (clsDetainedLicense.IsDetained(LicenseID))
                return enAddDetain.AlreadyDetained;

            if (CreatedByUserID <= 0 || LicenseID <= 0)
                return enAddDetain.InvalidData;

            DetainID = clsDetainAccess.AddDetain(LicenseID, FineFees, CreatedByUserID);

            if (DetainID > 0)
            {
                clsDetainedLicense temp = Find(DetainID);
                if (temp is null)
                    return enAddDetain.DBError;

                DetainDate = temp.DetainDate;
                IsReleased = temp.IsReleased;
                PersonID = temp.PersonID;
                return enAddDetain.AddedSuccessfully;
            }

            return enAddDetain.DBError;
        }

        public bool ReleaseDetainedLicense (int ReleasedByUserID)
        {
            clsApplication application = new clsApplication();
            application.ApplicantPersonID = PersonID;
            application.ApplicationTypeID = clsApplicationType.enApplicationType.ReleaseDetained;
            application.Status = clsApplication.enStatus.Completed;
            application.PaidFees = application.ApplicationType.ApplicationTypeFees;
            application.CreatedByUserID = ReleasedByUserID;

            if (!application.Save())
                return false;

            if (clsDetainAccess.ReleaseDetainedLicense(DetainID, ReleasedByUserID, application.ApplicationID))
            {
                clsDetainedLicense temp = clsDetainedLicense.Find(DetainID);
                if (temp is null)
                    return false;

                ReleaseDate = temp.ReleaseDate;
                IsReleased = temp.IsReleased;
                ReleaseApplicationID = temp.ReleaseApplicationID;

                return true;
            }

            clsApplication.Delete(application.ApplicationID);
            return false;
        }
    
        public static DataTable GetAllDetainedLicenses ()
        {
            return clsDetainAccess.GetAllDetainedLicenses();
        }

        public bool Delete (int DetainedID)
        {
            return clsDetainAccess.Delete(DetainID);
        }

        public static bool IsDetained (int LicenseID)
        {
            return clsDetainAccess.IsDetained(LicenseID);
        }


    }
}
