using PetanqueProSuite.Domain;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetanqueProSuite.Domain.Competition;
using PetanqueProSuite.AppLogic.Models;

namespace PetanqueProSuite.AppLogic.Services
{
    public class ApiService : IApiService
    {
        private string url = "https://api.dtc-xtreme.net";
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
        public async Task<License?> GetLicenseWithId(int id)
        {
            try
            {
                return await client.GetFromJsonAsync<License>(url + "/License/" + id);
            }
            catch (Exception ex)
            {
            }

            return null;
        }
        public async Task<List<License>?> GetAllLicenses()
        {
            try
            {
                return await client.GetFromJsonAsync<List<License>>(url + "/License");

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Province>?> GetAllProvinces()
        {
            try
            {
                return await client.GetFromJsonAsync<List<Province>>(url + "/Province");

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Federation>?> GetAllFederation()
        {
            try
            {
                return await client.GetFromJsonAsync<List<Federation>>(url + "/Federation");

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<License?> CreateLicense(string firstName, string lastName, DateTime dateOfBirth, Sex sex, byte[]? image, int clubId)
        {
            try
            {
                LicenseDTO licenseDTO = new LicenseDTO
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DayOfBirth = dateOfBirth,
                    Sex = sex,
                    Image = image,
                    ClubId = clubId
                };

                HttpResponseMessage response = await client.PostAsJsonAsync(url + "/License", licenseDTO);

                if (response != null && response.IsSuccessStatusCode)
                {
                    // Read and deserialize the response content to a License object
                    License? result = await response.Content.ReadFromJsonAsync<License>();

                    // Return the License object
                    return result;
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }

    }
}
