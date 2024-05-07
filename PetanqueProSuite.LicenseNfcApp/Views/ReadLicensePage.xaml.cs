using PetanqueProSuite.LicenseNfcApp.ViewModels;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class ReadLicensePage : ContentPage
{
	public ReadLicensePage(ReadLicenseViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}
}