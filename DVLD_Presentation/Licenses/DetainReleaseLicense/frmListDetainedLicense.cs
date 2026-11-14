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

namespace DVLD_Presentation.Applications.ReleaseDetainLicense
{
    public partial class frmListDetainedLicense : Form
    {
        private enum _enFilter { None = 0, D_ID, L_ID, N_No, FullName, ReleasedAppID }
        private struct stColumnName
        {
            public static string None = "None";
            public static string D_ID = "DetainID";
            public static string L_ID = "LicenseID";
            public static string N_No = "NationalNo";
            public static string FullName = "FullName";
            public static string ReleasedAppID = "ReleaseApplicationID";
            public static string IsReleased = "IsReleased";
        }

        private bool IsNumber
        {
            get
            {
                if (CB_FilterBy.SelectedValue is null || CB_FilterBy.SelectedValue is not _enFilter)
                    return false;

                switch (CB_FilterBy.SelectedValue)
                {
                    case _enFilter.D_ID:
                    case _enFilter.L_ID:
                    case _enFilter.ReleasedAppID:
                        return true;

                    default:
                        return false;
                }

            }
        }
        private void _ManageComboBox()
        {
            List<clsUtil.FilterItem<_enFilter>> filter = new List<clsUtil.FilterItem<_enFilter>>
            {
                new clsUtil.FilterItem<_enFilter> (stColumnName.None, _enFilter.None),
                new clsUtil.FilterItem<_enFilter> (stColumnName.D_ID, _enFilter.D_ID),
                new clsUtil.FilterItem<_enFilter> (stColumnName.L_ID, _enFilter.L_ID),
                new clsUtil.FilterItem<_enFilter> (stColumnName.N_No, _enFilter.N_No),
                new clsUtil.FilterItem<_enFilter> (stColumnName.FullName, _enFilter.FullName),
                new clsUtil.FilterItem<_enFilter> (stColumnName.ReleasedAppID, _enFilter.ReleasedAppID)
            };

            CB_FilterBy.DisplayMember = "DisplayText";
            CB_FilterBy.ValueMember = "Value";

            CB_FilterBy.DataSource = filter;


            CB_FilterBy.SelectedValue = _enFilter.None;
            TB_Search.Visible = false;
        }

        public frmListDetainedLicense()
        {
            InitializeComponent();
        }

        private void frmListDetainedLicense_Load(object sender, EventArgs e)
        {
            _ManageComboBox();
            dataGridView1.DataSource = clsDetainedLicense.GetAllDetainedLicenses();

            if (dataGridView1.ColumnCount > 0)
            {
                dataGridView1.Columns[0].HeaderText = "D ID";
                dataGridView1.Columns[1].HeaderText = "L ID";
                dataGridView1.Columns[2].HeaderText = "D Date";
                dataGridView1.Columns[3].HeaderText = "Is Released";
                dataGridView1.Columns[4].HeaderText = "Fine Fees";
                dataGridView1.Columns[5].HeaderText = "Released Date";
                dataGridView1.Columns[6].HeaderText = "N.No";
                dataGridView1.Columns[7].HeaderText = "Full Name";
                dataGridView1.Columns[8].HeaderText = "Released App ID";

                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Width = 180;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 180;
                dataGridView1.Columns[6].Width = 80;
                dataGridView1.Columns[7].Width = 200;




            }
        }

        private void TB_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.PressOnlyNombers(e, IsNumber);
        }

        private void TB_Search_TextChanged(object sender, EventArgs e)
        {
            clsValidate.SanitizeNumericInput(TB_Search, IsNumber);

            if (IsNumber)
                clsUtil.SearchByNumber(dataGridView1, TB_Search, CB_FilterBy.Text);
            else
                clsUtil.SearchByString(dataGridView1, TB_Search, CB_FilterBy.Text);
        }

        private void Btn_Detain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();

            frmListDetainedLicense_Load(null, null);
        }

        private void Btn_Release_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();

            frmListDetainedLicense_Load(null, null);
        }

        private void CB_FilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_Search.Text = string.Empty;
            if (CB_FilterBy.ValueMember is null || CB_FilterBy.SelectedValue is not _enFilter)
                return;

            TB_Search.Visible = ((_enFilter)CB_FilterBy.SelectedValue != _enFilter.None);

            if (TB_Search.Visible)
                TB_Search.Focus();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (dataGridView1.CurrentRow is not null && dataGridView1.Columns.Contains(stColumnName.IsReleased))
                {
                    releaseToolStripMenuItem.Enabled = !Convert.ToBoolean(dataGridView1.CurrentRow.Cells[stColumnName.IsReleased].Value);
                }
                    

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow is null || !dataGridView1.Columns.Contains(stColumnName.D_ID))
                return;

            int detainID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[stColumnName.D_ID].Value);
            frmReleaseLicense frm = new frmReleaseLicense(detainID);
            frm.ShowDialog();

            frmListDetainedLicense_Load(null, null);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow is null || !dataGridView1.Columns.Contains(stColumnName.N_No))
                return;

            string NationalNo = Convert.ToString(dataGridView1.CurrentRow.Cells[stColumnName.N_No].Value);
            frmPersonalInfo frm = new frmPersonalInfo(NationalNo);
            frm.ShowDialog();
        }

        private void showLicenseDetaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow is null || !dataGridView1.Columns.Contains(stColumnName.L_ID))
                return;

            int l_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[stColumnName.L_ID].Value);
            frmLicenseInfo frm = new frmLicenseInfo(l_ID, false);
            frm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow is null || !dataGridView1.Columns.Contains(stColumnName.N_No))
                return;

            string NationalNo = Convert.ToString(dataGridView1.CurrentRow.Cells[stColumnName.N_No].Value);

            frmHistoryLicenseInfo frm = new frmHistoryLicenseInfo(NationalNo);
            frm.ShowDialog();
        }
    }
}
