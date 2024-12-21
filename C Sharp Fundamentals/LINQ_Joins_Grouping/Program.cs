namespace LINQ_Joins_Grouping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*JOIN
            var department = new List<Departmentes>
            {
                new (1, "HR"),
                new (2 , "IT"),
                new (3 , "Finance"),
                new (4 , "Development")
            };
            var employee = new List<Employee>
            {
                new ("Rana"     , 20 ,  5000 , 1),
                new ("fawzy"    , 27 ,  5000 , 4),
                new ("Ali"      , 28 ,  5000 , 3),
                new ("mohammed" , 26 ,  5000 , 2)

            };
            // Query syntax
            //var query = from emp in employee
            //            join dep in department
            //            on emp.DepartmentId equals dep.Id
            //            select  new { EmployeeName = emp.Name, DepartmentName = dep.Name } ;
            // method syntax
            var query = employee.Join(department, x => x.DepartmentId, x => x.Id,
                (e, d) => new { EmployeeName = e.Name, DepartmentName = d.Name });
            foreach (var record in query)
            {
                Console.WriteLine($"{record.EmployeeName}@{record.DepartmentName}");
            }*/

            // Grouping
            var department = new List<Departmentes>
            {
                new (1, "HR"),
                new (2 , "IT"),
                new (3 , "Finance"),
                new (4 , "Development")
            };
            var employee = new List<Employee>
            {
                new ("Rana"          , 20 ,  5000 , 1),
                new ("Ahmed Salem"   , 36 ,  500  , 1),
                new ("bioo "         , 27 ,  5000 , 1),
                new ("Ali"           , 28 ,  5000 , 3),
                new ("elbayaa"       , 27 ,  5000 , 3),
                new ("mohammed"      , 26 ,  5000 , 2),
                new ("awad"          , 27 ,  5000 , 2),
                new ("fawzy"         , 27 ,  5000 , 4),
                new ("fawzy"         , 27 ,  5000 , 4)

            };
            var query = from Emp in employee
                        join dep in department
                        on Emp.DepartmentId equals dep.Id
                        group Emp by dep.Name;

            foreach (var record in query)
            {
                var employeenames = string.Join(",", record.Select(x => x.Name).ToArray());
                Console.WriteLine($"{record.Key} = {employeenames}");
            }

        }
    }
    
}
