using Microsoft.AspNetCore.Mvc;

namespace MVC_ITI.Controllers
{
    public class RouteController : Controller
    {
        //   /r1/fawzy/20
        public IActionResult Method1(string name , int age)
        {
            return Content("M1");
        }
        public IActionResult Method2()
        {
            return Content("M2");
        }
    }
}
