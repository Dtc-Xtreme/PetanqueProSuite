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
        public IList<IGameSession> Sessions { get; set; }

        public void AddSession(IGameSession session);
        public void RemoveSession(IGameSession session);
    }
}
