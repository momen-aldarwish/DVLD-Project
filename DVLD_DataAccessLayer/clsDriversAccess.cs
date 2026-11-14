using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace DVLD_DataAccessLayer
{
    public static class clsDriversAccess
    {
        public static DataTable GetAllDrivers ()
        {
            DataTable Drivers = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            const string Query = @"select * from Drivers_View;";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    Drivers.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return Drivers;
        }
    
        public static int AddDriver (int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int LicenseDriverID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"insert into Drivers (PersonID, CreatedByUserID, CreatedDate)
                            Values
                            ( @PersonID, @CreatedByUserID, @CreatedDate);
                            Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                connection.Open();

                object LicenseDriverIDobj = command.ExecuteScalar();

                if (int.TryParse(LicenseDriverIDobj.ToString(), out int ID))
                    LicenseDriverID = ID;
            }
            catch (Exception ex)
            {
                LicenseDriverID = -1;
            }
            finally
            {
                connection.Close();
            }

            return LicenseDriverID;
        }
    
        public static int GetDriverIDByPersonID (int PersonID)
        {
            int DriverID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select top 1 DriverID from Drivers where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object DriverIDobj = command.ExecuteScalar();

                if (DriverIDobj is null || DriverIDobj == DBNull.Value)
                    DriverID = -1;
                else 
                    DriverID = Convert.ToInt32(DriverIDobj);
            }
            catch (Exception ex)
            {
                DriverID = -1;
            }
            finally
            {
                connection.Close();
            }

            return DriverID;
        }
    
        public static int GetDriverIDForAnyApplicationByApplicationID (int ApplicationID)
        {
            int DriverID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"SELECT    Drivers.DriverID
                            FROM         Applications INNER JOIN
                            People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN
                            Drivers ON People.PersonID = Drivers.PersonID

                            where Applications.ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                object DriverIDobj = command.ExecuteScalar();

                if (DriverIDobj is null || DriverIDobj == DBNull.Value)
                    DriverID = -1;
                else 
                    DriverID = Convert.ToInt32(DriverIDobj);
            }
            catch (Exception ex)
            {
                DriverID = -1;
            }
            finally
            {
                connection.Close();
            }

            return DriverID;
        }
    
        public static bool Find (int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select * from Drivers where DriverID = @DriverID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                }
            }
            catch (Exception ex)
            {
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }


    }
}
