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


            const string Query = @"select * from TestAppointments_View";

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
                                Appointments.Load(Reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return Appointments;
        }

        public static DataTable GetAppointmentTests(int LDL_ID)
        {
            DataTable Appointments = new DataTable();


            const string Query = @"SELECT    TestAppointments_View.* FROM         TestAppointments_View
                                    where TestAppointments_View.LocalDrivingLicenseApplicationID = @LDL_ID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@LDL_ID", LDL_ID);
                        connection.Open();

                        using (SqlDataReader Reader = command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                Appointments.Load(Reader);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return Appointments;
        }
    
        public static bool IsPersonLocked (int TestAppointmentID)
        {
            bool IsLocked = false;


            const string Query = @"SELECT   top 1 TestAppointments_View.IsLocked
                            FROM         TestAppointments_View where TestAppointments_View.TestAppointmentID = @TestAppointmentID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                        connection.Open();

                        object IsLockedobj = command.ExecuteScalar();

                        IsLocked = (IsLockedobj != null) ? (bool)IsLockedobj : false;

                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                IsLocked = false;
            }

            return IsLocked;
        }
    
        public static bool Find (int AppointmentID, ref byte TestTypeID, ref int LDL_ID, ref DateTime AppointmentDate,
            ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int ReTakeApplicationID)
        {
            bool IsFound = false;

            const string Query = @"select * from TestAppointments where TestAppointments.TestAppointmentID = @AppointmentID;";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
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
    
        public static bool Update (int TestAppointmentID, DateTime AppointmentDate, float PaidFees, bool IsLocked)
        {
            int ExecutedRows = -1;


            const string Query = @"UPDATE [dbo].[TestAppointments]
                            SET [AppointmentDate] = @AppointmentDate
                            ,[PaidFees] = @PaidFees
                            ,[IsLocked] = @IsLocked
                            WHERE TestAppointmentID = @TestAppointmentID";
            
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                        command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@IsLocked", IsLocked);
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
        
        public static int Add (byte TestTypeID, int LDL_ID, DateTime AppointmentDate,
            float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeApplicationID = -1)
        {
            int TestAppointmentID = -1;

            const string Query = @"INSERT INTO [dbo].[TestAppointments]
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

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@LDL_ID", LDL_ID);
                        command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsLocked", IsLocked);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                        if (RetakeApplicationID > 0) 
                            command.Parameters.AddWithValue("@RetakeApplicationID", RetakeApplicationID);
                        else
                            command.Parameters.AddWithValue("@RetakeApplicationID", DBNull.Value);

                        connection.Open();

                        object TestAppointmentIDobj = command.ExecuteScalar();

                        if (int.TryParse(TestAppointmentIDobj.ToString(), out int ID))
                            TestAppointmentID = ID;
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }
            
            return TestAppointmentID;
        }
        
        public static bool DeleteAppointment (int TestAppointmentID)
        {
            int RowsEfficted = -1;

            const string Query = @"delete from TestAppointments where TestAppointments.TestAppointmentID = @TestAppointmentID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
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
        
        public static byte GetLastActiveAppointment (int LDL_ID)
        {
            byte lastAppointment = 0;

            const string Query = @"select top 1 TestAppointments.TestTypeID from TestAppointments
                            where TestAppointments.LocalDrivingLicenseApplicationID = @LDL_ID and TestAppointments.IsLocked = 0
                            order by TestAppointments.TestAppointmentID desc;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@LDL_ID", LDL_ID);

                        connection.Open();

                        object lastobj = command.ExecuteScalar();

                        if ((lastobj is not null) && lastobj != DBNull.Value)
                        {
                            lastAppointment = Convert.ToByte(lastobj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return lastAppointment;
        }
    
    
    }
}
