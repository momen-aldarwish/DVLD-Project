using DVLD_BusinessLogicLayer;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.PeopleForms;
using DVLD_Presentation.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD_Presentation
{
    public partial class frmPeopleWindow : Form
    {
        private enum _enFilter { None, PersonID, NationalNo, FullName, Phone, Email, CountryName }
        private struct _stFilter
        {
            public static readonly string None = "None";
            public static readonly string PersonID = "PersonID";
            public static readonly string NationalNo = "NationalNo";
            public static readonly string FullName = "FirstName";
            public static readonly string Phone = "Phone";
            public static readonly string Email = "Email";
            public static readonly string CountryName = "CountryName";
        }

        private struct _stFilterHeader
        {
            public static readonly string None = "None";
            public static readonly string PersonID = "Person ID";
            public static readonly string NationalNo = "National No";
            public static readonly string FirstName = "First Name";
            public static readonly string SecondName = "Second Name";
            public static readonly string ThirdName = "Third Name";
            public static readonly string LastName = "Last Name";
            public static readonly string DateOfBirth = "Date Of Birth";
            public static readonly string Gendor = "Gendor";
            public static readonly string Phone = "Phone";
            public static readonly string Email = "Email";
            public static readonly string CountryName = "Country Name";
        }

        private bool _IsTextOnlyNumber
        {
            get
            {
                if (CB_Filter.SelectedValue == null)
                    return false;

                return ((_enFilter)CB_Filter.SelectedValue == _enFilter.PersonID);
            }
        }

        public frmPeopleWindow()
        {
            InitializeComponent();
        }

        private void _FillComboBox()
        {
            List<clsUtil.FilterItem<_enFilter>> filter = new List<clsUtil.FilterItem<_enFilter>>
            {
                new clsUtil.FilterItem<_enFilter>(_stFilterHeader.None, _enFilter.None),
                new clsUtil.FilterItem<_enFilter>(_stFilterHeader.PersonID, _enFilter.PersonID),
                new clsUtil.FilterItem<_enFilter>(_stFilterHeader.NationalNo, _enFilter.NationalNo),
                new clsUtil.FilterItem<_enFilter>(_stFilterHeader.FirstName, _enFilter.FullName),
                new clsUtil.FilterItem<_enFilter>(_stFilterHeader.Phone, _enFilter.Phone),
                new clsUtil.FilterItem<_enFilter>(_stFilterHeader.Email, _enFilter.Email),
                new clsUtil.FilterItem<_enFilter>(_stFilterHeader.CountryName, _enFilter.CountryName)
            };

            CB_Filter.DisplayMember = "DisplayText";
            CB_Filter.ValueMember = "Value";

            CB_Filter.DataSource = filter;
        }

        private void frmPeopleWindow_Load(object sender, EventArgs e)
        {
            _FillComboBox();

            _LoadData();

        }

        private void _LoadData()
        {
            DGV_GroupOfPeople.DataSource = clsPerson.GetAllPeople();
            LB_CountPeople.Text = DGV_GroupOfPeople.Rows.Count.ToString();

            if (DGV_GroupOfPeople.Columns.Count <= 0)
                return;

            DGV_GroupOfPeople.Columns[0].HeaderText = _stFilterHeader.PersonID;
            DGV_GroupOfPeople.Columns[1].HeaderText = _stFilterHeader.NationalNo;
            DGV_GroupOfPeople.Columns[2].HeaderText = _stFilterHeader.FirstName;
            DGV_GroupOfPeople.Columns[3].HeaderText = _stFilterHeader.SecondName;
            DGV_GroupOfPeople.Columns[4].HeaderText = _stFilterHeader.ThirdName;
            DGV_GroupOfPeople.Columns[5].HeaderText = _stFilterHeader.LastName;
            DGV_GroupOfPeople.Columns[6].HeaderText = _stFilterHeader.DateOfBirth;
            DGV_GroupOfPeople.Columns[7].HeaderText = _stFilterHeader.Gendor;
            DGV_GroupOfPeople.Columns[8].HeaderText = _stFilterHeader.Phone;
            DGV_GroupOfPeople.Columns[10].HeaderText = _stFilterHeader.Email;
            DGV_GroupOfPeople.Columns[11].HeaderText = _stFilterHeader.CountryName;

            DGV_GroupOfPeople.Columns[12].Visible = false;
            DGV_GroupOfPeople.Columns[9].Visible = false;

            DGV_GroupOfPeople.Columns[0].Width = 100;
            DGV_GroupOfPeople.Columns[1].Width = 130;
            DGV_GroupOfPeople.Columns[2].Width = 150;
            DGV_GroupOfPeople.Columns[3].Width = 150;
            DGV_GroupOfPeople.Columns[4].Width = 150;
            DGV_GroupOfPeople.Columns[5].Width = 150;
            DGV_GroupOfPeople.Columns[6].Width = 150;
            DGV_GroupOfPeople.Columns[7].Width = 100;
            DGV_GroupOfPeople.Columns[8].Width = 100;
            DGV_GroupOfPeople.Columns[10].Width = 200;
            DGV_GroupOfPeople.Columns[11].Width = 100;
        }

        public void Btn_FindPerson_OnClick(object sender, EventArgs e)
        {
            frmFindPerson form = new frmFindPerson();
            form.ShowDialog();
        }

        private void Btn_AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();
            form.ShowDialog();

            this._LoadData();
        }

        private void DGV_GroupOfPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DGV_GroupOfPeople.CurrentCell = DGV_GroupOfPeople.Rows[e.RowIndex].Cells[e.ColumnIndex];

                CMS_More.Show(Cursor.Position);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_GroupOfPeople.CurrentRow == null || !DGV_GroupOfPeople.Columns.Contains("PersonID"))
                return;

            int PersonID = Convert.ToInt32(DGV_GroupOfPeople.CurrentRow.Cells["PersonID"].Value);

            frmAddUpdatePerson form = new frmAddUpdatePerson(PersonID);

            form.ShowDialog();

            this._LoadData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_GroupOfPeople.CurrentRow == null || !DGV_GroupOfPeople.Columns.Contains("PersonID"))
                return;

            int PersonID = Convert.ToInt32(DGV_GroupOfPeople.CurrentRow.Cells["PersonID"].Value);
            if (MessageBox.Show($"Are you sure you want to delete person ID {PersonID}?", "Quistion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            
            if (clsPerson.DeletePerson(PersonID))
            {
                MessageBox.Show("Person is deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Person is not deleted!,\nSomething wrong happend", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this._LoadData();
        }

        private void addNewContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();
            form.ShowDialog();

            this.Refresh();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindPerson frm = new frmFindPerson();
            frm.ShowDialog();
        }

        private void moreInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_GroupOfPeople.CurrentRow == null || !DGV_GroupOfPeople.Columns.Contains("PersonID"))
                return;

            int PersonID = Convert.ToInt32(DGV_GroupOfPeople.CurrentRow.Cells["PersonID"].Value);

            frmPersonalInfo Form = new frmPersonalInfo(PersonID);

            Form.Show();
        }

        private void _None ()
        {
            TB_Search.Visible = false;
            TB_Search.Text = string.Empty;
            (DGV_GroupOfPeople.DataSource as DataTable).DefaultView.RowFilter = "";
        }

        private void _ProcesSearch()
        {
            if (CB_Filter.SelectedValue == null || DGV_GroupOfPeople.DataSource == null)
                return;

            switch (CB_Filter.SelectedValue)
            {
                case _enFilter.PersonID:
                    clsUtil.SearchByNumber(DGV_GroupOfPeople, TB_Search, _stFilter.PersonID);
                    break;

                case _enFilter.NationalNo:
                    clsUtil.SearchByString(DGV_GroupOfPeople, TB_Search, _stFilter.NationalNo);
                    break;

                case _enFilter.FullName:
                    clsUtil.SearchByString(DGV_GroupOfPeople, TB_Search, _stFilter.FullName);
                    break;

                case _enFilter.Phone:
                    clsUtil.SearchByString(DGV_GroupOfPeople, TB_Search, _stFilter.Phone);
                    break;

                case _enFilter.Email:
                    clsUtil.SearchByString(DGV_GroupOfPeople, TB_Search, _stFilter.Email);
                    break;

                case _enFilter.CountryName:
                    clsUtil.SearchByString(DGV_GroupOfPeople, TB_Search, _stFilter.CountryName);
                    break;

                case _enFilter.None:
                default:
                    _None();
                    break;

            }

            LB_CountPeople.Text = DGV_GroupOfPeople.Rows.Count.ToString();
        }

        private void TB_Search_TextChanged(object sender, EventArgs e)
        {
            clsValidate.SanitizeNumericInput(sender, _IsTextOnlyNumber);
            _ProcesSearch();
        }

        private void TB_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.PressOnlyNombers(e, _IsTextOnlyNumber);
        }

        private void CB_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Filter.SelectedValue == null)
                return;

            TB_Search.Text = string.Empty;
            TB_Search.Visible = ((_enFilter)CB_Filter.SelectedValue != _enFilter.None);

            _ProcesSearch();

            if (TB_Search.Visible)
                TB_Search.Focus();
        }


    }
}
