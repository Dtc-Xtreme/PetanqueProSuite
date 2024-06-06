using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Services
{
    public interface INotificationService
    {
        public Task ShowAlertOkAsync(string title, string message);
        public Task<bool> ShowAlertNoYesAsync(string title, string message);
        public Task<string> DisplayPromptAsync(string title, string question);
        public Task<int> DisplayPromptNumericAsync(string title, string question, int maxLength);
    }
}
