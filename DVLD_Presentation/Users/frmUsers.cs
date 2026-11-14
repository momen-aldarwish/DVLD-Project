using DVLD_BusinessLogicLayer;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.PeopleForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UsersForms
{
    public partial class frmUsers : Form
    {
        enum enFilter {None, UserID, UserName, IsActive}
        struct stFilter 
        {
            public static string None = "None";
            public static string UserID = "UserID";
            public static string UserName = "UserName";
            public static string IsActive = "IsActive";
        }
        struct stFilterHeader
        {
            public static string None = "None";
            public static string UserID = "User ID";
            public static string UserName = "User Name";
            public static string IsActive = "Is Active";
        }

        bool IsNumber
        {
            get
            {
                if (CB_Filter.SelectedValue is not enFilter)
                    return false;

                return ((enFilter)CB_Filter.SelectedValue == enFilter.UserID);
            }
        }

        enum enActiveFilter { All, Yes, No };
        struct stActiveFilter
        {
            public static string All = "All";
            public static string Yes = "Yes";
            public static string No = "No";
        }

        public frmUsers()
        {
            InitializeComponent();
            _Referesh();

            CB_Activity.SelectedIndex = 0;
        }

        private void _FillComboBoxes ()
        {
            List<clsUtil.FilterItem<enFilter>> FilterList = new List<clsUtil.FilterItem<enFilter>>()
            {
                new clsUtil.FilterItem<enFilter> (stFilterHeader.None, enFilter.None),
                new clsUtil.FilterItem<enFilter> (stFilterHeader.UserID, enFilter.UserID),
                new clsUtil.FilterItem<enFilter> (stFilterHeader.UserName, enFilter.UserName),
                new clsUtil.FilterItem<enFilter> (stFilterHeader.IsActive, enFilter.IsActive)
            };

            CB_Filter.DataSource = FilterList;

            CB_Filter.DisplayMember = "DisplayText";
            CB_Filter.ValueMember = "Value";

            List<clsUtil.FilterItem<enActiveFilter>> ActivateList = new List<clsUtil.FilterItem<enActiveFilter>>()
            {
                new clsUtil.FilterItem<enActiveFilter> (stActiveFilter.All, enActiveFilter.All),
                new clsUtil.FilterItem<enActiveFilter> (stActiveFilter.Yes, enActiveFilter.Yes),
                new clsUtil.FilterItem<enActiveFilter> (stActiveFilter.No, enActiveFilter.No)
            };

            CB_Activity.DataSource = ActivateList;

            CB_Activity.DisplayMember = "DisplayText";
            CB_Activity.ValueMember = "Value";
        }
        
        private void frmUsers_Load(object sender, EventArgs e)
        {
            _FillComboBoxes();

            CB_Filter.SelectedValue = enFilter.None;
            CB_Activity.Visible = false;
            TB_Search.Visible = false;

            _Referesh();
        }

        private void _Referesh()
        {
            DGV_Users.DataSource = clsUser.GetAllUsers();
            LB_UsersCount.Text = DGV_Users.Rows.Count.ToString();

            if (DGV_Users.Columns.Contains("PersonID"))
                DGV_Users.Columns["PersonID"].Visible = false;

            if (DGV_Users.Columns.Contains("Password"))
                DGV_Users.Columns["Password"].Visible = false;
        }

        private void Btn_AddNewUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser form = new frmAddNewUser();
            form.ShowDialog();

            _Referesh();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            frmFindUser form = new frmFindUser();
            form.ShowDialog();

            _Referesh();
        }

        private void DGV_Users_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DGV_Users.CurrentCell = DGV_Users.Rows[e.RowIndex].Cells[e.ColumnIndex];

                CMS_More.Show(Cursor.Position);
            }
        }

        private void moreInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(DGV_Users.CurrentRow.Cells["UserID"].Value);

            frmMoreInfoUser form = new frmMoreInfoUser(UserID);

            form.OnDataBack += _Referesh;

            form.Show();


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(DGV_Users.CurrentRow.Cells["UserID"].Value);

            frmGiveAccessToUpdate form = new frmGiveAccessToUpdate(UserID);

            form.ShowDialog();

            _Referesh();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(DGV_Users.CurrentRow.Cells["UserID"].Value);

            if (UserID == clsGlobal.UserID)
            {
                MessageBox.Show("This user is connected to this system now!,\n if you want to delete it, delete it from another connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (clsUser.Delete(UserID))
            {
                MessageBox.Show("User has been deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Referesh();
            }
            else
            {
                MessageBox.Show("User can't be deleted, this user is already deleted or there are connections with it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addNewContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUser form = new frmAddNewUser();

            form.ShowDialog();

            _Referesh();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindUser form = new frmFindUser();

            form.ShowDialog();

            _Referesh();
        }

        private void _IsActiveSearch ()
        {
            bool yes = false;
            switch (CB_Activity.SelectedValue)
            {
                case enActiveFilter.All:
                    clsUtil.ShowAllDGVData(DGV_Users);
                    return;

                case enActiveFilter.Yes:
                    yes = true;
                    break;

                case enActiveFilter.No:
                    yes = false;
                    break;
            }
            clsUtil.SearchByBool(DGV_Users, yes, stFilter.IsActive);
        }

        private void _ProcesSearch()
        {
            switch (CB_Filter.SelectedValue)
            {
                case enFilter.UserName:
                    clsUtil.SearchByString(DGV_Users, TB_Search, stFilter.UserName);
                    break;

                case enFilter.UserID:
                    clsUtil.SearchByNumber(DGV_Users, TB_Search, stFilter.UserID);
                    break;

                case enFilter.IsActive:
                    _IsActiveSearch();
                        break;

                case enFilter.None:
                default:
                    clsUtil.ShowAllDGVData(DGV_Users);
                    break;
            }
        }

        private void CB_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Filter.SelectedValue is not enFilter)
                return;

            TB_Search.Text = string.Empty;
            TB_Search.Visible = ((enFilter)CB_Filter.SelectedValue != enFilter.None) && ((enFilter)CB_Filter.SelectedValue != enFilter.IsActive);
            CB_Activity.Visible = ((enFilter)CB_Filter.SelectedValue == enFilter.IsActive);

            if (TB_Search.Visible)
                TB_Search.Focus();

            _ProcesSearch();
        }

        private void TB_Search_TextChanged(object sender, EventArgs e)
        {
            clsValidate.SanitizeNumericInput(sender, IsNumber);

            _ProcesSearch();
        }

        private void TB_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.PressOnlyNombers(e, IsNumber);
        }

        private void CB_Activity_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ProcesSearch();
        }

    }
}
