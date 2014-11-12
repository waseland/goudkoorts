using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model
{
    public enum Richtingen : int
    {
        NOORD,
        ZUID,
        OOST,
        WEST,
        HOEK_NOORD_OOST,
        HOEK_NOORD_WEST,
        HOEK_ZUID_WEST,
        HOEK_ZUID_OOST,
        HOEK_WEST_ZUID,
        HOEK_OOST_NOORD,
        HOEK_OOST_ZUID,
        NEUTRAAL
    }
}
