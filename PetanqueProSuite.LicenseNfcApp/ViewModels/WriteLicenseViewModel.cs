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
    public partial class WriteLicenseViewModel : BaseViewModel, IContentPageEvents
    {
        private readonly INfcService _nfcService;

        public WriteLicenseViewModel(INfcService nfc)
        {
            _nfcService = nfc;
        }

        public async Task OnDisappearing()
        {
            await _nfcService.StopListening();
        }

        public Task OnOnAppearing()
        {
            throw new NotImplementedException();
        }


        [RelayCommand]
        private async Task Nfc()
        {
            _nfcService.OnAppearing();
        }
    }
}