using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tourismApp.Data;
using tourismApp.Models;
using tourismApp.Models.Entities;
using tourismApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
			return View();
		}

		// POST: Login
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

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
			if (model.UserPassword != model.UserPasswordConfirmed)
			{
				ViewData["Message"] = "Passwords do not match.";
				return View();
			}

			User user = new User
			{
				UserName = model.UserName,
				UserPassword = model.UserPassword,
				UserEmail = model.UserEmail
			};

			await _dbContext.AddAsync(user);
			await _dbContext.SaveChangesAsync();

			if (user.Id != 0)
			{
				return RedirectToAction("Login");
			}

			ViewData["Message"] = "Couldn't create user.";
			return View();
		}
	}
}
