using PetanqueProSuite.LicenseNfcApp.ViewModels;
using Plugin.NFC;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class ReadLicensePage : ContentPage
{
	public ReadLicensePage(ReadLicenseViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
    }
}