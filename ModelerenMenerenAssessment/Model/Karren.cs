using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model
{
    public class Karren
    {
        private KarLink eerste;
        private KarLink laatste;
        public int Lengte
        {
            get;
            set;
        }
        public void voegToe(Kar kar)
        {
            KarLink karLink = new KarLink(kar);
            if (eerste == null)
            {
                eerste = karLink;
                laatste = karLink;
            }
            else
            {
                KarLink tmp = laatste;
                laatste = karLink;
                tmp.zetVolgende(karLink);
            }

            Lengte++;
        }

        public KarLink pop()
        {
            KarLink eersteLink = eerste;
            eerste = eersteLink.geefVolgende();

            Lengte--;
            return eersteLink;
        }

        public KarLink peek()
        {
            return eerste;
        }

        public Boolean verwijder(KarLink teVerwijderenKarLink)
        {
            if (laatste != null) {
                KarLink huidigeLink = eerste;

                while (huidigeLink != teVerwijderenKarLink && huidigeLink.heeftVolgende()) {
                    huidigeLink = huidigeLink.geefVolgende();
                }

                if (huidigeLink == teVerwijderenKarLink) {
                    if (huidigeLink == eerste)
                    {
                        if (huidigeLink.heeftVolgende()) {
                            huidigeLink.geefVolgende().zetVorige(null);
                            eerste = huidigeLink.geefVolgende();
                        }
                        else
                        {
                            eerste = null;
                            laatste = null;
                        }
                    } else if (huidigeLink == laatste) {
                        laatste = huidigeLink.geefVorige();
                        laatste.zetVolgende(null);
                    }
                    else
                    {
                        KarLink vorige = huidigeLink.geefVorige();
                        vorige.zetVolgende(huidigeLink.geefVolgende());
                    }
                   
                    huidigeLink = null;

                    Lengte--;
                    return true;
                }
            }

            return false;
        }
    }
}
