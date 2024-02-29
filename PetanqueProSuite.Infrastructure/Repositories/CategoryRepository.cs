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
    public class CategoryRepository : GenericRepository, ICategoryRepository
    {
        public IQueryable<Category> Categories => context.Categories.Include(c=>c.Leagues).ThenInclude(c=>c.Divisions).ThenInclude(c=>c.CompetitionTeams).OrderBy(c => c.Name);

        public CategoryRepository(PetanqueProSuiteDbContext ctx) : base(ctx){}
    }
}
