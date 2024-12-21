using HR_System.Models;

namespace HR_System.Repositories
{
    public interface IRequestRepository
    {
        public IQueryable<Request> GetAll();

        public IQueryable<Request> GetAllByUserId(string id);
        public void Add(Request request);
        public void Update(Request request);
        public void Delete(Request request);

        public Request GetById(int id);

      

        public int Savechange();
        

    }
}
