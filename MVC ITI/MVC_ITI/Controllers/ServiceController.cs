using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVC_ITI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult TestAuth()
        {
            if(User.Identity.IsAuthenticated)
            {
                //get id
               Claim IdClaim =  User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.NameIdentifier);
               Claim AddressClaim = User.Claims.FirstOrDefault(C => C.Type== "UserAddress");
                string id = IdClaim.Value; //return id 
                //get name that using login
                string Name = User.Identity.Name;
                return Content($"Welcome {Name}\n Id ={id}");

            }
            return Content("Welcome Guest");
        }
    }
}
