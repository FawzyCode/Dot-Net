using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public DateTime Birthdate { get; set; }
        

        // student class is father for class grade
        // one to one
        public Grade grade {  get; set; }//novigation proparity 

        // student class  is child for class department
        //one to many
        [ForeignKey("department")]
        public int departmentId {  get; set; }
        public Department department { get; set; }
        

        public ICollection<StudentBook> books { get; set; }

        //novigation property
        //[NotMapped]
        public ICollection<Attendance> attendances { get; set; }
    }
}
