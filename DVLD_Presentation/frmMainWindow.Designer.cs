namespace DVLD_Presentation
{
    partial class frmMainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            CMS_ContactUser = new ContextMenuStrip(components);
            userInfoToolStripMenuItem = new ToolStripMenuItem();
            editInfoToolStripMenuItem = new ToolStripMenuItem();
            signoutToolStripMenuItem = new ToolStripMenuItem();
            Btn_AccountSettings = new Button();
            Btn_Users = new Button();
            Btn_People = new Button();
            Btn_Applications = new Button();
            CMS_Applications = new ContextMenuStrip(components);
            drivingLicenseServiceToolStripMenuItem = new ToolStripMenuItem();
            newDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            localDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            internationalDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            renewDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            replacementForLostOrDamagedLicenseToolStripMenuItem = new ToolStripMenuItem();
            retakeTestToolStripMenuItem = new ToolStripMenuItem();
            manageApplicationsToolStripMenuItem = new ToolStripMenuItem();
            localDrivingLicensceToolStripMenuItem = new ToolStripMenuItem();
            internationalDrivingLicensceApplicationToolStripMenuItem = new ToolStripMenuItem();
            applicationTypesToolStripMenuItem = new ToolStripMenuItem();
            testTypesToolStripMenuItem = new ToolStripMenuItem();
            dtainToolStripMenuItem = new ToolStripMenuItem();
            managementDetainedLicenseToolStripMenuItem = new ToolStripMenuItem();
            detainLicenseToolStripMenuItem = new ToolStripMenuItem();
            releaseLicenseToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            Btn_Drivers = new Button();
            CMS_ContactUser.SuspendLayout();
            CMS_Applications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // CMS_ContactUser
            // 
            CMS_ContactUser.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CMS_ContactUser.ImageScalingSize = new Size(40, 40);
            CMS_ContactUser.Items.AddRange(new ToolStripItem[] { userInfoToolStripMenuItem, editInfoToolStripMenuItem, signoutToolStripMenuItem });
            CMS_ContactUser.Name = "CMS_ContactUser";
            CMS_ContactUser.Size = new Size(241, 142);
            CMS_ContactUser.Text = "CMS_ContactUser";
            // 
            // userInfoToolStripMenuItem
            // 
            userInfoToolStripMenuItem.Image = Properties.Resources.info;
            userInfoToolStripMenuItem.Name = "userInfoToolStripMenuItem";
            userInfoToolStripMenuItem.Size = new Size(240, 46);
            userInfoToolStripMenuItem.Text = "User Info";
            userInfoToolStripMenuItem.Click += userInfoToolStripMenuItem_Click;
            // 
            // editInfoToolStripMenuItem
            // 
            editInfoToolStripMenuItem.Image = Properties.Resources.Edit_User_32;
            editInfoToolStripMenuItem.Name = "editInfoToolStripMenuItem";
            editInfoToolStripMenuItem.Size = new Size(240, 46);
            editInfoToolStripMenuItem.Text = "Edit Info";
            editInfoToolStripMenuItem.Click += editInfoToolStripMenuItem_Click;
            // 
            // signoutToolStripMenuItem
            // 
            signoutToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signoutToolStripMenuItem.Image = Properties.Resources.Sign_Out_32;
            signoutToolStripMenuItem.Name = "signoutToolStripMenuItem";
            signoutToolStripMenuItem.Size = new Size(240, 46);
            signoutToolStripMenuItem.Text = "Signout";
            signoutToolStripMenuItem.Click += signoutToolStripMenuItem_Click;
            // 
            // Btn_AccountSettings
            // 
            Btn_AccountSettings.Image = Properties.Resources.account_settings_64;
            Btn_AccountSettings.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_AccountSettings.Location = new Point(617, 4);
            Btn_AccountSettings.Name = "Btn_AccountSettings";
            Btn_AccountSettings.Size = new Size(193, 76);
            Btn_AccountSettings.TabIndex = 5;
            Btn_AccountSettings.Text = "Account Settings";
            Btn_AccountSettings.TextAlign = ContentAlignment.MiddleRight;
            Btn_AccountSettings.UseVisualStyleBackColor = true;
            Btn_AccountSettings.Click += Btn_AccountSettings_MouseDown;
            // 
            // Btn_Users
            // 
            Btn_Users.Image = Properties.Resources.Users_2_64;
            Btn_Users.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_Users.Location = new Point(482, 4);
            Btn_Users.Name = "Btn_Users";
            Btn_Users.Size = new Size(129, 76);
            Btn_Users.TabIndex = 6;
            Btn_Users.Text = "Users";
            Btn_Users.TextAlign = ContentAlignment.MiddleRight;
            Btn_Users.UseVisualStyleBackColor = true;
            Btn_Users.Click += Btn_Users_Click;
            // 
            // Btn_People
            // 
            Btn_People.Image = Properties.Resources.People_64;
            Btn_People.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_People.Location = new Point(325, 4);
            Btn_People.Name = "Btn_People";
            Btn_People.Size = new Size(151, 76);
            Btn_People.TabIndex = 7;
            Btn_People.Text = "People";
            Btn_People.TextAlign = ContentAlignment.MiddleRight;
            Btn_People.UseVisualStyleBackColor = true;
            Btn_People.Click += Btn_People_Click;
            // 
            // Btn_Applications
            // 
            Btn_Applications.Image = Properties.Resources.Manage_Applications_32;
            Btn_Applications.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_Applications.Location = new Point(12, 4);
            Btn_Applications.Name = "Btn_Applications";
            Btn_Applications.Size = new Size(138, 76);
            Btn_Applications.TabIndex = 8;
            Btn_Applications.Text = "Applications";
            Btn_Applications.TextAlign = ContentAlignment.MiddleRight;
            Btn_Applications.UseVisualStyleBackColor = true;
            Btn_Applications.Click += Btn_Applications_Click;
            // 
            // CMS_Applications
            // 
            CMS_Applications.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CMS_Applications.ImageScalingSize = new Size(40, 40);
            CMS_Applications.Items.AddRange(new ToolStripItem[] { drivingLicenseServiceToolStripMenuItem, manageApplicationsToolStripMenuItem, applicationTypesToolStripMenuItem, testTypesToolStripMenuItem, dtainToolStripMenuItem });
            CMS_Applications.Name = "CMS_Applications";
            CMS_Applications.Size = new Size(434, 234);
            // 
            // drivingLicenseServiceToolStripMenuItem
            // 
            drivingLicenseServiceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newDrivingLicenseToolStripMenuItem, renewDrivingLicenseToolStripMenuItem, toolStripSeparator1, replacementForLostOrDamagedLicenseToolStripMenuItem, retakeTestToolStripMenuItem });
            drivingLicenseServiceToolStripMenuItem.Image = Properties.Resources.Driver_License_481;
            drivingLicenseServiceToolStripMenuItem.Name = "drivingLicenseServiceToolStripMenuItem";
            drivingLicenseServiceToolStripMenuItem.Size = new Size(433, 46);
            drivingLicenseServiceToolStripMenuItem.Text = "Driving License Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localDrivingLicenseToolStripMenuItem, internationalDrivingLicenseToolStripMenuItem });
            newDrivingLicenseToolStripMenuItem.Image = Properties.Resources.License_View_32;
            newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            newDrivingLicenseToolStripMenuItem.Size = new Size(688, 46);
            newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // localDrivingLicenseToolStripMenuItem
            // 
            localDrivingLicenseToolStripMenuItem.Image = Properties.Resources.Local_32;
            localDrivingLicenseToolStripMenuItem.Name = "localDrivingLicenseToolStripMenuItem";
            localDrivingLicenseToolStripMenuItem.Size = new Size(504, 46);
            localDrivingLicenseToolStripMenuItem.Text = "Local Driving License";
            localDrivingLicenseToolStripMenuItem.Click += localDrivingLicenseToolStripMenuItem_Click;
            // 
            // internationalDrivingLicenseToolStripMenuItem
            // 
            internationalDrivingLicenseToolStripMenuItem.Image = Properties.Resources.International_32;
            internationalDrivingLicenseToolStripMenuItem.Name = "internationalDrivingLicenseToolStripMenuItem";
            internationalDrivingLicenseToolStripMenuItem.Size = new Size(504, 46);
            internationalDrivingLicenseToolStripMenuItem.Text = "International Driving License";
            internationalDrivingLicenseToolStripMenuItem.Click += internationalDrivingLicenseToolStripMenuItem_Click;
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            renewDrivingLicenseToolStripMenuItem.Image = Properties.Resources.Renew_Driving_License_32;
            renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            renewDrivingLicenseToolStripMenuItem.Size = new Size(688, 46);
            renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            renewDrivingLicenseToolStripMenuItem.Click += renewDrivingLicenseToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(685, 6);
            // 
            // replacementForLostOrDamagedLicenseToolStripMenuItem
            // 
            replacementForLostOrDamagedLicenseToolStripMenuItem.Image = Properties.Resources.Lost_Driving_License_32;
            replacementForLostOrDamagedLicenseToolStripMenuItem.Name = "replacementForLostOrDamagedLicenseToolStripMenuItem";
            replacementForLostOrDamagedLicenseToolStripMenuItem.Size = new Size(688, 46);
            replacementForLostOrDamagedLicenseToolStripMenuItem.Text = "Replacement for Lost or Damaged License";
            replacementForLostOrDamagedLicenseToolStripMenuItem.Click += replacementForLostOrDamagedLicenseToolStripMenuItem_Click;
            // 
            // retakeTestToolStripMenuItem
            // 
            retakeTestToolStripMenuItem.Image = Properties.Resources.Retake_Test_32;
            retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            retakeTestToolStripMenuItem.Size = new Size(688, 46);
            retakeTestToolStripMenuItem.Text = "Retake Test";
            retakeTestToolStripMenuItem.Click += retakeTestToolStripMenuItem_Click;
            // 
            // manageApplicationsToolStripMenuItem
            // 
            manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localDrivingLicensceToolStripMenuItem, internationalDrivingLicensceApplicationToolStripMenuItem });
            manageApplicationsToolStripMenuItem.Image = Properties.Resources.Manage_Applications_641;
            manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            manageApplicationsToolStripMenuItem.Size = new Size(433, 46);
            manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // localDrivingLicensceToolStripMenuItem
            // 
            localDrivingLicensceToolStripMenuItem.Image = Properties.Resources.Driver_License_48;
            localDrivingLicensceToolStripMenuItem.Name = "localDrivingLicensceToolStripMenuItem";
            localDrivingLicensceToolStripMenuItem.Size = new Size(676, 46);
            localDrivingLicensceToolStripMenuItem.Text = "Local Driving Licensce Application";
            localDrivingLicensceToolStripMenuItem.Click += localDrivingLicensceToolStripMenuItem_Click;
            // 
            // internationalDrivingLicensceApplicationToolStripMenuItem
            // 
            internationalDrivingLicensceApplicationToolStripMenuItem.Image = Properties.Resources.International_32;
            internationalDrivingLicensceApplicationToolStripMenuItem.Name = "internationalDrivingLicensceApplicationToolStripMenuItem";
            internationalDrivingLicensceApplicationToolStripMenuItem.Size = new Size(676, 46);
            internationalDrivingLicensceApplicationToolStripMenuItem.Text = "International Driving Licensce Application";
            internationalDrivingLicensceApplicationToolStripMenuItem.Click += internationalDrivingLicensceApplicationToolStripMenuItem_Click;
            // 
            // applicationTypesToolStripMenuItem
            // 
            applicationTypesToolStripMenuItem.Image = Properties.Resources.Applications_64;
            applicationTypesToolStripMenuItem.Name = "applicationTypesToolStripMenuItem";
            applicationTypesToolStripMenuItem.Size = new Size(433, 46);
            applicationTypesToolStripMenuItem.Text = "Application Types";
            applicationTypesToolStripMenuItem.Click += applicationTypesToolStripMenuItem_Click;
            // 
            // testTypesToolStripMenuItem
            // 
            testTypesToolStripMenuItem.Image = Properties.Resources.Test_32;
            testTypesToolStripMenuItem.Name = "testTypesToolStripMenuItem";
            testTypesToolStripMenuItem.Size = new Size(433, 46);
            testTypesToolStripMenuItem.Text = "Test Types";
            testTypesToolStripMenuItem.Click += testTypesToolStripMenuItem_Click;
            // 
            // dtainToolStripMenuItem
            // 
            dtainToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { managementDetainedLicenseToolStripMenuItem, detainLicenseToolStripMenuItem, releaseLicenseToolStripMenuItem });
            dtainToolStripMenuItem.Image = Properties.Resources.Detain_32;
            dtainToolStripMenuItem.Name = "dtainToolStripMenuItem";
            dtainToolStripMenuItem.Size = new Size(433, 46);
            dtainToolStripMenuItem.Text = "Dtain Licenses";
            // 
            // managementDetainedLicenseToolStripMenuItem
            // 
            managementDetainedLicenseToolStripMenuItem.Image = Properties.Resources.Detain_321;
            managementDetainedLicenseToolStripMenuItem.Name = "managementDetainedLicenseToolStripMenuItem";
            managementDetainedLicenseToolStripMenuItem.Size = new Size(540, 46);
            managementDetainedLicenseToolStripMenuItem.Text = "Management Detained License";
            managementDetainedLicenseToolStripMenuItem.Click += managementDetainedLicenseToolStripMenuItem_Click;
            // 
            // detainLicenseToolStripMenuItem
            // 
            detainLicenseToolStripMenuItem.Image = Properties.Resources.Detain_32;
            detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            detainLicenseToolStripMenuItem.Size = new Size(540, 46);
            detainLicenseToolStripMenuItem.Text = "Detain License";
            detainLicenseToolStripMenuItem.Click += detainLicenseToolStripMenuItem_Click;
            // 
            // releaseLicenseToolStripMenuItem
            // 
            releaseLicenseToolStripMenuItem.Image = Properties.Resources.Release_Detained_License_32;
            releaseLicenseToolStripMenuItem.Name = "releaseLicenseToolStripMenuItem";
            releaseLicenseToolStripMenuItem.Size = new Size(540, 46);
            releaseLicenseToolStripMenuItem.Text = "Release License";
            releaseLicenseToolStripMenuItem.Click += releaseLicenseToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Black;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = Properties.Resources.IconLogo;
            pictureBox1.Location = new Point(272, 171);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(286, 266);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // Btn_Drivers
            // 
            Btn_Drivers.Image = Properties.Resources.Drivers_64;
            Btn_Drivers.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_Drivers.Location = new Point(156, 4);
            Btn_Drivers.Name = "Btn_Drivers";
            Btn_Drivers.Size = new Size(163, 76);
            Btn_Drivers.TabIndex = 10;
            Btn_Drivers.Text = "Drivers";
            Btn_Drivers.TextAlign = ContentAlignment.MiddleRight;
            Btn_Drivers.UseVisualStyleBackColor = true;
            Btn_Drivers.Click += Btn_Drivers_Click;
            // 
            // frmMainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(851, 504);
            Controls.Add(Btn_Drivers);
            Controls.Add(Btn_Applications);
            Controls.Add(Btn_People);
            Controls.Add(Btn_Users);
            Controls.Add(Btn_AccountSettings);
            Controls.Add(pictureBox1);
            Name = "frmMainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main ";
            Load += frmMainWindow_Load;
            CMS_ContactUser.ResumeLayout(false);
            CMS_Applications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip CMS_ContactUser;
        private ToolStripMenuItem userInfoToolStripMenuItem;
        private ToolStripMenuItem editInfoToolStripMenuItem;
        private ToolStripMenuItem signoutToolStripMenuItem;
        private Button Btn_AccountSettings;
        private Button Btn_Users;
        private Button Btn_People;
        private Button Btn_Applications;
        private ContextMenuStrip CMS_Applications;
        private ToolStripMenuItem applicationTypesToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem testTypesToolStripMenuItem;
        private ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private ToolStripMenuItem localDrivingLicensceToolStripMenuItem;
        private ToolStripMenuItem internationalDrivingLicensceApplicationToolStripMenuItem;
        private ToolStripMenuItem drivingLicenseServiceToolStripMenuItem;
        private ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private ToolStripMenuItem localDrivingLicenseToolStripMenuItem;
        private ToolStripMenuItem internationalDrivingLicenseToolStripMenuItem;
        private Button Btn_Drivers;
        private ToolStripMenuItem retakeTestToolStripMenuItem;
        private ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem replacementForLostOrDamagedLicenseToolStripMenuItem;
        private ToolStripMenuItem dtainToolStripMenuItem;
        private ToolStripMenuItem managementDetainedLicenseToolStripMenuItem;
        private ToolStripMenuItem detainLicenseToolStripMenuItem;
        private ToolStripMenuItem releaseLicenseToolStripMenuItem;
    }
}
