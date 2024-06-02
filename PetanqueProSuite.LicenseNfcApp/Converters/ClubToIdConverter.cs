using PetanqueProSuite.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Converters
{
    public class ClubToIdConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int id && parameter is IList<Club> clubs)
            {
                return clubs.FirstOrDefault(c=>c.Id == id);
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is Club club)
            {
                return club.Id;
            }
            return null;
        }
    }
}
