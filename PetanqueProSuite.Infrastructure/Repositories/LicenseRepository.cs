using PetanqueProSuite.Domain;
using PetanqueProSuite.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Infrastructure.Repositories
{
    public class LicenseRepository : GenericRepository, ILicenseRepository
    {
        public IQueryable<License> Licenses => context.Licenses.OrderBy(c => c.Id);

        public LicenseRepository(PetanqueProSuiteDbContext ctx) : base(ctx){}
    }
}
