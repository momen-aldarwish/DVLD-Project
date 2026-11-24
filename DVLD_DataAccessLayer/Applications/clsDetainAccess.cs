using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Diagnostics;

namespace DVLD_DataAccessLayer.Applications
{
    public static class clsDetainAccess
    {
        public static bool FindByDetainedID(int DetainedID, ref int LicenseID, ref DateTime DetainDate, ref float FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID, ref int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select DetainedLicenses.*, Drivers.PersonID from DetainedLicenses inner join Licenses on 
                            DetainedLicenses.LicenseID = Licenses.LicenseID inner join Drivers on Licenses.DriverID = Drivers.DriverID
                            where DetainedLicenses.DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainedID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsReleased = (reader["IsReleased"] != DBNull.Value) ? Convert.ToBoolean(reader["IsReleased"]) : false;
                    ReleaseDate = (reader["ReleaseDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue;
                    ReleasedByUserID = (reader["ReleasedByUserID"] != DBNull.Value) ? Convert.ToInt32(reader["ReleasedByUserID"]) : -1;
                    ReleaseApplicationID = (reader["ReleaseApplicationID"] != DBNull.Value) ? Convert.ToInt32(reader["ReleaseApplicationID"]) : -1;
                    PersonID = Convert.ToInt32(reader["PersonID"]);
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

        public static bool FindLastDetainedByLicenseID(int LicenseID, ref int PersonID, ref int DetainedID, ref DateTime DetainDate, ref float FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select top 1 DetainedLicenses.*, Drivers.PersonID from DetainedLicenses inner join Licenses on 
                            DetainedLicenses.LicenseID = Licenses.LicenseID inner join Drivers on Licenses.DriverID = Drivers.DriverID
                            where DetainedLicenses.LicenseID = @LicenseID
                            order by DetainedLicenses.DetainID desc;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsReleased = (reader["IsReleased"] != DBNull.Value) ? Convert.ToBoolean(reader["IsReleased"]) : false;
                    ReleaseDate = (reader["ReleaseDate"] != DBNull.Value) ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue;
                    ReleasedByUserID = (reader["ReleasedByUserID"] != DBNull.Value) ? Convert.ToInt32(reader["ReleasedByUserID"]) : -1;
                    ReleaseApplicationID = (reader["ReleaseApplicationID"] != DBNull.Value) ? Convert.ToInt32(reader["ReleaseApplicationID"]) : -1;
                    DetainedID = Convert.ToInt32(reader["DetainID"]);
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

        public static int AddDetain (int LicenseID, float FineFees, int CreatedByUserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"insert into DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                             values
                             (@LicenseID, GetDate(), @FineFees, @CreatedByUserID, 0);
	                            select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();

                object IDobj = command.ExecuteScalar();
                if (IDobj is not null && IDobj != DBNull.Value)
                    ID = Convert.ToInt32(IDobj);
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                ID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ID;
        }
    
        public static bool ReleaseDetainedLicense (int DetainID, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int AffectedRows = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"update DetainedLicenses
                            set IsReleased = 1,
	                        ReleaseDate = getDate(),
	                        ReleasedByUserID = @ReleasedByUserID,
	                        ReleaseApplicationID = @ReleaseApplicationID
	                        where DetainedLicenses.DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);


            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                AffectedRows = -1;
            }
            finally
            {
                connection.Close();
            }

            return AffectedRows > 0;
        }

        public static bool Delete (int DetainID)
        {
            int AffectedRows = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"Delete from DetainedLicenses where DetainedLicenses.DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                AffectedRows = -1;
            }
            finally
            {
                connection.Close();
            }

            return AffectedRows > 0;
        }
    
        public static bool IsDetained (int LicenseID)
        {
            bool IsLicenseDetained = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select top 1 1 from DetainedLicenses
                            where LicenseID = @LicenseID and IsReleased = 0;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object IsLicenseDetainedobj = command.ExecuteScalar();

                if (IsLicenseDetainedobj is not null && IsLicenseDetainedobj != DBNull.Value)
                    IsLicenseDetained = true;
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
                IsLicenseDetained = false;
            }
            finally
            {
                connection.Close();
            }

            return IsLicenseDetained;
        }
    
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select * from DetainedLicenses_View order by DetainID desc, IsReleased asc;";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
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


    }
}
