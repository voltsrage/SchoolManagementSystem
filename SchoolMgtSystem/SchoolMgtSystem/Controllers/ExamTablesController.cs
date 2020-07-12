using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolDBAccess;
using SchoolMgtSystem.CustomerFilters;

namespace SchoolMgtSystem.Controllers
{
    [UserAuthorizationFilter]
    public class ExamTablesController : Controller
    {

        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: ExamTables
        public ActionResult Index()
        {
            var examTables = db.ExamTables.Include(e => e.UserTable);
            return View(examTables.ToList());
        }

        // GET: ExamTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamTable examTable = db.ExamTables.Find(id);
            if (examTable == null)
            {
                return HttpNotFound();
            }
            return View(examTable);
        }

        // GET: ExamTables/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: ExamTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamTable examTable)
        {
            examTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                db.ExamTables.Add(examTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", examTable.UserID);
            return View(examTable);
        }

        // GET: ExamTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamTable examTable = db.ExamTables.Find(id);
            if (examTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", examTable.UserID);
            return View(examTable);
        }

        // POST: ExamTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamTable examTable)
        {
            examTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                db.Entry(examTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", examTable.UserID);
            return View(examTable);
        }

        // GET: ExamTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamTable examTable = db.ExamTables.Find(id);
            if (examTable == null)
            {
                return HttpNotFound();
            }
            return View(examTable);
        }

        // POST: ExamTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamTable examTable = db.ExamTables.Find(id);
            db.ExamTables.Remove(examTable);
            db.SaveChanges();
            return RedirectToAction("Index");
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
