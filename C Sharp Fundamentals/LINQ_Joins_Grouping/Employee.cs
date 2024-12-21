using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Joins_Grouping
{
    internal class Employee
    {
        public Employee(string name , int age , double salary , int departmentId)
        {
            Name = name;
            Age = age;
            Salary = salary;
            DepartmentId = departmentId;
        }

        public string Name { get; }
        public int Age { get; }
        public double Salary { get; }
        public int DepartmentId { get; }
    }
}
