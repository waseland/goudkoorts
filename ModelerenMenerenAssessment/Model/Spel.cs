using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Spel
    {
        public Wissel[] wissels;
        private int numCalls = 0;
        public KarBaan BaanA
        {
            get;
            private set;
        }
        public KarBaan BaanB
        {
            get;
            private set;
        }
        public KarBaan BaanC
        {
            get;
            private set;
        }

        public Karren Karren
        {
            get;
            private set;
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
            Karren      = new Karren();
            IsVoorbij   = false;
            BaanA       = new KarBaan();
            BaanB       = new KarBaan();
            BaanC       = new KarBaan();
        }
        public virtual void Setup()
        {
            SetupWissels();
            Schip[] schepen = SetupSchepen();

            SetupKarBaanA(schepen[0]);
            SetupKarBaanB();
            SetupKarBaanC(schepen[1]);
            
        }
        protected void SetupWissels()
        {
            wissels = new Wissel[5];

            wissels[0] = new DubbelNaarEenWissel(Richtingen.NEUTRAAL) { WisselStand = WisselKant.Boven };
            wissels[1] = new EenNaarDubbelWissel(Richtingen.OOST) { WisselStand = WisselKant.Boven };
            wissels[2] = new DubbelNaarEenWissel(Richtingen.NEUTRAAL) { WisselStand = WisselKant.Boven };
            wissels[3] = new DubbelNaarEenWissel(Richtingen.NEUTRAAL) { WisselStand = WisselKant.Boven };
            wissels[4] = new EenNaarDubbelWissel(Richtingen.OOST) { WisselStand = WisselKant.Boven };
        }

        protected Schip[] SetupSchepen()
        {
            Schip[] schepen = new Schip[2];

            Depot           = new Depot();
            Schip schipA    = new Schip(Depot);
            Schip schipB    = new Schip(Depot);

            schepen[0]      = schipA;
            schepen[1]      = schipB;

            return schepen;
        }

        protected void SetupKarBaanA(Schip schip)
        {
            BaanA.Insert(new Loods("A", Richtingen.OOST));
            BaanA.Insert(new Veld(Richtingen.OOST));
            BaanA.Insert(new Veld(Richtingen.OOST));
            BaanA.Insert(new Veld(Richtingen.HOEK_OOST_ZUID));
            //Eerste dubbel wissel - -\__
            //                     - -/
            DubbelNaarEenWissel dubbleWissel = (DubbelNaarEenWissel)wissels[0];
            dubbleWissel.VeldVanBoven = BaanA.Eindveld;
            BaanA.Insert(dubbleWissel);

            BaanA.Insert(new Veld(Richtingen.OOST));
            //Eerste dubbel wissel - -\__
            //                     - -/
            EenNaarDubbelWissel eenNaarDubbel1 = (EenNaarDubbelWissel)wissels[1];
            BaanA.Insert(eenNaarDubbel1);
            BaanA.Insert(new Veld(Richtingen.HOEK_ZUID_OOST));
            BaanA.Insert(new Veld(Richtingen.OOST));
            BaanA.Insert(new Veld(Richtingen.OOST));
            BaanA.Insert(new Veld(Richtingen.OOST));
            BaanA.Insert(new Veld(Richtingen.HOEK_OOST_ZUID));
            
            DubbelNaarEenWissel dubbleWissel2 = (DubbelNaarEenWissel)wissels[2];
            dubbleWissel2.VeldVanBoven = BaanA.Eindveld;
            BaanA.Insert(dubbleWissel2);

            BaanA.Insert(new Veld(Richtingen.OOST));
            //Omhoog
            BaanA.Insert(new Veld(Richtingen.HOEK_OOST_NOORD));
            BaanA.Insert(new Veld(Richtingen.NOORD));
            BaanA.Insert(new Veld(Richtingen.NOORD));
            BaanA.Insert(new Veld(Richtingen.HOEK_ZUID_WEST));

            //Weer terug naar af
            BaanA.Insert(new Veld(Richtingen.WEST));
            BaanA.Insert(new Veld(Richtingen.WEST));
            //Voeg een kade toe
            BaanA.Insert(new Kade(schip, Richtingen.WEST));

            for (int i = 0; i < 7; i++ )
            {
                BaanA.Insert(new Veld(Richtingen.WEST));
            }
            
            BaanA.Insert(new Eindveld(Richtingen.WEST));
        }

        protected void SetupKarBaanB()
        {
            BaanB.Insert(new Loods("B", Richtingen.OOST));
            BaanB.Insert(new Veld(Richtingen.OOST));
            BaanB.Insert(new Veld(Richtingen.OOST));
            BaanB.Insert(new Veld(Richtingen.HOEK_OOST_NOORD));
            //Eerste dubbel wissel - -\__
            //                     - -/
            DubbelNaarEenWissel dubbleWissel = (DubbelNaarEenWissel)wissels[0];
            dubbleWissel.VeldVanOnder = BaanB.Eindveld;
            BaanB.Insert(dubbleWissel);
            
            Veld onderVeld = new Veld(Richtingen.HOEK_NOORD_OOST);
            EenNaarDubbelWissel eenNaarDubbel = (EenNaarDubbelWissel)wissels[1];
            eenNaarDubbel.OnderVeld = onderVeld;
            //onderVeld
            BaanB.Insert(onderVeld);
            BaanB.Insert(new Veld(Richtingen.HOEK_OOST_ZUID));
            
            DubbelNaarEenWissel dubbleWissel3 = (DubbelNaarEenWissel)wissels[3];
            dubbleWissel3.VeldVanBoven = BaanB.Eindveld;
            BaanB.Insert(dubbleWissel3);
            
            BaanB.Insert(new Veld(Richtingen.OOST));
            
            EenNaarDubbelWissel eenNaarDubbel4 = (EenNaarDubbelWissel)wissels[4];
            BaanB.Insert(eenNaarDubbel4);
            BaanB.Insert(new Veld(Richtingen.HOEK_ZUID_OOST));
            BaanB.Insert(new Veld(Richtingen.HOEK_OOST_NOORD));
            
            DubbelNaarEenWissel dubbleWissel2 = (DubbelNaarEenWissel)wissels[2];
            dubbleWissel2.VeldVanOnder = BaanB.Eindveld;
            BaanB.Eindveld.VolgendVeld = dubbleWissel2;
            //BaanB.Insert(dubbleWissel3);
        }

        protected void SetupKarBaanC(Schip schip)
        {
            BaanC.Insert(new Loods("C", Richtingen.OOST));
            for (int i = 0; i < 5; i++)
            {
                BaanC.Insert(new Veld(Richtingen.OOST));
            }

            BaanC.Insert(new Veld(Richtingen.HOEK_OOST_NOORD));

            DubbelNaarEenWissel dubbleWissel3 = (DubbelNaarEenWissel)wissels[3];
            dubbleWissel3.VeldVanOnder = BaanC.Eindveld;
            BaanC.Insert(dubbleWissel3);
            

            Veld onderVeld = new Veld(Richtingen.HOEK_NOORD_OOST);
            EenNaarDubbelWissel eenNaarDubbel4 = (EenNaarDubbelWissel)wissels[4];
            eenNaarDubbel4.OnderVeld = onderVeld;

            BaanC.Insert(onderVeld);
            BaanC.Insert(new Veld(Richtingen.OOST));
            BaanC.Insert(new Veld(Richtingen.OOST));
            BaanC.Insert(new Veld(Richtingen.HOEK_OOST_ZUID));
            BaanC.Insert(new Veld(Richtingen.ZUID));
            BaanC.Insert(new Veld(Richtingen.HOEK_NOORD_WEST));
            
            //Weer terug naar af
            BaanC.Insert(new Veld(Richtingen.WEST));
            BaanC.Insert(new Veld(Richtingen.WEST));
            //Voeg een kade toe
            BaanC.Insert(new Kade(schip, Richtingen.WEST));

            for (int i = 0; i < 7; i++ )
            {
                BaanC.Insert(new Veld(Richtingen.WEST));
            }
            
            BaanC.Insert(new Eindveld(Richtingen.WEST));
            
        }

        public void StopSpel()
        {
            IsVoorbij = true;
        }
        public void VeranderWisselStand(String wissel)
        {
            int wisselID;
            bool isGetal = int.TryParse(wissel, out wisselID);
            if (isGetal) {
                if (wisselID > 0 && wisselID <= 5)
                {
                    wissels[wisselID - 1].WijzigWisselStand();
                }
            }
            else
            {
                throw new Exception("Geen goeie input");
            }
        }
        public void DoeNieuweStap()
        {

            //Elke vier aanroepen, oftewel elke vier seconden komt er een kar bij 
            if (numCalls % 4 == 0)
            {
                Kar kar = new Kar(BaanA.Startveld);
                Karren.voegToe(kar);
            }
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
    }
}

