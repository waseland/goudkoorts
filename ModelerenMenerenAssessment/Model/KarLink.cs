using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model
{
    public class KarLink
    {
        private Kar kar;
        private KarLink volgendeLink;
        private KarLink vorigeLink;
        public KarLink(Kar kar)
        {
            this.kar = kar;
        }

        public Kar geefKar()
        {
            return kar;
        }

        public KarLink geefVolgende()
        {
            return volgendeLink;
        }

        public Boolean heeftVolgende()
        {
            return (volgendeLink != null);
        }

        public void zetVolgende(KarLink karLink)
        {
            volgendeLink = karLink;
            karLink.zetVorige(this);
        }

        public KarLink geefVorige()
        {
            return vorigeLink;
        }

        public Boolean heeftVorige()
        {
            return (vorigeLink != null);
        }

        public void zetVorige(KarLink karLink)
        {
            vorigeLink = karLink;
        }
    }
}
