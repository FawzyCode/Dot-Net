using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDotNet.DTO;
using WebApiDotNet.Models;

namespace WebApiDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ITIContext _context;
        public EmployeeController(ITIContext context)
        {
            _context = context;
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
           Employee emp =  _context.Employees.FirstOrDefault(e=> e.Id == id);
            GeneralResponse generalResponse = new GeneralResponse();
            if (emp != null)// IsSuccess
            {
                generalResponse.IsSuccess = true;
                generalResponse.Data = emp;
            }
            else 
            {
                generalResponse.IsSuccess = false;
                generalResponse.Data = "Id In Valid";
            }
            return Ok(generalResponse);
        }
    }
}
