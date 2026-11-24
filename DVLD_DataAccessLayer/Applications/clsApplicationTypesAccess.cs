using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DVLD_DataAccessLayer.Applications
{
    public class clsApplicationTypesAccess
    {
        public static DataTable GetAllApplicationTypes ()
        {
            DataTable ApplicationTypes = new DataTable();

            const string Query = @"select * from ApplicationTypes";

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
    
        public static bool Find (int ApplicationTypeID, ref string ApplicationTypeTitle, ref float ApplicationFees)
        {
            bool IsFound = false;

            const string Query = @"select * from ApplicationTypes where ApplicationTypeID = @ApplicationTypeID";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                ApplicationTypeTitle = Convert.ToString(reader["ApplicationTypeTitle"]);
                                ApplicationFees = Convert.ToSingle(reader["ApplicationFees"].ToString());
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
        
        public static bool Update (int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationFees)
        {
            int ExecutedRows = -1;

            const string Query = @"Update ApplicationTypes
                            set ApplicationTypeTitle = @ApplicationTypeTitle,
                            ApplicationFees = @ApplicationFees
                            where ApplicationTypeID = @ApplicationTypeID";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                        command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                        command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
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
