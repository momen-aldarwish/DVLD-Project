using DVLD_BusinessLogicLayer.Tests;
using DVLD_Presentation.ApplicationTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.TestTypeForms
{
    public partial class frmTestType : Form
    {
        public frmTestType()
        {
            InitializeComponent();
        }

        private void _NameColumns()
        {
            DGV_TestTypes.Columns[0].HeaderText = "Test Type ID";
            DGV_TestTypes.Columns[1].HeaderText = "Test Type Title";
            DGV_TestTypes.Columns[2].HeaderText = "Test Type Description";
            DGV_TestTypes.Columns[3].HeaderText = "Test Fees";

            DGV_TestTypes.Columns[0].Width = 100;
            DGV_TestTypes.Columns[1].Width = 150;
            DGV_TestTypes.Columns[2].Width = 600;
            DGV_TestTypes.Columns[3].Width = 100;
        }

        private void _Load ()
        {
            DGV_TestTypes.DataSource = clsTestType.GetAllTestTypes();

            if (DGV_TestTypes.DataSource != null)
            {
                LB_CountTestTypes.Text = DGV_TestTypes.Rows.Count.ToString();

                _NameColumns();
            }
            else
                LB_CountTestTypes.Text = "0";
        }

        private void frmTestType_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void DGV_TestTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DGV_TestTypes.CurrentCell = DGV_TestTypes.Rows[e.RowIndex].Cells[e.ColumnIndex];

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestType.enTestType TestTypeID = (clsTestType.enTestType)Convert.ToInt32(DGV_TestTypes.CurrentRow.Cells[0].Value);

            frmUpdateTestType frm = new frmUpdateTestType(TestTypeID);

            frm.ShowDialog();

            _Load();
        }
    }
}
