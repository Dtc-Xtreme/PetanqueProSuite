using PetanqueProSuite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Infrastructure;

namespace PetanqueProSuite.Infrastructure.Interfaces
{
    public interface ILicenseRepository : IGenericRepository
    {
        public IQueryable<License> Licenses { get; }

    }
}
