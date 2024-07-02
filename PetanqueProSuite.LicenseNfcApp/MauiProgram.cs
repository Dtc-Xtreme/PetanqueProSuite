using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PetanqueProSuite.AppLogic.Services;
using PetanqueProSuite.LicenseNfcApp.Services;
using PetanqueProSuite.LicenseNfcApp.ViewModels;
using PetanqueProSuite.LicenseNfcApp.Views;
using ZXing.Net.Maui.Controls;

namespace PetanqueProSuite.LicenseNfcApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitCamera()
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "GoogleMaterialFont");
                });

            #if DEBUG
    		    builder.Logging.AddDebug();
            #endif

            //builder.Services.AddTransient<AppShell>();

            builder.Services.AddSingleton<ReadLicensePage>();
            builder.Services.AddSingleton<CreateLicensePage>();
            builder.Services.AddSingleton<WriteLicensePage>();
            builder.Services.AddSingleton<ScanQrPage>();
            builder.Services.AddSingleton<ScanNfcPage>();

            builder.Services.AddSingleton<ReadLicenseViewModel>();
            builder.Services.AddSingleton<CreateLicenseViewModel>();
            builder.Services.AddSingleton<WriteLicenseViewModel>();
            builder.Services.AddSingleton<ScanQrViewModel>();
            builder.Services.AddSingleton<ScanNfcViewModel>();

            builder.Services.AddSingleton<INotificationService, NotificationService>();
            builder.Services.AddSingleton<IApiService, ApiService>();
            builder.Services.AddSingleton<INfcService, NfcService>();
            return builder.Build();
        }
    }
}
