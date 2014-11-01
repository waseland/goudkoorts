using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ModelerenMenerenAssessment.Model
{
    public class Spel
    {
        private Timer gameTimer = null;
        private int numCalls = 0;
        public KarBaan BaanA
        {
            get;
            private set;
        }

        public virtual List<Kar> Karren
        {
            get;
            set;
        }

        public virtual Depot Depot
        {
            get;
            set;
        }
        public Boolean IsVoorbij
        {
            get;
            set;
        }
        public Spel()
        {
            Karren = new List<Kar>();
        }
        public virtual void Setup()
        {
            Schip[] schepen = SetupSchepen();
            SetupKarBannen(schepen);
        }

        private Schip[] SetupSchepen()
        {
            Schip[] schepen = new Schip[2];

            Depot           = new Depot();
            Schip schipA    = new Schip(Depot);
            Schip schipB    = new Schip(Depot);

            schepen[0]      = schipA;
            schepen[1]      = schipB;

            return schepen;
        }

        private void SetupKarBannen(Schip[] schepen)
        {
            BaanA = new KarBaan();
            BaanA.Insert(new Loods());
            //Maak een testbaan op
            for (int i = 0; i < 5; i++ )
            {
                BaanA.Insert(new Veld());
            }

            BaanA.Insert(new Kade(schepen[0]));

            //Maak een testbaan op
            for (int i = 0; i < 5; i++)
            {
                BaanA.Insert(new Veld());
            }

            BaanA.Insert(new Kade(schepen[1]));
            BaanA.Insert(new Eindveld());
        }

        public void StartSpel()
        {
            TimerCallback tcb = this.NieuweStap;
            AutoResetEvent autoEvent    = new AutoResetEvent(false);
            Timer gameTimer             = new Timer(tcb, autoEvent, 3000, 500);
        }

        public void StopSpel()
        {
            gameTimer.Dispose();
            IsVoorbij = true;
        }

        public void NieuweStap(Object stateInfo)
        {
            Console.WriteLine("Me is called");
            //Elke vier aanroepen, oftewel elke vier seconden komt er een kar bij 
            if (numCalls % 20 == 0) {
                Kar kar = new Kar(BaanA.Startveld);
                Karren.Add(kar);
            }
            //Als er karren in het spel zitten, vraag deze dan een stap te nemen
            if (Karren.Count > 0) {
                List<Kar> verwijderLijst = new List<Kar>();
                foreach (Kar kar in Karren){
                    if (!kar.KanVerplaatsen())
                    {
                        StopSpel();
                        return;
                    } 
                    else 
                    {
                        kar.VerplaatsNaarVolgendeVeld();
                    }

                    if (kar.KarVeld == null) {
                        verwijderLijst.Add(kar);
                    }
                }
                //Verwijder alle karren die in het verwijder lijstje zijn gekomen
                if (verwijderLijst.Count > 0) {
                    foreach (Kar kar in verwijderLijst)
                    {
                        Karren.Remove(kar);
                    }
                }

                verwijderLijst = null;
            }

            numCalls++;
        }
    }
}

