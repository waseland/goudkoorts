using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Kar
    {
        protected Veld veld;
        public virtual Veld Veld
        {
            get;
            set;
        }

        public Boolean HeeftLading { get; set; }

        public Kar(Veld startVeld)
        {
            startVeld.PlaatsKarOpVeld(this);
            HeeftLading = true;
        }

        public Boolean Verplaats()
        {
            return Veld.VerplaatsKarNaarVolgendVeld();
        }
    }
}

