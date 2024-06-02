using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PetanqueProSuite.AppLogic.Models;
using PetanqueProSuite.AppLogic.Services;
using PetanqueProSuite.Domain;
using PetanqueProSuite.LicenseNfcApp.Interfaces;
using PetanqueProSuite.LicenseNfcApp.Models;
using PetanqueProSuite.LicenseNfcApp.Services;
using System.ComponentModel.DataAnnotations;


namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    public partial class CreateLicenseViewModel : BaseViewModel, IContentPageEvents
    {
        private readonly NfcService _nfcService;
        private readonly INotificationService _notificationService;
        private readonly IApiService _apiService;

        [ObservableProperty]
        LicenseForm form;

        [ObservableProperty]
        private List<Club>? clubs;

        public CreateLicenseViewModel(NfcService nfc, INotificationService notificationService, IApiService api)
        {
            _nfcService = nfc;
            _notificationService = notificationService;
            _apiService = api;
            form = new LicenseForm();
        }

        public async Task OnOnAppearing()
        {
            Clubs = await _apiService.GetAllClubs();
        }

        public async Task OnDisappearing()
        {
            await _nfcService.StopListening();
        }

        [RelayCommand]
        private async Task CreateLicense()
        {
            //validationErrors = new();
            //ValidationContext validationContext = new ValidationContext(Form);
            //IsValid = Validator.TryValidateObject(Form, validationContext, validationErrors, true);
            //Errors = String.Join(Environment.NewLine, validationErrors);
            // await _apiService.CreateLicense(Form.FirstName, Form.LastName, Form.DayOfBirth, Form.SelectedClub.Id);
        }

        [RelayCommand]
        private async Task EnableNfc()
        {
            _nfcService.OnAppearing();
        }

        [RelayCommand]
        public void TextChanged()
        {

        }

    }
}
