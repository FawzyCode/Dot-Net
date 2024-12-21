using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ITI.Models
{
	public class Student
	{
		public int Id { get; set; }
		[Display(Name ="Student Name")]
		[Required]
		[MaxLength(30)]
		[MinLength(3)]
		public string Name { get; set; } = string.Empty;
		[Required]
		[RegularExpression(@"(Alex|Mansoura)")]
        public string Address { get; set; }= string.Empty;
		[Required]
		[Range(20,50)]
        public int Age {  get; set; }
		[Required]
		[RegularExpression(@"\w+\.(jpg|png)")]
		public string ImgURL {  get; set; }

		[ForeignKey("department")]
		public int DepartmentId {  get; set; }
		public Department department {  get; set; }
	}
}
