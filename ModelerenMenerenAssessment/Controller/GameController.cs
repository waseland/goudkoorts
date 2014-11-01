using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelerenMenerenAssessment.View;
using ModelerenMenerenAssessment.Model;

namespace ModelerenMenerenAssessment.Controller
{

    public class GameController
    {
        public virtual BoardView BoardView
        {
            get;
            set;
        }

        public virtual InputView InputView
        {
            get;
            set;
        }

        public virtual Spel Spel
        {
            get;
            set;
        }

        public GameController()
        {
            Spel = new Spel();
            Spel.Setup();
        }

        public virtual void Start()
        {
            Spel.StartSpel();
            String input;

            while(!Spel.IsVoorbij && (input = InputView.VraagOmInput()).Equals("s")) {

            }
        }

    }
}