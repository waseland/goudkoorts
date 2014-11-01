using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Kar
    {
        protected Veld veld;
        public virtual Veld KarVeld
        {
            get
            {
                return veld;
            }
            set 
            {
                veld = value;

                if (value != null){
                    value.Kar = this;
                }
            }
        }

        public static bool HeeftLading { get; set; }

        public Kar(Veld startVeld)
        {
            KarVeld = startVeld;
            HeeftLading = true;
        }

        internal bool KanVerplaatsen()
        {
            return (KarVeld.VolgendVeld != null && KarVeld.VolgendVeld.KanVerplaatsen(KarVeld));
        }

        internal void VerplaatsNaarVolgendeVeld()
        {
            Veld nieuwVeld  = KarVeld.VolgendVeld;
            KarVeld.Kar     = null;
            KarVeld         = nieuwVeld;
        }
    }
}

