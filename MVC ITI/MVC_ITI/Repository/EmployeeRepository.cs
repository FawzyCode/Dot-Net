using MVC_ITI.Models;

namespace MVC_ITI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext _context)
        {
            context = _context;    /*new ITIContext()*/
        }
        //CRUD
        public void Add(Employee obj)
        {
            
            context.Add(obj);
        }
        public void Update(Employee obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Employee Emp = GetById(id);
            context.Remove(Emp);
        }
        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }
        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public List<Employee> GetByDeptId(int deptId)
        {
           return context.Employees.Where(e=> e.DepartmentId==deptId).ToList();
        }
    }
}
