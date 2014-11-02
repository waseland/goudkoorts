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

        public virtual Boolean KanVerplaatsen()
        {
            return (VolgendVeld != null && MagOpVeldStaan(VolgendVeld));
        }

        public virtual Boolean MagOpVeldStaan(Veld veld)
        {
            return (!veld.IsBezet());
        }
    }
}
