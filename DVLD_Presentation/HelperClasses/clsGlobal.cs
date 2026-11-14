using System;
using System.Collections.Generic;
using System.Text;
using DVLD_BusinessLogicLayer;
using System.IO;

namespace DVLD_Presentation.HelperClasses
{
    internal class clsGlobal
    {
        private readonly static string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DVLD");
        private readonly static string FilePath = Path.Combine(FolderPath, "UsersSaved.txt");

        private static int _UserID;
        public static int UserID 
        { 
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
                User = clsUser.Find(_UserID);
            }
        }

        public static clsUser User { get; private set; } = null;

        private static void _CreateFileIfNotExist(string FilePath)
        {
            string DirectoryPath = Path.GetDirectoryName(FilePath);

            if (!string.IsNullOrEmpty(DirectoryPath) && !Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

        public static bool GetUserNamePasswordFromFile(out string UserName, out string Password)
        {
          
            UserName = string.Empty;
            Password = string.Empty;

            if (!File.Exists(FilePath))
                return false;

            string[] Lines = File.ReadAllLines(FilePath);

            foreach (string line in Lines)
            {
                if (line.StartsWith("UserName:"))
                {
                    UserName = line.Replace("UserName:", "").Trim();
                }
                else if (line.StartsWith("Password:"))
                {
                    Password = line.Replace("Password:", "").Trim();
                }
            }

            if (!(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password)))
                UserID = clsUser.GetUserID(UserName, Password);

            return UserID > 0;

        }

        public static bool SaveUserNamePasswordInFile(string UserName, string Password)
        {
            _CreateFileIfNotExist(FilePath);

            try
            {
                string Contact = $"UserName: {UserName}\nPassword: {Password}\n----------------------------------\n";

                File.WriteAllText(FilePath, Contact);

                return true;
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public static bool ClearFile ()
        {
            try
            {
                File.WriteAllText(FilePath, string.Empty);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    
    }


}
