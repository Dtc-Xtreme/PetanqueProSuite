using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetanqueProSuite.API.Models;
using PetanqueProSuite.Domain.Competition;
using PetanqueProSuite.Infrastructure.Interfaces;

namespace PetanqueProSuite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeagueController : Controller
    {
        private readonly ILeagueRepository leagueRepository;

        public LeagueController(ILeagueRepository leagueRepository)
        {
            this.leagueRepository = leagueRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            try
            {
                League? item = await leagueRepository.Leagues.FirstOrDefaultAsync(c => c.Id == id);
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
                IEnumerable<League>? items = await leagueRepository.Leagues.ToListAsync();
                return Ok(items == null ? NotFound() : items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(LeagueDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    League newItem = new League
                    {
                        Name = dto.Name,
                        CategoryId = dto.CategoryId 
                    };

                    return Ok(await leagueRepository.CreateAsync(newItem) == false ? BadRequest() : newItem);
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
                League? selectedItem = await leagueRepository.Leagues.FirstOrDefaultAsync(c => c.Id == id);
                return Ok(await leagueRepository.DeleteAsync(selectedItem) == false ? BadRequest() : "League with id: " + id + " is removed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
