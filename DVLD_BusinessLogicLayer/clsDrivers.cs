using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DVLD_BusinessLogicLayer
{
    public class clsDrivers
    {
        public int DriverID {  get; private set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; private set; }

        public static DataTable GetAllDrivers()
        {
            return clsDriversAccess.GetAllDrivers();
        }

        public bool Add()
        {
            DriverID = GetDriverByPersonID(PersonID);
            if (DriverID > 0)
                return true;

            CreatedDate = DateTime.Now;
            DriverID = clsDriversAccess.AddDriver(PersonID, CreatedByUserID, CreatedDate);
            return DriverID > 0;
        }

        public static int GetDriverByPersonID (int PersonID)
        {
            return clsDriversAccess.GetDriverIDByPersonID(PersonID);
        }

        public static int GetDriverIDByApplicationID (int ApplicationID)
        {
            return clsDriversAccess.GetDriverIDForAnyApplicationByApplicationID(ApplicationID);
        }
    
        private clsDrivers (int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
        }

        public clsDrivers ()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Today;
        }

        public static clsDrivers Find (int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Today;

            if (clsDriversAccess.Find(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

    }
}
