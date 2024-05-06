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
        public int Number { get; set; }

        [ValidateComplexType]
        public IList<Player> Players { get; set; } = new List<Player>();

        public override string ToString()
        {
            string text = "";
            foreach(var player in Players)
            {
                text += Number +  ": " + player.ToString() + ",";
            }
            return text.TrimEnd(',');
        }
    }
}
