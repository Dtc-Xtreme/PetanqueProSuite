using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Domain.Competition
{
    public class Division
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        //public League League { get; set; }

        public int? LeagueId { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public ICollection<CompetitionTeam> CompetitionTeams { get; set; }
    }
}
