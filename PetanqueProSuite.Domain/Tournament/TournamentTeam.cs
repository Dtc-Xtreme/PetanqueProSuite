using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Domain.Tournament
{
    public class TournamentTeam
    {
        [ValidateComplexType]
        public IList<Player> Players { get; set; } = new List<Player>();
    }
}
