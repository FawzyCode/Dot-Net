using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDotNet.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        [ForeignKey("department")]
        public int DepartmentId {  get; set; }
        public Department? department { get; set; }
    }
}
