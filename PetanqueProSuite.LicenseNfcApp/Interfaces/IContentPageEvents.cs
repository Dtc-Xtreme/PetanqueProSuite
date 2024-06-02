using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.LicenseNfcApp.Interfaces
{
    public interface IContentPageEvents
    {
        public Task OnOnAppearing();

        public Task OnDisappearing();
    }
}
