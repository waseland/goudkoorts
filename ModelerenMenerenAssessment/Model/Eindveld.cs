using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Eindveld : Veld
    {
        public Eindveld(Richtingen richting) : base(richting) { }
        public override Boolean KanVerplaatsen()
        {
            return (VolgendVeld == null);
        }
    }
}

