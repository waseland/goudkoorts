using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model.Event
{
    public abstract class Event
    {
        public Events Type { get; protected set; }
        public Event(Events gebeurtenisType)
        {
            Type = gebeurtenisType;
        }
    }
}
