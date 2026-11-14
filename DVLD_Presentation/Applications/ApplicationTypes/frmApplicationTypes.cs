using DVLD_BusinessLogicLayer.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.ApplicationTypes
{
    public partial class frmApplicationTypes : Form
    {
        public frmApplicationTypes()
        {
            InitializeComponent();
        }

        private void _NameColumns()
        {
            DGV_ApplicationTypes.Columns[0].HeaderText = "Application Type ID";
            DGV_ApplicationTypes.Columns[1].HeaderText = "Application Type Title";
            DGV_ApplicationTypes.Columns[2].HeaderText = "Application Fees";

            DGV_ApplicationTypes.Columns[0].Width = 100;
            DGV_ApplicationTypes.Columns[1].Width = 500;
            DGV_ApplicationTypes.Columns[2].Width = 100;
        }

        private void _LoadData ()
        {
            DGV_ApplicationTypes.DataSource = clsApplicationType.GetAllApplicationTypes();

            if (DGV_ApplicationTypes.DataSource != null)
                LB_ApplicationTypesCount.Text = DGV_ApplicationTypes.Rows.Count.ToString();

            else
                LB_ApplicationTypesCount.Text = "0";
        }

        private void ApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();

            _NameColumns();
        }

        private void DGV_ApplicationTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DGV_ApplicationTypes.CurrentCell = DGV_ApplicationTypes.Rows[e.RowIndex].Cells[e.ColumnIndex];

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = Convert.ToInt32(DGV_ApplicationTypes.CurrentRow.Cells[0].Value);

            frmUpdateApplicationType frm = new frmUpdateApplicationType(ApplicationTypeID);

            frm.ShowDialog();

            _LoadData();
        }
    
    }
}
