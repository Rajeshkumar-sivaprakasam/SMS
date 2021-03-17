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
            if (userObj!=null)
            {
                if (userObj.Id > 0)
                {
                    
                    var userFromDb = _context.Users.FirstOrDefault(u => u.Id == userObj.Id);
                    if (userFromDb == null)
                        return HttpNotFound();
                    userFromDb.FirstName = userObj.FirstName;
                    userFromDb.LastName = userObj.LastName;
                    userFromDb.Password = userObj.Password;
                }
                else
                {
                    _context.Users.Add(userObj);
                }
            }
           
            _context.SaveChanges();
            //return View("~/Views/Student/GetStudent.cshtml");
            return RedirectToAction("GetStudent", "Student");
        }
        public ActionResult GetStudent()
        {
            var list = _context.Users.ToList();
            return View(list);
        }
        public ActionResult Edit(int id)
        {
            var studentDetails = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if(studentDetails != null)
            {
                return View("create",studentDetails);
            }
            return  View(); 
        }
        /*public ActionResult Details()
        {
            return View();
        }*/
        public ActionResult Details(int id)
        {
            var studentDetails = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (studentDetails != null)
            {
                return View(studentDetails);
            }

            return View();
        }
    }
}