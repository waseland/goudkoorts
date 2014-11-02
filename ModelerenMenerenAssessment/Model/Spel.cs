using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Spel
    {
        private Wissel[] wissels;
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
            Karren      = new List<Kar>();
            IsVoorbij   = false;
            BaanA       = new KarBaan();
        }
        public virtual void Setup()
        {
            SetupWissels();
            Schip[] schepen = SetupSchepen();

            SetupKarBaanA();
            SetUpKarBaanB();
            SetUpKarBaanC();
        }
        private void SetupWissels()
        {
            wissels = new Wissel[5];

            wissels[0] = new DubbelNaarEenWissel(Richtingen.OOST) { WisselStand = WisselKant.Boven };
            wissels[1] = new EenNaarDubbelWissel(Richtingen.OOST) { WisselStand = WisselKant.Boven };
            wissels[2] = new DubbelNaarEenWissel(Richtingen.OOST) { WisselStand = WisselKant.Boven };
            wissels[3] = new DubbelNaarEenWissel(Richtingen.OOST) { WisselStand = WisselKant.Boven };
            wissels[4] = new EenNaarDubbelWissel(Richtingen.OOST) { WisselStand = WisselKant.Boven };
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

        private void SetupKarBaanA()
        {
            BaanA.Insert(new Loods("A", Richtingen.OOST));
            BaanA.Insert(new Veld(Richtingen.OOST));
            BaanA.Insert(new Veld(Richtingen.OOST));
            //Eerste dubbel wissel - -\__
            //                     - -/
            DubbelNaarEenWissel dubbleWissel1 = (DubbelNaarEenWissel)wissels[0];
            dubbleWissel1.VeldVanBoven = BaanA.Eindveld;
            BaanA.Insert(dubbleWissel1);

            BaanA.Insert(new Veld(Richtingen.OOST));
            //Eerste dubbel wissel - -\__
            //                     - -/
            EenNaarDubbelWissel EenNaarDubbel = (EenNaarDubbelWissel)wissels[0];
            DubbleWissel1.VeldVanBoven = BaanA.Eindveld;
            BaanA.Insert(DubbleWissel1);
          
        }

        public void StopSpel()
        {
            IsVoorbij = true;
        }

        public void DoeNieuweStap()
        {
            
            //Elke vier aanroepen, oftewel elke vier seconden komt er een kar bij 
            if (numCalls % 4 == 0) {
                Kar kar = new Kar(BaanA.Startveld);
                Karren.Add(kar);
            }
            //Als er karren in het spel zitten, vraag deze dan een stap te nemen
            if (Karren.Count > 0) {
                List<Kar> verwijderLijst = new List<Kar>();
                foreach (Kar kar in Karren){
                    if (!kar.KanVerplaatsen())
                    {
                        Console.Clear();
                        Console.WriteLine("Kan Kar niet verplaatsen");
                        /*StopSpel();
                        return;*/
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

