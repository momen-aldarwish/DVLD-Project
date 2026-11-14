using DVLD_BusinessLogicLayer.Tests;
using DVLD_Presentation.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.TestTypeForms
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestType _TestType;

        public frmUpdateTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestType = clsTestType.Find(TestTypeID);
        }

        private void frmUpdateTestType_Load (object sender, EventArgs e)
        {
            if (_TestType == null)
            {
                MessageBox.Show("Test Type ID is not existed in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;
            }

            TB_TestTypeTitle.Text = _TestType.TestTypeTitle;
            TB_TestTypeDescription.Text = _TestType.TestTypeDescription;
            TB_TestFees.Text = _TestType.TestTypeFees.ToString();
        }

        private void _LoadDataToTestType ()
        {
            _TestType.TestTypeTitle = TB_TestTypeTitle.Text;
            _TestType.TestTypeDescription = TB_TestTypeDescription.Text;
            _TestType.TestTypeFees = float.Parse(TB_TestFees.Text);
        }

        private void TB_TestFees_KeyPress (object sender, KeyPressEventArgs e)
        {
            clsValidate.PressOnlyNombers(e, true);
        }

        private void TB_TestFees_Changed(object sender, EventArgs e)
        {
            clsValidate.SanitizeNumericInput(sender, true);
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            _LoadDataToTestType();

            if(_TestType.Update())
            {
                MessageBox.Show("The changed has been successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("DataBase rejected saving! this Test Type might be deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    
    }
}
