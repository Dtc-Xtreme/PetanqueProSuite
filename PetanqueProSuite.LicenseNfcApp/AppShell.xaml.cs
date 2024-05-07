using Android.OS;
using Microsoft.Extensions.DependencyInjection;
using PetanqueProSuite.LicenseNfcApp.Views;
using Plugin.NFC;

namespace PetanqueProSuite.LicenseNfcApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ReadLicensePage), typeof(ReadLicensePage));
            Routing.RegisterRoute(nameof(CreateLicensePage), typeof(CreateLicensePage));

        }
    }
}
