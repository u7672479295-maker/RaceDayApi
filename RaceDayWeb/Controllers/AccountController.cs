using Microsoft.AspNetCore.Mvc;
using RaceDayWeb.Models;
using RaceDayWeb.Services;

namespace RaceDayWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiService _apiSevice;

        public AccountController(ApiService apiService)
        {
            _apiSevice = apiService;
        }

        //get: /account/login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //post: /Account/login
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _apiSevice.PostAsync<dynamic>
                ("Authentication/login", model);

            if (response != null)
            {
                HttpContext.Session.SetString("UserEmail", model.Email);


                if (model.Email.Contains("organiser"))
                {
                    HttpContext.Session.SetString("UserRole", "Organiser");
                    return RedirectToAction("Index", "Event");

                }

                HttpContext.Session.SetString("UserRole", "Participant");
                return RedirectToAction("Index", "Event");
            }

            ModelState.AddModelError(string.Empty, "Invalid login credentials");
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var success = await _apiSevice.PostAsync("authentication/register", model);

            if (success)
            {
                    TempData["SuccessMessage"] = "Registration successful! Please Log in.";
                    return RedirectToAction("Login");
            }

            ModelState.AddModelError(string.Empty, "Registration failed. Email may already be in use.");
            return View(model);

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}