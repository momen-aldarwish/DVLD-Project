using DVLD_BusinessLogicLayer.Licenses;
using DVLD_Presentation.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls.License
{
    public partial class ctrlLicenseInfoWithFilter : UserControl
    {
        public clsLicense License { get { return ctrlLicenseInfo1.License; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool gbFilter
        {
            get { return GB_Filter.Enabled; }
            set { GB_Filter.Enabled = value; }
        }

        public void FocusOnFilter ()
        {
            if (gbFilter)
                TB_Filter.Focus();
        }

        public ctrlLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public event Action<int> OnLicenseSelected = null;
        protected virtual void LicenseSelected(int licenseId)
        {
            Action<int> handler = OnLicenseSelected;

            handler?.Invoke(licenseId);
        }

        private void Btn_Filter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_Filter.Text.Trim()))
            {
                LicenseSelected(-1);
                return;
            }

            int licenseID = Convert.ToInt32(TB_Filter.Text.Trim());

            ctrlLicenseInfo1.LoadData(licenseID);

            if (ctrlLicenseInfo1.License is null)
            {
                LicenseSelected(-1);
                return;
            }
            else
            {
                LicenseSelected(License.LicenseID);
            }
        }

        private void TB_Filter_TextChanged(object sender, EventArgs e)
        {
            clsValidate.SanitizeNumericInput(sender, true);
        }

        private void TB_Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                Btn_Filter.PerformClick();
                return;
            }

            clsValidate.PressOnlyNombers(e, true);
        }

        public void LoadData(clsLicense License)
        {
            if (License is null)
            {
                LicenseSelected(-1);
                return;
            }

            TB_Filter.Text = License.LicenseID.ToString();
            ctrlLicenseInfo1.LoadData(License);
            LicenseSelected(License.LicenseID);
        }
    }
}
