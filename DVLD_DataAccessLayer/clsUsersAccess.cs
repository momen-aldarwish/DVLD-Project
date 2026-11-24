using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace DVLD_DataAccessLayer
{
    public class clsUsersAccess
    {
        public static int GetPersonID (int UserID)
        {
            int PersonID = -1;

            string Query = @"Select Users.PersonID from Users where UserID = @UserID";

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                object PersonIDObj = command.ExecuteScalar();

                if (PersonIDObj != null && int.TryParse(PersonIDObj.ToString(), out int ID))
                {
                    PersonID = ID;
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

            return PersonID;
        }

        public static bool FindByUserID (int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            string Query = @"select * from Users where UserID = @UserID";

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    UserName = Convert.ToString(reader["UserName"]);
                    Password = Convert.ToString(reader["Password"]);

                    IsActive = Convert.ToBoolean(reader["IsActive"]);
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

        public static bool FindByUsername (string Username, ref int UserID, ref int PersonID, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            string Query = @"select * from Users where Username = @Username";

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    UserID = Convert.ToInt32(reader["UserID"]);
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    Password = Convert.ToString(reader["Password"]);

                    IsActive = Convert.ToBoolean(reader["IsActive"]);
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

        public static bool Update (int UserID, string UserName, string Password, bool IsActive)
        {
            int ExecutedRows = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"Update Users
                            set UserName = @UserName,
                            Password = @Password,
                            IsActive = @IsActive
                            where UserID = @UserID";

            SqlCommand command = new SqlCommand(Query, connection);

            int ActiveNomber = (IsActive) ? 1 : 0;

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", ActiveNomber);
            

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

        public static bool DeleteUser(int UserID)
        {
            int RowsEfficted = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"delete from Users where UserID = @UserID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"Insert into Users (PersonID, UserName, Password, IsActive)
                            values
                            (
                                @PersonID,
                                @UserName,
                                @Password,
                                @IsActive
                            );
                            Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            int ActivateNomber = (IsActive ? 1 : 0);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", ActivateNomber);
            
            try
            {
                connection.Open();

                object UserIDobj = command.ExecuteScalar();

                if (int.TryParse(UserIDobj.ToString(), out int ID))
                    UserID = ID;
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }

        public static DataTable GetAllUsers()
        {
            DataTable AllPeople = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            const string Query = @"select * from Users";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    AllPeople.Load(Reader);
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

            return AllPeople;
        }

        public static int GetUserIDByUserNamePassword (string UserName, string Password)
        {
            int UserID = -1;

            string Query = @"Select Users.UserID from Users where UserName = @UserName and Password = @Password";

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                object UserIDObj = command.ExecuteScalar();

                if (UserIDObj != null && int.TryParse(UserIDObj.ToString(), out int ID))
                {
                    UserID = ID;
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

            return UserID;
        }

        public static bool IsActive (int UserID)
        {
            bool IsActive = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select Users.IsActive from Users where UserID = @UserID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                object Activity = command.ExecuteScalar();
                if (Activity != DBNull.Value && bool.TryParse(Activity.ToString(), out bool active)) 
                    IsActive = active;

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                IsActive = false;
            }
            finally
            {
                connection.Close();
            }

            return IsActive;
        }

        public static int GetUserIDByPersonID(int PersonID)
        {
            int UserID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select Users.UserID from Users where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object UserIDobj = command.ExecuteScalar();

                if (UserIDobj != null && int.TryParse(UserIDobj.ToString(), out int ID))
                    UserID = ID;

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                UserID = -1;
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }

        public static int GetUserIDByUserName (string UserName)
        {
            int UserID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection);

            string Query = @"select Users.UserID from Users where UserName = @UserName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();

                object UserIDobj = command.ExecuteScalar();

                if (UserIDobj != null && int.TryParse(UserIDobj.ToString(), out int ID))
                    UserID = ID;

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                UserID = -1;
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }
    
    }
}
