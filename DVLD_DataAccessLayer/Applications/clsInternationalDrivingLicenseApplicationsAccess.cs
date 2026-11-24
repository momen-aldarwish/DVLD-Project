using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer.Applications
{
    public static class clsInternationalDrivingLicenseApplicationsAccess
    {
        public static DataTable GetAll()
        {
            DataTable all = new DataTable();


            const string Query = @"select * from InternationalLicenses;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader Reader = command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                all.Load(Reader);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return all;
        }

        public static DataTable GetAllForDriver(int DriverID)
        {
            DataTable all = new DataTable();


            const string Query = @"select * from InternationalLicenses where DriverID = @DriverID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        connection.Open();

                        using (SqlDataReader Reader = command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                all.Load(Reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return all;
        }

        public static bool FindByLocalLicense_ID (int LocalLicense_ID, ref int ApplicationID, ref int DriverID, ref int IL_ID, ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;


            const string Query = @"select * from InternationalLicenses
                            where InternationalLicenses.IssuedUsingLocalLicenseID = @LocalLicense_ID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@LocalLicense_ID", LocalLicense_ID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                IL_ID = Convert.ToInt32(reader["InternationalLicenseID"]);
                                ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                                DriverID = Convert.ToInt32(reader["DriverID"]);
                                IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                                ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                IsFound = false;
            }

            return IsFound;
        }

        public static bool FindByIL_ID(int IL_ID, ref int ApplicationID, ref int DriverID, ref int LDL_ID, ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;


            const string Query = @"select * from InternationalLicenses
                            where InternationalLicenses.InternationalLicenseID = @IL_ID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@IL_ID", IL_ID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                LDL_ID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                                ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                                DriverID = Convert.ToInt32(reader["DriverID"]);
                                IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                                ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                IsFound = false;
            }

            return IsFound;
        }

        public static int Add(int ApplicationID, int DriverID, int LDL_ID, DateTime IssueDate, DateTime ExpirationDate,
            bool IsActive, int CreatedByUserID)
        {
            int IL_ID = -1;

            const string Query = @"Insert into [dbo].[InternationalLicenses] 
                (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                            values
                            (
                                @ApplicationID,
                                @DriverID,
                                @LocalLicense_ID,
                                @IssueDate,
                                @ExpirationDate,
                                @IsActive,
                                @CreatedByUserID
                            );
                            
                            select Scope_Identity();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue("@LocalLicense_ID", LDL_ID);
                        command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        connection.Open();

                        object IL_IDobj = command.ExecuteScalar();

                        if (IL_IDobj != null && int.TryParse(IL_IDobj.ToString(), out int ID))
                            IL_ID = ID;
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return IL_ID;
        }

        public static bool Update (int IL_ID, bool IsActive, DateTime ExpirationDate)
        {
            int ExecutedRows = -1;

            const string Query = @"update InternationalLicenses
                            set IsActive = @IsActive,
                            ExpirationDate = @ExpirationDate
                            where InternationalLicenseID = @IL_ID;";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@IL_ID", IL_ID);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        connection.Open();

                        ExecutedRows = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }
           
            return (ExecutedRows > 0);
        }
    
        public static bool IsExistByLocalLicenseID (int LocalLicenseID)
        {
            bool IsFound = false;

            const string Query = @"select top 1 1 from InternationalLicenses where InternationalLicenses.IssuedUsingLocalLicenseID = @LocalLicenseID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
                        connection.Open();

                        object IsFoundobj = command.ExecuteScalar();

                        IsFound = Convert.ToBoolean(IsFoundobj);
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                IsFound = false;
            }

            return IsFound;
        }
    
    }
}
