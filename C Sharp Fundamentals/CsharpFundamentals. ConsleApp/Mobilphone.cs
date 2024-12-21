using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFundamentals._ConsleApp
{
    public  class Mobilphone :IDervice , IRestartable
    {
        
        public void TurnOn()
        {
            Console.WriteLine("Thr mobil is  turned on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Thr mobil is  turned Off");
        }
        public void Restart()
        {
            Console.WriteLine( " MobilPhone restarted");
        }


    }
}
