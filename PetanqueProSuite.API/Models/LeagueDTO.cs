using System.ComponentModel.DataAnnotations;

namespace PetanqueProSuite.API.Models
{
    public class LeagueDTO
    {
        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
