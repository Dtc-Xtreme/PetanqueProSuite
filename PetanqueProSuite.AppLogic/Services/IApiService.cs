using PetanqueProSuite.AppLogic.Models;
using PetanqueProSuite.Domain;
using PetanqueProSuite.Domain.Competition;

namespace PetanqueProSuite.AppLogic.Services
{
    public interface IApiService
    {
        public Task<List<Category>?> GetAllCategories();
        public Task<List<League>?> GetAllLeagues();
        public Task<List<Division>?> GetAllDivisions();
        public Task<List<CompetitionTeam>?> GetAllCompetitionTeams();
        public Task<List<Club>?> GetAllClubs();
        public Task<List<License>?> GetAllLicenses();

        public Task<License?> CreateLicense(string firstName, string lastName, DateTime dateOfBirth, int clubId);

    }
}
