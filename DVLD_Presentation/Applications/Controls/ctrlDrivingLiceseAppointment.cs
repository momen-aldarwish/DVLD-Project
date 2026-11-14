using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Licenses;
using DVLD_BusinessLogicLayer.Tests;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.PeopleForms;
using DVLD_Presentation.Tests.SchedualTests.Vision;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls.Applications
{
    public partial class ctrlDrivingLiceseAppointment : UserControl
    {
        public clsLocalDrivingLicenseApplication localDrivingLicensce = null;
        public clsTestType.enTestType TestTypeID { get; private set; }

        public ctrlDrivingLiceseAppointment()
        {
            InitializeComponent();
            TestTypeID = clsTestType.enTestType.None;
        }

        public void LoadData(int LDL_ID, clsTestType.enTestType TestTypeID)
        {
            this.TestTypeID = TestTypeID;
            localDrivingLicensce = clsLocalDrivingLicenseApplication.Find(LDL_ID);

            ctrlDrivingLicenseInfo1.LoadData(localDrivingLicensce);

            _LoadDataToDGV_Appointments();
            return;
        }

        private void _Refresh()
        {
            if (localDrivingLicensce is null || TestTypeID == clsTestType.enTestType.None)
                return;

            LoadData(localDrivingLicensce.LDL_ID, TestTypeID);
        }

        private void _NameCoulumns()
        {
            if (DGV_Appointments.Columns.Count > 0)
            {
                DGV_Appointments.Columns[0].HeaderText = "Test Appointment ID";
                DGV_Appointments.Columns[1].HeaderText = "Local Driving License Application ID";
                DGV_Appointments.Columns[2].Visible = false;
                DGV_Appointments.Columns[3].Visible = false;
                DGV_Appointments.Columns[4].HeaderText = "Appointment Date";
                DGV_Appointments.Columns[5].Visible = false;
                DGV_Appointments.Columns[6].Visible = false;
                DGV_Appointments.Columns[7].HeaderText = "Is Locked";

                DGV_Appointments.Columns[0].Width = 150;
                DGV_Appointments.Columns[1].Width = 230;
                DGV_Appointments.Columns[2].Width = 0;
                DGV_Appointments.Columns[3].Width = 0;
                DGV_Appointments.Columns[4].Width = 200;
                DGV_Appointments.Columns[5].Width = 0;
                DGV_Appointments.Columns[6].Width = 0;
                DGV_Appointments.Columns[7].Width = 90;
            }
        }

        private void _LoadDataToDGV_Appointments()
        {
            if (localDrivingLicensce is null)
                return;

            DGV_Appointments.DataSource = clsTestAppointment.GetAppointmentsByTestType_LDL_IDLicenseClass(TestTypeID, localDrivingLicensce.LDL_ID, localDrivingLicensce.LicenseClassID);
            _NameCoulumns();
        }


        public event Action<int, clsLicenseClass.enLicenseClass> OnAddClick;
        protected virtual void AddClick(int LDL_ID, clsLicenseClass.enLicenseClass LicenseClassID)
        {
            OnAddClick?.Invoke(LDL_ID, LicenseClassID);
        }

        private void Btn_AddAppointment_Click(object sender, EventArgs e)
        {
            if (localDrivingLicensce is null)
            {
                MessageBox.Show("Local driving license not existes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTestAppointment.enAddTestAppointment result = clsTestAppointment.ValidateAddTestAppointment(localDrivingLicensce.LDL_ID, TestTypeID);
            switch (result)
            {
                case clsTestAppointment.enAddTestAppointment.HasActiveAppointment:
                    MessageBox.Show("It already has active appointment!", "Can not add new appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                case clsTestAppointment.enAddTestAppointment.LocalDrivingLicenseNotExisted:
                    MessageBox.Show("There is no local driving license to add appointment on it!", "Can not add new appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                case clsTestAppointment.enAddTestAppointment.PrevTestIsNotPassed:
                    MessageBox.Show("Previous Test is not passed!, Pass it first.", "Can not add new appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                case clsTestAppointment.enAddTestAppointment.TestTypeIsPassed:
                    MessageBox.Show("this test is already passed!", "Can not add new appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

            }
            
            AddClick(localDrivingLicensce.LDL_ID, localDrivingLicensce.LicenseClassID);

            _Refresh();
        }

        private void DGV_Appointments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DGV_Appointments.CurrentCell = DGV_Appointments.Rows[e.RowIndex].Cells[e.ColumnIndex];

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        public event Action<int> OnEditClick;
        protected virtual void EditClick (int AppointmentID)
        {
            OnEditClick?.Invoke(AppointmentID);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_Appointments.CurrentRow is null || !DGV_Appointments.Columns.Contains("TestAppointmentID"))
                return;

            int appointmentID = Convert.ToInt32(DGV_Appointments.CurrentRow.Cells["TestAppointmentID"].Value);

            EditClick(appointmentID);

            _Refresh();
        }

        public event Action<int> OnEndTaskClick;
        protected virtual void EndTaskClick (int TestAppointmentID)
        {
            OnEndTaskClick?.Invoke(TestAppointmentID);
        }

        private void endTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_Appointments.CurrentRow is null || !DGV_Appointments.Columns.Contains("TestAppointmentID"))
                return;

            int appointmentID = Convert.ToInt32(DGV_Appointments.CurrentRow.Cells["TestAppointmentID"].Value);
            EndTaskClick(appointmentID);

            _Refresh();
        }
    }
}
