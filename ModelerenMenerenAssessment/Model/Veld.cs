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

        public virtual Boolean IsBezet()
        {
            return (Kar != null);
        }

        public virtual Boolean KanVerplaatsen(Veld veld)
        {
            return true;
        }
    }
}
