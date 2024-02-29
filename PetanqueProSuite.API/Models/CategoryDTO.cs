using System.ComponentModel.DataAnnotations;

namespace PetanqueProSuite.API.Models
{
    public class CategoryDTO
    {
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
    }
}
