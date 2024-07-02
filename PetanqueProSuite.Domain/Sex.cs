using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Domain
{
    public enum Sex
    {
        [Description("Man")]
        M,

        [Description("Vrouw")]
        F,

        [Description("X")]
        X
    }
}
