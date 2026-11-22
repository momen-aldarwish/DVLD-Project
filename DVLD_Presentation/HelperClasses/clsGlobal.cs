using System;
using System.Collections.Generic;
using System.Text;
using DVLD_BusinessLogicLayer;
using System.IO;
using Microsoft.Win32;

namespace DVLD_Presentation.HelperClasses
{
    internal class clsGlobal
    {
        private const string SUB_KEY = @"Software\DVLD";
        private readonly static string HKEY_REGESTERY = @"HKEY_CURRENT_USER\" + SUB_KEY;
        private const string VALUE_USER_NAME = "Username";
        private const string VALUE_PASSWORD = "Password";


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

        public static bool GetUserNamePasswordFromFile(out string UserName, out string Password)
        {
          
            UserName = string.Empty;
            Password = string.Empty;

            try
            {
                UserName = Registry.GetValue(HKEY_REGESTERY, VALUE_USER_NAME, string.Empty) as string;
                Password = Registry.GetValue(HKEY_REGESTERY, VALUE_PASSWORD, string.Empty) as string;

                return (!string.IsNullOrEmpty(UserName) || !string.IsNullOrEmpty(Password));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool SaveUserNamePasswordInFile(string UserName, string Password)
        {
            

            try
            {
                Registry.SetValue(HKEY_REGESTERY, VALUE_USER_NAME, UserName, RegistryValueKind.String);
                Registry.SetValue(HKEY_REGESTERY, VALUE_PASSWORD, Password, RegistryValueKind.String);

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong in save in registry!: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    
        public static bool Clear ()
        {
            try
            {
                using RegistryKey Key = Registry.CurrentUser.OpenSubKey(SUB_KEY, true);
                if (Key is null)
                    return true;

                Key.DeleteValue(VALUE_USER_NAME, false);
                Key.DeleteValue(VALUE_PASSWORD, false);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }


}
