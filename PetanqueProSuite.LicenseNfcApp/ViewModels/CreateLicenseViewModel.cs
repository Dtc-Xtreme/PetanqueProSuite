using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PetanqueProSuite.AppLogic.Services;
using PetanqueProSuite.Domain;
using PetanqueProSuite.LicenseNfcApp.Interfaces;
using PetanqueProSuite.LicenseNfcApp.Models;
using PetanqueProSuite.LicenseNfcApp.Services;

namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    public partial class CreateLicenseViewModel : BaseViewModel, IContentPageEvents
    {
        private readonly INotificationService _notificationService;
        private readonly IApiService _apiService;

        [ObservableProperty]
        LicenseForm form;

        [ObservableProperty]
        private List<Club>? clubs;

        public CreateLicenseViewModel(INotificationService notificationService, IApiService api)
        {
            _notificationService = notificationService;
            _apiService = api;
            Form = new LicenseForm();
        }

        public async Task OnOnAppearing()
        {
            if(Clubs is null)  Clubs = await _apiService.GetAllClubs();
        }

        public async Task OnDisappearing()
        {

        }

        [RelayCommand]
        private async Task CreateLicense()
        {
            License? result = await _apiService.CreateLicense(Form.FirstName, Form.LastName, Form.DayOfBirth, Form.SelectedClub.Id);
            if (result != null)
            {
                await _notificationService.ShowAlertOkAsync("License added.", "Succesfully added!");
                Form = new LicenseForm();
                
            }
            else
            {
                await _notificationService.ShowAlertOkAsync("License added.", "License is not added!");
            }
        }
    }
}
