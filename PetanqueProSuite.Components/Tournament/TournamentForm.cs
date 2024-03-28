using PetanqueProSuite.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Components.Tournament
{
    public class TournamentForm
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime Start { get; set; } = DateTime.Now;

        [Required]
        public TeamSize TeamSize { get; set; }
    }
}
