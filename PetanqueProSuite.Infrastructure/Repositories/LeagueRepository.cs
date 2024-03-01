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
    public class LeagueRepository : GenericRepository, ILeagueRepository
    {
        public IQueryable<League> Leagues => context.Leagues.Where(c => c.Divisions.Any()).OrderBy(c => c.Name);

        public LeagueRepository(PetanqueProSuiteDbContext ctx) : base(ctx){}
    }
}
