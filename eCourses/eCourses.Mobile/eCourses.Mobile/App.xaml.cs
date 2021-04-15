using eCourses.Mobile.Views.Account;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eCourses.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDEyMzI3QDMxMzgyZTM0MmUzMGhGNXd3aUFreUk5NGFzRUVpOWlMRzlrbWI5SENEUTdsSFA4QVFxU01DaUk9");
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
