using PetanqueProSuite.LicenseNfcApp.ViewModels;

namespace PetanqueProSuite.LicenseNfcApp.Views;

public partial class ScanNfcPage : ContentPage
{
    private ScanNfcViewModel viewModel;

    public ScanNfcPage(ScanNfcViewModel vm)
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