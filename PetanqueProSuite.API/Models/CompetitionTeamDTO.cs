using System.ComponentModel.DataAnnotations;

namespace PetanqueProSuite.API.Models
{
    public class CompetitionTeamDTO
    {
        [StringLength(1)]
        public char? Identifyer { get; set; }

        [Required]
        public int ClubId { get; set; }

        [Required]
        public int DivisionId { get; set; }
    }
}
