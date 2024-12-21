using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core.Models
{
    public class StudentBook
    {
        public int Id { get; set; }
        // Foreign key for table student
        [ForeignKey("student")]
        public int StudentId {  get; set; }
        public Student student {  get; set; }

        // Foreign key for table book
        [ForeignKey("book")]
        public int bookId { get; set; }
        public Book book { get; set; }

    }
}
