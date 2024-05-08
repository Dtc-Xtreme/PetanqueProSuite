using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class ReadLicenseViewModel : BaseViewModel
    {
        private readonly NfcService nfcService;

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

        public ReadLicenseViewModel(NfcService nfc)
        {
            nfcService = nfc;
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
        }

        [RelayCommand]
        private async Task Nfc()
        {
            IsVisible = true;
            await nfcService.StartListeningIfNotiOS();
        }

        [RelayCommand]
        private async Task Qr()
        {
            await Shell.Current.GoToAsync(nameof(ScanQRPage));
        }
    }
}