using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class KarBaan
    {
        public int Length
        {
            get;
            private set;
        }
        public virtual Veld Startveld
        {
            get;
            private set;
        }

        public virtual Veld Eindveld
        {
            get;
            private set;
        }

        public Boolean Insert(Veld veld)
        {
            if (Startveld == null)
            {
                Startveld   = veld;
                Eindveld    = veld;
            }
            else
            {
                Veld tmp = Eindveld;

                Eindveld        = veld;
                if (tmp.VolgendVeld == null)
                {
                    tmp.VolgendVeld = Eindveld;
                }
            }
            
            Length++;

            return true;
        }
    }
}

