using PetanqueProSuite.LicenseNfcApp.Interfaces;
using PetanqueProSuite.LicenseNfcApp.Services;

namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    public partial class ScanNfcViewModel : BaseViewModel, IContentPageEvents
    {
        private readonly INotificationService _notificationService;
        private readonly INfcService _nfcService;

        public ScanNfcViewModel(INotificationService notification, INfcService nfc)
        {
            _notificationService = notification;
            _nfcService = nfc;
        }

        public async Task OnDisappearing()
        {
            await _nfcService.StopListening();
        }
        public async Task OnOnAppearing()
        {
            _nfcService.OnAppearing();
        }
    }
}
