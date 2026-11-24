using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DVLD_DataAccessLayer.Licenses
{
    public class clsLicenseClassAccess
    {
        public static bool FindByLC_ID(int LC_ID, ref byte MinimumAllowedAge, ref byte DefaultValidityLength 
            ,ref string ClassName, ref string ClassDescription, ref float ClassFees)
        {
            bool IsFound = false;

            string Query = @"select * from LicenseClasses where LicenseClassID = @LC_ID";

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LC_ID", LC_ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    MinimumAllowedAge = byte.Parse(reader["MinimumAllowedAge"].ToString());
                    DefaultValidityLength = byte.Parse(reader["DefaultValidityLength"].ToString());

                    ClassName = reader["ClassName"].ToString();
                    ClassDescription = reader["ClassDescription"].ToString();

                    ClassFees = float.Parse(reader["ClassFees"].ToString());
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

        public static int GetLC_ID_ByClassName(string ClassName)
        {
            int LC_ID = -1;

            string Query = @"select LicenseClasses.LicenseClassID from LicenseClasses where LicenseClasses.ClassName = @ClassName;";

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();

                object LC_IDobj = command.ExecuteScalar();

                if (LC_IDobj != null && int.TryParse(LC_IDobj.ToString(), out int ID))
                    LC_ID = ID; 
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return LC_ID;
        }
    
        public static DataTable GetAllClassName ()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string query = @"select LicenseClasses.LicenseClassID, LicenseClasses.ClassName from LicenseClasses;";
            
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
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
