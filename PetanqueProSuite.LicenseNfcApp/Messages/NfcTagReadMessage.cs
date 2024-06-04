using CommunityToolkit.Mvvm.Messaging.Messages;
using Plugin.NFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Messages
{
    public class NfcTagReadMessage : ValueChangedMessage<NFCNdefRecord>
    {
        public NfcTagReadMessage(NFCNdefRecord value) : base(value)
        {
        }
    }
}
