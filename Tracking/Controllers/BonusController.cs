using Microsoft.AspNetCore.Mvc;
using Tracking.Models;

namespace Tracking.Controllers
{
    public class BonusController : Controller
    {
        public IActionResult Index()
        {
            var context = new BonustrackingContext();
            var employeeId = int.Parse(HttpContext.Session.GetString("Id"));
            var result = context.Bonus.Where(x => x.EmployeeId == employeeId).ToList(); ;
            return View(result);
        }
    }
}
