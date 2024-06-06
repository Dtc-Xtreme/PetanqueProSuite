using PetanqueProSuite.LicenseNfcApp.ViewModels;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class WriteLicensePage : ContentPage
{
    private WriteLicenseViewModel viewModel;

    public WriteLicensePage(WriteLicenseViewModel vm)
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