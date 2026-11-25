using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DVLD_BusinessLogicLayer
{
    public class clsUser
    {
        public int UserID { get; private set; }
        
        public int PersonID { get; set; }
        private clsPerson _Person = null;
        public clsPerson Person
        {
            get
            {
                if (PersonID <= 0)
                    return null;

                if (_Person == null || _Person.PersonID != PersonID)
                    _Person = clsPerson.Find(PersonID);

                return _Person;
            }
        }

        public string UserName { get; set; }

        private string _Password = string.Empty;
        public string Password 
        {
            get 
            { 
                return _Password; 
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Password = string.Empty;
                    return;
                }

                _Password = clsUtil.HashCompute(value);
            }
        }

        public bool IsActive { get; set; }

        private enum _enMode { Update, AddNew };
        private _enMode _Mode;


        private clsUser (int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this._Password = Password;
            this.IsActive = IsActive;

            _Mode = _enMode.Update;
        }

        public clsUser ()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;

            _Mode = _enMode.AddNew;
        }

        public enum enSaveResult { PersonIDIsNotExisted, PersonAllreadyUser, DBError, SavedSuccessfully }
        private enSaveResult _UpdateUser ()
        {
            return clsUsersAccess.Update(UserID, UserName, Password, IsActive) ? enSaveResult.SavedSuccessfully : enSaveResult.DBError;
        }

        private enSaveResult _AddNewUser ()
        {
            if (!clsPerson.IsExist(PersonID))
                return enSaveResult.PersonIDIsNotExisted;

            int userID = clsUser.GetUserID(PersonID);
            if (userID > 0)
                return enSaveResult.PersonAllreadyUser;

            UserID = clsUsersAccess.AddNewUser(PersonID, UserName, Password, IsActive);

            return (UserID > 0) ? enSaveResult.SavedSuccessfully : enSaveResult.DBError;
            
        }

        public enSaveResult Save()
        {
            switch (_Mode)
            {
                case _enMode.Update:
                {
                    return _UpdateUser();
                }
                case _enMode.AddNew:
                {
                    enSaveResult result = _AddNewUser();
                    if (result == enSaveResult.SavedSuccessfully)
                    {
                        _Mode = _enMode.Update;
                    }
                    return result;
                }
            }

            return enSaveResult.DBError;
        }

        public static clsUser Find (int UserID)
        {
            int PersonID = 0;
            string UserName = "", Password = "";
            bool IsActive = false;

            if (clsUsersAccess.FindByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);

            else
                return null;
        }

        public static clsUser Find (string Username)
        {
            int PersonID = -1, UserID = -1;
            string Password = "";
            bool IsActive = false;

            if (clsUsersAccess.FindByUsername(Username, ref UserID, ref PersonID, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, Username, Password, IsActive);

            else
                return null;
        }

        public static DataTable GetAllUsers ()
        {
            return clsUsersAccess.GetAllUsers();
        }

        public static bool IsExist (int UserID)
        {
            return (clsUsersAccess.GetPersonID(UserID) > 0);
        }

        public static int GetPersonID (int UserID)
        {
            return clsUsersAccess.GetPersonID(UserID);
        }

        public static int GetUserID(string UserName, string Password)
        {
            return clsUsersAccess.GetUserIDByUserNamePassword(UserName, Password);
        }

        public static int GetUserID (int PersonID)
        {
            return clsUsersAccess.GetUserIDByPersonID(PersonID);
        }

        public static int GetUserID (string UserName)
        {
            return clsUsersAccess.GetUserIDByUserName(UserName);
        }
    
        public static bool Delete (int UserID)
        {
            return clsUsersAccess.DeleteUser(UserID);
        }

        public static bool IsUserActive (int UserID)
        {
            return clsUsersAccess.IsActive(UserID);
        }
    }
}
