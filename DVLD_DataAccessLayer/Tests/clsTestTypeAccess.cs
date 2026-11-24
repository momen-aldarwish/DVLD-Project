using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DVLD_DataAccessLayer.Tests
{
    public class clsTestTypeAccess
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable ApplicationTypes = new DataTable();

            const string Query = @"select * from TestTypes";

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
                                ApplicationTypes = new DataTable();
                                ApplicationTypes.Load(Reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return ApplicationTypes;
        }

        public static bool Find(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref float TestTypeFees)
        {
            bool IsFound = false;

            const string Query = @"select * from TestTypes where TestTypeID = @TestTypeID";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                TestTypeTitle = reader["TestTypeTitle"].ToString();
                                TestTypeDescription = reader["TestTypeDescription"].ToString();
                                TestTypeFees = float.Parse(reader["TestTypeFees"].ToString());

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

        public static bool Update(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            int ExecutedRows = -1;

            const string Query = @"Update TestTypes
                            set TestTypeTitle = @TestTypeTitle,
                            TestTypeDescription = @TestTypeDescription,
                            TestTypeFees = @TestTypeFees
                            where TestTypeID = @TestTypeID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                        command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                        command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
                        command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
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

    }
}
