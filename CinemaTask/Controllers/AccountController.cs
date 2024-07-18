using CinemaTask.Models;
using CinemaTask.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUserVM userVM)
        {
            if (ModelState.IsValid) 
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {

                    //No Password To Hash it
                    UserName = userVM.UserName,
                    Email = userVM.Email
                };

               var result= await userManager.CreateAsync(applicationUser, userVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    ModelState.AddModelError("Password", "Don't Match With Constrain");
                }
            }
            return View();
        }
    }
}
