using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ModelerenMenerenAssessment.View;
using ModelerenMenerenAssessment.Model;

namespace ModelerenMenerenAssessment.Controller
{

    public class GameController
    {
        public virtual BordView BordView
        {
            get;
            private set;
        }

        public virtual InputView InputView
        {
            get;
            private set;
        }

        public virtual Spel Spel
        {
            get;
            private set;
        }

        public GameController()
        {
            Spel = new Spel();
            Spel.Setup();

            InputView = new InputView();
            BordView = new BordView();
        }

        public virtual void Start()
        {
            StartTimer();
            String input;

            while(!Spel.IsVoorbij) {
                BordView.ShowBoard(Spel);
                input = InputView.VraagOmInput();
                //Speller wil stoppen
                if (input.Equals("s")) {
                    break;
                }
                else
                {
                    
                    switch (input) {
                        default:
                        break;   
                    }
                }
                
            }
        }
        public void StartTimer()
        {
            TimerCallback tcb = NieuweStap;
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            Timer gameTimer = new Timer(tcb, autoEvent, 3000, 2000);
        }

        public void NieuweStap(Object stateInfo)
        {
            Spel.DoeNieuweStap();
            BordView.ShowBoard(Spel);
            InputView.ToonVraagOmInput();
        }
    }
}