using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DVLD_DataAccessLayer.Applications
{
    public static class clsApplicationAccess
    {
        public static int Add(int ApplicantPersonID, DateTime ApplicationDate, int ApplictaionTypeID, byte AplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;

            const string Query = @"Insert into Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                            values
                            (
                                @ApplicantPersonID,
                                @ApplicationDate,
                                @ApplictaionTypeID,
                                @AplicationStatus,
                                @LastStatusDate, 
                                @PaidFees, 
                                @CreatedByUserID
                            );
                            Select Scope_Identity();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                        command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                        command.Parameters.AddWithValue("@ApplictaionTypeID", ApplictaionTypeID);
                        command.Parameters.AddWithValue("@AplicationStatus", AplicationStatus);
                        command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        connection.Open();

                        object UserIDobj = command.ExecuteScalar();

                        if (int.TryParse(UserIDobj.ToString(), out int ID))
                            ApplicationID = ID;
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return ApplicationID;
        }
    
        public static bool Update (int ApplicationID, int ApplicationStatus, float PaidFees, DateTime LastStatusDate)
        {
            int ExecutedRows = -1;


            const string Query = @"Update Applications
                            set ApplicationStatus = @ApplicationStatus,
                            PaidFees = @PaidFees,
                            LastStatusDate = @LastStatusDate
                            where ApplicationID = @ApplicationID";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
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

        public static bool Find (int ApplicationID, ref int ApplicationPersonID, ref DateTime ApplicationDate, 
            ref int ApplictaionTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;

            const string Query = @"select * from Applications where ApplicationID = @ApplicationID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                ApplicationPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                                ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                                ApplictaionTypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                                ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]);
                                LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
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

        public static bool ChangeStatus(int ApplicationID, byte status)
        {
            int RowsEfficted = -1;

            const string Query = @"UPDATE Applications
                             SET ApplicationStatus = @status
      
                            WHERE ApplicationID = @ApplicationID;";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@status", status);
                        connection.Open();

                        RowsEfficted = command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return RowsEfficted > 0;
        }

        public static bool DeleteApplication (int ApplicationID)
        {
            int RowsEfficted = -1;

            const string Query = @"delete from Applications where ApplicationID = @ApplicationID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        connection.Open();

                        RowsEfficted = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                RowsEfficted = -1;
            }

            return (RowsEfficted > 0);
        }
    
    
    }
}