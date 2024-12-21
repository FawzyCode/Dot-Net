using Microsoft.EntityFrameworkCore;

namespace WebApiDotNet.Models
{
    public class ITIContext(DbContextOptions<ITIContext> options) : DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
