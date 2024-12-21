using MVC_ITI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ITI.ViewModel
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string jobTittle { get; set; }
        public string ImageURL { get; set; }
        public string Adress { get; set; }
        public int DepartmentId { get; set; }

        public List<Department>DeptList { get; set; }
    }
}
