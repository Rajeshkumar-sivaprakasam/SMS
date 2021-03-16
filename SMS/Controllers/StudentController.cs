using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        // GET: Stduent
        private Models.AppContext _context;

        public StudentController()
        {
            _context = new Models.AppContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Create(User userObj)
        {

            _context.Users.Add(userObj);
            _context.SaveChanges();
            //return View("~/Views/Student/GetStudent.cshtml");
            return RedirectToAction("GetStudent", "Student");
        }
        public ActionResult GetStudent()
        {
            var list = _context.Users.ToList();
            return View(list);
        }
    }
}