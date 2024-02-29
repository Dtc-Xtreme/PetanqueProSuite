using System.ComponentModel.DataAnnotations;

namespace PetanqueProSuite.API.Models
{
    public class ClubDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1, 999)]
        public int Number { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(150)]
        public string? ContactPerson { get; set; }
    }
}
