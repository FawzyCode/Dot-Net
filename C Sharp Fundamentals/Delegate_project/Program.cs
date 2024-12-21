using System.Runtime.CompilerServices;

namespace Delegate_project
{
    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Deduction { get; set; }
        public int Bonus { get; set; }
    }
    internal class Program
    {
        delegate bool ShouldCalculate(Employee employee);
        
        static void Main(string[] args)
        {
                List<Employee>employees = new List<Employee>();
                for (int i = 0; i < 100; i++)
                {

                    employees.Add(new Employee
                    {
                    Name = $"Employee {i}",                                 // name of employee (employee[i])
                    Salary = Random.Shared.Next(2000, 6001),                // salary include value between (2000 , 6000)
                    Deduction = Random.Shared.Next(0, 501),                 //Deduction include value between (0 , 500)
                    Bonus = Random.Shared.Next(0, 1001)                     //Bonus include value between (0 , 1001)
                    });
                }
            //CalculateSalries(employees , 4000);                 //call the method 

            CalculateSalries(employees, e => e.Salary > 5500);


        }
        private static void CalculateSalries(List<Employee> emp , ShouldCalculate predicate)
        {
            foreach (Employee employee in emp)
            {
                if (predicate(employee))  //predicate(employee)==true
                {
                    var Salary = employee.Salary + employee.Bonus - employee.Deduction;  //to calc the salary of employee
                    Console.WriteLine($"Salary for Employee {employee.Name} with basic salary{employee.Salary} = {Salary}");  //to print name of all employee and their salary 
                }
            }

        }

    }
}
