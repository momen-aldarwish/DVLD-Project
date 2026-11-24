using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DVLD_DataAccessLayer
{
    public class clsCountriesAccess
    {
        public static bool GetCountryNameByCountryID (int CountryID, ref string CountryName)
        {
            bool isfound = false;


            const string Query = "Select Countries.CountryName from Countries where CountryID = @CountryID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@CountryID", CountryID);
                        connection.Open();

                        object CountryNameOBJ = command.ExecuteScalar();

                        if (CountryNameOBJ != DBNull.Value)
                        {
                            CountryName = CountryNameOBJ.ToString();
                            isfound = true;
                        }
                    }    
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                isfound = false;
            }

            return isfound;
        }

        public static int GetCountryIDByCountryName(string CountryName)
        {
            int CountryID = -1;

            const string Query = @"Select Countries.CountryID from Countries where CountryName = @CountryName";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@CountryName", CountryName);
                        connection.Open();

                        object CountryIDOBJ = command.ExecuteScalar();

                        if(CountryIDOBJ == null || int.TryParse(CountryIDOBJ.ToString(), out CountryID) == false)
                        {
                            CountryID = -1;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return CountryID;
        }
    
        public static DataTable GetAllCountries ()
        {
            DataTable CountriesInfo = new DataTable();


            const string Query = @"Select * from Countries;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                CountriesInfo.Load(reader);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return CountriesInfo;
        }


    }
}
