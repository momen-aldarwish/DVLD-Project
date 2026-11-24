using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DVLD_DataAccessLayer.Tests
{
    public static class clsTestAppointmentAccess
    {
        public static DataTable GetAllAppointments()
        {
            DataTable Appointments = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            const string Query = @"select * from TestAppointments_View";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    Appointments.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return Appointments;
        }

        public static DataTable GetAppointmentTests(int LDL_ID)
        {
            DataTable Appointments = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            const string Query = @"SELECT    TestAppointments_View.* FROM         TestAppointments_View
                                    where TestAppointments_View.LocalDrivingLicenseApplicationID = @LDL_ID;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDL_ID", LDL_ID);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    Appointments.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return Appointments;
        }
    
        public static bool IsPersonLocked (int TestAppointmentID)
        {
            bool IsLocked = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"SELECT   top 1 TestAppointments_View.IsLocked
                            FROM         TestAppointments_View where TestAppointments_View.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();

                object IsLockedobj = command.ExecuteScalar();

                IsLocked = (IsLockedobj != null) ? (bool)IsLockedobj : false;
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                IsLocked = false;
            }
            finally
            {
                connection.Close();
            }

            return IsLocked;
        }
    
        public static bool Find (int AppointmentID, ref byte TestTypeID, ref int LDL_ID, ref DateTime AppointmentDate,
            ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int ReTakeApplicationID)
        {
            bool IsFound = false;

            string Query = @"select * from TestAppointments where TestAppointments.TestAppointmentID = @AppointmentID;";

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    TestTypeID = Convert.ToByte(reader["TestTypeID"]);
                    LDL_ID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsLocked = (bool)reader["IsLocked"];
                    ReTakeApplicationID = (reader["RetakeTestApplicationID"] != DBNull.Value) ?
                        Convert.ToInt32(reader["RetakeTestApplicationID"]) : -1;

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
    
        public static bool Update (int TestAppointmentID, DateTime AppointmentDate, float PaidFees, bool IsLocked)
        {
            int ExecutedRows = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"UPDATE [dbo].[TestAppointments]
                            SET [AppointmentDate] = @AppointmentDate
                            ,[PaidFees] = @PaidFees
                            ,[IsLocked] = @IsLocked
                            WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            
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
        
        public static int Add (byte TestTypeID, int LDL_ID, DateTime AppointmentDate,
            float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeApplicationID = -1)
        {
            int TestAppointmentID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"INSERT INTO [dbo].[TestAppointments]
                           ([TestTypeID]
                           ,[LocalDrivingLicenseApplicationID]
                           ,[AppointmentDate]
                           ,[PaidFees]
                           ,[CreatedByUserID]
                           ,[IsLocked]
                           ,[RetakeTestApplicationID])
                     VALUES
                           (@TestTypeID
                           ,@LDL_ID
                           ,@AppointmentDate
                           ,@PaidFees
                           ,@CreatedByUserID
                           ,@IsLocked
                           ,@RetakeApplicationID);
                                        Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LDL_ID", LDL_ID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeApplicationID > 0) 
                command.Parameters.AddWithValue("@RetakeApplicationID", RetakeApplicationID);
            else
                command.Parameters.AddWithValue("@RetakeApplicationID", DBNull.Value);



            try
            {
                connection.Open();

                object TestAppointmentIDobj = command.ExecuteScalar();

                if (int.TryParse(TestAppointmentIDobj.ToString(), out int ID))
                    TestAppointmentID = ID;
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return TestAppointmentID;
        }
        
        public static bool DeleteAppointment (int TestAppointmentID)
        {
            int RowsEfficted = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"delete from TestAppointments where TestAppointments.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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
        
        public static byte GetLastActiveAppointment (int LDL_ID)
        {
            byte lastAppointment = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select top 1 TestAppointments.TestTypeID from TestAppointments
                            where TestAppointments.LocalDrivingLicenseApplicationID = @LDL_ID and TestAppointments.IsLocked = 0
                            order by TestAppointments.TestAppointmentID desc;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LDL_ID", LDL_ID);

            try
            {
                connection.Open();

                object lastobj = command.ExecuteScalar();

                if ((lastobj is not null) && lastobj != DBNull.Value)
                {
                    lastAppointment = Convert.ToByte(lastobj);
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

            return lastAppointment;
        }
    
    
    }
}
