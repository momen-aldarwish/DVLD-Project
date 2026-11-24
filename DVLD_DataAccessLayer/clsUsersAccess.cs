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

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        connection.Open();

                        object PersonIDObj = command.ExecuteScalar();

                        if (PersonIDObj != null && int.TryParse(PersonIDObj.ToString(), out int ID))
                        {
                            PersonID = ID;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);
            }

            return PersonID;
        }

        public static bool FindByUserID (int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            string Query = @"select * from Users where UserID = @UserID";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                         command.Parameters.AddWithValue("@UserID", UserID);
                         connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                PersonID = Convert.ToInt32(reader["PersonID"]);
                                UserName = Convert.ToString(reader["UserName"]);
                                Password = Convert.ToString(reader["Password"]);

                                IsActive = Convert.ToBoolean(reader["IsActive"]);
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

        public static bool FindByUsername (string Username, ref int UserID, ref int PersonID, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            string Query = @"select * from Users where Username = @Username";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                UserID = Convert.ToInt32(reader["UserID"]);
                                PersonID = Convert.ToInt32(reader["PersonID"]);
                                Password = Convert.ToString(reader["Password"]);

                                IsActive = Convert.ToBoolean(reader["IsActive"]);
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

        public static bool Update (int UserID, string UserName, string Password, bool IsActive)
        {
            int ExecutedRows = -1;


            string Query = @"Update Users
                            set UserName = @UserName,
                            Password = @Password,
                            IsActive = @IsActive
                            where UserID = @UserID";

            

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
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

        public static bool DeleteUser(int UserID)
        {
            int RowsEfficted = -1;
            const string Query = @"delete from Users where UserID = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
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

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = -1;


            string Query = @"Insert into Users (PersonID, UserName, Password, IsActive)
                            values
                            (
                                @PersonID,
                                @UserName,
                                @Password,
                                @IsActive
                            );
                            Select Scope_Identity();";

            
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        connection.Open();

                        object UserIDobj = command.ExecuteScalar();

                        if (UserIDobj is not null && int.TryParse(UserIDobj.ToString(), out int ID))
                            UserID = ID;
                    }
                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return UserID;
        }

        public static DataTable GetAllUsers()
        {
            DataTable AllPeople = new DataTable();
            const string Query = @"select * from Users";

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
                                AllPeople.Load(Reader);
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }
            

            return AllPeople;
        }

        public static int GetUserIDByUserNamePassword (string UserName, string Password)
        {
            int UserID = -1;

            string Query = @"Select Users.UserID from Users where UserName = @UserName and Password = @Password";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        connection.Open();

                        object UserIDObj = command.ExecuteScalar();

                        if (UserIDObj != null && int.TryParse(UserIDObj.ToString(), out int ID))
                        {
                            UserID = ID;
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return UserID;
        }

        public static bool IsActive (int UserID)
        {
            bool IsActive = false;


            string Query = @"select Users.IsActive from Users where UserID = @UserID";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        connection.Open();
                            
                        object Activity = command.ExecuteScalar();
                        if (Activity != DBNull.Value && bool.TryParse(Activity.ToString(), out bool active)) 
                            IsActive = active;
                    }

                }


            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                IsActive = false;
            }

            return IsActive;
        }

        public static int GetUserIDByPersonID(int PersonID)
        {
            int UserID = -1;

            string Query = @"select Users.UserID from Users where PersonID = @PersonID";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        connection.Open();
                        object UserIDobj = command.ExecuteScalar();

                        if (UserIDobj != null && int.TryParse(UserIDobj.ToString(), out int ID))
                            UserID = ID;
                    }

                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                UserID = -1;
            }
           

            return UserID;
        }

        public static int GetUserIDByUserName (string UserName)
        {
            int UserID = -1;
            const string Query = @"select Users.UserID from Users where UserName = @UserName";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        connection.Open();

                        object UserIDobj = command.ExecuteScalar();

                        if (UserIDobj != null && int.TryParse(UserIDobj.ToString(), out int ID))
                            UserID = ID;

                    }

                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                UserID = -1;
            }

            return UserID;
        }
    
    }
}
