using Microsoft.AspNetCore.Mvc;
using Tracking.Models;
using Tracking.ViewModels;

namespace Tracking.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Index()
        {
            var context = new BonustrackingContext();
            var employeeId = int.Parse(HttpContext.Session.GetString("Id"));
            var datas = context.SupportWithTimeDifferences.Where(x=>x.EmployeeId == employeeId).ToList();
            return View(datas);
        }

        public IActionResult CreateSupport()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSupport(CreateSupportViewModel model)
        {
            var context = new BonustrackingContext();

            var support = context.Supports.Add(new Support()
            {
                CustomerFullName = model.CustomerFullName,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Status = model.Status,
                Subject = model.Subject,
                EmployeeId = int.Parse(HttpContext.Session.GetString("Id"))
            });

            context.SaveChanges();

            if (model.Note != null)
            {
                context.SupportDetails.Add(new SupportDetail()
                {
                    Message = model.Note,
                    SupportId = support.Entity.Id
                });

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
