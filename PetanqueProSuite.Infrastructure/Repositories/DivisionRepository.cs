using Microsoft.EntityFrameworkCore;
using PetanqueProSuite.Domain.Competition;
using PetanqueProSuite.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Infrastructure.Repositories
{
    public class DivisionRepository : GenericRepository, IDivisionRepository
    {
        public IQueryable<Division> Divisions => context.Divisions.Include(c => c.CompetitionTeams).OrderBy(c => c.Name);

        public DivisionRepository(PetanqueProSuiteDbContext ctx) : base(ctx){}
    }
}
