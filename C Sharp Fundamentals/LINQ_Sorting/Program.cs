namespace LINQ_Sorting
{
    public class Program
    {
      

        static void Main(string[] args)
        {
            var emp = new List<Employee>
            {
                new("mohammed", 38, 8000),
                new("ayman", 35, 7000),
                new("ahmed", 35, 5000),
                new("ahmed", 30, 4000)
            };
            var QueryEmployee = emp.OrderBy(x => x.Name ).ThenBy(x=> x.Age);
            //var QueryEmployee = from employee in emp orderby employee.Name , employee.Age select employee;
            foreach (var e in QueryEmployee)
                Console.WriteLine($"Name= {e.Name} , Age = {e.Age} , Salary = {e.Salary}");

            /*var list = new List<int> {  6,5,2,8,10,3,1,4,7 ,9 };
            //method syntax
            //var query = list.Where(x => x > 2).OrderByDescending(x=> x);
            // Query expresion syntax
            var query = from number in list where number > 2  orderby number descending  select number; 
            //looping to print query
            foreach(var item in query)
            {
                Console.WriteLine(item);
            }*/
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public Employee(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;

        }
    }
    

}
