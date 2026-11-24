using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DVLD_DataAccessLayer.Tests
{
    public static class clsTestAccess
    {
        public static bool GetTest (int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;

            const string Query = @"select * from Tests where TestID = @TestID;";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@TestID", TestID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                                TestResult = Convert.ToBoolean(reader["TestResult"]);
                                Notes = (reader["Notes"] != DBNull.Value) ? Convert.ToString(reader["Notes"]) : string.Empty;
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
    
        public static int AddTest (int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = -1;

            const string Query = @"INSERT INTO [dbo].[Tests]
                                  ([TestResult]
                                  ,[Notes]
                                  ,[CreatedByUserID]
                                  ,[TestAppointmentID])
                            VALUES
                                  (@TestResult
                                  ,@Notes
                                  ,@CreatedByUserID
                                  ,@TestAppointmentID);

                            update TestAppointments
                                  set IsLocked = 1 
                                  where TestAppointmentID = @TestAppointmentID;

                                    select Scope_Identity();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@TestResult", TestResult);
                        command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                        connection.Open();

                        object TestIDobj = command.ExecuteScalar();

                        if (TestIDobj is not null && int.TryParse(TestIDobj.ToString(), out int ID))
                        {
                            TestID = ID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                TestID = -1;
            }

            return TestID;
        }
    
        public static bool Update (int TestID, string Notes)
        {
            int ExecutedRows = -1;

            const string Query = @"Update Tests
                            set Notes = @Notes
                            
                            where TestID = @TestID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@TestID", TestID);
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

        public static bool Delete (int TestID)
        {
            int RowsEfficted = -1;

            const string Query = @"delete from Tests where TestID = @TestID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@TestID", TestID);
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
    
        public static byte GetLastTestTypePassed (int LDL_ID)
        {
            byte lastTest = 0;

            const string Query = @"select top 1 TestAppointments.TestTypeID from Tests 
                                    inner join TestAppointments on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                    where Tests.TestResult = 1 and TestAppointments.LocalDrivingLicenseApplicationID = @LDL_ID
                                    order by TestAppointments.TestAppointmentID desc;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@LDL_ID", LDL_ID);

                        connection.Open();

                        object TestResultobj = command.ExecuteScalar();

                        if (TestResultobj is not null && TestResultobj != DBNull.Value)
                            lastTest = Convert.ToByte(TestResultobj);
                    }    
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return lastTest;
        }

        public static short TotalTrial (int LDL_ID, byte TestTypeID)
        {
            short HowMuchTests = -1;


            const string Query = @"select Count = count (*) from Tests inner join TestAppointments on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
            where TestAppointments.LocalDrivingLicenseApplicationID = @LDL_ID and TestAppointments.TestTypeID = @TestTypeID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@LDL_ID", LDL_ID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        connection.Open();

                        object HowMuchTestsobj = command.ExecuteScalar();

                        if (HowMuchTestsobj != DBNull.Value)
                            HowMuchTests = Convert.ToInt16(HowMuchTestsobj);
                    }
                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                HowMuchTests = -1;
            }

            return HowMuchTests;
        }
        
        public static int GetTestID (int TestAppointmentID)
        {
            int testID = -1;

            const string Query = @"select Tests.TestID from Tests where Tests.TestAppointmentID = @TestAppointmentID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                        connection.Open();

                        object testIDobj = command.ExecuteScalar();

                        if (testIDobj != DBNull.Value)
                            testID = Convert.ToInt32(testIDobj);
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                testID = -1;
            }

            return testID;
        }
    
        public static bool GetLastTestTypeAndResultByLocalDrivingLicense (int LDL_ID, ref byte TestTypeID, ref bool TestResult)
        {
            bool IsFound = false;

            const string Query = @"select top 1 Tests.TestResult, TestAppointments.TestTypeID from Tests inner join TestAppointments on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                            where TestAppointments.LocalDrivingLicenseApplicationID = @LDL_ID
                            order by Tests.TestID desc;";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@LDL_ID", LDL_ID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                TestResult = Convert.ToBoolean(reader["TestResult"]);
                                TestTypeID = Convert.ToByte(reader["TestTypeID"]);
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
    
    }

}
