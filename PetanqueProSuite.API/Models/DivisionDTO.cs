using System.ComponentModel.DataAnnotations;

namespace PetanqueProSuite.API.Models
{
    public class DivisionDTO
    {
        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        public int LeagueId { get; set; }
    }
}
