using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Depot
    {
        public const int GOUDKOERS = 10;
        protected int aantalLadingen = 0;

        internal void NieweLading()
        {
            aantalLadingen++;
        }

        public int TotaalAantalPunten()
        {
            return (aantalLadingen * GOUDKOERS);
        }
    }
}

