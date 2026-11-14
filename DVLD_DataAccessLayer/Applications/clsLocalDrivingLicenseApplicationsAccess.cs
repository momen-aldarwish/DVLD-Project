using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"SELECT 
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

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LDL_ID", LDL_ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID =  Convert.ToByte(reader["LicenseClassID"]);
                    PassedTestCount = Convert.ToInt32(reader["PassedTestCount"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error in GetLocalDrivingLicenseApplicationInfoByID: " + ex.Message);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool DoesPersonActiveInLicense(string NationalNo, byte LicenseClassID)
        {
            bool IsActive = false;
            string Query = @"select top 1 result = 1
                              FROM         Applications INNER JOIN
                              People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN
                              LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
            
                              where People.NationalNo = @NationalNo and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID and (Applications.ApplicationStatus in (1, 3));";

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object IsActiveobj = command.ExecuteScalar();

                IsActive = (IsActiveobj != null);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return IsActive;
        }

        public static DataTable GetAll()
        {
            DataTable all = null;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            const string Query = @"SELECT    LocalDrivingLicenseApplicationID as LDLID, ClassName, FullName, NationalNo, ApplicationDate, PassedTestCount, Status
                                    FROM         LocalDrivingLicenseApplications_View";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    all = new DataTable();
                    all.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return all;
        }
        
        public static int GetApplicationID (int LDL_ID)
        {
            int ApplicationID = -1;

            string Query = @"select LocalDrivingLicenseApplications.ApplicationID from LocalDrivingLicenseApplications 
                                where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDL_ID;";

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDL_ID", LDL_ID);

            try
            {
                connection.Open();

                object ApplicationIDobj = command.ExecuteScalar();

                if (ApplicationIDobj != null && int.TryParse(ApplicationIDobj.ToString(), out int ID))
                    ApplicationID = ID;

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }

            return ApplicationID;
        }
    
        public static bool IsExist (int LDL_ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select top 1 Found = 1 from LocalDrivingLicenseApplications 
            where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDL_ID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LDL_ID", LDL_ID);

            try
            {
                connection.Open();

                object IsFoundobj = command.ExecuteScalar();

                IsFound = (IsFoundobj != null);
               
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error in GetLocalDrivingLicenseApplicationInfoByID: " + ex.Message);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }
        
        public static int Add (int ApplicationID, byte LicenseClassID)
        {
            int LDL_ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"Insert into LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                            values
                            (
                                @ApplicationID,
                                @LicenseClassID
                            );
                            
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            

            try
            {
                connection.Open();

                object LDL_IDobj = command.ExecuteScalar();

                if (LDL_IDobj != null && int.TryParse(LDL_IDobj.ToString(), out int ID))
                    LDL_ID = ID;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return LDL_ID;
        }

        public static bool Delete(int LDL_ID)
        {
            int RowsEfficted = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"delete from LocalDrivingLicenseApplications where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDL_ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LDL_ID", LDL_ID);

            try
            {
                connection.Open();

                RowsEfficted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RowsEfficted = -1;
            }
            finally
            {
                connection.Close();
            }

            return (RowsEfficted > 0);
        }

        public static bool Update (int LDL_ID, byte LicenseClassID)
        {
            int ExecutedRows = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"Update LocalDrivingLicenseApplications
                            set LicenseClassID = @LicenseClassID
                            where LocalDrivingLicenseApplicationID = @LDL_ID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LDL_ID", LDL_ID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                ExecutedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (ExecutedRows > 0);
        }    
        
    }
}
