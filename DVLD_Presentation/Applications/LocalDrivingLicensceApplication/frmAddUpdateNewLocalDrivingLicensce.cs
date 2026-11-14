using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Licenses;
using DVLD_BusinessLogicLayer.Tests;
using DVLD_DataAccessLayer;
using DVLD_Presentation.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.LocalDrivingLicensce
{
    public partial class frmAddUpdateNewLocalDrivingLicensce : Form
    {
        private enum _enMode { New, Update }
        _enMode _Mode;

        private int _PersonID;
        private int _LDL_ID;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicense;

        private void _FillLicenseClassComboBox ()
        {
            List<clsUtil.FilterItem<clsLicenseClass.enLicenseClass>> filterItems = new List<clsUtil.FilterItem<clsLicenseClass.enLicenseClass>>();
            DataTable dt = clsLicenseClass.GetAllClassName();

            foreach (DataRow dr in dt.Rows)
            {
                string ClassName = (string)dr["ClassName"];
                clsLicenseClass.enLicenseClass LicenseClassID = (clsLicenseClass.enLicenseClass)Convert.ToInt32(dr["LicenseClassID"]);

                filterItems.Add(new clsUtil.FilterItem<clsLicenseClass.enLicenseClass>(ClassName, LicenseClassID));
            }

            CB_LicenseClass.DataSource = filterItems;
            CB_LicenseClass.DisplayMember = "DisplayText";
            CB_LicenseClass.ValueMember = "Value";
        }

        public frmAddUpdateNewLocalDrivingLicensce()
        {
            InitializeComponent();
            _PersonID = -1;

            _LocalDrivingLicense = new clsLocalDrivingLicenseApplication();
            _Mode = _enMode.New;
        }

        public frmAddUpdateNewLocalDrivingLicensce(int LDL_ID)
        {
            InitializeComponent();
            _LDL_ID = LDL_ID;

            _Mode = _enMode.Update;
        }

        private void frmAddNewLocalDrivingLicensce_Load(object sender, EventArgs e)
        {
            _FillLicenseClassComboBox();

            switch (_Mode)
            {
                case _enMode.New:
                    LB_Title.Text = "Add New Local License Application";
                    _PrepareApplication();
                    break;

                case _enMode.Update:
                    LB_Title.Text = "Update Local License Application";
                    _LocalDrivingLicense = clsLocalDrivingLicenseApplication.Find(_LDL_ID);

                    _LoadDataToScreen();
                    break;
            }


            CB_LicenseClass.Enabled = false;
        }

        private void _PrepareApplication()
        {
            _LocalDrivingLicense.ApplicationTypeID = clsApplicationType.enApplicationType.NewLocal;
            _LocalDrivingLicense.CreatedByUserID = clsGlobal.UserID;
            _LocalDrivingLicense.ApplicantPersonID = _PersonID;

            LB_ApplicationDate.Text = DateTime.Now.ToString();

            if (_LocalDrivingLicense.ApplicationType != null)
                LB_ApplicationFees.Text = _LocalDrivingLicense.ApplicationType.ApplicationTypeFees.ToString();
            else
                LB_ApplicationFees.Text = "Unknown";
            

            if (clsGlobal.User != null)
                LB_CreatedBy.Text = clsGlobal.User.UserName;
            else
                LB_CreatedBy.Text = "Unknown";
        }

        private void _LoadDataToScreen ()
        {
            if (_LocalDrivingLicense is null)
            {
                MessageBox.Show($"This Local driving license ID {_LDL_ID} is not existed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _PersonID = _LocalDrivingLicense.ApplicantPersonID;
            findControl1.LoadData(_PersonID);



            LB_DL_ID.Text = _LocalDrivingLicense.LDL_ID.ToString();
            LB_CreatedBy.Text = _LocalDrivingLicense.ApplicationUser.UserName;
            LB_ApplicationFees.Text = _LocalDrivingLicense.ApplicationType.ApplicationTypeFees.ToString();
            LB_ApplicationDate.Text = _LocalDrivingLicense.ApplicationDate.ToString();

            CB_LicenseClass.SelectedValue = _LocalDrivingLicense.LicenseClassID;
        }

        private void Btn_Next_Click(object sender, EventArgs e)
        {
            if (_PersonID <= 0)
            {
                MessageBox.Show("there is no person found yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CB_LicenseClass.Enabled = (clsTestAppointment.GetAppointmentsByLDL_ID(_LDL_ID).Rows.Count == 0);
            tabControl1.SelectedTab = TP_ApplicationInfo;

        }

        private void findControl1_OnPersonSelected(int obj)
        {
            _PersonID = findControl1.PersonID;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _Save ()
        {
            if (_PersonID <= 0 || CB_LicenseClass.SelectedValue == null)
                return false;

            _LocalDrivingLicense.ApplicantPersonID = _PersonID;
            _LocalDrivingLicense.ApplicationDate = DateTime.Now;
            _LocalDrivingLicense.Status = clsApplication.enStatus.New;
            _LocalDrivingLicense.PaidFees = 0.0f;
            _LocalDrivingLicense.CreatedByUserID = clsGlobal.UserID;
            _LocalDrivingLicense.LicenseClassID = (clsLicenseClass.enLicenseClass)CB_LicenseClass.SelectedValue;
            return _LocalDrivingLicense.Save();
        }
        
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (CB_LicenseClass.SelectedValue == null)
            {
                MessageBox.Show("License Classes is not Loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsHelperMethods.IsValidApplicationSelection(_PersonID , (clsLicenseClass.enLicenseClass)CB_LicenseClass.SelectedValue))
                return;

            if (_Save())
            {
                MessageBox.Show("Person " + _PersonID + " is added successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Person " + _PersonID + " is not added!\nthis choosed class is not existed in database!\n" +
                    "contact with admin to add it or choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}
