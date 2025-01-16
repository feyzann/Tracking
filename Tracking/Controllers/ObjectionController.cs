using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracking.Models;
using Tracking.ViewModels;

namespace Tracking.Controllers
{
    public class ObjectionController : Controller
    {
        public IActionResult Index()
        {
            var context = new BonustrackingContext();
            var employeeId = int.Parse(HttpContext.Session.GetString("Id"));
            var result = context.GetObjectionsByEmployeeId.FromSqlRaw("EXECUTE dbo.GetObjectionsByEmployeeId {0}", employeeId).ToList();
            if (result.Count > 0)
            {
                result = result.OrderByDescending(x => x.ObjectionDate).ToList();
            }
            return View(result);
        }

        public IActionResult CreateObjection(int bonusId)
        {
            var model = new CreateObjectionViewModel();
            model.BonusId = bonusId;
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateObjection(CreateObjectionViewModel model)
        {
            var context = new BonustrackingContext();
            context.Database.ExecuteSqlRaw("EXEC dbo.CreateObjectionSp @p0, @p1", parameters: new[] { model.BonusId.ToString(), model.Desc.ToString() });

            return RedirectToAction("Index"); 
        }

        public IActionResult TeamLeadIndex()
        {
            var context = new BonustrackingContext();
            var employeeId = int.Parse(HttpContext.Session.GetString("Id"));
            var result = context.ObjectionsForTeamLead.ToList();
            if (result.Count > 0)
            {
                result = result.OrderByDescending(x => x.ObjectionDate).ToList();
            }
            return View(result);
        }

        public IActionResult ObjectionReponseForTeamLead(int result,int objectionId)
        {

            return View(result);
        }
    }
}
