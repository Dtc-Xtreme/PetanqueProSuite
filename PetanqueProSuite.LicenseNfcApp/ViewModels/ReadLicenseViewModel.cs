using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using PetanqueProSuite.AppLogic.Services;
using PetanqueProSuite.Domain;
using PetanqueProSuite.LicenseNfcApp.Messages;
using PetanqueProSuite.LicenseNfcApp.Services;
using PetanqueProSuite.LicenseNfcApp.Views;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    [QueryProperty(nameof(Number), "Link")]
    public partial class ReadLicenseViewModel : BaseViewModel
    {
        private readonly INotificationService _notificationService;
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
        private string firstName;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private DateTime dayOfBirth;

        [ObservableProperty]
        private string clubName;

        [ObservableProperty]
        private DateTime validDate;

        [ObservableProperty]
        private License? selectedLicense;

        public ReadLicenseViewModel(INotificationService notificationService, IApiService api)
        {
            _notificationService = notificationService;
            _apiService = api;

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Yield();
                WeakReferenceMessenger.Default.Register<ReadLicenseViewModel, NfcTagReadMessage>(this, (r, m) => r.ReceiveNfcTag(m));
                WeakReferenceMessenger.Default.Register<ReadLicenseViewModel, QrCodeScannedMessage>(this, async (r, m) => await r.ReceiveQrCode(m));
            });
        }

        private async Task OnParameterChanged()
        {
            SelectedLicense = await _apiService.GetLicenseWithId(Number);
        }

        [RelayCommand]
        private async Task FindByLicenseNumber()
        {
            int result = await _notificationService.DisplayPromptNumericAsync("Search license.", "Please input the license number?", 5);
            SelectedLicense = await _apiService.GetLicenseWithId(result);
            FillFields(SelectedLicense);
        }

        [RelayCommand]
        private async Task FindByNfc()
        {
            await Shell.Current.GoToAsync(nameof(ScanNfcPage));
        }

        [RelayCommand]
        private async Task FindByQr()
        {
            await Shell.Current.GoToAsync(nameof(ScanQrPage));
        }

        private async Task ReceiveQrCode(QrCodeScannedMessage m)
        {
            try
            {
                Uri uri = new Uri(m.Value);
                await Launcher.Default.OpenAsync(uri);
            }
            catch (Exception ex)
            {
                // An unexpected error occurred. No browser may be installed on the device.
            }
        }
        private void ReceiveNfcTag(NfcTagReadMessage m)
        {
            try
            {
                // Check if internet then api call otherwhise use serialization.
                SelectedLicense = JsonSerializer.Deserialize<License>(m.Value.Message);
                FillFields(SelectedLicense);
            }
            catch (Exception ex)
            {
                // An unexpected error occurred. No browser may be installed on the device.
            }
        }
        private void FillFields(License? license)
        {
            if (SelectedLicense != null && SelectedLicense.Id != 0)
            {
                FirstName = SelectedLicense.FirstName;
                LastName = SelectedLicense.LastName;
                DayOfBirth = SelectedLicense.DayOfBirth;
                //ClubName = SelectedLicense.Club.Name;
                //ValidDate = SelectedLicense.ValidDate;
            }
        }
    }
}