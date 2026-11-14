using DVLD_BusinessLogicLayer;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.Licenses;
using DVLD_Presentation.PeopleForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.Drivers
{
    public partial class frmDrivers : Form
    {
        private enum _enFilter { None, DriverID, PersonID, NationalNo, FullName }
        private struct _stFilter
        {
            public static readonly string None = "None";
            public static readonly string DriverID = "ID";
            public static readonly string PersonID = "PersonID";
            public static readonly string NationalNo = "NationalNo";
            public static readonly string FullName = "FirstName";
        }
        private bool _IsTextBoxNumber
        {
            get
            {
                if (CB_FilterBy.SelectedValue == null)
                    return false;

                switch (CB_FilterBy.SelectedValue)
                {
                    case _enFilter.DriverID:
                    case _enFilter.PersonID:
                        return true;

                    default:
                        return false;
                }

            }
        }

        public frmDrivers()
        {
            InitializeComponent();
        }

        private void frmDrivers_Load(object sender, EventArgs e)
        {
            List<clsUtil.FilterItem<_enFilter>> filter = new List<clsUtil.FilterItem<_enFilter>>
            {
                new clsUtil.FilterItem<_enFilter> (_stFilter.None, _enFilter.None),
                new clsUtil.FilterItem<_enFilter> (_stFilter.DriverID, _enFilter.DriverID),
                new clsUtil.FilterItem<_enFilter> (_stFilter.PersonID, _enFilter.PersonID),
                new clsUtil.FilterItem<_enFilter> (_stFilter.NationalNo, _enFilter.NationalNo),
                new clsUtil.FilterItem<_enFilter> (_stFilter.FullName, _enFilter.FullName)
            };

            CB_FilterBy.DisplayMember = "DisplayText";
            CB_FilterBy.ValueMember = "Value";

            CB_FilterBy.DataSource = filter;


            CB_FilterBy.SelectedValue = _enFilter.None;
            TB_Search.Visible = false;

            DGV_Drivers.DataSource = clsDrivers.GetAllDrivers();

            LB_Count.Text = DGV_Drivers.Rows.Count.ToString();
        }

        private void _None()
        {
            TB_Search.Text = string.Empty;
            TB_Search.Visible = false;

            (DGV_Drivers.DataSource as DataTable).DefaultView.RowFilter = "";
        }

        private void _ProcessSearch()
        {
            if (DGV_Drivers.DataSource == null)
                return;

            switch (CB_FilterBy.SelectedValue)
            {
                case _enFilter.None:
                    _None();
                    break;

                case _enFilter.DriverID:
                    clsUtil.SearchByNumber(DGV_Drivers, TB_Search, _stFilter.DriverID);
                    break;

                case _enFilter.PersonID:
                    clsUtil.SearchByNumber(DGV_Drivers, TB_Search, _stFilter.PersonID);
                    break;

                case _enFilter.NationalNo:
                    clsUtil.SearchByString(DGV_Drivers, TB_Search, _stFilter.NationalNo);
                    break;

                case _enFilter.FullName:
                    clsUtil.SearchByString(DGV_Drivers, TB_Search, _stFilter.FullName);
                    break;
            }

            LB_Count.Text = DGV_Drivers.Rows.Count.ToString();
        }

        private void TB_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CB_FilterBy.SelectedValue == null)
                return;

            clsValidate.PressOnlyNombers(e, _IsTextBoxNumber);
        }

        private void TB_Search_TextChanged(object sender, EventArgs e)
        {
            if (CB_FilterBy.SelectedValue == null)
                return;

            clsValidate.SanitizeNumericInput(sender, _IsTextBoxNumber);

            _ProcessSearch();
        }

        private void CB_FilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_FilterBy.SelectedValue == null)
                return;

            TB_Search.Visible = ((_enFilter)CB_FilterBy.SelectedValue != _enFilter.None);

            TB_Search.Text = string.Empty;

            if (TB_Search.Visible)
                TB_Search.Focus();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_Drivers.CurrentRow is null || !DGV_Drivers.Columns.Contains("PersonID"))
                return;

            int personID = Convert.ToInt32(DGV_Drivers.CurrentRow.Cells["PersonID"].Value);
            frmPersonalInfo frm = new frmPersonalInfo(personID);
            frm.ShowDialog();
        }

        private void licenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_Drivers.CurrentRow is null || !DGV_Drivers.Columns.Contains("PersonID"))
                return;

            int personID = Convert.ToInt32(DGV_Drivers.CurrentRow.Cells["PersonID"].Value);
            frmHistoryLicenseInfo frm = new frmHistoryLicenseInfo(personID);
            frm.ShowDialog();
        }

        private void DGV_Drivers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DGV_Drivers.CurrentCell = DGV_Drivers.Rows[e.RowIndex].Cells[e.ColumnIndex];

                contextMenuStrip1.Show(Cursor.Position);
            }
        }


    }
}
