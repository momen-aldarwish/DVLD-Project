using DVLD_BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.PeopleForms
{
    public partial class frmPersonalInfo : Form
    {
        public frmPersonalInfo(int PersonID)
        {
            InitializeComponent();
            ctrlPersonalInfo1.LoadData(PersonID);
        }

        public frmPersonalInfo(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonalInfo1.LoadData(NationalNo);
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
