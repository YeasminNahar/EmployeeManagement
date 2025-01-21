using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminUsername") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var admins = _context.Admins.ToList();
            return View(admins);
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminUsername") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
        [HttpPost]
        public IActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("AdminUsername") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var admin = _context.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }
        [HttpPost]
        public IActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Admins.Update(admin);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("AdminUsername") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var admin = _context.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
