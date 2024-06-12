using System.ComponentModel.DataAnnotations;

namespace PetanqueProSuite.API.Models
{
    public class ProvinceDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int FederationId { get; set; }
    }
}
