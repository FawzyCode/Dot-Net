using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Training
{
    internal class SalariedEmployee : Employee
    {
        public decimal BasicSalary { get; set; }
        public decimal Transportation { get; set; }
        public decimal Housing { get; set; }
        public override decimal GetSalary()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return BasicSalary + Transportation + Housing ;
                    
        }
        public decimal GetSalary(int TaxPercentage)
        {
            return GetSalary() - (BasicSalary * TaxPercentage/100);
        }
        public decimal GetSalary(int TaxPercentage, decimal Bonus)
        {
            return GetSalary(TaxPercentage) + Bonus;

        }
    }
}
