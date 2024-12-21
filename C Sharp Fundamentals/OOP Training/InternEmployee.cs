using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Training
{
    internal class InternEmployee : Employee
    {
        public override decimal GetSalary()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return 2000;
        }
    }
}
