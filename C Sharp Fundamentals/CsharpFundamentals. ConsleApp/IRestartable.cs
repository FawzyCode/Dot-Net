using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFundamentals._ConsleApp
{
    internal interface IRestartable
    {
        void Restart()
        {
            Console.WriteLine("no implementation");
        }
    }
}
