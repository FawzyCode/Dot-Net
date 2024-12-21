using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Enumerables
{
    internal class Program
    {

        static void  Main(string[] args)
        {
            var employee = new Employees();
            employee.AddPayItem("Basic salary", 3000);
            employee.AddPayItem("Housing", 500);
            employee.AddPayItem("Tranportaion", 600);
            employee.AddPayItem("Insurance", -250);

            foreach (var item in employee)
            {
                Console.WriteLine(item);
            }






        }

    }
}
