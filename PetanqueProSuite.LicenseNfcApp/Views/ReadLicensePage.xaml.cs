using PetanqueProSuite.LicenseNfcApp.Services;
using PetanqueProSuite.LicenseNfcApp.ViewModels;
using ZXing.Net.Maui;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class ReadLicensePage : ContentPage
{
    private readonly NfcService nfcService;

	public ReadLicensePage(ReadLicenseViewModel vm, NfcService nfc)
	{
        nfcService = nfc;
        BindingContext = vm;
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        nfcService.OnAppearing();
        base.OnAppearing();
    }

    protected async override void OnDisappearing()
    {
        await nfcService.StopListening();
        base.OnDisappearing();
    }
}