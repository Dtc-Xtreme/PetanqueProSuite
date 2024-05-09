using PetanqueProSuite.LicenseNfcApp.ViewModels;
using ZXing.Net.Maui;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class ScanQrPage : ContentPage
{
    public ScanQrPage(ScanQrViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();

        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.TwoDimensional,
            AutoRotate = true,
            Multiple = false
        };
    }

    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        if (BindingContext is ScanQrViewModel vm) {
            vm.BarcodesDetectedCommand.Execute(e); 
        }
    }
}