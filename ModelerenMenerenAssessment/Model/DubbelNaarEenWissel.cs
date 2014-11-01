﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model
{
    class DubbelNaarEenWissel : Wissel
    {
        public Veld VeldVanBoven { get; set; }
        public Veld VeldVanOnder { get; set; }
        public override Boolean KanVerplaatsen(Veld veld)
        {
            //Is het veld, afkanelijk van de stand, het vorig veld
            if ((WisselStand == WisselKant.Boven && VeldVanBoven != veld)
                || (WisselStand == WisselKant.Onder && VeldVanOnder != veld))
            {
                return false;
            }
            return true;
        }
    }
}
