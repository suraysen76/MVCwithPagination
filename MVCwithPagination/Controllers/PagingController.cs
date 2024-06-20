using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCwithPagination.DAL;
using MVCwithPagination.Models;

namespace MVCwithPagination.Controllers
{
    public class PagingController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Paging
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PagingModel model)
        {
            return RedirectToAction("Paging", new {pageSize=model.PageSize, pageNumber = 1 });
        }
        public ActionResult Paging( int pageSize=0, int pageNumber = 1)
        {
            if (pageSize == 0)
            {
                pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
            }
            var masterModel = new MasterModel();
            int skip = pageSize * (pageNumber - 1);
            var dbStudents = db.Students;
            var cnt = dbStudents.Count();
            
            var totalPages = Math.Ceiling((float)cnt / pageSize);

           var students = dbStudents
                .OrderByDescending(m => m.LastName)
                .Skip(skip)
                .Take(pageSize);
            masterModel.Students = students;
            
            masterModel.Paging = new PagingModel() 
            { 
                PageNumber=pageNumber,
                PageSize=pageSize,
                TotalPages=(int) totalPages 
            };
            
            return View(masterModel);
        }

        // GET: Paging/Details/5
        public ActionResult Details(int? id)
        {
            var masterModel = new MasterModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            var studentModel = new List<StudentModel>();
            studentModel.Add(student);
            masterModel.Students=studentModel;

            var pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
            masterModel.Paging = new PagingModel() { PageNumber =1, PageSize = pageSize, TotalPages = 1 };


            return View(masterModel);
        }

        // GET: Paging/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paging/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel student)
        {
            var pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Paging", new { pageNumber = 1 });
            }

            return View(student);
        }

        // GET: Paging/Edit/5
        public ActionResult Edit(int? id)
        {
            var masterModel = new MasterModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            var studentModel = new List<StudentModel>();
            studentModel.Add(student);
            masterModel.Students = studentModel;

            var pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
            masterModel.Paging = new PagingModel() { PageNumber = 1, PageSize = pageSize, TotalPages = 1 };


            return View(masterModel);
        }

        // POST: Paging/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( StudentModel student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Paging", new { pageNumber = 1 }); ;
            }
            return View(student);
        }

        // GET: Paging/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Paging/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentModel student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Paging", new { pageNumber = 1 });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
