using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Eindveld : Veld
    {
        public Eindveld(Richtingen richting) : base(richting) { }
        internal override Boolean VerplaatsKarNaarVolgendVeld()
        {
            if (VolgendVeld != null)
            {
                throw new Exception("Mag Geen volgend veld");
            }
            //Als er een kar op het veld staat.. Anders kan ie niet verplaatst worden he
            if (IsBezet()){
                Kar.Veld = null;
                Kar = null;

                return true;
            }

            return false;
        }
    }
}

