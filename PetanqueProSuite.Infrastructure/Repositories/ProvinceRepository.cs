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
    public class ProvinceRepository : GenericRepository, IProvinceRepository
    {
        public IQueryable<Province> Provinces => context.Provinces.OrderBy(c => c.Name);

        public ProvinceRepository(PetanqueProSuiteDbContext ctx) : base(ctx){}
    }
}
