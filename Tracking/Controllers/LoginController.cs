using Microsoft.AspNetCore.Mvc;
using Tracking.Models;
using Tracking.ViewModels;

namespace Tracking.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var context = new BonustrackingContext();

            var control = context.Employees.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();

            if (control != null)
            {
                HttpContext.Session.SetString("Id", control.Id.ToString());
                HttpContext.Session.SetString("RoleId", control.RoleId.ToString());
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
