using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelerenMenerenAssessment.Controller;

namespace ModelerenMenerenAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            GameController gc = new GameController();
            //Hier gaan we....
            gc.Start();
        }
    }
}
