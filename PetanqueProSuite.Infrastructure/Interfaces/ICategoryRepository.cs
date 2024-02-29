using PetanqueProSuite.Domain.Competition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Infrastructure;

namespace PetanqueProSuite.Infrastructure.Interfaces
{
    public interface ICategoryRepository : IGenericRepository
    {
        public IQueryable<Category> Categories { get; }

    }
}
