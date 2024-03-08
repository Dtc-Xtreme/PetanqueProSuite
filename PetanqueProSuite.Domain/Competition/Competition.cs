using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Domain.Competition
{
    public class Competition
    {
        public Category Category { get; set; }
        public League League { get; set; }
        public Division Division { get; set; }

        public CompetitionTeam Home { get; set; }
        public CompetitionTeam Visitor { get; set; }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; } = null;

        public override string ToString()
        {
            return Home.ToString() + " VS " + Visitor.ToString() + " (" + Division.Name + ")";
        }
    }
}
