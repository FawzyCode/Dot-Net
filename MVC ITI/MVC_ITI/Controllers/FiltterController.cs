using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_ITI.Filters;

namespace MVC_ITI.Controllers
{
    [HandleError]
    public class FiltterController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            throw new Exception("Exception fr index");
        }
        //public IActionResult Index2()
        //{
        //    throw new Exception("Exception for Index");
        //}
    }
}
