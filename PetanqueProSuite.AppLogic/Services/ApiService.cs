using PetanqueProSuite.Domain;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetanqueProSuite.Domain.Competition;

namespace PetanqueProSuite.AppLogic.Services
{
    public class ApiService : IApiService
    {
        private string url = "https://localhost:44362";
        private HttpClient client = new HttpClient();

        public ApiService()
        {
            
        }

        public async Task<List<Category>?> GetAllCategories()
        {
            try
            {
                return await client.GetFromJsonAsync<List<Category>>(url + "/Category");

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<League>?> GetAllLeagues()
        {
            try
            {
                return await client.GetFromJsonAsync<List<League>>(url + "/League");

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Division>?> GetAllDivisions()
        {
            try
            {
                return await client.GetFromJsonAsync<List<Division>>(url + "/Division");

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<CompetitionTeam>?> GetAllCompetitionTeams()
        {
            try
            {
                return await client.GetFromJsonAsync<List<CompetitionTeam>>(url + "/CompetitionTeam");

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Club>?> GetAllClubs()
        {
            try
            {
                return await client.GetFromJsonAsync<List<Club>>(url + "/Club");

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
