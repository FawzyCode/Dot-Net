using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVC_ITI.Models
{
	public class ITIContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }

        public ITIContext() :base()
        {
            
        }
		public ITIContext(DbContextOptions options) : base(options) 
		{
		}

  //      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("Data Source=WIN-R4A9L55AHK9\\SQLEXPRESS;" +
		//		"Initial Catalog=ITI_MVC;" +
		//		"Integrated Security=True;" +
		//		"Trust Server Certificate=True");
		//	base.OnConfiguring(optionsBuilder);
		//}

	}
}
