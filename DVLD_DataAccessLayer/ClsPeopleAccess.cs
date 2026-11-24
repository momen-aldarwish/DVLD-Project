using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Diagnostics;

namespace DVLD_DataAccessLayer
{
    public class ClsPeopleAccess
    {
        public static bool GetPersonByID (int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
            ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {
            bool IsFound = false;


            string Query = @"SELECT    People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, People.Gendor,
                             People.Address, People.Phone, People.Email, People.NationalityCountryID, 
                                                  People.ImagePath
                             FROM  People
                             where People.PersonID = @PersonID";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                NationalNo = Convert.ToString(reader["NationalNo"]);
                                FirstName = Convert.ToString(reader["FirstName"]);
                                SecondName = Convert.ToString(reader["SecondName"]);
                                ThirdName = Convert.ToString(reader["ThirdName"]);
                                LastName = Convert.ToString(reader["LastName"]);
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                Gender = Convert.ToByte(reader["Gendor"]);
                                Address = Convert.ToString(reader["Address"]);
                                Phone = Convert.ToString(reader["Phone"]);
                                Email = Convert.ToString(reader["Email"]);
                                CountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                                ImagePath = Convert.ToString(reader["ImagePath"]);
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

        public static bool GetPersonByNationalNo (string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName,
            ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {
            bool IsFound = false;

            const string Query = @"SELECT    People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, People.Gendor
                            , People.Address, People.Phone, People.Email, People.NationalityCountryID, 
                                                  People.ImagePath
                            FROM  People
                            where People.NationalNo = @NationalNo;";


            try
            {

                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                PersonID = Convert.ToInt32(reader["PersonID"]);

                                FirstName = Convert.ToString(reader["FirstName"]);
                                SecondName = Convert.ToString(reader["SecondName"]);
                                ThirdName = Convert.ToString(reader["ThirdName"]);
                                LastName = Convert.ToString(reader["LastName"]);
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                Address = Convert.ToString(reader["Address"]);
                                Phone = Convert.ToString(reader["Phone"]);
                                Email = Convert.ToString(reader["Email"]);
                                CountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                                ImagePath = Convert.ToString(reader["ImagePath"]);
                                Gender = Convert.ToByte(reader["Gendor"]);
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

        public static DataTable GetAllPeople ()
        {
            DataTable AllPeople = new DataTable();


            const string Query = @"SELECT    People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, 
                            Gendor =
                            case 
                            when People.Gendor = 0 then 'Male'
                            when People.Gendor = 1 then 'Female'
                            end
                            , People.Phone, People.Address, People.Email, Countries.CountryName, 
                                                  People.ImagePath
                            FROM         People INNER JOIN
                                                  Countries ON People.NationalityCountryID = Countries.CountryID";


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
            catch(Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }
            

            return AllPeople;
        }

        public static bool Update (int PersonID, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int ExecutedRows = -1;

            const string Query = @"Update People
                            set FirstName = @FirstName,
                            SecondName = @SecondName,
                            ThirdName = @ThirdName,
                            LastName = @LastName,
                            DateOfBirth = @DateOfBirth,
                            Gendor = @Gendor,
                            Address = @Address,
                            Phone = @Phone,
                            Email = @Email,
                            NationalityCountryID = @NationalityCountryID,
                            ImagePath = @ImagePath
                            where PersonID = @PersonID;";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@SecondName", SecondName);
                        if (string.IsNullOrEmpty(ThirdName))
                            command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                        else 
                            command.Parameters.AddWithValue("@ThirdName", ThirdName);

                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", (DateTime)DateOfBirth);
                        command.Parameters.AddWithValue("@Gendor", Gendor);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        if (string.IsNullOrEmpty(Email))
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        else
                        command.Parameters.AddWithValue("@Email", Email);

                        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                        
                        if (string.IsNullOrEmpty(ImagePath))
                            command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                        else 
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);
                        
                        
                        command.Parameters.AddWithValue("@PersonID", PersonID);

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
    
        public static bool IsExist (int PersonID)
        {
            bool IsPersonExist = false;


            string Query = @"Select top 1 IsExist = '1' from People where PersonID = @PersonID;";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        connection.Open();

                        object IsExist = command.ExecuteScalar();
                        if (IsExist != null)
                        {
                            IsPersonExist = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                IsPersonExist = false;
            }

            return IsPersonExist;
        }

        public static bool DeletePerson(int PersonID) 
        {
            int RowsEfficted = -1;


            string Query = @"delete from People where PersonID = @PersonID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static int AddNewPerson (string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, 
            DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;


            const string Query = @"Insert into People (NationalNo, FirstName, SecondName, ThirdName, LastName, 
               DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                            values
                            (
                                @NationalNo,
                                @FirstName,
                                @SecondName,
                                @ThirdName,
                                @LastName,
                                @DateOfBirth,
                                @Gendor,
                                @Address,
                                @Phone,
                                @Email,
                                @NationalityCountryID,
                                @ImagePath
                            );
                            
                            select Scope_Identity();";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@SecondName", SecondName);
                        if (string.IsNullOrEmpty(ThirdName))
                            command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                        else 
                            command.Parameters.AddWithValue("@ThirdName", ThirdName);
                        
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gendor", Gendor);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        if (string.IsNullOrEmpty(Email))
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Email", Email);
    
                        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                        if (string.IsNullOrEmpty(ImagePath))
                            command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                        else 
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);

                        connection.Open();

                        object PersonIDobj = command.ExecuteScalar();
                        if (PersonIDobj != null && int.TryParse(PersonIDobj.ToString(), out int ID))
                            PersonID = ID;
                    }

                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

            }

            return PersonID;
        }

        public static bool IsExist(string NationalNo)
        {
            bool IsPersonExist = false;


            const string Query = @"Select top 1 IsExist = '1' from People where NationalNo = @NationalNo;";


            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.DataConnection))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        connection.Open();
                        
                        object IsExist = command.ExecuteScalar();
                        if (IsExist != null)
                        {
                            IsPersonExist = true;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                DataAccessSettings.WriteMessageOnEventViewer(ex.Message, EventLogEntryType.Error);

                IsPersonExist = false;
            }

            return IsPersonExist;
        }

    }

}

    


