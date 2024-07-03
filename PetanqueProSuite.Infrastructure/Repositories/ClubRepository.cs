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
    public class ClubRepository : GenericRepository, IClubRepository
    {
        public IQueryable<Club> Clubs => context.Clubs.Include(c => c.Province).ThenInclude(c => c.Federation).OrderBy(c => c.Number);

        public ClubRepository(PetanqueProSuiteDbContext ctx, ILogger<GenericRepository> logger) : base(ctx, logger) { }
    }
}
