using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PetanqueProSuite.AppLogic.Services;
using PetanqueProSuite.Domain;
using PetanqueProSuite.LicenseNfcApp.Interfaces;
using PetanqueProSuite.LicenseNfcApp.Models;
using PetanqueProSuite.LicenseNfcApp.Services;
using PetanqueProSuite.LicenseNfcApp.Views;
using System.Collections.ObjectModel;

namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    public partial class CreateLicenseViewModel : BaseViewModel, IContentPageEvents
    {
        private readonly INotificationService _notificationService;
        private readonly IApiService _apiService;

        [ObservableProperty]
        LicenseForm form;

        [ObservableProperty]
        private bool provinceIsEnabled = false;

        [ObservableProperty]
        private bool clubIsEnabled = false;

        private IList<Federation>? federations;
        public IList<Federation>? Federations
        {
            get { return federations; } 
            set { 
                SetProperty(ref federations, value);
            }
        }

        private Federation? selectedFederation;
        public Federation? SelectedFederation
        {
            get
            {
                return selectedFederation;
            }
            set
            {
                if (SetProperty(ref selectedFederation, value))
                {
                    OnPropertyChanged("Provinces");
                    ProvinceIsEnabled = selectedFederation != null;
                }
            }
        }

        private IList<Province>? provinces;
        public IList<Province>? Provinces
        {
            get
            {
                return provinces?.Where(c => c.FederationId == SelectedFederation?.Id).ToList();
            }
            set
            {
                SetProperty(ref provinces, value);
            }
        }

        private Province? selectedProvince;
        public Province? SelectedProvince
        {
            get
            {
                return selectedProvince;
            }
            set
            {
                if(SetProperty(ref selectedProvince, value))
                {
                    OnPropertyChanged("Clubs");
                    ClubIsEnabled = selectedProvince != null && Clubs?.Count < 0;
                }
            }
        }

        private IList<Club>? clubs;
        public IList<Club>? Clubs
        {
            get {
                return clubs?.Where(c => c.ProvinceId == SelectedProvince?.Id).ToList();
            }
            set
            {
                SetProperty(ref clubs, value);
            }
        }

        public CreateLicenseViewModel(INotificationService notificationService, IApiService api)
        {
            _notificationService = notificationService;
            _apiService = api;
            Form = new LicenseForm();
        }

        public async Task OnOnAppearing()
        {
            if (Federations is null)
            {
                Federations = await _apiService.GetAllFederation();
            }
            if (Provinces is null)
            {
                Provinces = await _apiService.GetAllProvinces();
            }
            if (Clubs is null)
            {
                Clubs = await _apiService.GetAllClubs();
            }
        }

        public async Task OnDisappearing()
        {

        }

        [RelayCommand]
        private async Task CreateLicense()
        {
            License? result = await _apiService.CreateLicense(Form.FirstName, Form.LastName, Form.DayOfBirth, Form.Club.Id);
            if (result != null)
            {
                if(await _notificationService.ShowAlertNoYesAsync("License added.", "Succesfully added! Do you want to write it to a NFC tag?"))
                {
                    await Shell.Current.GoToAsync($"{nameof(WriteLicensePage)}?Number={result.Id}");
                }
                Form = new LicenseForm();
                SelectedFederation = null;
                SelectedProvince = null;
            }
            else
            {
                await _notificationService.ShowAlertOkAsync("License added.", "License is not added!");
            }
        }
    }
}