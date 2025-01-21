using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            var adminUsername = HttpContext.Session.GetString("AdminUsername");

            if (string.IsNullOrEmpty(adminUsername))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewData["AdminUsername"] = adminUsername;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = _context.Admins
                    .FirstOrDefault(a => a.Username == model.Username && a.Password == model.Password);

                if (admin != null)
                {
                    HttpContext.Session.SetString("AdminUsername", admin.Username);

                    return RedirectToAction("Index", "Employee","Index","Admin");
                }

                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
