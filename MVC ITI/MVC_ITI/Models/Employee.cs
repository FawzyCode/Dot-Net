using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ITI.Models
{
	public class Employee
	{
		public int Id { get; set; }
        [Display(Name = "Student Name")]
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        
        public string Name { get; set; }=string.Empty;
		public int Salary {  get; set; }
		public string jobTittle {  get; set; }=string.Empty;
        [Required]
        [RegularExpression(@"\w+\.(jpg|png)")]
        public string ImageURL {  get; set; }=string.Empty;
        [Required]
        [RegularExpression(@"(Alex|Mansoura|cairo|domiat)")]
        public string Adress {  get; set; }=string.Empty ;

		[ForeignKey("department")]
		[Display(Name ="Department")]
		public int DepartmentId {  get; set; }
		public Department? department { get; set; }
	    
	}
}
