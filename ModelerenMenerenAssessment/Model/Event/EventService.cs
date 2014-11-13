using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.Model.Event
{
    public class EventService
    {
        private static EventService instance;
        private Hashtable abonnees;
        protected EventService()
        {
            abonnees = new Hashtable();
        }

        public static EventService GeefInstantie()
        {
            if (instance == null)
            {
                instance = new EventService();
            }

            return instance;
        }

        public void publiseer(Event gebeurtenis)
        {
            if (this.abonnees.ContainsKey(gebeurtenis.Type)) {
                List<IEventAbonnee> abonnees = (List<IEventAbonnee>)this.abonnees[gebeurtenis.Type];

                foreach (IEventAbonnee abonnee in abonnees) {
                    abonnee.informeer(gebeurtenis);
                }
            }
        }

        public void abonneer(Events gebeurtenisType, IEventAbonnee abonnee)
        {
            List<IEventAbonnee> gebeurtenisAbonnees;
            if (!this.abonnees.ContainsKey(gebeurtenisType)) 
            {
                 gebeurtenisAbonnees = new List<IEventAbonnee>();
                this.abonnees.Add(gebeurtenisType, gebeurtenisAbonnees);
            } 
            else 
            {
                gebeurtenisAbonnees = (List<IEventAbonnee>)this.abonnees[gebeurtenisType];
            }

            gebeurtenisAbonnees.Add(abonnee);
        }
    }
}
