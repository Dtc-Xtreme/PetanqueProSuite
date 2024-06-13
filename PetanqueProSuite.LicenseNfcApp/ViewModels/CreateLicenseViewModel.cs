using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PetanqueProSuite.AppLogic.Services;
using PetanqueProSuite.Domain;
using PetanqueProSuite.LicenseNfcApp.Interfaces;
using PetanqueProSuite.LicenseNfcApp.Models;
using PetanqueProSuite.LicenseNfcApp.Services;
using PetanqueProSuite.LicenseNfcApp.Views;

namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    public partial class CreateLicenseViewModel : BaseViewModel, IContentPageEvents
    {
        private readonly INotificationService _notificationService;
        private readonly IApiService _apiService;

        [ObservableProperty]
        LicenseForm form;

        [ObservableProperty]
        private List<Federation>? federations;

        [ObservableProperty]
        private List<Province>? provinces;

        [ObservableProperty]
        private List<Club>? clubs;

        [ObservableProperty]
        private Province? selectedProvince;

        public CreateLicenseViewModel(INotificationService notificationService, IApiService api)
        {
            _notificationService = notificationService;
            _apiService = api;
            Form = new LicenseForm();
        }

        public async Task OnOnAppearing()
        {
            if(Federations is null)  Federations = await _apiService.GetAllFederation();
            if(Provinces is null)  Provinces = await _apiService.GetAllProvinces();
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
                if(await _notificationService.ShowAlertNoYesAsync("License added.", "Succesfully added! Do you want to write it to a NFC tag?"))
                {
                    await Shell.Current.GoToAsync($"{nameof(WriteLicensePage)}?Number={result.Id}");
                }
                Form = new LicenseForm();
                
            }
            else
            {
                await _notificationService.ShowAlertOkAsync("License added.", "License is not added!");
            }
        }
    }
}