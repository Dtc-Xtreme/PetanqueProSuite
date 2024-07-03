using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetanqueProSuite.Domain;
using PetanqueProSuite.Domain.Competition;
using PetanqueProSuite.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Infrastructure.Repositories
{
    public class FederationRepository : GenericRepository, IFederationRepository
    {
        public IQueryable<Federation> Federations => context.Federations.OrderBy(c => c.Name);

        public FederationRepository(PetanqueProSuiteDbContext ctx, ILogger<GenericRepository> logger) : base(ctx, logger) { }
    }
}
