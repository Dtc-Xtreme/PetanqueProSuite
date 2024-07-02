using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Domain
{
    public enum LicenseCategory
    {
        [Description("Min.")]
        Min,

        [Description("Cad.")]
        Cad,

        [Description("Jun.")]
        Junior,

        [Description("Bel.")]
        Bel,

        [Description("Sen H.")]
        SenH,

        [Description("Sen D.")]
        SenD,

        [Description("Vet H.")]
        VetH,

        [Description("Vet D.")]
        VetD,
    }
}
