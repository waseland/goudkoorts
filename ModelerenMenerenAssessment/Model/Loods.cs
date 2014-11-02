using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Loods : Veld
    {
        public String Letter
        {
            get;
            private set;
        }

        public Loods(String letter, Richtingen richting) : base (richting)
        {
            Letter = letter;
        }
    }
}

