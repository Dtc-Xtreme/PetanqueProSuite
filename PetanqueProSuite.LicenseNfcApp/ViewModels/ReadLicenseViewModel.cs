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
    //[QueryProperty(nameof(Number), "Link")]
    public partial class ReadLicenseViewModel : BaseViewModel
    {
        private readonly INotificationService _notificationService;
        private readonly IApiService _apiService;
        private JsonSerializerOptions jsonOptions;
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
        private bool isVisible = false;

        [ObservableProperty]
        private bool isLoading = false;

        [ObservableProperty]
        private License? selectedLicense;

        public ReadLicenseViewModel(INotificationService notificationService, IApiService api)
        {
            _notificationService = notificationService;
            _apiService = api;

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Yield();
                WeakReferenceMessenger.Default.Register<ReadLicenseViewModel, NfcTagReadMessage>(this, (r, m) => r.ReceiveNfcTag(m));
                WeakReferenceMessenger.Default.Register<ReadLicenseViewModel, QrCodeScannedMessage>(this, async (r, m) => await r.ReceiveQrCode(m));
            });

            IsVisible = false; 
        }

        private async Task OnParameterChanged()
        {
            SelectedLicense = await _apiService.GetLicenseWithId(Number);
        }

        [RelayCommand]
        private async Task FindByLicenseNumber()
        {
            int result = await _notificationService.DisplayPromptNumericAsync("Search license.", "Please input the license number?", 5);
            StartSearchingUI();
 
            SelectedLicense = await _apiService.GetLicenseWithId(result);
            if (SelectedLicense != null && selectedLicense.Id != 0) {
                ItemLoadedUI();
            }
            else
            {
                await ItemNotFound();
            }
        }

        [RelayCommand]
        private async Task FindByNfc()
        {
            ClearingItem();
            await Shell.Current.GoToAsync(nameof(ScanNfcPage));
        }

        [RelayCommand]
        private async Task FindByQr()
        {
            ClearingItem();
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
        private async Task ReceiveNfcTag(NfcTagReadMessage m)
        {

            try
            {
                StartSearchingUI();
                // Check if internet then api call otherwhise use serialization.
                try
                {
                    SelectedLicense = JsonSerializer.Deserialize<License>(m.Value.Message, jsonOptions);

                }
                catch (Exception ex) {
                }
                if (SelectedLicense != null && selectedLicense.Id != 0 )
                {
                    ItemLoadedUI();
                }
                else
                {
                    await ItemNotFound();
                }
            }
            catch (Exception ex)
            {
                // An unexpected error occurred. No browser may be installed on the device.
            }
        }


        private void ClearingItem()
        {
            SelectedLicense = null;
            IsVisible = false;
        }
        private void StartSearchingUI()
        {
            ClearingItem();
            IsLoading = true;
        }
        private void ItemLoadedUI()
        {
            IsVisible = true;
            IsLoading = false;
        }
        private async Task ItemNotFound()
        {
            IsLoading = false;
            await _notificationService.ShowAlertOkAsync("Error", "No license was found!");
        }

    }
}