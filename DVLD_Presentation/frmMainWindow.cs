using DVLD_BusinessLogicLayer;
using DVLD_Presentation.Applications.InternationalDrivingLicense;
using DVLD_Presentation.Applications.ReleaseDetainLicense;
using DVLD_Presentation.ApplicationTypes;
using DVLD_Presentation.Drivers;
using DVLD_Presentation.Licenses;
using DVLD_Presentation.LocalDrivingLicensce;
using DVLD_Presentation.TestTypeForms;
using DVLD_Presentation.UsersForms;

namespace DVLD_Presentation
{
    public partial class frmMainWindow : Form
    {
        private int _UserID;

        private string _UserName;

        private string _Password;
        public frmMainWindow(int UserID, string Username, string Password)
        {
            InitializeComponent();

            this._UserID = UserID;
            this._UserName = Username;
            this._Password = Password;
        }

        private void signoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMoreInfoUser form = new frmMoreInfoUser(_UserID);

            form.ShowDialog();
        }

        private void editInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateUserInfo form = new frmUpdateUserInfo(_UserID);

            form.ShowDialog();
        }

        private void Btn_AccountSettings_MouseDown(object sender, EventArgs e)
        {
            CMS_ContactUser.Show(Btn_AccountSettings, new Point(0, Btn_AccountSettings.Height));
        }

        private void Btn_Users_Click(object sender, EventArgs e)
        {
            frmUsers form = new frmUsers();
            form.ShowDialog();
        }

        private void Btn_People_Click(object sender, EventArgs e)
        {
            frmPeopleWindow form = new frmPeopleWindow();

            form.ShowDialog();
        }

        private void frmMainWindow_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Btn_Applications_Click(object sender, EventArgs e)
        {
            CMS_Applications.Show(Btn_Applications, new Point(0, Btn_Applications.Height));

        }

        private void applicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationTypes frm = new frmApplicationTypes();
            frm.ShowDialog();
        }

        private void testTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestType frm = new frmTestType();
            frm.ShowDialog();
        }

        private void localDrivingLicensceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicensce frm = new frmLocalDrivingLicensce();
            frm.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewLocalDrivingLicensce frm = new frmAddUpdateNewLocalDrivingLicensce();
            frm.ShowDialog();
        }

        private void Btn_Drivers_Click(object sender, EventArgs e)
        {
            frmDrivers frm = new frmDrivers();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicensce frm = new frmLocalDrivingLicensce();
            frm.ShowDialog();
        }

        private void internationalDrivingLicensceApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalDrivingLicense frm = new frmInternationalDrivingLicense();
            frm.ShowDialog();
        }

        private void internationalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddInternationalDrivingLicense frm = new frmAddInternationalDrivingLicense();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueRenewLicense frm = new frmIssueRenewLicense();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceDamagedLostLicense frm = new frmReplaceDamagedLostLicense();
            frm.ShowDialog();
        }

        private void managementDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicense frm = new frmListDetainedLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }
    
    
    }
}
