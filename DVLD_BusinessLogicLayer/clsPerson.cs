using DVLD_DataAccessLayer;
using System.Data;
namespace DVLD_BusinessLogicLayer
{
    public class clsPerson
    {
        public int PersonID { get; private set; }

        public string NationalNo { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return string.Format($"{FirstName} {SecondName} {ThirdName} {LastName}");
            }
        }

        public DateTime DateOfBirth { get; set; }

        public enum enGendor { Male = 0, Female = 1 }
        public enGendor Gender { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int CountryID { get; set; }

        private clsCountry _Country = null;
        public clsCountry Country 
        { 
            get
            {
                if (CountryID <= 0)
                    return null;

                if (_Country is null || _Country.CountryID != CountryID)
                    _Country = clsCountry.Find(CountryID);

                return _Country;
            }
        }

        public string ImagePath { get; set; }

        private enum _enMode { Update, AddNewPerson }
        private _enMode _Mode;

        private clsPerson (int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            enGendor Gender, string Address, string Phone, string Email, int CountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.ImagePath = ImagePath;
            this.CountryID = CountryID;

            _Mode = _enMode.Update;

        }

        public clsPerson()
        {
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = enGendor.Male;
            Address = "";
            Phone = "";
            Email = "";
            ImagePath = "";

            _Mode = _enMode.AddNewPerson;
        }

        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "",
                Address = "", Email = "", ImagePath = "";

            byte Gender = 0;

            int CountryID = -1;

            DateTime DateOfBirth = DateTime.Now;

            bool IsFound = ClsPeopleAccess.GetPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath);

            if (IsFound)
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName,
                LastName, DateOfBirth, (enGendor)Gender, Address, Phone, Email, CountryID, ImagePath);
            }
            else
                return null;
            
        }

        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "",
                Email = "", ImagePath = "";
            byte Gender = 0;
            int CountryID = -1;

            DateTime DateOfBirth = DateTime.Now;

            if (ClsPeopleAccess.GetPersonByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, (enGendor)Gender, Address, Phone, Email, CountryID, ImagePath);
            }
            else
                return null;
        }

        public static DataTable GetAllPeople()
        {
            return ClsPeopleAccess.GetAllPeople();
        }

        public static bool IsExist (int PersonID)
        {
            return ClsPeopleAccess.IsExist(PersonID);
        }
        
        public static bool IsExist (string NationalNo)
        {
            return ClsPeopleAccess.IsExist(NationalNo);
        }

        public static bool DeletePerson (int PersonID)
        {
            return ClsPeopleAccess.DeletePerson(PersonID);
        }

        public enum enSaveResult { NationalNoAlreadyExist, DBError, SavedSuccessfully }
        private enSaveResult _Update ()
        {
            return (ClsPeopleAccess.Update(PersonID, FirstName, SecondName, ThirdName, LastName,
                DateOfBirth, (byte)Gender, Address, Phone, Email, CountryID, ImagePath)) ? enSaveResult.SavedSuccessfully : enSaveResult.DBError;
        }

        private enSaveResult _AddNewPerson ()
        {
            if (IsExist(NationalNo))
                return enSaveResult.NationalNoAlreadyExist;

            this.PersonID = ClsPeopleAccess.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth
                , (byte)Gender, Address, Phone, Email, CountryID, ImagePath);

            return (PersonID > 0) ? enSaveResult.SavedSuccessfully : enSaveResult.DBError;
        }

        public enSaveResult Save ()
        {
            switch (_Mode)
            {
                case _enMode.Update:
                    return _Update();

                case _enMode.AddNewPerson:
                {
                        enSaveResult result = _AddNewPerson();
                    if (result == enSaveResult.SavedSuccessfully)
                    {
                        _Mode = _enMode.Update;
                    }
                    return result;
                }
            }

            return enSaveResult.DBError;
        }
    
    
    }
}
