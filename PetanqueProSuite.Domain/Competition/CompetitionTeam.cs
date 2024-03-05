using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Domain.Competition
{
    public class CompetitionTeam : Team
    {
        [Key]
        public int Id { get; set; }

        [StringLength(1)]
        public char? Identifyer { get; set; }

        [Required]
        public Club Club { get; set; }
        public int? ClubId { get; set; }

        [Required]
        public Division Division { get; set; }
        public int? DivisionId { get; set; }

        public ICollection<License> Licenses { get; set; }

        public override string ToString()
        {
            return Identifyer == null ? Club.Name : Club.Name + " " + Identifyer;
        }
    }
}
