﻿using ModelerenMenerenAssessment.Model.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Kade : Veld
    {
        private EventService eventService;
        public virtual Schip Schip
        {
            get;
            private set;
        }


        public Kade(Schip schip, Richtingen richting)
            : base(richting)
        {
            Schip = schip;
            eventService = EventService.GeefInstantie();
        }

        protected void LaadKarLadingAf () {
            Schip.LadingErBij();
            Kar.HeeftLading = false;
            eventService.publiseer(new PuntenGescoordEvent(1));
        }

        public override Boolean PlaatsKarOpVeld(Kar kar)
        {
            if (base.PlaatsKarOpVeld(kar))
            {
                LaadKarLadingAf();
                return true;
            }

            return false;
        }
    }
}

