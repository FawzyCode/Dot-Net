﻿
namespace GameZone.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Game> Games {  get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Data Seeding for Category
            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
                    new Category{Id=1 , Name="Sports"},
                    new Category{Id=2 , Name="Action"},
                    new Category{Id=3 , Name="Adventure"},
                    new Category{Id=4 , Name="Racing"},
                    new Category{Id=5 , Name="Fighting"},
                    new Category{Id=6 , Name="Film"}
                });
            //Data Seeding for Device
            modelBuilder.Entity<Device>()
                .HasData(new Device[]
                {
                    new Device{Id=1 , Name="PlayStation" , Icon ="bi bi-playstation"},
                    new Device{Id=2 , Name="xbox", Icon ="bi bi-xbox"},
                    new Device{Id=3 , Name="Nintendo switch", Icon ="bi bi-Nintendo-switch"},
                    new Device{Id=4 , Name="PC", Icon ="bi bi-pc-display"}
                    
                });
			// relation between Games and Devices is Many To many ==> 
			// that create table GameDevices include FK between it
			modelBuilder.Entity<GameDevice>()
                .HasKey(e => new { e.GameId, e.DeviceId });
            base.OnModelCreating(modelBuilder);
        }

    }
}
