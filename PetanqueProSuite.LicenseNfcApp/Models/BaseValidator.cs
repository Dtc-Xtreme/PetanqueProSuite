using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Models
{
    public abstract class BaseValidator : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new();
        public bool HasErrors => _errors.Count() > 0;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public event PropertyChangedEventHandler? PropertyChanged;


        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName))
            {
                return null;
            }
            return _errors[propertyName];
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected void ValidateProperty(object value, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null) return;

            var validationContext = new ValidationContext(value)
            {
                MemberName = propertyName
            };

            var validationResults = new List<ValidationResult>();
            try
            {  
                Validator.TryValidateProperty(value, validationContext, validationResults);
            }
            catch (Exception ex)
            {

            }


            if (validationResults.Any())
            {
                foreach (var validationResult in validationResults)
                {
                    AddError(propertyName, validationResult.ErrorMessage);
                }
            }
            else
            {
                RemoveError(propertyName);
            }
        }

        private void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
                _errors[propertyName] = new List<string>();

            if (!_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }
        private void RemoveError(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
