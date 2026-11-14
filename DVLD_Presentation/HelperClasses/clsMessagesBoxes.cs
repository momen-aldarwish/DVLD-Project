using System;
using System.Collections.Generic;
using System.Text;

namespace DVLD_Presentation.HelperClasses
{
    internal static class clsMessagesBoxes
    {
        // ================================================
        // 1. Entity Non-Existed / Not Found Messages
        // ================================================

        public static void PersonDoesNotExist(int personID)
        {
            MessageBox.Show("Person with ID = " + personID + " does not exist.", "Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void PersonDoesNotExist(string nationalNo)
        {
            MessageBox.Show("Person with National No = " + nationalNo + " does not exist.", "Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void UserDoesNotExist(int userID)
        {
            MessageBox.Show("User with ID = " + userID + " does not exist.", "Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void UserDoesNotExist(string username)
        {
            MessageBox.Show("User with Username = " + username + " does not exist.", "Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void ApplicationDoesNotExist(int applicationID)
        {
            MessageBox.Show("Application with ID = " + applicationID + " does not exist.", "Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void LicenseDoesNotExist(int licenseID)
        {
            MessageBox.Show("License with ID = " + licenseID + " does not exist.", "Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void DriverDoesNotExist(int driverID)
        {
            MessageBox.Show("Driver with ID = " + driverID + " does not exist.", "Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        // ================================================
        // 2. People & Users CRUD Operations
        // ================================================

        public static void PersonAddedSuccessfully(int personID)
        {
            MessageBox.Show("Person added successfully with ID = " + personID, "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void FailedToAddPerson()
        {
            MessageBox.Show("Failed to add person. Please check the entered data and try again.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void PersonUpdatedSuccessfully()
        {
            MessageBox.Show("Person details updated successfully.", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void FailedToUpdatePerson()
        {
            MessageBox.Show("Failed to update person information.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ConfirmDeletePerson()
        {
            return MessageBox.Show("Are you sure you want to delete this person?", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }

        public static void DeletePersonRestricted()
        {
            MessageBox.Show("This person cannot be deleted because they have active records or applications linked to them.", "Delete Restricted",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ================================================
        // 3. Local Driving License Applications
        // ================================================

        public static void FailedToLoadData()
        {
            MessageBox.Show("Failed to load _application data. Please try again or contact system admin.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void DuplicateApplicationError()
        {
            MessageBox.Show("This person already has an active _application or license for the selected license class!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void LocalLicenseApplicationCreatedSuccessfully(int applicationID)
        {
            MessageBox.Show("Local driving license _application created successfully with ID = " + applicationID, "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ConfirmCancelApplication()
        {
            return MessageBox.Show("Are you sure you want to cancel this local driving license _application?", "Confirm Cancelation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        // ================================================
        // 4. Tests & License Issuance
        // ================================================

        public static void NotEligibleForLicense(int passedTestCount)
        {
            MessageBox.Show("This applicant has not passed all required tests yet. Passed tests: " + passedTestCount + "/3", "Not Eligible",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void LicenseIssuedSuccessfully(int licenseID)
        {
            MessageBox.Show("License issued successfully with ID = " + licenseID, "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================
        // 5. Validation & General System Errors
        // ================================================

        public static void ValidationError()
        {
            MessageBox.Show("Some required fields are missing or invalid. Please check the highlighted inputs.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void LocalLicenseIsCancelledSuccessfully()
        {
            MessageBox.Show("Local license has been cancelled successfully.", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void LocalLicenseCancellationFailed()
        {
            MessageBox.Show("Failed to cancel the local license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void LocalDrivingLicennseFoundFaild()
        {
            MessageBox.Show("Local Driving License ID does not exist in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
