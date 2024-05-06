using Microsoft.Extensions.DependencyInjection;
using PetanqueProSuite.LicenseNfcApp.Views;

namespace PetanqueProSuite.LicenseNfcApp
{
    public partial class AppShell : Shell
    {
        private IServiceProvider serviceProvider;

        public AppShell(IServiceProvider services)
        {
            this.serviceProvider = services;
            InitializeComponent();

            Routing.RegisterRoute(nameof(ReadLicensePage), typeof(ReadLicensePage));
            Routing.RegisterRoute(nameof(CreateLicensePage), typeof(CreateLicensePage));

        }
    }
}
