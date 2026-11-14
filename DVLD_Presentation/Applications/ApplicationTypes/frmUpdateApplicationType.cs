using DVLD_BusinessLogicLayer.Applications;
using DVLD_Presentation.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.ApplicationTypes
{
    public partial class frmUpdateApplicationType : Form
    {
        clsApplicationType _ApplicationType;

        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationType = clsApplicationType.Find(ApplicationTypeID);
        }

        private void TB_ApplicationFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.PressOnlyNombers(e, true);

            if (e.KeyChar == '.')
                TB_ApplicationFees.Text += '.';
        }

        private void text_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (string.IsNullOrEmpty(txt.Text))
            {
                errorProvider1.SetError(txt, "This field is required");
                e.Cancel = true;

            }
            else
            {
                errorProvider1.SetError(txt, "");
                e.Cancel = false;
            }
        }

        private void TB_ApplicationFees_TextChanged(object sender, EventArgs e)
        {
            clsValidate.SanitizeNumericInput(sender, true);
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            Btn_Close.CausesValidation = false;

            if (_ApplicationType == null)
            {
                MessageBox.Show("Application Type ID is not existed", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TB_ApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle;
            TB_ApplicationFees.Text = _ApplicationType.ApplicationTypeFees.ToString();
        }

        private void _UpdateApplicationType ()
        {
            _ApplicationType.ApplicationTypeTitle = TB_ApplicationTypeTitle.Text;
            _ApplicationType.ApplicationTypeFees = float.Parse(TB_ApplicationFees.Text);

            if (_ApplicationType.Update())
                MessageBox.Show("Application type has been changed successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Application type is not existed in database!", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            _UpdateApplicationType();
        }
    }

}
