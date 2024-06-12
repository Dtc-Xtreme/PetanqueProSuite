using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetanqueProSuite.API.Models;
using PetanqueProSuite.Domain;
using PetanqueProSuite.Infrastructure.Interfaces;
using Serilog;

namespace PetanqueProSuite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FederationController : Controller
    {
        private readonly IFederationRepository federationRepository;

        public FederationController(IFederationRepository federationRepository)
        {
            this.federationRepository = federationRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            try
            {
                Federation? item = await federationRepository.Federations.FirstOrDefaultAsync(c => c.Id == id);
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
                Log.Information("Hello, file logger!");
                IEnumerable<Federation>? items = await federationRepository.Federations.ToListAsync();
                return Ok(items == null ? NotFound() : items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(FederationDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Federation newItem = new Federation
                    {
                        Name = dto.Name
                    };

                    return Ok(await federationRepository.CreateAsync(newItem) == false ? BadRequest() : newItem);
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
                Federation? selectedItem = await federationRepository.Federations.FirstOrDefaultAsync(c => c.Id == id);
                return Ok(await federationRepository.DeleteAsync(selectedItem) == false ? BadRequest() : "Federation with id: " + id + " is removed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
