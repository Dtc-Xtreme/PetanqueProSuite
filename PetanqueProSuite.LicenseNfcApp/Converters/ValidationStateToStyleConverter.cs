using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Converters
{
    public class ValidationStateToStyleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if there are validation errors for the property
            IEnumerable errors = (IEnumerable)values[0];
            Style invalidStyle = (Style)values[1];

            if (errors != null && errors.Cast<object>().Any())
            {
                // If there are validation errors, return the style for invalid input
                return invalidStyle;
            }
            else
            {
                // If there are no validation errors, return null to use the default style
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
