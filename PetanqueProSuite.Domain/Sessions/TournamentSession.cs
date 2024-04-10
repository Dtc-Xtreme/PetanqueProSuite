using PetanqueProSuite.Domain.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Domain.Sessions
{
    public class TournamentSession : GameSession, IGameSession
    {
        public IList<TournamentTeam> Teams { get; set; } = new List<TournamentTeam>();
    }
}
