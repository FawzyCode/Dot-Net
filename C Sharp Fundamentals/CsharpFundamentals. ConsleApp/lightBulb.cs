using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFundamentals._ConsleApp
{
    internal class lightBulb :IDervice
    {
        public void TurnOn()
        {
            Console.WriteLine("Thr Computer is  turned on");
        }

        public void TurnOff()
        {

            Console.WriteLine("Thr Computer is  turned Off");
        }

    }
}
