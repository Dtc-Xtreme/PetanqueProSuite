using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Maui;

namespace PetanqueProSuite.LicenseNfcApp.Converters
{
    public class BarcodesDetectedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is BarcodeDetectionEventArgs eventArgs)
            {
                // Return the first detected barcode or whatever processing is needed
                string result = eventArgs.Results[0].Value;
                return result;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
