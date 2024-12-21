using Microsoft.AspNetCore.Mvc;
using MVC_ITI.Models;

namespace MVC_ITI.Controllers
{
	public class StudentController : Controller
	{
		//Student/showall
		public IActionResult ShowAll()
		{
			StudentBL studentBL = new StudentBL();
			List<Student> StudentListModel = studentBL.Getall();
			return View("ShowAll" , StudentListModel);//model list of student
		}
		public IActionResult Details(int id)
		{
			StudentBL studentBL = new StudentBL();
			Student studentmodel = studentBL.GetById(id);
			return View("ShowDetails",studentmodel);
		}
	}
}
