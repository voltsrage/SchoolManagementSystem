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
    public class MarksTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: MarksTables
        public ActionResult Index()
        {
            var marksTables = db.MarksTables.Include(m => m.ClassSubjectTable).Include(m => m.ExamTable).Include(m => m.StudentTable).Include(m => m.UserTable);
            return View(marksTables.ToList());
        }

        // GET: MarksTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarksTable marksTable = db.MarksTables.Find(id);
            if (marksTable == null)
            {
                return HttpNotFound();
            }
            return View(marksTable);
        }

        // GET: MarksTables/Create
        public ActionResult Create()
        {
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name");
            ViewBag.ExamID = new SelectList(db.ExamTables, "ExamID", "Title");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: MarksTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarksTable marksTable)
        {
            marksTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                db.MarksTables.Add(marksTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", marksTable.ClassSubjectID);
            ViewBag.ExamID = new SelectList(db.ExamTables, "ExamID", "Title", marksTable.ExamID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", marksTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", marksTable.UserID);
            return View(marksTable);
        }

        // GET: MarksTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarksTable marksTable = db.MarksTables.Find(id);
            if (marksTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", marksTable.ClassSubjectID);
            ViewBag.ExamID = new SelectList(db.ExamTables, "ExamID", "Title", marksTable.ExamID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", marksTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", marksTable.UserID);
            return View(marksTable);
        }

        // POST: MarksTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MarksTable marksTable)
        {
            marksTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                db.Entry(marksTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", marksTable.ClassSubjectID);
            ViewBag.ExamID = new SelectList(db.ExamTables, "ExamID", "Title", marksTable.ExamID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", marksTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", marksTable.UserID);
            return View(marksTable);
        }

        // GET: MarksTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarksTable marksTable = db.MarksTables.Find(id);
            if (marksTable == null)
            {
                return HttpNotFound();
            }
            return View(marksTable);
        }

        // POST: MarksTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarksTable marksTable = db.MarksTables.Find(id);
            db.MarksTables.Remove(marksTable);
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
