using DVLD_DataAccessLayer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace DVLD_BusinessLogicLayer.Tests
{
    public class clsTestType
    {
        public enum enTestType { None = 0, VisionTest = 1, WrittenTest = 2, PracticalTest = 3 }

        public enTestType TestTypeID {  get; private set; }

        public string TestTypeTitle { get; set; }

        public string TestTypeDescription { get; set; }

        public float TestTypeFees { get; set; }

        private clsTestType (enTestType TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeAccess.GetAllApplicationTypes();
        }

        public bool Update ()
        {
            return clsTestTypeAccess.Update((int)TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
        }

        public static clsTestType Find (enTestType TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            float TestTypeFees = 0.0f;

            if (clsTestTypeAccess.Find((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            else
                return null;
        }


    }
}
