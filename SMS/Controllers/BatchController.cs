using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class BatchController : Controller
    {
        private Models.AppContext _context;
        public BatchController()
        {
            _context = new Models.AppContext();
        }
        // GET: Batch
        public ActionResult Index()
        {
            var list = _context.Batches.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Batch batchObj)
        {
            if (batchObj != null)
            {
                if (batchObj.Id > 0)
                {

                    var batchFromDb = _context.Batches.FirstOrDefault(u => u.Id == batchObj.Id);
                    if (batchFromDb == null)
                        return HttpNotFound();
                    batchFromDb.BatchName = batchObj.BatchName;
                    batchFromDb.Year = batchObj.Year;

                }
                else
                {
                    _context.Batches.Add(batchObj);
                }
            }
            _context.SaveChanges();
            //return View("~/Views/Student/GetStudent.cshtml");
            return RedirectToAction("Index", "Batch");

        }

        public ActionResult Edit(int id)
        {
            var batchDetails = _context.Batches.Where(x => x.Id == id).FirstOrDefault();
            if (batchDetails != null)
            {
                return View("create", batchDetails);
            }
            return View();
        }
        /*public ActionResult Details()
        {
            return View();
        }
        */

        public ActionResult Details(int? id)
        {
            //value types and reference type



            var batchDetails = _context.Batches.Where(x => x.Id == id).FirstOrDefault();
            if (batchDetails != null)
            {
                return View(batchDetails);
            }

            return View();
        }


        public ActionResult Delete(int? id)
        {

            if (id == null)
                return HttpNotFound();

            var batch = _context.Batches.FirstOrDefault(u => u.Id == id);

            if (batch == null)
                return HttpNotFound();
            _context.Batches.Remove(batch);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}