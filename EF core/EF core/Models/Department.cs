using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core.Models
{
	public class Department
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage ="Please enter the Name")]
		public string Name { get; set; }
		//[Required(ErrorMessage = "Please enter the des")]
		[MaxLength(200,ErrorMessage ="Max Length can't be >200 chars")]
		public string des {  get; set; }

		public ICollection<Student> students { get; set; } //novigation properity
	}
}
