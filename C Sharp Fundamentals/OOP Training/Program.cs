namespace OOP_Training
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var salary_employee = new SalariedEmployee();
            salary_employee.BasicSalary = 3000;
            salary_employee.Transportation = 1000;
            salary_employee.Housing = 1000;

            Console.WriteLine($"the salary of emplyee without taxpercentage is {salary_employee.GetSalary()}");
            Console.WriteLine($"the salary of emplyee  with 10% taxpercentage is {salary_employee.GetSalary(10)}");
            Console.WriteLine($"the salary of emplyee  with 10% taxpercentage and bonus 1000 is {salary_employee.GetSalary(10 , 1000)}");
            var freelance = new HourlyEmployee();
            freelance.HourRate = 60;
            freelance.TotalWorkingHours = 50;
            Console.WriteLine($"the salary of freelancing is {freelance.GetSalary()}");

            var internship = new InternEmployee();
            Console.WriteLine($"the salary of emplyee is {internship.GetSalary()}");
            /*var emp = new Employee();
            emp.SetName("fawzy" ," elbayaa");
            emp.SetSalary(5000);
            emp.SetBirthDate (new DateOnly(2000, 1, 1));
            emp.Taxpercentage = 100;

            PrintPersonDetails(emp);
            Console.WriteLine("-----------------");
            Applicant  applicant = new Applicant();
            applicant.SetName("ebrahim", " abdo");
            applicant.SetBirthDate(new DateOnly(2002,1,1));
            PrintPersonDetails(applicant); */


            /* Console.WriteLine($"FullName = {emp.FirstName}{emp.LastName}");
             Console.WriteLine($"BasicSalary = {emp.BasicSalary}");
             Console.WriteLine($"DateBirthdate = {emp.Birthdate}");
             Console.WriteLine($"Tax Percentage = {emp.Taxpercentage}");*/
        }
        
        internal static  void PrintPersonDetails(person p)
        {
            Console.WriteLine($"full name = {p.FirstName}{p.LastName}");
            Console.WriteLine($"BirthDate = {p.Birthdate}");
        }
    }

}
