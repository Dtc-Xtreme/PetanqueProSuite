using PetanqueProSuite.Domain;
using System.ComponentModel.DataAnnotations;

namespace PetanqueProSuite.AppLogic.Models
{
    public class LicenseDTO
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DayOfBirth { get; set; }

        [Required]
        public Sex Sex { get; set; }

        public byte[]? Image { get; set; }

        [Required]
        public int ClubId { get; set; }
    }
}
