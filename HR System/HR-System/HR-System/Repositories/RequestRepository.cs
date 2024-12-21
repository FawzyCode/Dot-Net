using HR_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HR_System.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _db;
        public RequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Request> GetAll()
        {
            return _db.Requests.Include(r=> r.AppUser);
        }
        public IQueryable<Request> GetAllByUserId(string id)
        {
            return _db.Requests.Where(r => r.AppUserId == id);
        }

        public void Add(Request request)
        {
            _db.Requests.Add(request);
        }

        public void Update(Request request)
        {
            _db.Requests.Update(request);
        }

        public void Delete(Request request)
        {
            _db.Requests.Remove(request);
        }

       

        public Request GetById(int id)
        {
            return _db.Requests.FirstOrDefault(i=> i.Id==id);
        }
        public int Savechange()
        {
            return _db.SaveChanges();
        }

        
    }
}
