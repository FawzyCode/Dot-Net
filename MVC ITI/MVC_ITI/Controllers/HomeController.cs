using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MVC_ITI.Models;
using System.Diagnostics;

namespace MVC_ITI.Controllers
{
    public class HomeController : Controller
    {


        public ContentResult showmsg()
        {
            //1- declare obj
            ContentResult result = new ContentResult();
            //2- init
            result.Content = "hello world";
            //3- return
            return result;
        }

        public ViewResult showview()
        {
            //1- declare obj
            ViewResult result = new ViewResult();
            //2- init
            result.ViewName = "View1";
            //3- return
            return result;
        }
        
        public IActionResult showmix(int id) 
        {
            if(id%2==0) //id is even
            {
                ////1- declare obj
                //ViewResult result = new ViewResult();
                ////2- init
                //result.ViewName = "View1";
                ////3- return
                //return result;
                return View("View1");
            }
            else
            {
                ////1- declare obj
                //ContentResult result = new ContentResult();
                ////2- init
                //result.Content = "hello world";
                ////3- return
                //return result;
                return Content("hello world");

            }
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
