using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetanqueProSuite.API.Models;
using PetanqueProSuite.Domain;
using PetanqueProSuite.Infrastructure.Interfaces;

namespace PetanqueProSuite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LicenseController : Controller
    {
        private readonly ILicenseRepository licenseRepository;

        public LicenseController(ILicenseRepository licenseRepository)
        {
            this.licenseRepository = licenseRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            try
            {
                License? item = await licenseRepository.Licenses.FirstOrDefaultAsync(c => c.Id == id);
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
                IEnumerable<License>? items = await licenseRepository.Licenses.ToListAsync();
                return Ok(items == null ? NotFound() : items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(LicenseDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    License newItem = new License
                    {
                        Number = dto.Number,
                        ClubId = dto.ClubId,
                        FirstName = dto.FirstName,
                        LastName = dto.LastName
                    };

                    return Ok(await licenseRepository.CreateAsync(newItem) == false ? BadRequest() : newItem);
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
                License? selectedItem = await licenseRepository.Licenses.FirstOrDefaultAsync(c => c.Id == id);
                return Ok(await licenseRepository.DeleteAsync(selectedItem) == false ? BadRequest() : "License with id: " + id + " is removed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
