using EF_core;
using EF_core.Models;

namespace EFCore
{
    class Program
    {
        public static void Main()
        {
            var db = new ApplicationDbContext();
            //create
            // var department = new Department()
            // {
            //      Name = "fawzy"
            // };
            // db.Departments.Add(department);
            // db.SaveChanges();

            //Edit(Create)
            //var department = db.Departments.Find(1);// find the element that have id =1
            //if (department != null)
            //{
            //    Console.WriteLine(department.Name);
            //    department.Name = "Ali";
            //    db.SaveChanges();
            //}

            //Delete
            //var department = db.Departments.Find(1);
            //if (department != null)
            //{
            //    Console.WriteLine(department.Name);
            //    db.Departments.Remove(department);
            //    db.SaveChanges();
            //}
            //else
            //    Console.WriteLine("nothing");

            //var department = new Department()
            //{
            //    Name = "fawzy",
            //    des = "1234"
            //};
            //var context = new ValidationContext(department);
            //var errors =new List<ValidationResult>();

            //if (!Validator.TryValidateObject(department, context, errors, true))
            //{
            //    foreach (var validationResult in errors)
            //    {
            //        Console.WriteLine(validationResult);
            //    }
            //}
            //else
            //{
            //    db.Departments.Add(department);
            //    db.SaveChanges();
            //}

            //var book = new Book()
            //{
            //    Name = "fawzy",
            //    Author = "Bioo",
            //    Created = DateTime.Now,
            //};

            //var uniform = new Uniform()
            //{
            //    Name  = "test",
            //    Created = DateTime.Now

            //};
            //db.Books.Add(book);
            //db.Uniforms.Add(uniform);

            //var dep = new List<Department>()//adding list to Deprtment table
            //{
            //    new Department {Name = "CSED"           , des = "1" }, 
            //    new Department {Name = "Electriacl"     , des = "2"}  ,
            //    new Department {Name = "Civil"          , des = "3"},
            //    new Department {Name = "Communication"  , des = "4"},
            //};

            //var stu = new List<Student>()  //adding list to Student table
            //{
            //    new Student {Name = "fawzy", Email = "Bioo@mail.com" , Age = 26 ,Grade = 40 , Birthdate = DateTime.Now , departmentId = 7},
            //    new Student {Name = "Ali",   Email = "Bioo@mail.com" , Age = 26 ,Grade = 40 , Birthdate = DateTime.Now , departmentId = 7 },
            //    new Student {Name = "ayman", Email = "Bioo@mail.com" , Age = 26 ,Grade = 40 , Birthdate = DateTime.Now , departmentId = 8},
            //    new Student {Name = "Labib", Email = "Bioo@mail.com" , Age = 26 ,Grade = 40 , Birthdate = DateTime.Now , departmentId = 9},
            //    new Student {Name = "Adel",  Email = "Bioo@mail.com" , Age = 26 ,Grade = 40 , Birthdate = DateTime.Now , departmentId = 10},
            //    new Student {Name = "Sayed", Email = "Bioo@mail.com" , Age = 26 ,Grade = 40 , Birthdate = DateTime.Now , departmentId = 9},
            //};


            //db.Departments.AddRange(dep);
            //db.Students.AddRange(stu);

            //var student = db.Students.ToList();
            //foreach (var item in student)
            //    Console.WriteLine(item.Name);

            //var s = db.Students.Find(6);
            //Console.WriteLine(s.Name);

            //var st = db.Students.SingleOrDefault(x => x.Id == 7 && x.Age < 27);
            //if (st != null)
            //{
            //    Console.WriteLine(st.Name);
            //}

            //db.Departments.AddRange(departments);

            //Updating Records
            //var update1 = new Student()
            //{
            //    Id = 3,
            //    Name = "Ali",
            //    Age = 27,
            //    Email = "Ali@mail.com",
            //    departmentId = 10,
            //    Grade = 40
            //};

            //db.Students.Update(update1);

            //var departments = new List<Department>()//Updating Data In DB
            //{
            //    new  Department()
            //    {
            //        Id = 9 , Name = "new Civil" , des = "0110" ,
            //        students = new List<Student>()
            //        {
            //            new Student {Id = 5 ,Name = "Azza", Email = "Bioo@mail.com" , Age = 26 ,Grade = 40 , Birthdate = DateTime.Now , departmentId = 5 },
            //            new Student {Id = 7 ,Name = "nour",   Email = "Bioo@mail.com" , Age = 26 ,Grade = 40 , Birthdate = DateTime.Now , departmentId = 6 },
                        

            //        }

            //    },
            //    new Department()
            //    {
            //        Id = 10 ,Name ="New CIO" , des = "0101",
            //        students = new List<Student>()
            //        {
            //            new Student {Id = 3 ,Name = "Rabab", Email = "Bioo@mail.com" , Age = 26 ,Grade = 40 , Birthdate = DateTime.Now , departmentId = 4},
            //            new Student {Id = 6 ,Name = "Amal",  Email = "Bioo@mail.com" , Age = 26 ,Grade = 40 , Birthdate = DateTime.Now , departmentId = 5},
                        

            //        }
            //    }
            //};
            //db.Departments.UpdateRange(departments);

            db.SaveChanges();


        }
    }
}
