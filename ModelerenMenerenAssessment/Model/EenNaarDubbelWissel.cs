using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model
{
    class EenNaarDubbelWissel : Wissel
    {
        public Veld OnderVeld
        {
            get;
            set;
        }

        public override Veld VolgendVeld
        {
            get
            {
                if (WisselStand == WisselKant.Boven)
                {
                    return base.VolgendVeld;
                }
                else if (WisselStand == WisselKant.Onder)
                {
                    return OnderVeld;
                }

                else
                {
                    return null;
                }
            }
            set
            {
                base.VolgendVeld = value;
            }
        }

        public EenNaarDubbelWissel(Richtingen richting) : base(richting) { }
    }
}
