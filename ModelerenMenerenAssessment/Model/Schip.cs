using ModelerenMenerenAssessment.Model.Event;
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
        private EventService eventService;
        public virtual Kade Kade
        {
            get;
            set;
        }

        internal void LadingErBij()
        {
            if (++aantalLadingen == MAX_AANTAL_LADINGEN) {
                eventService.publiseer(new PuntenGescoordEvent(1));
                aantalLadingen = 0;
            }
        }
    }
}

