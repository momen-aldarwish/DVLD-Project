using DVLD_DataAccessLayer.Applications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DVLD_BusinessLogicLayer.Applications
{
    public class clsApplicationType
    {
        public enum enApplicationType 
        {
            None = 0,
            NewLocal = 1,
            ReNew = 2,
            ReplacementLost = 3,
            ReplacementDamaged = 4,
            ReleaseDetained = 5,
            NewInternational = 6,
            ReTakeTest = 7
        }

        public enApplicationType ApplicationTypeID { get; private set; }

        public string ApplicationTypeTitle { get; set; }

        public float ApplicationTypeFees { get; set; }

        public clsApplicationType() 
        {
            ApplicationTypeID = enApplicationType.None;
            ApplicationTypeTitle = string.Empty;
            ApplicationTypeFees = 0.0f;
        }
            
        private clsApplicationType(enApplicationType ApplicationTypeID, string ApplicationTypeTitle, float ApplicationTypeFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;
        }

        public static DataTable GetAllApplicationTypes ()
        {
            return clsApplicationTypesAccess.GetAllApplicationTypes();
        }

        public static clsApplicationType Find (enApplicationType ApplicationTypeID)
        {
            if (ApplicationTypeID == enApplicationType.None) 
                return new clsApplicationType();

            string ApplicationTypeTitle = "";
            float ApplicationTypeFees = 0;

            if (clsApplicationTypesAccess.Find((int)ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationTypeFees))
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFees);

            else
                return null;
        }

        public static clsApplicationType Find (int ApplicationTypeID)
        {
            return Find((enApplicationType)ApplicationTypeID);
        }

        public bool Update()
        {
            return clsApplicationTypesAccess.Update((int)ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFees);
        }


    }
}
