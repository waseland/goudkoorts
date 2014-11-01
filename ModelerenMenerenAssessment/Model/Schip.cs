using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Schip
    {
        public int aantalLadingen = 0;
        public const int MAX_AANTAL_LADINGEN = 8;
        public virtual Kade Kade
        {
            get;
            set;
        }

        public virtual Depot Depot
        {
            get;
            private set;
        }

        public Schip(Depot depot)
        {
            Depot = depot;
        }

        internal void LadingErBij()
        {
            if (++aantalLadingen == MAX_AANTAL_LADINGEN) {
                Depot.NieweLading();
            }
        }
    }
}

