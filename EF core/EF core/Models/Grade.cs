using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        public decimal Physics {  get; set; }
        public decimal Chemistry {  get; set; }
        public decimal Programming {  get; set; }

        //[foreignkey(" pkاسم كلاس الل هاخد منه  ")]
        [ForeignKey("student")]
        public int? StudentId { get; set; }
        public Student student { get; set; }//novigation proparity
    }
}
