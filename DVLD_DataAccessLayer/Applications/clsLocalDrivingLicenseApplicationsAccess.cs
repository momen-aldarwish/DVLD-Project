using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer.Applications
{
    public static class clsLocalDrivingLicenseApplicationsAccess
    {
        public static bool FindByLDL_ID(int LDL_ID, ref int ApplicationID, ref byte LicenseClassID, ref int PassedTestCount)
        {                                                
            bool IsFound = false;                      


            const string Query = @"SELECT 
                         LocalDrivingLicenseApplications.ApplicationID, 
                            LocalDrivingLicenseApplications.LicenseClassID,
                         
                         ISNULL((
                             SELECT COUNT(dbo.TestAppointments.TestTypeID)
                             FROM dbo.Tests 
                             INNER JOIN dbo.TestAppointments 
                                 ON dbo.Tests.TestAppointmentID = dbo.TestAppointments.TestAppointmentID
                             WHERE dbo.TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID 
                               AND dbo.Tests.TestResult = 1
                         ), 0) AS PassedTestCount

                         FROM  LocalDrivingLicenseApplications 

                         WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDL_ID;";

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

                                ApplicationID = (int)reader["ApplicationID"];
                                LicenseClassID = Convert.ToByte(reader["LicenseClassID"]);
                                PassedTestCount = Convert.ToInt32(reader["PassedTestCount"]);
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

        public static bool DoesPersonActiveInLicense(string NationalNo, byte LicenseClassID)
        {
            bool IsActive = false;
            const string Query = @"select top 1 result = 1
                              FROM         Applications INNER JOIN
                              People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN
                              LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
            
                              where People.NationalNo = @NationalNo and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID and (Applications.ApplicationStatus in (1, 3));";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                        connection.Open();

                        object IsActiveobj = command.ExecuteScalar();

                        IsActive = (IsActiveobj != null);
                    }
                }
            
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
            }

            return IsActive;
        }

        public static DataTable GetAll()
        {
            DataTable all = new DataTable();


            const string Query = @"SELECT    LocalDrivingLicenseApplicationID as LDLID, ClassName, FullName, NationalNo, ApplicationDate, PassedTestCount, Status
                                    FROM         LocalDrivingLicenseApplications_View";


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
        
        public static int GetApplicationID (int LDL_ID)
        {
            int ApplicationID = -1;

            const string Query = @"select LocalDrivingLicenseApplications.ApplicationID from LocalDrivingLicenseApplications 
                                where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDL_ID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@LDL_ID", LDL_ID);
                        connection.Open();

                        object ApplicationIDobj = command.ExecuteScalar();

                        if (ApplicationIDobj != null && int.TryParse(ApplicationIDobj.ToString(), out int ID))
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
    
        public static bool IsExist (int LDL_ID)
        {
            bool IsFound = false;

            const string Query = @"select top 1 Found = 1 from LocalDrivingLicenseApplications 
            where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDL_ID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@LDL_ID", LDL_ID);
                        connection.Open();

                        object IsFoundobj = command.ExecuteScalar();

                        IsFound = (IsFoundobj != null);
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
        
        public static int Add (int ApplicationID, byte LicenseClassID)
        {
            int LDL_ID = -1;

            const string Query = @"Insert into LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                            values
                            (
                                @ApplicationID,
                                @LicenseClassID
                            );
                            
                            select Scope_Identity();";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                        connection.Open();

                        object LDL_IDobj = command.ExecuteScalar();

                        if (LDL_IDobj != null && int.TryParse(LDL_IDobj.ToString(), out int ID))
                            LDL_ID = ID;
                    }
                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return LDL_ID;
        }

        public static bool Delete(int LDL_ID)
        {
            int RowsEfficted = -1;

            const string Query = @"delete from LocalDrivingLicenseApplications where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDL_ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@LDL_ID", LDL_ID);
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

        public static bool Update (int LDL_ID, byte LicenseClassID)
        {
            int ExecutedRows = -1;

            const string Query = @"Update LocalDrivingLicenseApplications
                            set LicenseClassID = @LicenseClassID
                            where LocalDrivingLicenseApplicationID = @LDL_ID;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@LDL_ID", LDL_ID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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
