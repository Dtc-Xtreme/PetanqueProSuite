using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Models
{
    public static class ImageSourceExtensions
    {
        public static async Task<byte[]> ToByteArrayAsync(this ImageSource imageSource)
        {
            if (imageSource == null)
                return null;

            // Get the stream from the ImageSource
            var streamImageSource = (StreamImageSource)imageSource;
            using (var stream = await streamImageSource.Stream(CancellationToken.None))
            {
                if (stream == null)
                    return null;

                // Read the stream into a byte array
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
