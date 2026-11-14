using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Licenses;
using DVLD_Presentation.Applications.InternationalDrivingLicense;
using DVLD_Presentation.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls.License
{
    public partial class ctrlDriverLicenses : UserControl
    {
        public clsPerson Person = null;

        private DataTable LocalDrivingLicenses;

        private DataTable InternationalDrivingLicense;

        public int DriverID { get; private set; }

        private clsDrivers _Driver = null;
        public clsDrivers Driver
        {
            get
            {
                if (DriverID <= 0)
                    return null;

                if (_Driver is null)
                    _Driver = clsDrivers.Find(DriverID);

                return _Driver;
            }
        }

        public ctrlDriverLicenses()
        {
            InitializeComponent();
            LocalDrivingLicenses = new DataTable();
            InternationalDrivingLicense = new DataTable();
        }

        public void LoadData(string NationalNo)
        {
            Person = clsPerson.Find(NationalNo);
            LoadData(Person);
        }

        public void LoadData(int PersonID)
        {
            Person = clsPerson.Find(PersonID);
            LoadData(Person);
        }

        public void LoadData(clsPerson Person)
        {
            if (Person is null)
            {
                MessageBox.Show($"Person is not exist!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LocalDrivingLicenses = clsLicense.GetAllDriverLicenses(Person.PersonID);

            DGV_Local.DataSource = LocalDrivingLicenses;
            LB_Local_Records.Text = LocalDrivingLicenses.Rows.Count.ToString();

            DGV_Local.Columns[0].HeaderText = "License ID";
            DGV_Local.Columns[1].HeaderText = "Application ID";
            DGV_Local.Columns[2].HeaderText = "Issue Date";
            DGV_Local.Columns[3].HeaderText = "Expiration Date";
            DGV_Local.Columns[4].HeaderText = "Is Active";

            DGV_Local.Columns[1].Width = 150;
            DGV_Local.Columns[2].Width = 150;
            DGV_Local.Columns[3].Width = 150;

            DriverID = clsDrivers.GetDriverByPersonID(Person.PersonID);
            InternationalDrivingLicense = clsInternationalDrivingLicenseApplication.GetAll(DriverID);

            DGV_International.DataSource = InternationalDrivingLicense;
            LB_International_Count.Text = InternationalDrivingLicense.Rows.Count.ToString();

            DGV_International.Columns[0].HeaderText = "I.L ID";
            DGV_International.Columns[1].HeaderText = "Application ID";
            DGV_International.Columns[3].HeaderText = "L.L ID";
            DGV_International.Columns[4].HeaderText = "Issue Date";
            DGV_International.Columns[5].HeaderText = "Expiration Date";
            DGV_International.Columns[6].HeaderText = "Is Active";

            DGV_International.Columns[1].Width = 150;
            DGV_International.Columns[4].Width = 150;
            DGV_International.Columns[5].Width = 150;

            DGV_International.Columns[2].Visible = false;
            DGV_International.Columns[7].Visible = false;

        }

        private void DGV_Local_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DGV_Local.CurrentCell = DGV_Local.Rows[e.RowIndex].Cells[e.ColumnIndex];

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void DGV_International_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DGV_International.CurrentCell = DGV_International.Rows[e.RowIndex].Cells[e.ColumnIndex];

                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void licenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DGV_Local.CurrentRow is null)
                return;

            int id = Convert.ToInt32(DGV_Local.CurrentRow.Cells[0].Value);

            frmLicenseInfo frm = new frmLicenseInfo(id, false);
            frm.ShowDialog();
        }

        private void licenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_International.CurrentRow is null)
                return;

            int id = Convert.ToInt32(DGV_International.CurrentRow.Cells[0].Value);

            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(id);
            frm.ShowDialog();
        }

        public void Clear()
        {
            LocalDrivingLicenses.Clear();
            InternationalDrivingLicense.Clear();

            DGV_International.DataSource = null;
            DGV_Local.DataSource = null;
        }


    }
}
