using Municipal_Application.Forms;
using Municipal_Application.Data;

namespace Municipal_Application
{
    internal static class Program
    {
       
        ///  The main entry point for the application.
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ServiceRequestSeeder.SeedIfEmpty();
            LocalEventSeeder.Instance.Start();
            Application.Run(new LoginForm());
        }
    }
}
