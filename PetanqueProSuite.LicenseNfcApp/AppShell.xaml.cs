using PetanqueProSuite.LicenseNfcApp.Views;

namespace PetanqueProSuite.LicenseNfcApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ReadLicensePage), typeof(ReadLicensePage));
            Routing.RegisterRoute(nameof(CreateLicensePage), typeof(CreateLicensePage));
            Routing.RegisterRoute(nameof(WriteLicensePage), typeof(WriteLicensePage));
            Routing.RegisterRoute(nameof(ScanQrPage), typeof(ScanQrPage));
        }
    }
}
