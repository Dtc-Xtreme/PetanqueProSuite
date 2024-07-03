using PetanqueProSuite.AppLogic.Models;
using PetanqueProSuite.Domain;
using PetanqueProSuite.Domain.Competition;
using System;

namespace PetanqueProSuite.AppLogic.Services
{
    public interface IApiService
    {
        public Task<List<Category>?> GetAllCategories();
        public Task<List<League>?> GetAllLeagues();
        public Task<List<Division>?> GetAllDivisions();
        public Task<List<CompetitionTeam>?> GetAllCompetitionTeams();
        public Task<List<Club>?> GetAllClubs();
        public Task<License?> GetLicenseWithId(int id);
        public Task<List<License>?> GetAllLicenses();
        public Task<List<Province>?> GetAllProvinces();
        public Task<List<Federation>?> GetAllFederation();

        public Task<License?> CreateLicense(string firstName, string lastName, DateTime dateOfBirth, Sex sex, byte[]? image, int clubId);

    }
}
