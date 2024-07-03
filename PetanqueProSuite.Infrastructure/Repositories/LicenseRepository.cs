using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public IQueryable<License> Licenses => context.Licenses.Include(c => c.Club).ThenInclude(c =>c.Province).ThenInclude(c => c.Federation).OrderBy(c => c.Id);

        public LicenseRepository(PetanqueProSuiteDbContext ctx, ILogger<GenericRepository> logger) : base(ctx, logger) { }
    }
}
