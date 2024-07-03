using PetanqueProSuite.Domain;
using PetanqueProSuite.LicenseNfcApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Converters
{
    public class ByteArrayConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is byte[] bytes && bytes.Length > 0)
            {
                // Create ImageSource from byte[]
                ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(bytes));
                return imageSource;
            }

            // Return default image if byte[] is null or empty
            return ImageSource.FromFile("no_image.png");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is ImageSource imageSource)
            {
                // Convert ImageSource back to byte[]
                return imageSource.ToByteArrayAsync();
            }

            return null;
        }
    }
}
