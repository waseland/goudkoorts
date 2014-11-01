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
            Console.Write("Input: >");
            String input = Console.ReadLine();

            return input;
        }
    }
}
