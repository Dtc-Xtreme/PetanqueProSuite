using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.ViewModels
{
    public partial class ReadLicenseViewModel : BaseViewModel
    {
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


        public ReadLicenseViewModel()
        {
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
    }
}
