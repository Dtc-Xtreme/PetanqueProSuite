﻿using CommunityToolkit.Mvvm.Input;
using PetanqueProSuite.LicenseNfcApp.Services;
using ZXing.Net.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using PetanqueProSuite.LicenseNfcApp.Messages;

namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    public partial class ScanQrViewModel : BaseViewModel
    {
        private readonly INotificationService _notificationService;
        
        [ObservableProperty]
        private CameraLocation cameraLocation;

        [ObservableProperty]
        private bool isTorchOn;

        public ScanQrViewModel(INotificationService notification)
        {
            _notificationService = notification;
            
        }

        [RelayCommand]
        private async Task SwitchCamera()
        {
            if (await _notificationService.ShowAlertNoYesAsync("Camera", "Would you like to switch cameras?"))   
            {
                CameraLocation = CameraLocation == CameraLocation.Rear ? CameraLocation.Front : CameraLocation.Rear;
            }
        }

        [RelayCommand]
        private async Task ToggleTorch()
        {
            if (await _notificationService.ShowAlertNoYesAsync("Torch", "Would you like to toggle the torch?"))
            {
                IsTorchOn = !IsTorchOn;
            }
        }

        [RelayCommand]
        private void OnBarcodesDetected(BarcodeDetectionEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                WeakReferenceMessenger.Default.Send(new QrCodeScannedMessage(e.Results[0].Value));
                await Shell.Current.GoToAsync("..");
            });
        }
    }
}
