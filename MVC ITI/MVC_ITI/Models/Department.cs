namespace MVC_ITI.Models
{
	public class Department
	{
		public int Id { get; set; }
		
		public string Name { get; set; }=string.Empty;
		public string? ManagerName { get; set; }

		public List<Employee>? Emps { get; set; }
	}
}
