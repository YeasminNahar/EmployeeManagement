using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
        //        var user = new Admin
        //        {
        //            Username = model.Username,
        //            Email = model.Email,
        //            PasswordHash = hashedPassword
        //        };

        //        _context.Users.Add(user);
        //        _context.SaveChanges();
        //        return RedirectToAction("Login");
        //    }
        //    return View(model);
        //}

    }
}
