using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HR_System.ViewModels;

namespace HR_System.Models
{
    public class ApplicationDbContext :IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Request> Requests { get; set; }
        
       
    }
}
