using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetanqueProSuite.API.Models;
using PetanqueProSuite.Domain;
using PetanqueProSuite.Infrastructure.Interfaces;

namespace PetanqueProSuite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvinceController : Controller
    {
        private readonly IProvinceRepository provinceRepository;

        public ProvinceController(IProvinceRepository provinceRepository)
        {
            this.provinceRepository = provinceRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            try
            {
                Province? item = await provinceRepository.Provinces.FirstOrDefaultAsync(c => c.Id == id);
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
                IEnumerable<Province>? items = await provinceRepository.Provinces.ToListAsync();
                return Ok(items == null ? NotFound() : items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProvinceDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Province newItem = new Province
                    {
                        Name = dto.Name,
                        FederationId = dto.FederationId
                    };

                    return Ok(await provinceRepository.CreateAsync(newItem) == false ? BadRequest() : newItem);
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
                Province? selectedItem = await provinceRepository.Provinces.FirstOrDefaultAsync(c => c.Id == id);
                return Ok(await provinceRepository.DeleteAsync(selectedItem) == false ? BadRequest() : "Province with id: " + id + " is removed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
