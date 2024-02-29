using PetanqueProSuite.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Components.Competition
{
    public class CompetitionForm
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than 0.")]
        public int CategoryId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "LeagueId must be greater than 0.")]
        public int LeagueId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "DivisionId must be greater than 0.")]
        public int DivisionId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a valid home club.")]
        public int HomeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a valid visitor club.")]
        public int VisitorId { get; set; }

        [Required]
        public DateTime Start { get; set; } = DateTime.Now;

    }
}
