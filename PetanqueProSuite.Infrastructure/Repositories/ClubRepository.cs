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
        public IQueryable<Club> Clubs => context.Clubs.OrderBy(c => c.Number);

        public ClubRepository(PetanqueProSuiteDbContext ctx) : base(ctx){}
    }
}
