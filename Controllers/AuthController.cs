using Book.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Controllers
{
    public class AuthController : Controller
    {
         private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signmanager;
        private readonly RoleManager<IdentityRole> _role;
        public AuthController(RoleManager<IdentityRole> Role,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _role = Role;
            _signmanager = signInManager;
        }


        [HttpGet]
        [Route("/Account/Login")]
        public IActionResult Login(string pass)
        {
            //IdentityUser admin = new IdentityUser()
            //{
            //    UserName = "ali2004h",
            //    Email = "ali2004h@gmail.com",
            //    EmailConfirmed = true,
            //    PasswordHash = pass,
            //    PhoneNumber = "09930972924"
            //};
            //_userManager.CreateAsync(admin);

            if (_signmanager.IsSignedIn(User))
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost]
        [Route("/Account/Login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            
             if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult res = await _signmanager.PasswordSignInAsync(model.Username, model.Password,model.Rem, true);

                if (res.Succeeded)
                {
                    return Redirect("/");
                }

                if (res.IsLockedOut)
                {
                    ViewData["Message"] = "اکانت شما به دلیل وارد کردن پسورد اشتباه به مدت 5 دقیقه قفل شد";
                    ViewData["Mode"] = "warning";
                    return View(model);
                }
                ViewData["Message"] = "رمز عبور یا نام کاربری اشتباه هست";
                ViewData["Mode"] = "error";
            }
            return View(model);
        }

        [HttpGet]
        [Route("/logout")]
        public async Task<IActionResult> LogOut()
        {
            if (_signmanager.IsSignedIn(User))
            {
                await _signmanager.SignOutAsync();
                return Redirect("/account/login");
            }
                return Redirect("/account/login");
        }

        [HttpGet]
        [Route("/Account/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
