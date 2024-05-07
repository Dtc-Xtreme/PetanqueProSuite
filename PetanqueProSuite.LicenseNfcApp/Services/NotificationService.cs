using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace PetanqueProSuite.LicenseNfcApp.Services
{
    public class NotificationService : INotificationService
    {
        public async Task ShowAlertOkAsync(string title, string message)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, "OK");
        }

        public async Task<bool> ShowAlertNoYesAsync(string title, string message)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, "Yes", "No");
        }

        public async Task<string> DisplayPromptAsync(string title, string question)
        {
            return await Application.Current.MainPage.DisplayPromptAsync(title, question);
        }
    }
}
