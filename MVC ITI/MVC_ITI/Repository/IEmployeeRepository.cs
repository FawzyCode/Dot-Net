using MVC_ITI.Models;

namespace MVC_ITI.Repository
{
    public interface IEmployeeRepository
    {
        public void Add(Employee obj);

        public void Update(Employee obj);

        public void Delete(int id);

        public List<Employee> GetAll();

        public Employee GetById(int id);

        public void Save();
        public List<Employee>GetByDeptId(int deptId);
        
    }
}
