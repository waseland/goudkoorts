using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model
{
    public class Baan
    {
        public Wissel[] wissels;
        private Random random;
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

        public Baan()
        {
            BaanA = new KarBaan();
            BaanB = new KarBaan();
            BaanC = new KarBaan();
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


            Schip schipA = new Schip();
            Schip schipB = new Schip();

            schepen[0] = schipA;
            schepen[1] = schipB;

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
            schip.Plaatsing = Richtingen.NOORD;
            BaanA.Insert(new Kade(schip, Richtingen.WEST));

            for (int i = 0; i < 7; i++)
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
            schip.Plaatsing = Richtingen.ZUID;
            BaanC.Insert(new Kade(schip, Richtingen.WEST));

            for (int i = 0; i < 7; i++)
            {
                BaanC.Insert(new Veld(Richtingen.WEST));
            }

            BaanC.Insert(new Eindveld(Richtingen.WEST));
        }

        public Veld GeefWillekurigeBaan()
        {
            if (random == null)
            {
                random = new Random();
            }

            int willekeurigGetal = random.Next(1, 4);
            KarBaan karBaan = BaanA;

            if (willekeurigGetal == 1)
            {
                karBaan = BaanA;
            } else if (willekeurigGetal == 2) {
                karBaan =  BaanB;
            } else if (willekeurigGetal == 3) {
                karBaan =  BaanC;
            }

            return karBaan.Startveld;
        }
        public void VeranderWisselStand(String wissel)
        {
            int wisselID;
            bool isGetal = int.TryParse(wissel, out wisselID);
            if (isGetal)
            {
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
    }
}
