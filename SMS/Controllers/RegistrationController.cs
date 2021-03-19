using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class RegistrationController : Controller
    {
        private Models.AppContext _context;
        public RegistrationController()
        {
            _context = new Models.AppContext();
        }
        // GET: Registration
        public ActionResult Index()
        {
            var list = _context.Registrations.ToList();
            return View(list);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Registration regObj)
        {
            if (regObj != null)
            {
                if (regObj.Id > 0)
                {

                    var regFromDb = _context.Registrations.FirstOrDefault(u => u.Id == regObj.Id);
                    if (regFromDb == null)
                        return HttpNotFound();
                    regFromDb.FirstName = regObj.FirstName;
                    regFromDb.LastName = regObj.LastName;
                    regFromDb.Batch = regObj.Batch;
                    regFromDb.Course = regObj.Course;
                    regFromDb.Email = regObj.Email;
                }
                else
                {
                    _context.Registrations.Add(regObj);
                }
            }

            _context.SaveChanges();
            //return View("~/Views/Student/GetStudent.cshtml");
            return RedirectToAction("Index", "Registration");
        }

        public ActionResult Edit(int? id)
        {
            var regDetails = _context.Registrations.Where(r => r.Id == id).FirstOrDefault();
            if(regDetails != null)
            {
                return View("create", regDetails);
            }
            return View();
        }

        public  ActionResult Details(int? id)
        {
            var regDetails = _context.Registrations.Where(r => r.Id == id).FirstOrDefault();

            if(regDetails != null)
            {
                return View(regDetails);
            }
            return View();
        }

        public  ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var regDetails = _context.Registrations.Where(r => r.Id == id).FirstOrDefault();
            if (regDetails == null)
                return HttpNotFound();
            _context.Registrations.Remove(regDetails);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}