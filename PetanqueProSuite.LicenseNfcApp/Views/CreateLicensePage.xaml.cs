using PetanqueProSuite.LicenseNfcApp.ViewModels;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class CreateLicensePage : ContentPage
{
	public CreateLicensePage(CreateLicenseViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}
}