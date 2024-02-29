using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetanqueProSuite.API.Models;
using PetanqueProSuite.Domain;
using PetanqueProSuite.Domain.Competition;
using PetanqueProSuite.Infrastructure.Interfaces;

namespace PetanqueProSuite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompetitionTeamController : Controller
    {
        private readonly ICompetitionTeamRepository competitionTeamRepository;

        public CompetitionTeamController(ICompetitionTeamRepository competitionTeamRepository)
        {
            this.competitionTeamRepository = competitionTeamRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            try
            {
                CompetitionTeam? item = await competitionTeamRepository.CompetitionTeams.FirstOrDefaultAsync(c => c.Id == id);
                return Ok(item == null ? BadRequest() : item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<CompetitionTeam>? items = await competitionTeamRepository.CompetitionTeams.ToListAsync();
                return Ok(items == null ? NotFound() : items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CompetitionTeamDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CompetitionTeam newItem = new CompetitionTeam
                    {
                        Identifyer = dto.Identifyer,
                        ClubId = dto.ClubId,
                        DivisionId = dto.DivisionId
                    };

                    return Ok(await competitionTeamRepository.CreateAsync(newItem) == false ? BadRequest() : newItem);
                }
                return BadRequest("Model is not valid!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            try
            {
                CompetitionTeam? selectedItem = await competitionTeamRepository.CompetitionTeams.FirstOrDefaultAsync(c => c.Id == id);
                return Ok(await competitionTeamRepository.DeleteAsync(selectedItem) == false ? BadRequest() : "Club with id: " + id + " is removed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
