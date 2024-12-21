using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class SalaryCalculate
    {
       // to calculate or no 
       public delegate bool ShouldCalculate(Employee employee);
       // delegate to related event
       public delegate void EmployeeSalaryCalculatedEventHandler(Employee employee, int Salary);
       // event to  notification after invoke calaculate salary of all employee
       public event EmployeeSalaryCalculatedEventHandler EmployeeSalaryCalculated;
       

        // to calculate salary of all employee
        public void CalculateSalaries(List<Employee> employee , ShouldCalculate Predicate )
        {
            foreach (Employee emp in employee)// looping of all employee
            {
                if (Predicate(emp) == true) // do emppoyee[i] calc or not
                {
                    // salary  of employee[i]
                    int salary = emp.BasicSalary + emp.Bonus - emp.Deduction;
                    // fire the  event
                    EmployeeSalaryCalculated.Invoke(emp , salary);
                }
            }
        }
    }
}
