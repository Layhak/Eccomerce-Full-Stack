using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Eccomerce_Full_Stack.Models;
using Eccomerce_Full_Stack.ViewModels;
using System.Threading.Tasks;

namespace Eccomerce_Full_Stack.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CadrNumber = model.CadrNumber,
                    ExpireDate = model.ExpireDate,
                    Cvv = model.Cvv
                };

                // Attempt to create the user
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Log the user in
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    // Redirect to the home page
                    return RedirectToAction("Index", "Home");
                }

                // If there are errors, add them to the ModelState
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Attempt to sign in the user
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Redirect to the specified return URL or to the home page
                    return RedirectToLocal(returnUrl);
                }

                // If login fails, add an error message
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}