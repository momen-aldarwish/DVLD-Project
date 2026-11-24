using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DVLD_DataAccessLayer
{
    public static class clsDriversAccess
    {
        public static DataTable GetAllDrivers ()
        {
            DataTable Drivers = new DataTable();


            const string Query = @"select * from Drivers_View;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        connection.Open();

                        SqlDataReader Reader = command.ExecuteReader();

                        if (Reader.HasRows)
                        {
                            Drivers.Load(Reader);
                        }

                    }    

                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return Drivers;
        }
    
        public static int AddDriver (int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int LicenseDriverID = -1;

            const string Query = @"insert into Drivers (PersonID, CreatedByUserID, CreatedDate)
                            Values
                            ( @PersonID, @CreatedByUserID, @CreatedDate);
                            Select Scope_Identity();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                        connection.Open();

                        object LicenseDriverIDobj = command.ExecuteScalar();

                        if (int.TryParse(LicenseDriverIDobj.ToString(), out int ID))
                            LicenseDriverID = ID;
                    }

                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                LicenseDriverID = -1;
            }

            return LicenseDriverID;
        }
    
        public static int GetDriverIDByPersonID (int PersonID)
        {
            int DriverID = -1;


            string Query = @"select top 1 DriverID from Drivers where PersonID = @PersonID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        connection.Open();

                        object DriverIDobj = command.ExecuteScalar();

                        if (DriverIDobj is null || DriverIDobj == DBNull.Value)
                            DriverID = -1;
                        else 
                            DriverID = Convert.ToInt32(DriverIDobj);

                    }

                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                DriverID = -1;
            }

            return DriverID;
        }
    
        public static int GetDriverIDForAnyApplicationByApplicationID (int ApplicationID)
        {
            int DriverID = -1;


            const string Query = @"SELECT    Drivers.DriverID
                            FROM         Applications INNER JOIN
                            People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN
                            Drivers ON People.PersonID = Drivers.PersonID

                            where Applications.ApplicationID = @ApplicationID;";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        connection.Open();

                        object DriverIDobj = command.ExecuteScalar();
    
                        if (DriverIDobj is null || DriverIDobj == DBNull.Value)
                            DriverID = -1;
                        else 
                            DriverID = Convert.ToInt32(DriverIDobj);
                    }
                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                DriverID = -1;
            }

            return DriverID;
        }
    
        public static bool Find (int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool Found = false;

            const string Query = @"select * from Drivers where DriverID = @DriverID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Found = true;

                                PersonID = Convert.ToInt32(reader["PersonID"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                Found = false;
            }

            return Found;
        }


    }
}
