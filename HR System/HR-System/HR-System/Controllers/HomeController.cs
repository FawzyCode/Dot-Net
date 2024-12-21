using HR_System.Models;
using HR_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Diagnostics;

namespace HR_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
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
        [Authorize]
        //[HttpGet("all-users")]
        public IActionResult AllUsersList()
        {
            var allUsers = _userManager.Users.ToList();
            var allUsersVm = allUsers.Select(u=> new AppUserVM() 
            {FirstName= u.FirstName, LastName= u.LastName ,Id =  u.Id}).ToList();
            //return Ok(allUsersVm);
            return PartialView(allUsersVm);
         
        }
        [Authorize]
        public async Task<IActionResult> AddRoleToUser(AddUserRoleVM addUserRoleVM)
        {
            var user =  await _userManager.FindByIdAsync(addUserRoleVM.UserId);
            if(user==null)
            {
                return BadRequest("User not Found");
            }
            var result = await _userManager.AddToRoleAsync(user, addUserRoleVM.RoleName);
            if(!result.Succeeded)
            {
                return BadRequest("failed to add user to this role");
            }
            return Ok(addUserRoleVM);
        }
        
    }
}
