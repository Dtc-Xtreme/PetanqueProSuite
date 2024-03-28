using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Domain.Sessions
{
    public abstract class GameSession
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public TeamSize TeamSize { get; set; }

        public override string ToString()
        {
            return Name + " (" + TeamSize + ")";
        }
    }
}
