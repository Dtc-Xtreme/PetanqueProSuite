using System.ComponentModel.DataAnnotations;

namespace PetanqueProSuite.API.Models
{
    public class FederationDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
