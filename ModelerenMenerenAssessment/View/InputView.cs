using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelerenMenerenAssessment.View
{
    public class InputView
    {
        public virtual String VraagOmInput()
        {
            ToonVraagOmInput();
            String input = Console.ReadLine();

            return input;
        }

        public void ToonVraagOmInput()
        {
            //Console.Write("Input >");
        }
    }
}
