using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Models
{
    public class BaseModel : ObservableValidator
    {
        public string GetAllErrors { 
            get {
                var errors = this.GetErrors();
                return string.Join(Environment.NewLine, errors.Select(e => e.ErrorMessage));
            } 
        }
        
    }
}
