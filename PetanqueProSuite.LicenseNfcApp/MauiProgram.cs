using Microsoft.Extensions.Logging;
using PetanqueProSuite.LicenseNfcApp.Services;
using PetanqueProSuite.LicenseNfcApp.ViewModels;
using PetanqueProSuite.LicenseNfcApp.Views;

namespace PetanqueProSuite.LicenseNfcApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            #if DEBUG
    		    builder.Logging.AddDebug();
            #endif

            //builder.Services.AddTransient<AppShell>();

            builder.Services.AddTransient<ReadLicensePage>();
            builder.Services.AddTransient<CreateLicensePage>();

            builder.Services.AddTransient<ReadLicenseViewModel>();
            builder.Services.AddTransient<CreateLicenseViewModel>();

            builder.Services.AddSingleton<INotificationService, NotificationService>();
            builder.Services.AddSingleton<NfcService>();
            return builder.Build();
        }
    }
}
