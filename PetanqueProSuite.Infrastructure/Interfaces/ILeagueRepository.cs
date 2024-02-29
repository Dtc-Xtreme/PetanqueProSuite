using PetanqueProSuite.Domain.Competition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Infrastructure;

namespace PetanqueProSuite.Infrastructure.Interfaces
{
    public interface ILeagueRepository : IGenericRepository
    {
        public IQueryable<League> Leagues { get; }

    }
}
