using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_ITI.ViewModel;

namespace MVC_ITI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        [HttpPost]
        public async Task<IActionResult> SaveRole(RoleViewModel roleViewModel)
        {
            if(ModelState.IsValid)
            {
                //save DB
                IdentityRole role = new IdentityRole();
                role.Name = roleViewModel.RoleName;
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    ViewBag.sucess = true;
                    return View("AddRole");
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }
            return View("AddRole", roleViewModel);
        }
    }
}
