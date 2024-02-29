using PetanqueProSuite.Domain.Competition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.AppLogic.Services
{
    public interface ICompetitionSessionManager
    {
        public IList<Competition> Competitions { get; set; }

        public void AddSession();
        public void AddSession(Competition session);
        public void RemoveSession(Competition session);
    }
}
