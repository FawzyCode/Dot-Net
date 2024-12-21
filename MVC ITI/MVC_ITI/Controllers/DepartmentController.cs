using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_ITI.Models;
using MVC_ITI.Repository;

namespace MVC_ITI.Controllers
{
	public class DepartmentController : Controller
	{
		//ITIContext context = new ITIContext();
		IDepartmentRepository DeptRepo;
		IEmployeeRepository EmployeeRepo;

       

        public DepartmentController(IDepartmentRepository deptRepo , IEmployeeRepository empRepo)//inject
        {
            DeptRepo = deptRepo;
            EmployeeRepo = empRepo;
        }
		public IActionResult DeptEmps()
		{
			return View("DeptEmps",DeptRepo.GetAll()); //List<department>
		}
		public IActionResult GetEmpsByDeptId(int deptId)
		{
			List<Employee> EmpList = EmployeeRepo.GetByDeptId(deptId);
			return Json(EmpList);
		}
        //[HttpGet]
		[Authorize]
		public IActionResult Index()
		{
			List<Department> departmentlist = DeptRepo.GetAll();
				
            return View("Index", departmentlist); //list<department>
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View("Add");//Model is null
		}
		[HttpPost]//Filter
		public IActionResult SaveAdd(Department NewDept)
		{
			if(NewDept.Name !=null)
			{
				DeptRepo.Add(NewDept);
				DeptRepo.Save();
                //return View("Index");//you must send (context.Departments.oList();) as a parameter
				return RedirectToAction("Index"); //call action from another action
            }
            return View("Add" );
		}
	}
}
