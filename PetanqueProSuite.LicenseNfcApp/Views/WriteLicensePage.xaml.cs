using PetanqueProSuite.LicenseNfcApp.ViewModels;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class WriteLicensePage : ContentPage
{
	public WriteLicensePage(WriteLicenseViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
    }
}