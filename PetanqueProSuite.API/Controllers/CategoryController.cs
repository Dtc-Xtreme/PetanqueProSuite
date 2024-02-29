using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetanqueProSuite.API.Models;
using PetanqueProSuite.Domain.Competition;
using PetanqueProSuite.Infrastructure.Interfaces;

namespace PetanqueProSuite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            try
            {
                Category? item = await categoryRepository.Categories.FirstOrDefaultAsync(c => c.Id == id);
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
                IEnumerable<Category>? items = await categoryRepository.Categories.ToListAsync();
                return Ok(items == null ? NotFound() : items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category newItem = new Category
                    {
                        Name = dto.Name
                    };

                    return Ok(await categoryRepository.CreateAsync(newItem) == false ? BadRequest() : newItem);
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
                Category? selectedItem = await categoryRepository.Categories.FirstOrDefaultAsync(c => c.Id == id);
                return Ok(await categoryRepository.DeleteAsync(selectedItem) == false ? BadRequest() : "Category with id: " + id + " is removed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
