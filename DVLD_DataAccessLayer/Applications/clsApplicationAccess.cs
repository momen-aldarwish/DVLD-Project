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

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"Insert into Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
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

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplictaionTypeID", ApplictaionTypeID);
            command.Parameters.AddWithValue("@AplicationStatus", AplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object UserIDobj = command.ExecuteScalar();

                if (int.TryParse(UserIDobj.ToString(), out int ID))
                    ApplicationID = ID;
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return ApplicationID;
        }
    
        public static bool Update (int ApplicationID, int ApplicationStatus, float PaidFees, DateTime LastStatusDate)
        {
            int ExecutedRows = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"Update Applications
                            set ApplicationStatus = @ApplicationStatus,
                            PaidFees = @PaidFees,
                            LastStatusDate = @LastStatusDate
                            where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);


            try
            {
                connection.Open();

                ExecutedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return (ExecutedRows > 0);
        }

        public static bool Find (int ApplicationID, ref int ApplicationPersonID, ref DateTime ApplicationDate, 
            ref int ApplictaionTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string Query = @"select * from Applications where ApplicationID = @ApplicationID";

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationPersonID = int.Parse(reader["ApplicantPersonID"].ToString());
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplictaionTypeID = int.Parse(reader["ApplicationTypeID"].ToString());
                    ApplicationStatus = byte.Parse(reader["ApplicationStatus"].ToString());
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = float.Parse(reader["PaidFees"].ToString());
                    CreatedByUserID = int.Parse(reader["CreatedByUserID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool ChangeStatus(int ApplicationID, byte status)
        {
            int RowsEfficted = -1;

            string Query = @"UPDATE Applications
                             SET ApplicationStatus = @status
      
                            WHERE ApplicationID = @ApplicationID;";

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@status", status);

            try
            {
                connection.Open();

                RowsEfficted = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return RowsEfficted > 0;
        }

        public static bool DeleteApplication (int ApplicationID)
        {
            int RowsEfficted = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"delete from Applications where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                RowsEfficted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                RowsEfficted = -1;
            }
            finally
            {
                connection.Close();
            }

            return (RowsEfficted > 0);
        }
    
    
    }
}