using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetanqueProSuite.API.Models;
using PetanqueProSuite.Domain;
using PetanqueProSuite.Infrastructure.Interfaces;

namespace PetanqueProSuite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubController : Controller
    {
        private readonly IClubRepository clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            try
            {
                Club? item = await clubRepository.Clubs.FirstOrDefaultAsync(c => c.Id == id);
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
                IEnumerable<Club>? items = await clubRepository.Clubs.ToListAsync();
                return Ok(items == null ? NotFound() : items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ClubDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Club newItem = new Club
                    {
                        Name = dto.Name,
                        Address = dto.Address,
                        Phone = dto.Phone,
                        Number = dto.Number
                    };

                    return Ok(await clubRepository.CreateAsync(newItem) == false ? BadRequest() : newItem);
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
                Club? selectedItem = await clubRepository.Clubs.FirstOrDefaultAsync(c => c.Id == id);
                return Ok(await clubRepository.DeleteAsync(selectedItem) == false ? BadRequest() : "Club with id: " + id + " is removed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
