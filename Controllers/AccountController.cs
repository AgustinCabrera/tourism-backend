using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tourismApp.Models.Entities;
using tourismApp.Views.Home;

public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    public AccountController(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }
    [HttpPost]
    [ValidateAntiForgeryToken]


    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(loginModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.LoginUser, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Account locked out.");
            }
            else if (result.RequiresTwoFactor)
            {
              
                return RedirectToAction("SendCode", new { ReturnUrl = "", RememberMe = model.RememberMe });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
        }

      
        return View(model);
    }

}