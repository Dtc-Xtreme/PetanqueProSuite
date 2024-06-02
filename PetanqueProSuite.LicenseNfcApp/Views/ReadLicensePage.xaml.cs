using PetanqueProSuite.LicenseNfcApp.Services;
using PetanqueProSuite.LicenseNfcApp.ViewModels;
using ZXing.Net.Maui;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class ReadLicensePage : ContentPage
{
	public ReadLicensePage(ReadLicenseViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
    }
}