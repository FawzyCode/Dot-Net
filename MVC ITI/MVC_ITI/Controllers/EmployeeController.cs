using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_ITI.Models;
using MVC_ITI.Repository;
using MVC_ITI.ViewModel;

namespace MVC_ITI.Controllers
{
    public class EmployeeController : Controller
    {
        //ITIContext context = new ITIContext();
        IDepartmentRepository DepartmentRepository;
        IEmployeeRepository EmployeeRepository;
        public EmployeeController(IDepartmentRepository deptRepo, IEmployeeRepository EmpRepo )
        {
            DepartmentRepository = deptRepo;
            EmployeeRepository = EmpRepo;
        }
        public IActionResult EmpCardPartial(int Id)
        {
            return PartialView("_EmpCard",EmployeeRepository.GetById(Id));
        }
        public IActionResult CheckSalary(int Salary, string JibTitle)
        {
            if (Salary > 6000 && JibTitle == "S")
            {
                return Json(true);
            }
            else if (JibTitle == "B" && Salary > 10000)
            {
                return Json(true);
            }
            else if (JibTitle == "M" && Salary > 40000)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        [HttpGet]
        public IActionResult New()
        {
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View("New" );
        }
        [HttpPost]
        public IActionResult SaveNew(Employee EmpFromRequest)
        {
            //if((EmpFromRequest.Name!=null ) && (EmpFromRequest.Salary>=6000) )
            if(ModelState.IsValid==true)
            {
                //Save in Db
                EmployeeRepository.Add(EmpFromRequest);
                EmployeeRepository.Save();
                return RedirectToAction("Index");
            }
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View("New", EmpFromRequest);
        }


        public IActionResult Index()
        {
          
            //url /Employee/Edit/1
            return View("Index", EmployeeRepository.GetAll()); //go to the edit html page
        }
        
        public IActionResult Edit(int id)
        {
            if (id != null)
            {
                Employee EmpModel = EmployeeRepository.GetById(id);
                //list <DEpartment> 
                List<Department> DepartmentList = DepartmentRepository.GetAll();
                //-------Create view model mapping
                EmpWithDeptListViewModel EmpViewModel = new EmpWithDeptListViewModel();
                //mapping from employee to View model 
                EmpViewModel.Id = EmpModel.Id;
                EmpViewModel.Name = EmpModel.Name;
                EmpViewModel.Adress = EmpModel.Adress;
                EmpViewModel.ImageURL = EmpModel.ImageURL;
                EmpViewModel.Salary = EmpModel.Salary;
                EmpViewModel.jobTittle = EmpModel.jobTittle;
                EmpViewModel.DepartmentId = EmpModel.DepartmentId;
                //mapping from Department to View model
                EmpViewModel.DeptList = DepartmentList;
                return View("Edit", EmpViewModel);
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPost]
        public IActionResult SaveEdit(int id , EmpWithDeptListViewModel EmpFromRequest )
        {
            //if(EmpFromRequest.Name !=null)
            if(ModelState.IsValid==true)
            {
                //Custom Validation Dept_id !=0
                if (EmpFromRequest.DepartmentId != 0)
                {
                    try
                    {
                        Employee EmpFromDb = EmployeeRepository.GetById(id);

                        EmpFromDb.Name = EmpFromRequest.Name;
                        EmpFromDb.Adress = EmpFromRequest.Adress;
                        EmpFromDb.ImageURL = EmpFromRequest.ImageURL;
                        EmpFromDb.Salary = EmpFromRequest.Salary;
                        EmpFromDb.jobTittle = EmpFromRequest.jobTittle;
                        EmpFromDb.DepartmentId = EmpFromRequest.DepartmentId;
                        EmpFromDb.Id = EmpFromRequest.Id;
                        EmployeeRepository.Save();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("",ex.Message);
                    }

                }
                else // client forget pass dept_id from existing department 
                {
                    //error mesage send view
                    ModelState.AddModelError("DepartmentId", "Select Department"); 

                }
            }
            EmpFromRequest.DeptList = DepartmentRepository.GetAll();
            return View("Edit", EmpFromRequest);
        }
        public IActionResult Delete(int id)
        {
            return View("Delete", EmployeeRepository.GetById(id));
        }
        public IActionResult Details(int id)
        {
            string msg = "hello from action";
            int temp = 50;
            List<string> branches = new List<string>();
            branches.Add("mansoura");
            branches.Add("Alex");
            branches.Add("Cairo");

            //Aditional info send to view from action 
            ViewData["message"] = msg;
            ViewData["Temp"] = temp;
            ViewData["brch"] = branches;
            ViewBag.Color = "red";
            Employee EmpModel=EmployeeRepository.GetById(id);
            return View("Details", EmpModel);
        }
        public IActionResult DetailsVM(int id)
        {
            Employee EmpModel = EmployeeRepository.GetById(id);
            List<string> branches = new List<string>();
            branches.Add("mansoura");
            branches.Add("Alex");
            branches.Add("Cairo");
             //Declare view model
            EmpDeptColorTempMsgBrchViewModel EmpVM = new EmpDeptColorTempMsgBrchViewModel();

            //mapping
            EmpVM.EmpName = EmpModel.Name;
            EmpVM.DeptName = EmpModel.department.Name;
            EmpVM.Branches = branches;
            EmpVM.Msg = "Hello from VM";
            EmpVM.Color = "red";
            EmpVM.Temp = 25;

            return View("DetailsVM", EmpVM);//EmpDeptColorTempMsgBrchViewModel
        }
    }
}
