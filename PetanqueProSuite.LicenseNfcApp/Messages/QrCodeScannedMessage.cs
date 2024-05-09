using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Messages
{
    public class QrCodeScannedMessage : ValueChangedMessage<string>
    {
        public QrCodeScannedMessage(string value) : base(value)
        {
        }
    }
}
