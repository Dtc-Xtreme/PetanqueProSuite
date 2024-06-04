using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using PetanqueProSuite.AppLogic.Services;
using PetanqueProSuite.Domain;
using PetanqueProSuite.LicenseNfcApp.Interfaces;
using PetanqueProSuite.LicenseNfcApp.Messages;
using PetanqueProSuite.LicenseNfcApp.Services;
using PetanqueProSuite.LicenseNfcApp.Views;

namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    [QueryProperty(nameof(Link), "Link")]
    public partial class ReadLicenseViewModel : BaseViewModel
    {
        private readonly IApiService _apiService;

        private int link;
        public int Link
        {
            get
            {
                return link;
            }
            set
            {
                if (SetProperty(ref link, value))
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
        private string dayOfBirth;
        [ObservableProperty]
        private byte[] photo;

        [ObservableProperty]
        private string country;
        [ObservableProperty]
        private string federation;
        [ObservableProperty]
        private string clubName;
        [ObservableProperty]
        private int licenseNumber;
        [ObservableProperty]
        private string type;
        [ObservableProperty]
        private string category;
        [ObservableProperty]
        private string validDate;

        [ObservableProperty]
        private bool isVisible;

        [ObservableProperty]
        NfcTagReadMessage message;

        public ReadLicenseViewModel(IApiService api)
        {
            _apiService = api;

            IsVisible = false;

            FirstName = "Steven Albert Marius";
            LastName = "Kazmierczak";
            DayOfBirth = "08/03/1989";

            Country = "BE";
            Federation = "Petanque Federatie Vlaanderen (PFV)";
            ClubName = "PC Boekt";
            LicenseNumber = 4077;
            Type = "Competief lid";
            Category = "Sen H";

            ValidDate = "01/05/2024 - " + DateTime.Now.ToString("dd, MM, yyyy");

            WeakReferenceMessenger.Default.Register<ReadLicenseViewModel, NfcTagReadMessage>(this, (r, m) => r.ReceiveNfcTag(m));
            WeakReferenceMessenger.Default.Register<ReadLicenseViewModel, QrCodeScannedMessage>(this, (r, m) => r.ReceiveQrCode(m));
        }

        private async Task OnParameterChanged()
        {
            License? license = await _apiService.GetLicenseWithId(Link);
        }

        //public void Receive(QrCodeScannedMessage message)
        //{
        //    MainThread.BeginInvokeOnMainThread(() =>
        //    {
        //        IsVisible = true;
        //        string param = message.Value.Substring(message.Value.Length - 4, 4);

        //    });
        //}

        [RelayCommand]
        private async Task Nfc()
        {
            await Shell.Current.GoToAsync(nameof(ScanNfcPage));
        }

        [RelayCommand]
        private async Task Qr()
        {
            await Shell.Current.GoToAsync(nameof(ScanQrPage));
        }

        private void ReceiveQrCode(QrCodeScannedMessage m)
        {
            //throw new NotImplementedException();
        }

        private void ReceiveNfcTag(NfcTagReadMessage m)
        {
            //throw new NotImplementedException();
        }
    }
}