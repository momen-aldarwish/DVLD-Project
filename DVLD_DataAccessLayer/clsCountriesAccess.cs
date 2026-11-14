using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsCountriesAccess
    {
        public static bool GetCountryNameByCountryID (int CountryID, ref string CountryName)
        {
            bool isfound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = "Select Countries.CountryName from Countries where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();

                object CountryNameOBJ = command.ExecuteScalar();

                if (CountryNameOBJ != DBNull.Value)
                {
                    CountryName = CountryNameOBJ.ToString();
                    isfound = true;
                }
            }
            catch (Exception ex)
            {
                isfound = false;
            }
            finally
            {
                connection.Close();
            }

            return isfound;
        }

        public static int GetCountryIDByCountryName(string CountryName)
        {
            int CountryID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"Select Countries.CountryID from Countries where CountryName = @CountryName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                object CountryIDOBJ = command.ExecuteScalar();

                if(CountryIDOBJ == null || int.TryParse(CountryIDOBJ.ToString(), out CountryID) == false)
                {
                    CountryID = -1;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return CountryID;
        }
    
        public static DataTable GetAllCountries ()
        {
            DataTable CountriesInfo = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            const string Query = @"Select * from Countries;";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    CountriesInfo.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return CountriesInfo;
        }


    }
}
