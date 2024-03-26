using PetanqueProSuite.Domain.Competition;
using PetanqueProSuite.Domain.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.AppLogic.Services
{
    public class GameSessionManager : IGameSessionManager
    {
        public IList<IGameSession> Sessions { get; set; }

        public GameSessionManager()
        {
            Sessions = new List<IGameSession>();
        }

        public void AddSession(IGameSession session)
        {
            Sessions.Add(session);
        }

        public void RemoveSession(IGameSession session)
        {
            Sessions.Remove(session);
        }
    }
}
