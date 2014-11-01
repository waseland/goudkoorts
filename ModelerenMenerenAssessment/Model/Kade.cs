using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelerenMenerenAssessment.Model
{
    public class Kade : Veld
    {
        public virtual Schip Schip
        {
            get;
            private set;
        }

        public override Kar Kar
        {
            get
            {
                return base.Kar;
            }
            set
            {
                base.Kar = value;

                LaadKarLadingAf();
            }
        }

        public Kade(Schip schip)
        {
            Schip = schip;
        }

        protected void LaadKarLadingAf () {
            Schip.LadingErBij();
            Kar.HeeftLading = false;
        }
    }
}

