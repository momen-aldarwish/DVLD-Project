using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DVLD_DataAccessLayer.Licenses;

namespace DVLD_BusinessLogicLayer.Licenses
{
    public class clsLicenseClass
    {
        public enum enLicenseClass
        {
            None = 0,
            Small_Motorcycle = 1,
            Heavy_Motorcycle = 2,
            Ordinary_driving = 3,
            Commercial = 4,
            Agricultural = 5,
            SmallANDmedium_bus = 6,
            TruckANDheavy_vehicle = 7,
        }

        public enLicenseClass LC_ID;
        public string ClassName;
        public string ClassDescription;
        public byte MinimumAllowedAge;
        public byte DefaultValdityLength;
        public float ClassFees;

        private clsLicenseClass (enLicenseClass LC_ID, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            this.LC_ID = LC_ID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValdityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        public static clsLicenseClass Find (byte LC_ID)
        {
            string ClassName = "";
            string ClassDescription = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            float ClassFees = 0.0f;

            if (clsLicenseClassAccess.FindByLC_ID(LC_ID, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassName, ref ClassDescription, ref ClassFees))
                return new clsLicenseClass((enLicenseClass)LC_ID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }

        public static clsLicenseClass Find (enLicenseClass LC_ID)
        {
            return Find((byte)LC_ID);
        }

        public static int GetLC_ID (string ClassName)
        {
            return clsLicenseClassAccess.GetLC_ID_ByClassName(ClassName);
        }

        public static enLicenseClass enLicenseClass_GetLC_ID (string ClassName)
        {
            return (enLicenseClass)GetLC_ID(ClassName);
        }

        public static DataTable GetAllClassName ()
        {
            return clsLicenseClassAccess.GetAllClassName();
        }

    }
}
