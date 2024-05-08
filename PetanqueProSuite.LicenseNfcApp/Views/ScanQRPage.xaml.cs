using PetanqueProSuite.LicenseNfcApp.Services;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using ZXing.QrCode.Internal;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class ScanQRPage : ContentPage
{
    private readonly INotificationService notificationService;

    public string Result { get; set; }

	public ScanQRPage(INotificationService notification)
    {
        notificationService = notification;
        InitializeComponent();

        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = false
        };
    }

    protected async void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        Result = e.Results[0].Value;
    }

    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        if(await notificationService.ShowAlertNoYesAsync("Camera", "Would you like to switch cameras?"))
        {
            cameraBarcodeReaderView.CameraLocation = cameraBarcodeReaderView.CameraLocation == CameraLocation.Rear ? CameraLocation.Front : CameraLocation.Rear;
        }
    }

    private async void ToolbarItem_Clicked_2(object sender, EventArgs e)
    {
        if (await notificationService.ShowAlertNoYesAsync("Torch", "Would you like to toggle the torch?"))
        {
            cameraBarcodeReaderView.IsTorchOn = !cameraBarcodeReaderView.IsTorchOn;
        }
    }
}