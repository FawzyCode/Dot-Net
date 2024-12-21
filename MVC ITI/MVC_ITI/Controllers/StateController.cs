using Microsoft.AspNetCore.Mvc;

namespace MVC_ITI.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession(string name)
        {
            //logic
            HttpContext.Session.SetString("Name", name);
            //logic
            HttpContext.Session.SetInt32("Age", 21);

            return Content("Data Session Save Succes");
        }
        public IActionResult GetSession()
        {
            //logic 
            string? str =    HttpContext.Session.GetString("Name");
            int? a = HttpContext.Session.GetInt32("Age");

            return Content($"name = {str}\t Age={a}");
        }

        public IActionResult SetCookie()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            //Logic
            //session cookie
            HttpContext.Response.Cookies.Append("Name", "Fawzy");
            //presistence cookie
            HttpContext.Response.Cookies.Append("Age", "27" ,options);
            return Content("cookies save");
        }
        public IActionResult GetCookie()
        {
        
            string? name= HttpContext.Request.Cookies["Name"];
            string? age = HttpContext.Request.Cookies["Age"];
            return Content($"name={name}\t age={age}");
        }


    }
}
