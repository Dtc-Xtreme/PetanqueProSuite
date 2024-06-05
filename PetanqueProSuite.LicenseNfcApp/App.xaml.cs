using Microsoft.Maui.ApplicationModel;

namespace PetanqueProSuite.LicenseNfcApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
