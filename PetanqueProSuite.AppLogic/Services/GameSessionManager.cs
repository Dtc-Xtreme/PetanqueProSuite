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
        private IGameSession? selectedSession;
        public IGameSession? SelectedSession { get { return selectedSession; } }

        public IList<IGameSession> Sessions { get; }

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
            if(selectedSession == session) selectedSession = null;
            Sessions.Remove(session);
        }
        public void SelectSession(IGameSession session)
        {
            selectedSession = session;
        }
    }
}
