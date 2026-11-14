using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Applications;
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

namespace DVLD_Presentation.Applications.InternationalDrivingLicense
{
    public partial class frmInternationalDrivingLicense : Form
    {
        private struct _stColumnsName
        {
            public static readonly string None = "None";
            public static readonly string IL_ID = "InternationalLicenseID";
            public static readonly string ApplicationID = "ApplicationID";
            public static readonly string DriverID = "DriverID";
            public static readonly string LDL_ID = "IssuedUsingLocalLicenseID";
            public static readonly string IssueDate = "IssueDate";
            public static readonly string ExpirationDate = "ExpirationDate";
            public static readonly string IsActive = "IsActive";
            public static readonly string CreatedByUserID = "CreatedByUserID";

        }

        private struct _stColumnsHeader
        {
            public static readonly string None = "None";
            public static readonly string IL_ID = "IL ID";
            public static readonly string ApplicationID = "Application ID";
            public static readonly string DriverID = "Driver ID";
            public static readonly string LDL_ID = "LDL ID";
            public static readonly string IssueDate = "Issue Date";
            public static readonly string ExpirationDate = "Expiration Date";
            public static readonly string IsActive = "Is Active";
            public static readonly string CreatedByUserID = "Created By User ID";
        }

        private enum _enFilter { None, IL_ID, ApplicationID, DriverID, LDL_ID, IsActive, CreatedByUserID };
        private _enFilter _FilterMode;

        private string _FilterSelected
        {
            get
            {
                switch (_FilterMode)
                {
                    case _enFilter.IL_ID:
                        return _stColumnsName.IL_ID;

                    case _enFilter.ApplicationID:
                        return _stColumnsName.ApplicationID;

                    case _enFilter.DriverID:
                        return _stColumnsName.DriverID;

                    case _enFilter.LDL_ID:
                        return _stColumnsName.LDL_ID;

                    case _enFilter.IsActive:
                        return _stColumnsName.IsActive;

                    case _enFilter.CreatedByUserID:
                        return _stColumnsName.CreatedByUserID;

                    case _enFilter.None:
                    default:
                        return _stColumnsName.None;
                }
            }
        }

        public frmInternationalDrivingLicense()
        {
            InitializeComponent();
            _FilterMode = _enFilter.None;
            TB_Search.Text = string.Empty;
            TB_Search.Visible = false;
        }

        private void _FillComboBox()
        {
            List<clsUtil.FilterItem<_enFilter>> filterItems = new List<clsUtil.FilterItem<_enFilter>>()
            {
                new clsUtil.FilterItem<_enFilter>(_stColumnsHeader.None, _enFilter.None),
                new clsUtil.FilterItem<_enFilter>(_stColumnsHeader.IL_ID, _enFilter.IL_ID),
                new clsUtil.FilterItem<_enFilter>(_stColumnsHeader.ApplicationID, _enFilter.ApplicationID),
                new clsUtil.FilterItem<_enFilter>(_stColumnsHeader.LDL_ID, _enFilter.LDL_ID),
                new clsUtil.FilterItem<_enFilter>(_stColumnsHeader.DriverID, _enFilter.DriverID),
                new clsUtil.FilterItem<_enFilter>(_stColumnsHeader.IsActive, _enFilter.IsActive)
            };

            CB_Filter.DataSource = filterItems;
            CB_Filter.DisplayMember = "DisplayText";
            CB_Filter.ValueMember = "Value";

            CB_Filter.SelectedValue = _enFilter.None;
        }

        private void _NameColumns()
        {
            if (DGV_IL.ColumnCount > 0)
            {
                DGV_IL.Columns[0].HeaderText = _stColumnsHeader.IL_ID;
                DGV_IL.Columns[1].HeaderText = _stColumnsHeader.ApplicationID;
                DGV_IL.Columns[2].HeaderText = _stColumnsHeader.DriverID;
                DGV_IL.Columns[3].HeaderText = _stColumnsHeader.LDL_ID;
                DGV_IL.Columns[4].HeaderText = _stColumnsHeader.IssueDate;
                DGV_IL.Columns[5].HeaderText = _stColumnsHeader.ExpirationDate;
                DGV_IL.Columns[6].HeaderText = _stColumnsHeader.IsActive;
                DGV_IL.Columns[7].HeaderText = _stColumnsHeader.CreatedByUserID;

                DGV_IL.Columns[7].Visible = false;

                DGV_IL.Columns[1].Width = 140;
                DGV_IL.Columns[4].Width = 150;
                DGV_IL.Columns[5].Width = 150;
            }
        }

        private void frmInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            _FillComboBox();

            DGV_IL.DataSource = clsInternationalDrivingLicenseApplication.GetAll();
            _NameColumns();
            LB_ILCount.Text = DGV_IL.Rows.Count.ToString();
        }

        private void TB_Search_TextChanged(object sender, EventArgs e)
        {
            clsUtil.SearchByNumber(DGV_IL, TB_Search, _FilterSelected);
            clsValidate.SanitizeNumericInput(sender, true);
        }

        private void TB_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.PressOnlyNombers(e, true);
        }

        private void Btn_AddNewIL_Click(object sender, EventArgs e)
        {
            frmAddInternationalDrivingLicense frm = new frmAddInternationalDrivingLicense();
            frm.ShowDialog();

            frmInternationalDrivingLicense_Load(null, null);
        }

        private void DGV_IL_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DGV_IL.CurrentCell = DGV_IL.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (DGV_IL.CurrentRow is null)
                    return;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_IL.CurrentRow is null || !DGV_IL.Columns.Contains(_stColumnsName.DriverID))
                return;

            int driverID = Convert.ToInt32(DGV_IL.CurrentRow.Cells[_stColumnsName.DriverID].Value);

            clsDrivers driver = clsDrivers.Find(driverID);
            if (driver is null)
            {
                MessageBox.Show($"Driver ID {driverID} is Not existed!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmHistoryLicenseInfo frm = new frmHistoryLicenseInfo(driver.PersonID);
            frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_IL.CurrentRow is null || !DGV_IL.Columns.Contains(_stColumnsName.DriverID))
                return;

            int driverID = Convert.ToInt32(DGV_IL.CurrentRow.Cells[_stColumnsName.DriverID].Value);
            clsDrivers driver = clsDrivers.Find(driverID);

            if (driver is null)
            {
                MessageBox.Show($"Driver ID {driverID} is not existed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmPersonalInfo frm = new frmPersonalInfo(driver.PersonID);
            frm.ShowDialog();
        }

        private void CB_Filter_SelectedValueChanged(object sender, EventArgs e)
        {
            TB_Search.Text = string.Empty;

            if (CB_Filter.SelectedValue is _enFilter)
                _FilterMode = (_enFilter)CB_Filter.SelectedValue;

            TB_Search.Visible = (_FilterMode != _enFilter.None);

            if (TB_Search.Visible)
                TB_Search.Focus();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_IL.CurrentRow is null || !DGV_IL.Columns.Contains(_stColumnsName.IL_ID))
                return;

            int il_ID = Convert.ToInt32(DGV_IL.CurrentRow.Cells[_stColumnsName.IL_ID].Value);
            
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(il_ID);
            frm.ShowDialog();
        }
    }
}
