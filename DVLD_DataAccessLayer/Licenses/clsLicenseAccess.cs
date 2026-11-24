using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer.Licenses
{
    public static class clsLicenseAccess
    {
        public static int AddNewLicense (int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, 
            DateTime ExpirationDate, string Note, float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"insert into Licenses(ApplicationID, DriverID, LicenseClass, IssueDate, 
                            ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                            Values
                            (@ApplicationID, @DriverID, @LicenseClassID, @IssueDate, @ExpirationDate, 
                            @Note, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                            Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Note", Note);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object LicenseIDobj = command.ExecuteScalar();

                if (int.TryParse(LicenseIDobj.ToString(), out int ID))
                    LicenseID = ID;
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                LicenseID = -1;
            }
            finally
            {
                connection.Close();
            }

            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, DateTime ExpirationDate, string Note, float PaidFees, bool IsActive, int CreatedByUserID)
        {
            int AffectiveRows = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"UPDATE [dbo].[Licenses]
                              SET [ExpirationDate] = @ExpirationDate
                                 ,[Notes] = @Notes
                                 ,[PaidFees] = @PaidFees
                                 ,[IsActive] = @IsActive
                                 ,[CreatedByUserID] = @CreatedByUserID
                            WHERE [LicenseID] = @LicenseID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", Note);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                AffectiveRows = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                LicenseID = -1;
            }
            finally
            {
                connection.Close();
            }

            return AffectiveRows > 0;
        }

        public static bool IsExist (int LicenseID)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select top 1 found = 1 from Licenses where LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object LicenseIDobj = command.ExecuteScalar();

                Found = Convert.ToBoolean(LicenseIDobj);
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }
    
        public static bool FindByApplicationID (int ApplicationID, ref int LicenseID,  ref int DriverID, ref byte licenseClassID,
           ref  DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, 
           ref bool IsActive, ref byte issueReason, ref int CreatedByUserID)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select * from Licenses where Licenses.ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    licenseClassID = Convert.ToByte(reader["LicenseClass"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    Notes = (reader["Notes"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Notes"]);
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    issueReason = Convert.ToByte(reader["IssueReason"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }
    
        public static bool Delete (int LicenseID)
        {
            int AffectiveRows = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"delete from Licenses where Licenses.LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                AffectiveRows = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                LicenseID = -1;
            }
            finally
            {
                connection.Close();
            }

            return AffectiveRows > 0;
        }
    
        public static bool FindByLicenseID(int LicenseID, ref int ApplicationID, ref int DriverID, ref byte licenseClassID,
           ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees,
           ref bool IsActive, ref byte issueReason, ref int CreatedByUserID)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select * from Licenses where Licenses.LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    licenseClassID = Convert.ToByte(reader["LicenseClass"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    Notes = (reader["Notes"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Notes"]);
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    issueReason = Convert.ToByte(reader["IssueReason"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static bool FindByLDLApplication_ID(int LDL_ID, ref int LicenseID, ref int ApplicationID, ref int DriverID, ref byte licenseClassID,
           ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees,
           ref bool IsActive, ref byte issueReason, ref int CreatedByUserID)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select top 1 Licenses.* from Licenses 
                             inner join LocalDrivingLicenseApplications on Licenses.ApplicationID = LocalDrivingLicenseApplications.ApplicationID 
                             where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDL_ID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LDL_ID", LDL_ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    licenseClassID = Convert.ToByte(reader["LicenseClass"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    Notes = (reader["Notes"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Notes"]);
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    issueReason = Convert.ToByte(reader["IssueReason"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static DataTable GetAllDriverLicenses(int PersonID)
        {
            DataTable dt = new DataTable ();

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select Licenses.LicenseID, Licenses.ApplicationID, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive from Licenses inner join Applications on Licenses.ApplicationID = Applications.ApplicationID
                            where Applications.ApplicantPersonID = @PersonID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetActiveLicense (int LicenseID, ref int LicenseActiveID, ref int ApplicationID, ref int DriverID, ref byte licenseClassID,
           ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees,
           ref bool IsActive, ref byte issueReason, ref int CreatedByUserID)

        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select * from Licenses 
where Licenses.ExpirationDate > GetDate() and 
DriverID = (select DriverID from Licenses where LicenseID = @LicenseID) and 
Licenses.LicenseClass = (select Licenses.LicenseClass from Licenses where Licenses.LicenseID = @LicenseID);";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    LicenseActiveID = Convert.ToInt32(reader["LicenseID"]);
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    licenseClassID = Convert.ToByte(reader["LicenseClass"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    Notes = (reader["Notes"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Notes"]);
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    issueReason = Convert.ToByte(reader["IssueReason"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
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
