using DVLD_Presentation.UsersForms;

namespace DVLD_Presentation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the _application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize _application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmSignIn());
        }
    }
}