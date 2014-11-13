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
        private Timer gameTimer;
        //private int counter = 0;
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
            Boolean heeftFoutMelding = false;
            String foutMelding = "";

            while(!Spel.IsVoorbij) {
                BordView.ShowBoard(Spel);
                if (heeftFoutMelding) {
                    InputView.ToonFoutMelding(foutMelding);
                }
                input = InputView.VraagOmInput();
                heeftFoutMelding = false;
                //Speller wil stoppen
                if (input.Equals("s")) {
                    break;
                }
                else
                {
                    try
                    {
                        Spel.VeranderWisselStand(input);
                    }
                    catch (Exception e) {
                        heeftFoutMelding = true;
                        foutMelding = e.Message;
                    }
                }
            }
        }
        public void StartTimer()
        {
            TimerCallback tcb = NieuweStap;
            gameTimer = new Timer(tcb, null, 500, 1000);
        }

        public void NieuweStap(Object stateInfo)
        {
            Spel.DoeNieuweStap();
            BordView.ShowBoard(Spel);
            InputView.ToonVraagOmInput();

            if (Spel.IsVoorbij) {
                gameTimer.Dispose();
            }
        }
    }
}