using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Animations;
using PetanqueProSuite.LicenseNfcApp.Services;
using PetanqueProSuite.LicenseNfcApp.Views;


namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    public partial class CreateLicenseViewModel : BaseViewModel
    {
        private readonly INotificationService _notificationService;

        [ObservableProperty]
        private string test;

        public CreateLicenseViewModel(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [RelayCommand]
        private async Task Alert()
        {
            await _notificationService.ShowAlertOkAsync("Title", "lalal!");
        }

    }
}
