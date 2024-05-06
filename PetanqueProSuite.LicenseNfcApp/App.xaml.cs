namespace PetanqueProSuite.LicenseNfcApp
{
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;
        public App(IServiceProvider services)
        {
            this.serviceProvider = services;
            InitializeComponent();

            MainPage = serviceProvider.GetRequiredService<AppShell>();
        }
    }
}
