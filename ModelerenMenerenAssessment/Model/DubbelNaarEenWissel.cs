using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model
{
    class DubbelNaarEenWissel : Wissel
    {
        public DubbelNaarEenWissel(Richtingen richting) : base(richting) { }
        public Veld VeldVanBoven { get; set; }
        public Veld VeldVanOnder { get; set; }
        public override Boolean PlaatsKarOpVeld(Kar kar)
        {
           //Is het veld, afkanelijk van de stand, het vorig veld
            if ((WisselStand == WisselKant.Boven && kar.Veld == VeldVanBoven) || (WisselStand == WisselKant.Onder && kar.Veld == VeldVanOnder))
            {
                return base.PlaatsKarOpVeld(kar);
            }

            return false;
        }
    }
}
