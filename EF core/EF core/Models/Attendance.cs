using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core.Models
{
    //to update the table name and create new schema for this table
    //[Table("studentAtts" , Schema ="Std")]

    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        //[Column("dayname")]
        public string DayName {  get; set; }
        
        //[Column("TheName" ,TypeName ="varchar(20)")] //to rename column and change data type
        public string name { get; set; }
        //[NotMapped] //to don't exist in Db
        public DateTime TheDate {  get; set; }
        
        [ForeignKey("student")]
        public int StudentId {  get; set; }
        public Student student { get; set; }//novigation proparity
    }
}
