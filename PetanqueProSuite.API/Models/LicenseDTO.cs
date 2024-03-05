using PetanqueProSuite.Domain;
using System.ComponentModel.DataAnnotations;

namespace PetanqueProSuite.API.Models
{
    public class LicenseDTO
    {
        [Required]
        [Range(1, 9999)]
        public int Number { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public int ClubId { get; set; }
    }
}
