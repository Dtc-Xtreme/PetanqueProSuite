using PetanqueProSuite.Domain.Competition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.AppLogic.Services
{
    public class CompetitionSessionManager : ICompetitionSessionManager
    {
        public IList<Competition> Competitions { get; set; }

        public CompetitionSessionManager()
        {
            Competitions = new List<Competition>();
        }

        public void AddSession()
        {
            Competitions.Add(new Competition());
        }
        public void AddSession(Competition session)
        {
            Competitions.Add(session);
        }

        public void RemoveSession(Competition session)
        {
            Competitions.Remove(session);
        }
    }
}
