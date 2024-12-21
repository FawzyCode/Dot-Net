using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDotNet.DTO;
using WebApiDotNet.Models;

namespace WebApiDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        ITIContext context;
        public DepartmentController(ITIContext _context)
        {
            context = _context;
        }


        [HttpGet("p")]
        public IActionResult GetDeptDetails()
        {
            List<Department> deptlist = context.Departments
                .Include(d => d.Emps).ToList();

            List<DeptWithEmpCountDTO>deptlistdto =
                new List<DeptWithEmpCountDTO>();
            foreach(Department item in deptlist)
            {
                DeptWithEmpCountDTO deptdto = new DeptWithEmpCountDTO();
                deptdto.Id = item.Id;
                deptdto.Name = item.Name;
                deptdto.EmpCount = item.Emps.Count();

                deptlistdto.Add(deptdto);

            }
            return Ok(deptlistdto);
        }
        [HttpGet] //api/Department verb get
        public IActionResult DisplayAllDept()
        {
            List<Department>deptlist = context.Departments.ToList();
            return Ok(deptlist);
        }
        [HttpGet("{id:int}")]  //api/Department/1
        public IActionResult GetById(int id)
        {
            Department dept = context.Departments.FirstOrDefault(de => de.Id == id);
            return Ok(dept);
        }

        [HttpGet("{name:alpha}")]  //api/Department/{name}
        public IActionResult GetByName(string name)
        {
            Department dept = context.Departments.FirstOrDefault(de => de.Name == name);
            return Ok(dept);
        }
        [HttpPost] //api/Department Post
        public IActionResult AddDept(Department dept)
        {
            context.Departments.Add(dept);
            context.SaveChanges();
            //return Created($"http://localhost:3143/api/Department/{dept.Id}",dept);
            return CreatedAtAction("GetById", new {id = dept.Id},dept);

        }
        [HttpPut("{id:int}")] //api/Department Put
        public IActionResult DisplayAllDept(int id , Department deptfromrequest)
        {
            Department deptfromdb = 
                context.Departments.FirstOrDefault(de =>de.Id == id);
            if (deptfromdb != null)
            {
                deptfromdb.Name = deptfromrequest.Name;
                deptfromdb.ManagerName = deptfromrequest.ManagerName;
                context.SaveChanges();
                return NoContent();
            }
            else
                return NotFound("department not valid");
        }
    }
}
