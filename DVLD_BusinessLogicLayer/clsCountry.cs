using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DVLD_BusinessLogicLayer
{
    public class clsCountry
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public clsCountry()
        {
            CountryID = -1;
            CountryName = string.Empty;
        }

        private clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCountry Find (int CountryID)
        {
            string CountryName = "";

            if (clsCountriesAccess.GetCountryNameByCountryID(CountryID, ref CountryName))
            {
                return new clsCountry(CountryID, CountryName);
            }
            else
                return null;
        }

        public static clsCountry Find (string CountryName)
        {
            int CountryID = -1;

            if((CountryID = clsCountriesAccess.GetCountryIDByCountryName(CountryName)) > 0)
            {
                return new clsCountry(CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllCountries ()
        {
            return clsCountriesAccess.GetAllCountries();
        }

        public static bool IsCountryExist (string CountryName)
        {
            return (Find(CountryName) != null);
        }


    }
}
