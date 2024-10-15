using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tourismApp.Data;
using tourismApp.Models;
using tourismApp.Models.Entities;
using tourismApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace tourismApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationDbContext _dbContext;

		public AccountController(SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext)
		{
			_signInManager = signInManager;
			_dbContext = dbContext;
		}

		// GET: Login
		[HttpGet]
		public IActionResult Login()
		{
			if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
			return View();
		}

		// POST: Login
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);


			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name,model.Email)
			};

			ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			AuthenticationProperties propieties = new AuthenticationProperties()
			{
				AllowRefresh = true,
			};

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity), propieties);


            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }

		// GET: Register
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		// POST: Register
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(UserViewModel model)
		{

			if(!ModelState.IsValid) { 
				return View(model); 
			}

			if (model.UserPassword != model.UserPasswordConfirmed)
			{
				ModelState.AddModelError(string.Empty, "Passwords do not match.");
				return View(model);
			}

			User user = new User
			{
				UserName = model.UserName,
				UserPassword = model.UserPassword,
				UserEmail = model.UserEmail
			};

			await _dbContext.AddAsync(user);
			await _dbContext.SaveChangesAsync();

			return RedirectToAction("Login");
		}
	}
}
