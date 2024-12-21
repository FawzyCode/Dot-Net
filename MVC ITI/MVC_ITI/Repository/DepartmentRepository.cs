using MVC_ITI.Models;
using System.Diagnostics.Contracts;

namespace MVC_ITI.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIContext context;
        public DepartmentRepository(ITIContext _context)
        {
            context = _context; /*new ITIContext()*/
        }
        public void Add(Department obj)
        {
            context.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Department dept = GetById(id);
            context.Remove(dept);
        }
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public Department GetById(int id)
        { 
            return context.Departments.FirstOrDefault(d=> d.Id==id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
