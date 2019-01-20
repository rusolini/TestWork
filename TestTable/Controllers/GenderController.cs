using System.Linq;
using System.Web.Mvc;
using Dropdownlistmvc.Data;
using Dropdownlistmvc.Service;

namespace Dropdownlistmvc.Controllers
{
    public class GenderController : Controller
    {
        private readonly IEmployee EmpRepository;
        private readonly IGender GenderRepository;

        public GenderController(IEmployee EmpRepo, IGender GenderRepo)
        {
            EmpRepository = EmpRepo;
            GenderRepository = GenderRepo;
        }

        public ActionResult Index()
        {
            var model = GenderRepository.GetGenders;
            return View(model);
        }

        public ActionResult AddGender()
        {
            var gd = new Gender {GenderId = 0};
            return View("Edit", gd);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound();
            var gd = GenderRepository.GetGenders.First(gender => gender.GenderId == Id);
            return View(gd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gender data)
        {
            if (ModelState.IsValid)
            {
                GenderRepository.Save(data);
                TempData["message"] = "Save";
                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null) HttpNotFound();
            GenderRepository.Delete(Id);
            TempData["message"] = "Deleted";
            return RedirectToAction("Index");
        }
    }
}