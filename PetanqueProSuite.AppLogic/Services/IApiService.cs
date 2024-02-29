using PetanqueProSuite.Domain;
using PetanqueProSuite.Domain.Competition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.AppLogic.Services
{
    public interface IApiService
    {
        public Task<List<Category>?> GetAllCategories();
        public Task<List<League>?> GetAllLeagues();
        public Task<List<Division>?> GetAllDivisions();
        public Task<List<CompetitionTeam>?> GetAllCompetitionTeams();

        public Task<List<Club>?> GetAllClubs();
    }
}
