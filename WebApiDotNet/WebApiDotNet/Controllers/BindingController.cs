using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDotNet.Models;

namespace WebApiDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindingController : ControllerBase
    {
        [HttpGet("{age:int}/{name:alpha}")]
        public IActionResult TestPremitive(int age , string name)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult TestObj(Department dep, string name)
        {
            return Ok();
        }
        [HttpGet("{Id:int}/{Name:alpha}/{ManagerName:alpha}")]
        public IActionResult TestCustomBind([FromRoute]Department dept)
        {
            return Ok(dept);
        }
    }
}
