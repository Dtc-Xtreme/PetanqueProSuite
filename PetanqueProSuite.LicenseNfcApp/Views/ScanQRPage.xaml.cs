using CommunityToolkit.Mvvm.Messaging;
using PetanqueProSuite.LicenseNfcApp.Messages;
using PetanqueProSuite.LicenseNfcApp.ViewModels;
using System;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class ScanQrPage : ContentPage
{
    private ScanQrViewModel viewModel;
    private CameraBarcodeReaderView scanner;

    public ScanQrPage(ScanQrViewModel vm)
    {
        viewModel = vm;
        BindingContext = vm;
        InitializeComponent();

        scanner = cameraBarcodeReaderView;
        scanner.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.TwoDimensional,
            AutoRotate = true,
            Multiple = false
        };
        scanner.BarcodesDetected += BarcodesDetected;

    }

    private void BarcodesDetected(object? sender, BarcodeDetectionEventArgs e)
    {
        scanner.BarcodesDetected -= BarcodesDetected;
        viewModel.BarcodesDetectedCommand.Execute(e);
    }

    protected override void OnAppearing()
    {
        scanner.BarcodesDetected += BarcodesDetected;
    }
}