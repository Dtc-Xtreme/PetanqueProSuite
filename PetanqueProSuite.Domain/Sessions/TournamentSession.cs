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
        private IList<TournamentTeam> teams = new List<TournamentTeam>();
        public IList<TournamentTeam> Teams { get { return teams;  } }

        public void AddTeam(TournamentTeam team)
        {
            team.Number = GetFirstFreeTeamNumber();
            teams.Add(team);
        }
        public override void StartSession()
        {
            if(teams.Count == 4)
            {
                Started = true;
                ShuffleTeam();
            }
        }
        public override void NextRound()
        {
            throw new NotImplementedException();
        }

        private void ShuffleTeam()
        {
            Random rng = new Random();
            teams = teams.OrderBy(x => rng.Next()).ToList();
        }
        private int GetFirstFreeTeamNumber()
        {
            return Teams.Count()+1;
        }


    }
}
