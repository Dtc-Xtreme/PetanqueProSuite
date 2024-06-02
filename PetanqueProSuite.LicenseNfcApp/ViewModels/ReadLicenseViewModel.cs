using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using PetanqueProSuite.LicenseNfcApp.Interfaces;
using PetanqueProSuite.LicenseNfcApp.Messages;
using PetanqueProSuite.LicenseNfcApp.Services;
using PetanqueProSuite.LicenseNfcApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    //[QueryProperty(nameof(Link), "Link")]
    public partial class ReadLicenseViewModel : BaseViewModel, IRecipient<QrCodeScannedMessage>, IContentPageEvents
    {
        private readonly INfcService _nfcService;

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
        private string result;

        public ReadLicenseViewModel(INfcService nfc)
        {
            _nfcService = nfc;
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

            WeakReferenceMessenger.Default.Register<QrCodeScannedMessage>(this);
        }

        public async Task OnDisappearing()
        {
            await _nfcService.StopListening();
        }

        public Task OnOnAppearing()
        {
            throw new NotImplementedException();
        }

        public void Receive(QrCodeScannedMessage message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                IsVisible = true;
                Result = message.Value;
                NavigateBackToThisPage();
            });
        }

        private async void NavigateBackToThisPage()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task Nfc()
        {
            IsVisible = true;
            _nfcService.OnAppearing();
        }

        [RelayCommand]
        private async Task Qr()
        {
            await Shell.Current.GoToAsync(nameof(ScanQrPage));
        }
    }
}