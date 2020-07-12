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
    public class SubmissionTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: SubmissionTables
        public ActionResult Index()
        {
            var submissionTables = db.SubmissionTables.Include(s => s.ClassTable).Include(s => s.ProgramTable).Include(s => s.StudentTable).Include(s => s.UserTable);
            return View(submissionTables.ToList());
        }

        // GET: SubmissionTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubmissionTable submissionTable = db.SubmissionTables.Find(id);
            if (submissionTable == null)
            {
                return HttpNotFound();
            }
            return View(submissionTable);
        }

        // GET: SubmissionTables/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name");
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: SubmissionTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubmissionTable submissionTable)
        {
            submissionTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                db.SubmissionTables.Add(submissionTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", submissionTable.ClassID);
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", submissionTable.ProgramID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", submissionTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", submissionTable.UserID);
            return View(submissionTable);
        }

        // GET: SubmissionTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubmissionTable submissionTable = db.SubmissionTables.Find(id);
            if (submissionTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", submissionTable.ClassID);
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", submissionTable.ProgramID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", submissionTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", submissionTable.UserID);
            return View(submissionTable);
        }

        // POST: SubmissionTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubmissionTable submissionTable)
        {
            submissionTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                db.Entry(submissionTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", submissionTable.ClassID);
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", submissionTable.ProgramID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", submissionTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", submissionTable.UserID);
            return View(submissionTable);
        }

        // GET: SubmissionTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubmissionTable submissionTable = db.SubmissionTables.Find(id);
            if (submissionTable == null)
            {
                return HttpNotFound();
            }
            return View(submissionTable);
        }

        // POST: SubmissionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubmissionTable submissionTable = db.SubmissionTables.Find(id);
            db.SubmissionTables.Remove(submissionTable);
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
