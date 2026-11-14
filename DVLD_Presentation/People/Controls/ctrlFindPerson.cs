using DVLD_BusinessLogicLayer;
using DVLD_Presentation.HelperClasses;
using DVLD_Presentation.PeopleForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace DVLD_Presentation.UserControls
{

    public partial class ctrlFindPerson : UserControl
    {
        private enum _enFilter { PersonID, NationalNo }

        private struct _stFilterName
        {
            public static readonly string PersonID = "PersonID";
            public static readonly string NationalNo = "NationalNo";
        }

        private struct _stFilterHeader
        {
            public static readonly string PersonID = "Person ID";
            public static readonly string NationalNo = "National No";
        }

        private bool FilterCondition
        {
            get
            {
                if (CB_FilterBy.SelectedValue is _enFilter)
                    return ((_enFilter)CB_FilterBy.SelectedValue == _enFilter.PersonID);
                else
                    return false;
            }
        }

        private void _FillComboBox()
        {
            List<clsUtil.FilterItem<_enFilter>> filterItems = new List<clsUtil.FilterItem<_enFilter>>()
            {
                new clsUtil.FilterItem<_enFilter> (_stFilterHeader.PersonID, _enFilter.PersonID),
                new clsUtil.FilterItem<_enFilter> (_stFilterHeader.NationalNo, _enFilter.NationalNo)
            };

            CB_FilterBy.DataSource = filterItems;

            CB_FilterBy.ValueMember = "Value";
            CB_FilterBy.DisplayMember = "DisplayText";

        }

        public clsPerson Person { get { return informationView1.Person; } }

        public int PersonID { get { return informationView1.PersonID; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnabledFilter
        {
            get
            {
                return GB_Filter.Enabled;
            }
            set
            {
                GB_Filter.Enabled = value;
            }
        }

        public event Action<int> OnPersonSelected = null;

        protected void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;

            if (handler != null)
            {
                PersonID = (Person == null) ? -1 : Person.PersonID;

                handler(PersonID);
            }
        }

        public ctrlFindPerson()
        {
            InitializeComponent();
            CB_FilterBy.SelectedValue = _enFilter.PersonID;
        }

        private void informationView1_Load(object sender, EventArgs e)
        {
            _FillComboBox();
        }

        public void Search ()
        {
            Btn_Search.PerformClick();
        }

        public void FocusFilter ()
        {
            TB_Search.Focus();
        }

        private void TB_Search_TextChanged(object sender, EventArgs e)
        {
            clsValidate.SanitizeNumericInput(sender, FilterCondition);
        }

        private void TB_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.PressOnlyNombers(e, FilterCondition);

            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Search.PerformClick();
            }
        }

        private void _ProcesSearch()
        {
            switch (CB_FilterBy.SelectedValue)
            {
                case _enFilter.PersonID:
                    if (int.TryParse(TB_Search.Text.Trim(), out int personID))
                        informationView1.LoadData(personID);
                    break;

                case _enFilter.NationalNo:
                    informationView1.LoadData(TB_Search.Text.Trim());
                    break;

                default:
                    break;
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            _ProcesSearch();

            if (OnPersonSelected is not null && Person is not null)
                PersonSelected(Person.PersonID);
            else if (OnPersonSelected is not null)
                PersonSelected(-1);
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();

            form.OnDataSent += _Load_Person;

            form.ShowDialog();
        }

        private void _Load_Person(int PersonID)
        {
            informationView1.LoadData(PersonID);

            if (Person is null)
                return;

            TB_Search.Text = Person.PersonID.ToString();
            CB_FilterBy.SelectedIndex = 0;

            Btn_Search.PerformClick();
        }

        public void LoadData(int PersonID)
        {
            CB_FilterBy.SelectedValue = _enFilter.PersonID;

            TB_Search.Text = PersonID.ToString();
            Btn_Search.PerformClick();
            EnabledFilter = false;
        }

        public void LoadData(string NationalNo)
        {
            CB_FilterBy.SelectedValue = _enFilter.NationalNo;

            TB_Search.Text = NationalNo.Trim();
            Btn_Search.PerformClick();
            EnabledFilter = false;

        }

    }
}
