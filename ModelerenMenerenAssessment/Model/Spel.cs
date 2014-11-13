using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ModelerenMenerenAssessment.Model.Event;

namespace ModelerenMenerenAssessment.Model
{
    public class Spel : IEventAbonnee
    {
        private int numCalls = 0;
        private Timer gameTimer;
        private Random random;
        public int AantalPunten
        {
            get;
            private set;
        }
        public Baan Baan
        {
            get;
            private set;
        }
        public Karren Karren
        {
            get;
            private set;
        }

        public Boolean IsVoorbij
        {
            get;
            private set;
        }
        public Spel()
        {
            Karren      = new Karren();
            //Initieer de baan en laat deze alle bannen instellen 
            Baan        = new Baan();
            Baan.Setup();

            random = new Random();
            IsVoorbij   = false;
            //Abonneer jezelf op de gebeurtenis dat er puntent zijn gescoord
            EventService eventService = EventService.GeefInstantie();
            eventService.abonneer(Events.NIEUWE_PUNTEN, this);
        }
        public void StartSpel()
        {
            TimerCallback tcb = VoegKarToe;
            gameTimer = new Timer(tcb, null, 500, 8000);
        }
     
        public void StopSpel()
        {
            gameTimer.Dispose();
            IsVoorbij = true;
        }

        public void VoegKarToe(Object stateInfo)
        {
            //Elke vier aanroepen, oftewel elke vier seconden komt er een kar bij 
            Kar kar = new Kar(Baan.GeefWillekurigeBaan());
            Karren.voegToe(kar);

            gameTimer.Change(random.Next(2000, 10000), 0);
        }

        public void DoeNieuweStap()
        {
            //Als er karren in het spel zitten, vraag deze dan een stap te nemen
            if (Karren.Lengte > 0)
            {
                try
                {
                    List<KarLink> verwijderLijst = new List<KarLink>();
                    KarLink karLink = Karren.peek();
                    Kar kar;
                   
                    while (karLink != null)
                    {
                        kar = karLink.geefKar();
                        //Vraag aan de kar om zig te verplaatsen
                        if (kar.Verplaats())
                        {
                            //Als er geen referentie naar een veld is 
                            if (kar.Veld == null)
                            {
                                verwijderLijst.Add(karLink);
                            }
                        }
                        else
                        {
                            StopSpel();
                            return ;
                        }

                        karLink = karLink.geefVolgende();
                    }

                    //Verwijder alle karren die in het verwijder lijstje zijn gekomen
                    if (verwijderLijst.Count > 0)
                    {
                        foreach (KarLink karList in verwijderLijst)
                        {
                            Boolean result = Karren.verwijder(karList);
                        }
                    }

                    verwijderLijst = null;
                }
                catch (Exception e)
                {
                    StopSpel();
                }
            }

            numCalls++;
        }

        public void informeer(Event.Event gebeurtenis)
        {
            if (gebeurtenis.Type == Events.NIEUWE_PUNTEN) {
                PuntenGescoordEvent puntentGescoord = (PuntenGescoordEvent)gebeurtenis;
                AantalPunten += puntentGescoord.AantalPunten;
            }
        }
    }
}

