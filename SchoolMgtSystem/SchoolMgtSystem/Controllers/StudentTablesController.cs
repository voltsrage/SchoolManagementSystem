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
    public class StudentTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: StudentTables
        public ActionResult Index()
        {
            var studentTables = db.StudentTables.Include(s => s.ClassTable).Include(s => s.ProgramTable).Include(s => s.SessionTable).Include(s => s.UserTable);
            return View(studentTables.ToList());
        }

        // GET: StudentTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            return View(studentTable);
        }

        // GET: StudentTables/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name");
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name");
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: StudentTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentTable studentTable)
        {
            studentTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                db.StudentTables.Add(studentTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentTable.ClassID);
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", studentTable.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", studentTable.UserID);
            return View(studentTable);
        }

        // GET: StudentTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentTable.ClassID);
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", studentTable.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", studentTable.UserID);
            return View(studentTable);
        }

        // POST: StudentTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentTable studentTable)
        {
            studentTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                db.Entry(studentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentTable.ClassID);
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", studentTable.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", studentTable.UserID);
            return View(studentTable);
        }

        // GET: StudentTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            return View(studentTable);
        }

        // POST: StudentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentTable studentTable = db.StudentTables.Find(id);
            db.StudentTables.Remove(studentTable);
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
