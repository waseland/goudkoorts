using ModelerenMenerenAssessment.Model.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Schip
    {
        public const int MAX_AANTAL_LADINGEN = 8;
        private EventService eventService;
        public int AantalLadingen
        {
            get;
            private set;
        }
        public virtual Kade Kade
        {
            get;
            set;
        }
        public Richtingen Plaatsing
        {
            get;
            set;
        }

        public Schip () 
        {
            eventService = EventService.GeefInstantie();
        }

        internal void LadingErBij()
        {
            //Is het aantal ladingen gelijk aan het maximum???
            if (++AantalLadingen == MAX_AANTAL_LADINGEN)
            {
                //Geef door aan de Luisteraar dat er punten zijn gescoord
                eventService.publiseer(new PuntenGescoordEvent(10));
                //Reset
                AantalLadingen = 0;
            }
        }
    }
}

