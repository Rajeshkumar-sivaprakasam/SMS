using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class CourseController : Controller
    {
        private Models.AppContext _context;
        public CourseController()
        {
            _context = new Models.AppContext();
        }
        // GET: Course
        public ActionResult Index()
        {
            var list = _context.Courses.ToList();
            return View(list);
        }

        // GET: Course/Details/5
        
        [HttpPost]
        public ActionResult Create(Course courseObj)
        {
            if (courseObj != null)
            {
                if (courseObj.Id > 0)
                {

                    var courseFromDb = _context.Users.FirstOrDefault(u => u.Id == courseObj.Id);
                    if (courseFromDb == null)
                        return HttpNotFound();
                    courseFromDb.FirstName = courseObj.CourseName;
                    courseFromDb.LastName = courseObj.Year;
                    //courseFromDb.Password = courseObj.Password;
                }
                else
                {
                    _context.Courses.Add(courseObj);
                }
            }

            _context.SaveChanges();
            //return View("~/Views/Student/GetStudent.cshtml");
            return RedirectToAction("Index","Course");
        }
        
        public ActionResult Create()
        {
            return View();
            
        }

        /*public ActionResult Details()
        {
            return View();
        }*/
        public ActionResult Details(int? id)
        {
            //value types and reference type



            var courseDetails = _context.Courses.Where(x => x.Id == id).FirstOrDefault();
            if (courseDetails != null)
            {
                return View(courseDetails);
            }

            return View();
        }


        public ActionResult Delete(int? id)
        {

            if (id == null)
                return HttpNotFound();

            var course = _context.Courses.FirstOrDefault(u => u.Id == id);

            if (course == null)
                return HttpNotFound();
            _context.Courses.Remove(course);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
