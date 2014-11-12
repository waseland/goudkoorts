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

            if (VolgendVeld.PlaatsKarOpVeld(Kar))
            {
                Kar = null;
                return true;
            }

            return false;
        }

        public virtual Boolean PlaatsKarOpVeld(Kar kar)
        {
            if (IsBezet())
            {
                return false;
            } else {

                Kar = kar;
                kar.Veld = this;
                return true;
            }
        }
    }
}
