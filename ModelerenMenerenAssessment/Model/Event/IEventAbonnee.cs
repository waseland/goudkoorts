using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model.Event
{
    interface IEventAbonnee
    {
        void informeer(Event gebeurtenis);
    }
}