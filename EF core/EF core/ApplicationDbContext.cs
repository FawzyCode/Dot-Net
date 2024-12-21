using EF_core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder Options)
        {
            Options.UseSqlServer(Connection.SqlConstStr);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Grade> Grades { get; set; } 

        public DbSet<Book> Books { get; set; }

        public DbSet<StudentBook> StudentBooks { get; set; }
        
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<InVoice> Invoices { get; set; }
        public DbSet<Uniform>Uniforms { get; set; }

        //fluent Api 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Department>().Property(x => x.des).IsRequired();
            //update Referential actio (cascade - restrict - -------)
            // modelBuilder.Entity<Department>()
            //    .HasMany(s => s.students)
            //    .WithOne(d => d.department)
            //    .OnDelete(DeleteBehavior.Restrict);
            //
            //modelBuilder.Entity<Grade>()
            //    .HasOne(s=> s.student)
            //    .WithOne(g=> g.grade)
            //    .OnDelete(DeleteBehavior.SetNull);

            

            //using Fluent Api to default referential = restrict
            foreach (var relationship in modelBuilder.Model.
                GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //using fluent Api - not mapped for table attendances
            //modelBuilder.Ignore<Attendance>();

            // to update in EF only => not update in  my DB
            //modelBuilder.Entity<Attendance>().ToTable("Attendances", a => a.ExcludeFromMigrations());

            // //-----------------------------------------------------
            // //Fluent Api for rename table and create schma 
            // modelBuilder.Entity<Attendance>().ToTable("MyAtts", "Myschema");
            //
            // //Fluent Api for rename field in table
            // modelBuilder.Entity<Attendance>().Property(x => x.name)
            //     .HasColumnName("Name").HasColumnType("varchar(40)");
            //
            // //Fluent Api for ignore specefic field from table
            // modelBuilder.Entity<Attendance>().Ignore(x => x.TheDate);

            //set default value in table invoice to specific field
            modelBuilder.Entity<InVoice>().Property(x => x.Qty)
                .HasDefaultValue(1);  //set default value 1 for column qty

            modelBuilder.Entity<InVoice>().Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");//Set default value to date.now

            //set computed value FullName = CustomerTitle + CustomerName
            modelBuilder.Entity<InVoice>().Property(x => x.FullName)
                .HasComputedColumnSql("[CustomerTitle] + ' '+ [CustomerName]");

            //set computed value Tatal = Price * Qty
            modelBuilder.Entity<InVoice>().Property(x => x.Total)
                .HasComputedColumnSql("[Price] * [Qty]");

            //Create Sequence that name is  DeliveryOrder and data type int and start from 101
            //and incremented by 1  
            modelBuilder.HasSequence<int>("DeliveryOrder").StartsAt(101).IncrementsBy(1);

            //the sequne in  book 
            modelBuilder.Entity<Book>().Property(x => x.DeliveryOrder)
                .HasDefaultValueSql("Next Value For DeliveryOrder");

            //the sequne in  Uniform 
            modelBuilder.Entity<Uniform>().Property(x => x.DeliveryOrder)
                .HasDefaultValueSql("Next Value For DeliveryOrder");

        }


    }
        
}
