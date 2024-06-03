﻿using CommunityToolkit.Maui;
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

            builder.Services.AddTransient<ReadLicensePage>();
            builder.Services.AddTransient<CreateLicensePage>();
            builder.Services.AddTransient<WriteLicensePage>();
            builder.Services.AddTransient<ScanQrPage>();
            builder.Services.AddTransient<ScanNfcPage>();

            builder.Services.AddTransient<ReadLicenseViewModel>();
            builder.Services.AddTransient<CreateLicenseViewModel>();
            builder.Services.AddTransient<WriteLicenseViewModel>();
            builder.Services.AddTransient<ScanQrViewModel>();
            builder.Services.AddTransient<ScanNfcViewModel>();

            builder.Services.AddSingleton<INotificationService, NotificationService>();
            builder.Services.AddSingleton<IApiService, ApiService>();
            builder.Services.AddSingleton<INfcService, NfcService>();
            return builder.Build();
        }
    }
}
