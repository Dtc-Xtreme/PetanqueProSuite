using CommunityToolkit.Mvvm.ComponentModel;
using PetanqueProSuite.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Models
{
    public partial class LicenseForm : BaseModel
    {
        public LicenseForm()
        {
            this.ValidateAllProperties();
        }

        [Required(ErrorMessage = "First name is required")]
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasErrors))]
        [NotifyPropertyChangedFor(nameof(GetAllErrors))]
        [NotifyDataErrorInfo]
        private string firstName;

        [Required(ErrorMessage = "Last name is required")]
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasErrors))]
        [NotifyPropertyChangedFor(nameof(GetAllErrors))]
        [NotifyDataErrorInfo]
        private string lastName;

        [Required(ErrorMessage = "Day of birth is required")]
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasErrors))]
        [NotifyPropertyChangedFor(nameof(GetAllErrors))]
        [NotifyDataErrorInfo]
        private DateTime? dayOfBirth;

        [Required(ErrorMessage = "Sex is required")]
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasErrors))]
        [NotifyPropertyChangedFor(nameof(GetAllErrors))]
        [NotifyDataErrorInfo]
        private Sex? sex;

        [Required(ErrorMessage = "Club is required")]
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasErrors))]
        [NotifyPropertyChangedFor(nameof(GetAllErrors))]
        [NotifyDataErrorInfo]
        private Club club;
    }
}