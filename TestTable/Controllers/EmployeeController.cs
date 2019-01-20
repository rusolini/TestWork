using Dropdownlistmvc.Data;
using Dropdownlistmvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Dropdownlistmvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _empRepository;
        private readonly IGender _genderRepository;

        public EmployeeController(IEmployee empRepo, IGender genderRepo)
        {
            _empRepository = empRepo;
            _genderRepository = genderRepo;
        }

        public ActionResult Index()
        {
            IEnumerable<Employee> model = _empRepository.GetEmployees;
            return View(model);
        }
        public ActionResult AddEmployee()
        {
            Employee emp = new Employee {Id = 0, GendersEnum = _genderRepository.GetGenders};
            return View("Edit",emp);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            Employee emp = _empRepository.GetEmployee(Id);
            emp.GendersEnum = _genderRepository.GetGenders;
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee data, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid && (upload != null && upload.ContentLength > 0))
            {
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    data.Image = reader.ReadBytes(upload.ContentLength);
                }

                _empRepository.Save(data);
                TempData["message"] = "Save";
                return RedirectToAction("Index");
            }

            data.GendersEnum = _genderRepository.GetGenders;
            return View(data);
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                HttpNotFound();
            }
            _empRepository.Delete(Id);
            TempData["message"] = "Deleted";
            return RedirectToAction("Index");
        }
    }
}