using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model
{
    public class Veld
    {
        public virtual Kar Kar
        {
            get;
            set;
        }

        public virtual Veld VolgendVeld
        {
            get;
            set;
        }

        public virtual Richtingen Richting
        {
            get;
            private set;
        }

        public Veld(Richtingen richting)
        {
            Richting = richting;
        }

        public virtual Boolean IsBezet()
        {
            return (Kar != null);
        }

        internal virtual Boolean VerplaatsKarNaarVolgendVeld()
        {
            if (VolgendVeld == null)
            {
                throw new Exception("Geen volgend veld");
            }
            int resultaat = VolgendVeld.PlaatsKarOpVeld(Kar);
            if (resultaat >= 0)
            {
                if (resultaat == 0)
                {
                    Kar = null;
                }
                return true;
            } 

            return false;
        }

        public virtual int PlaatsKarOpVeld(Kar kar)
        {
            if (IsBezet())
            {
                return -1;
            } else {

                Kar = kar;
                kar.Veld = this;
                return 0;
            }
        }
    }
}
