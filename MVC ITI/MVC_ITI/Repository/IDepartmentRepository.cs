using MVC_ITI.Models;

namespace MVC_ITI.Repository
{
    public interface IDepartmentRepository
    {

        public void Add(Department obj);

        public void Update(Department obj);

        public void Delete(int id);

        public List<Department> GetAll();

        public Department GetById(int id);

        public void Save();
       
    }
8B7DF653-0582-4F25-897F-6950C74CBF94

8c21c728-f9a8-4c26-872c-b2396ec584b5

8B7DF653-0582-4F25-897F-6950C74CBF94
}
