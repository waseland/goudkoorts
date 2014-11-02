using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    abstract public class Wissel : Veld
    {
        public virtual WisselKant WisselStand
        {
            get;
            set;
        }

        public Wissel(Richtingen richting) : base(richting) { }

        public void WijzigWisselStand()
        {
            if (WisselStand == WisselKant.Boven) {
                WisselStand = WisselKant.Onder;
            }
            else
            {
                WisselStand = WisselKant.Boven;
            }
        }
    }
}

