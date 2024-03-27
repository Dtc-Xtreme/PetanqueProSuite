using PetanqueProSuite.Domain.Competition;
using PetanqueProSuite.Domain.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.AppLogic.Services
{
    public interface IGameSessionManager
    {
        public IGameSession SelectedSession { get; }
        public IList<IGameSession> Sessions { get; }

        public void AddSession(IGameSession session);
        public void RemoveSession(IGameSession session);
        public void SelectSession(IGameSession session);
    }
}
