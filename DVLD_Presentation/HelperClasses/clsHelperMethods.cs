using System;
using System.Collections.Generic;
using System.Text;
using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Licenses;

namespace DVLD_Presentation.HelperClasses
{
    internal class clsHelperMethods
    {
        public static bool IsValidApplicationSelection(int PersonID, clsLicenseClass.enLicenseClass CB_LicenseClass_, bool IsNewApplication = true)
        {
            clsPerson Person = clsPerson.Find(PersonID);

            if (Person == null)
            {
                MessageBox.Show("Person selected is not existed!\nchoose another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (clsLocalDrivingLicenseApplication.IsLicenseClassAppliedOrCompleted(Person.NationalNo, CB_LicenseClass_))
            {
                if (IsNewApplication)
                {
                    MessageBox.Show("Can not add new localdrivinglicense because it's already existed!.\n" +
                        "Please choose another class name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
                else
                {
                    MessageBox.Show("Can not change status because this status is already existed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


            return true;
        }
    
    
    }
}
