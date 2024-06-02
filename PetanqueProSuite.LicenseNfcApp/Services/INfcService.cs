using Plugin.NFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Services
{
    public interface INfcService
    {
        public bool NfcIsAvailable { get; }

        void OnAppearing();
        Task Publish(object payload, NFCNdefTypeFormat? type = null);
        Task StopListening();
    }
}
