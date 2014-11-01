using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Wissel : Veld
    {
        public virtual WisselKant WisselKant
        {
            get;
            set;
        }

    }
}

