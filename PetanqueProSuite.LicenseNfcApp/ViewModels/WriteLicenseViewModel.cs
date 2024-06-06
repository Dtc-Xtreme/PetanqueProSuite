using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PetanqueProSuite.AppLogic.Services;
using PetanqueProSuite.Domain;
using PetanqueProSuite.LicenseNfcApp.Interfaces;
using PetanqueProSuite.LicenseNfcApp.Services;


namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    [QueryProperty(nameof(Number), "Number")]
    public partial class WriteLicenseViewModel : BaseViewModel, IContentPageEvents
    {
        private readonly INotificationService _notificationService;
        private readonly INfcService _nfcService;
        private readonly IApiService _apiService;

        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (SetProperty(ref number, value))
                {
                    OnParameterChanged();
                }
            }
        }

        [ObservableProperty]
        private License? selectedLicense;

        public WriteLicenseViewModel(INotificationService notificationService, INfcService nfc, IApiService apiService)
        {
            _notificationService = notificationService;
            _nfcService = nfc;
            _apiService = apiService;
        }

        private async Task OnParameterChanged()
        {
            SelectedLicense = await _apiService.GetLicenseWithId(Number);
        }
        public async Task OnDisappearing()
        {
            await _nfcService.StopListening();
        }
        public async Task OnOnAppearing()
        {
            if (Number != 0)
            {
                SelectedLicense = await _apiService.GetLicenseWithId(Number);
                Number = 0;
            }
        }

        [RelayCommand]
        private async Task FindByLicenseNumber()
        {
            int result = await _notificationService.DisplayPromptNumericAsync("Search license.", "Please input the license number?", 5);
            SelectedLicense = await _apiService.GetLicenseWithId(result);
        }

        [RelayCommand]
        private async Task Nfc()
        {
            _nfcService.OnAppearing();
        }
    }
}