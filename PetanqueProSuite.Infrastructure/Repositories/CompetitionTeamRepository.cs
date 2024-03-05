using Microsoft.EntityFrameworkCore;
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
    public class CompetitionTeamRepository : GenericRepository, ICompetitionTeamRepository
    {
        public IQueryable<CompetitionTeam> CompetitionTeams => context.CompetitionTeams.Include(c=>c.Club).Include(c=>c.Licenses);

        public CompetitionTeamRepository(PetanqueProSuiteDbContext ctx) : base(ctx){}
    }
}
