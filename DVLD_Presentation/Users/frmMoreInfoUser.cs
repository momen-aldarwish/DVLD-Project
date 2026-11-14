using DVLD_BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Presentation.UsersForms
{
    public partial class frmMoreInfoUser : Form
    {
        private int _UserID;
        public frmMoreInfoUser(int UserID)
        {
            InitializeComponent();
            
            _UserID = UserID; 
        }

        public delegate void DataBack();

        public event DataBack OnDataBack = null;

        private void MoreInfoUserScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnDataBack?.Invoke();
        }

        private void MoreInfoUserScreen_Load(object sender, EventArgs e)
        {
            informationUserView1.LoadData(_UserID);
        }


    }
}
