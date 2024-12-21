using CsharpFundamentals._ConsleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFundamentals._ConsleApp
{
    public  class Computer : IDervice , IRestartable
    {
        public void TurnOn()
        {
            Console.WriteLine("Thr Computer is  turned on");
        }

        public void TurnOff()
        {
          
            Console.WriteLine("Thr Computer is  turned Off");
        }
        public void Restart()
        {
            Console.WriteLine(" Computer restarted");
        }



    }
    
}
    
