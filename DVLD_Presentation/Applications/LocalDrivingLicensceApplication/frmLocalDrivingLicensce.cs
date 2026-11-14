using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Applications;
using DVLD_BusinessLogicLayer.Tests;
using DVLD_Presentation.Applications.LocalDrivingLicensce;
using DVLD_Presentation.Applications.SchedualTests;
using DVLD_Presentation.ApplicationTypes;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.Licenses;
using DVLD_Presentation.Tests.SchedualTests.Practical;
using DVLD_Presentation.Tests.SchedualTests.Written;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.LocalDrivingLicensce
{
    public partial class frmLocalDrivingLicensce : Form
    {
        private enum _enFilterMode { None, NationalNo, LDL_ID }
        private struct _stFilter
        {
            public static readonly string None = "None";
            public static readonly string NationalNo = "NationalNo";
            public static readonly string LDL_ID = "LDLID";
        }

        private bool _IsTextNumber
        {
            get
            {
                if (CB_Filter.SelectedValue == null)
                    return false;

                return ((_enFilterMode)CB_Filter.SelectedValue == _enFilterMode.LDL_ID);
            }
        }

        private void _FillComboBox()
        {
            List<clsUtil.FilterItem<_enFilterMode>> filters = new List<clsUtil.FilterItem<_enFilterMode>>
            {
                new clsUtil.FilterItem<_enFilterMode> (_stFilter.None, _enFilterMode.None),
                new clsUtil.FilterItem<_enFilterMode> (_stFilter.NationalNo, _enFilterMode.NationalNo),
                new clsUtil.FilterItem<_enFilterMode> (_stFilter.LDL_ID, _enFilterMode.LDL_ID)
            };

            CB_Filter.DataSource = filters;
            CB_Filter.DisplayMember = "DisplayText";
            CB_Filter.ValueMember = "Value";

            CB_Filter.SelectedValue = _enFilterMode.None;
        }

        public frmLocalDrivingLicensce()
        {
            InitializeComponent();

            TB_Search.Visible = false;
        }

        private void _ValidateProcessShow(int LDL_ID)
        {
            clsTestType.enTestType TestTypeID = clsTest.GetLastPassedTestTypeByLDL_ID(LDL_ID);


            switch (TestTypeID)
            {
                case clsTestType.enTestType.None:
                    visionToolStripMenuItem.Enabled = true;
                    schedualWrittenTestToolStripMenuItem.Enabled = false;
                    schedualStreetTestToolStripMenuItem.Enabled = false;
                    IssueDrivingLicensetoolStripMenuItem1.Enabled = false;
                    cancelledToolStripMenuItem.Enabled = true;
                    ShowLicenseDrivingtoolStripMenuItem.Enabled = false;
                    ShowLicenseDrivingHistorytoolStripMenuItem3.Enabled = false;
                    updateToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;


                    break;

                case clsTestType.enTestType.VisionTest:
                    visionToolStripMenuItem.Enabled = false;
                    schedualWrittenTestToolStripMenuItem.Enabled = true;
                    schedualStreetTestToolStripMenuItem.Enabled = false;
                    IssueDrivingLicensetoolStripMenuItem1.Enabled = false;
                    cancelledToolStripMenuItem.Enabled = true;
                    ShowLicenseDrivingtoolStripMenuItem.Enabled = false;
                    ShowLicenseDrivingHistorytoolStripMenuItem3.Enabled = false;
                    updateToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                    break;

                case clsTestType.enTestType.WrittenTest:
                    visionToolStripMenuItem.Enabled = false;
                    schedualWrittenTestToolStripMenuItem.Enabled = false;
                    schedualStreetTestToolStripMenuItem.Enabled = true;
                    IssueDrivingLicensetoolStripMenuItem1.Enabled = false;
                    cancelledToolStripMenuItem.Enabled = true;
                    ShowLicenseDrivingtoolStripMenuItem.Enabled = false;
                    ShowLicenseDrivingHistorytoolStripMenuItem3.Enabled = false;
                    updateToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                    break;

                case clsTestType.enTestType.PracticalTest:
                default:
                    visionToolStripMenuItem.Enabled = false;
                    schedualWrittenTestToolStripMenuItem.Enabled = false;
                    schedualStreetTestToolStripMenuItem.Enabled = false;
                    cancelledToolStripMenuItem.Enabled = false;
                    updateToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;

                    clsLocalDrivingLicenseApplication LDL = clsLocalDrivingLicenseApplication.Find(LDL_ID);
                    if (LDL.Status == clsLocalDrivingLicenseApplication.enStatus.Completed)
                    {
                        IssueDrivingLicensetoolStripMenuItem1.Enabled = false;
                        ShowLicenseDrivingtoolStripMenuItem.Enabled = true;
                        ShowLicenseDrivingHistorytoolStripMenuItem3.Enabled = true;
                    }
                    else
                    {
                        IssueDrivingLicensetoolStripMenuItem1.Enabled = true;
                        ShowLicenseDrivingtoolStripMenuItem.Enabled = false;
                        ShowLicenseDrivingHistorytoolStripMenuItem3.Enabled = false;
                    }
                    break;

            }

        }

        private void _NameColumns()
        {
            if (DGV_LDL.Rows.Count == 0)
            {
                MessageBox.Show("There are no data to show up on table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DGV_LDL.Columns[0].HeaderText = "LDL ID";
            DGV_LDL.Columns[1].HeaderText = "Class Driving";
            DGV_LDL.Columns[2].HeaderText = "Full Name";
            DGV_LDL.Columns[3].HeaderText = "National No";
            DGV_LDL.Columns[4].HeaderText = "Application Date";
            DGV_LDL.Columns[5].HeaderText = "Passed Test Count";
            DGV_LDL.Columns[6].HeaderText = "Application Status";

            DGV_LDL.Columns[0].Width = 60;
            DGV_LDL.Columns[1].Width = 300;
            DGV_LDL.Columns[2].Width = 300;
            DGV_LDL.Columns[3].Width = 120;
            DGV_LDL.Columns[4].Width = 100;
            DGV_LDL.Columns[5].Width = 60;
            DGV_LDL.Columns[6].Width = 100;

        }

        private void _LoadData()
        {
            DGV_LDL.DataSource = clsLocalDrivingLicenseApplication.GetAll();

            if (DGV_LDL.DataSource != null)
                LB_LDLCount.Text = DGV_LDL.Rows.Count.ToString();

            else
                LB_LDLCount.Text = "0";
        }

        private void LDLApplication_Load(object sender, EventArgs e)
        {
            _FillComboBox();

            _LoadData();

            _NameColumns();

            CB_Filter.SelectedValue = _enFilterMode.None;
        }

        private void DGV_LDL_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DGV_LDL.CurrentCell = DGV_LDL.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (DGV_LDL.CurrentRow is null)
                    return;

                int LDL_ID = Convert.ToInt32(DGV_LDL.CurrentRow.Cells[0].Value);
                _ValidateProcessShow(LDL_ID);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void _None()
        {
            TB_Search.Text = string.Empty;
            (DGV_LDL.DataSource as DataTable).DefaultView.RowFilter = "";
        }

        private void _ProcesSearchInFilter()
        {
            if (CB_Filter.SelectedValue is null || DGV_LDL.DataSource is null)
                return;

            switch (CB_Filter.SelectedValue)
            {

                case _enFilterMode.LDL_ID:
                    clsUtil.SearchByNumber(DGV_LDL, TB_Search, _stFilter.LDL_ID);
                    break;

                case _enFilterMode.NationalNo:
                    clsUtil.SearchByString(DGV_LDL, TB_Search, _stFilter.NationalNo);
                    break;

                case _enFilterMode.None:
                default:
                    _None();
                    break;
            }

            LB_LDLCount.Text = DGV_LDL.Rows.Count.ToString();
        }

        private void TB_Search_TextChanged(object sender, EventArgs e)
        {
            clsValidate.SanitizeNumericInput(sender, _IsTextNumber);
            _ProcesSearchInFilter();
        }

        private void TB_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.PressOnlyNombers(e, _IsTextNumber);
        }

        private void CB_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Filter.SelectedValue == null || !(CB_Filter.SelectedValue is _enFilterMode))
                return;

            TB_Search.Visible = ((_enFilterMode)CB_Filter.SelectedValue != _enFilterMode.None);
            TB_Search.Text = string.Empty;

            _ProcesSearchInFilter();

            if (TB_Search.Visible)
                TB_Search.Focus();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_LDL.CurrentRow == null)
                return;

            int LDL_ID = Convert.ToInt32(DGV_LDL.CurrentRow.Cells[0].Value);

            frmAddUpdateNewLocalDrivingLicensce frm = new frmAddUpdateNewLocalDrivingLicensce(LDL_ID);

            frm.ShowDialog();

            _LoadData();
        }

        private void cancelledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_LDL.CurrentRow == null)
                return;

            int LDL_ID = Convert.ToInt32(DGV_LDL.CurrentRow.Cells[0].Value);
            bool Confirm = clsMessagesBoxes.ConfirmCancelApplication();

            if (Confirm)
            {
                if (clsLocalDrivingLicenseApplication.Cancel(LDL_ID))
                    clsMessagesBoxes.LocalLicenseIsCancelledSuccessfully();
                else
                    clsMessagesBoxes.LocalLicenseCancellationFailed();

                _LoadData();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_LDL.CurrentRow is null)
                return;

            int LDL_ID = Convert.ToInt32(DGV_LDL.CurrentRow.Cells[0].Value);

            DialogResult result = MessageBox.Show($"Are you sure you want to delete {LDL_ID}?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            clsLocalDrivingLicenseApplication.enDeleteResult DeleteResult = clsLocalDrivingLicenseApplication.Delete(LDL_ID);

            switch (DeleteResult)
            {
                case clsLocalDrivingLicenseApplication.enDeleteResult.LocalDrivingLicenseNotFound:
                    MessageBox.Show("local driving license is not found!", "local delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsLocalDrivingLicenseApplication.enDeleteResult.StatusAcceptionFaild:
                    MessageBox.Show($"can not delete it because it's not cancelled status!,\n" +
                    $" if you want to delete it cancel the application", "local delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsLocalDrivingLicenseApplication.enDeleteResult.DoesHaveAppointmentsActive:
                    MessageBox.Show("this Application has appointments,", "local delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsLocalDrivingLicenseApplication.enDeleteResult.DeleteCompletedSuccessfully:
                    MessageBox.Show("local application has been deleted successfully", "local delete successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadData();
                    break;

                case clsLocalDrivingLicenseApplication.enDeleteResult.DeleteFailedFromDB:
                default:
                    MessageBox.Show("local application is not deleted!,\n" +
                        "On the probably the problem from database.", "local delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }

        private void Btn_AddNewLDL_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewLocalDrivingLicensce frm = new frmAddUpdateNewLocalDrivingLicensce();
            frm.ShowDialog();

            _LoadData();
        }

        private void visionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_LDL.CurrentRow == null)
                return;

            int LDL_ID = Convert.ToInt32(DGV_LDL.CurrentRow.Cells[0].Value);

            frmVision frm = new frmVision(LDL_ID);
            frm.ShowDialog();

            _LoadData();
        }

        private void schedualWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_LDL.CurrentRow is null)
                return;

            int LDL_ID = Convert.ToInt32(DGV_LDL.CurrentRow.Cells[0].Value);

            frmWritten frm = new frmWritten(LDL_ID);
            frm.ShowDialog();

            _LoadData();
        }

        private void schedualStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_LDL.CurrentRow is null)
                return;

            int LDL_ID = Convert.ToInt32(DGV_LDL.CurrentRow.Cells[0].Value);
            frmPractical frm = new frmPractical(LDL_ID);
            frm.ShowDialog();

            _LoadData();
        }

        private void IssueDrivingLicensetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DGV_LDL.CurrentRow is null)
                return;

            int LDL_ID = Convert.ToInt32(DGV_LDL.CurrentRow.Cells[0].Value);

            frmIssueLicense frm = new frmIssueLicense(LDL_ID);
            frm.ShowDialog();

            _LoadData();
        }

        private void ShowLicenseDrivingtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_LDL.CurrentRow is null)
                return;

            int LDL_ID = Convert.ToInt32(DGV_LDL.CurrentRow.Cells[0].Value);

            frmLicenseInfo frm = new frmLicenseInfo(LDL_ID);
            frm.ShowDialog();
        }

        private void ShowLicenseDrivingHistorytoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (DGV_LDL.CurrentRow is null || !DGV_LDL.Columns.Contains(_stFilter.NationalNo))
                return;

            string NationalNo = Convert.ToString(DGV_LDL.CurrentRow.Cells[_stFilter.NationalNo].Value);

            if (string.IsNullOrEmpty(NationalNo))
                return;

            frmHistoryLicenseInfo frm = new frmHistoryLicenseInfo(NationalNo);
            frm.ShowDialog();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_LDL.CurrentRow is null)
                return;

            int LDL_ID = Convert.ToInt32(DGV_LDL.CurrentRow.Cells[0].Value);
            frmShowLocalApplicationDetails frm = new frmShowLocalApplicationDetails(LDL_ID);
            frm.ShowDialog();
        }
    }
}
