using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetanqueProSuite.API.Models;
using PetanqueProSuite.Domain.Competition;
using PetanqueProSuite.Infrastructure.Interfaces;

namespace PetanqueProSuite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisionController : Controller
    {
        private readonly IDivisionRepository divisionRepository;

        public DivisionController(IDivisionRepository divisionRepository)
        {
            this.divisionRepository = divisionRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            try
            {
                Division? item = await divisionRepository.Divisions.FirstOrDefaultAsync(c => c.Id == id);
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
                IEnumerable<Division>? items = await divisionRepository.Divisions.ToListAsync();
                return Ok(items == null ? NotFound() : items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(DivisionDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Division newItem = new Division
                    {
                        LeagueId = dto.LeagueId,
                        Name = dto.Name
                    };

                    return Ok(await divisionRepository.CreateAsync(newItem) == false ? BadRequest() : newItem);
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
                Division? selectedItem = await divisionRepository.Divisions.FirstOrDefaultAsync(c => c.Id == id);
                return Ok(await divisionRepository .DeleteAsync(selectedItem) == false ? BadRequest() : "Division with id: " + id + " is removed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
