using PetanqueProSuite.LicenseNfcApp.Services;
using PetanqueProSuite.LicenseNfcApp.ViewModels;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class CreateLicensePage : ContentPage
{
    private CreateLicenseViewModel viewModel;

    public CreateLicensePage(CreateLicenseViewModel vm)
	{
        viewModel = vm;
        BindingContext = vm;
        InitializeComponent();
	}

    protected override void OnAppearing()
    {
        viewModel.OnOnAppearing();
    }

    protected override void OnDisappearing()
    {
        viewModel.OnDisappearing();
    }

}