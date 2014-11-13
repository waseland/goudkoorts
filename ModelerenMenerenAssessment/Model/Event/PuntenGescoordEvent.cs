using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model.Event
{
    class PuntenGescoordEvent : Event
    {
        public int AantalPunten { get; private set; }
        public PuntenGescoordEvent(int aantalPunten) : base(Events.NIEUWE_PUNTEN)
        {
            AantalPunten = aantalPunten;
        }
    }
}
