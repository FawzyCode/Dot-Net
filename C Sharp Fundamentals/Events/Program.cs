namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < 100; i++)
            {

                employees.Add(new Employee 
                {
                    Name = $"Employee {i}",                    // name of employee (employee[i])
                    BasicSalary = Random.Shared.Next(2000, 6001),  // salary include value between (2000 , 6000)
                    Deduction = Random.Shared.Next(0, 501),   //Deduction include value between (0 , 500)
                    Bonus = Random.Shared.Next(0, 1001)       //Bonus include value between (0 , 1001)
                });
            }
            // object from class salarycalculated
            SalaryCalculate Calculator = new SalaryCalculate();
            // Call the method LogEmployeeSalary when event fire
            Calculator.EmployeeSalaryCalculated += LogEmployeeSalary;
            //send sms for employee when fire event
            Calculator.EmployeeSalaryCalculated += (employees, salary) =>
            Console.WriteLine($"Payslip sent to employee {employees.Name}");
            //call the method  CalculateSalaries in class SalaryCalculate and pass employee and conditioon
            Calculator.CalculateSalaries(employees, e => e.BasicSalary > 2000);

        }
        private static void LogEmployeeSalary(Employee employee, int salary)
        {
            // call this method automatic when fire event
            Console.WriteLine($"Salary for emplopee {employee.Name} = {salary}");

        }



    }
}
