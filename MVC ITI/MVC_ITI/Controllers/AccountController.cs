using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_ITI.Models;
using MVC_ITI.ViewModel;
using System.Security.Claims;

namespace MVC_ITI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , 
                                 SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterUserViewModel UserViewModel)
        {
            if (ModelState.IsValid == true)
            {
                //Mapping
                ApplicationUser appUser = new ApplicationUser();
                appUser.Address = UserViewModel.Address;    
                appUser.UserName = UserViewModel.UserName;
                appUser.PasswordHash = UserViewModel.Password;  

                //Save DB
                
                IdentityResult result = await userManager.CreateAsync(appUser,UserViewModel.Password);
                
                if (result.Succeeded)//check the data is convert success
                {
                    //add role
                    await userManager.AddToRoleAsync(appUser, "admin");
                    //Create Cookie
                    await signInManager.SignInAsync(appUser , false);
                    return RedirectToAction("Index", "Department");
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register", UserViewModel);
        }

        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(LoginUserViewModel userLoginUser)
        {
            if (ModelState.IsValid == true)
            {
                //check founded
                ApplicationUser appuser =
                    await userManager.FindByNameAsync(userLoginUser.UserName);

                if (appuser != null)// UserName is valid
                {
                    //check password
                   bool found = 
                        await userManager.CheckPasswordAsync(appuser, userLoginUser.Password);
                    if (found == true)
                    {
                        //create cookie
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("UserAddress", appuser.Address));

                         await signInManager.SignInWithClaimsAsync(appuser, userLoginUser.RememberMe, claims);
                        //await signInManager.SignInAsync(appuser, userLoginUser.RememberMe);
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "UserName Or Password Wrong ");
            }
            return View("Login", userLoginUser);

        }
        public  async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("Login");
        }
       
    }
}
