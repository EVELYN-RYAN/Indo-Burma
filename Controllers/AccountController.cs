using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Indo_Burma.Models.ViewModels;


namespace Indo_Burma.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            userManager = um;
            signInManager = sim;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost] // ensure this is async
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            //If everything looks fine we find the usernames and passwords and verify
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Username);

                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        //Then we return them to the admin route
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin");
                    }
                }

            }
            //Check to see if the the credentials are correct
            ModelState.AddModelError("", "Invalid username or password");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();

            return Redirect(returnUrl);
        }
    }
}
