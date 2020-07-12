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
    public class StudentAttendanceTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: StudentAttendanceTables
        public ActionResult Index()
        {
            var studentAttendanceTables = db.StudentAttendanceTables.Include(s => s.ClassTable).Include(s => s.SessionTable).Include(s => s.StudentTable);
            return View(studentAttendanceTables.ToList());
        }

        // GET: StudentAttendanceTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendanceTable studentAttendanceTable = db.StudentAttendanceTables.Find(id);
            if (studentAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendanceTable);
        }

        // GET: StudentAttendanceTables/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name");
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name");
            return View();
        }

        // POST: StudentAttendanceTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentAttendanceTable studentAttendanceTable)
        {            
            if (ModelState.IsValid)
            {
                db.StudentAttendanceTables.Add(studentAttendanceTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentAttendanceTable.ClassID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentAttendanceTable.SessionID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentAttendanceTable.StudentID);
            return View(studentAttendanceTable);
        }

        // GET: StudentAttendanceTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendanceTable studentAttendanceTable = db.StudentAttendanceTables.Find(id);
            if (studentAttendanceTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentAttendanceTable.ClassID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentAttendanceTable.SessionID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentAttendanceTable.StudentID);
            return View(studentAttendanceTable);
        }

        // POST: StudentAttendanceTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentAttendanceTable studentAttendanceTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAttendanceTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentAttendanceTable.ClassID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentAttendanceTable.SessionID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentAttendanceTable.StudentID);
            return View(studentAttendanceTable);
        }

        // GET: StudentAttendanceTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendanceTable studentAttendanceTable = db.StudentAttendanceTables.Find(id);
            if (studentAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendanceTable);
        }

        // POST: StudentAttendanceTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAttendanceTable studentAttendanceTable = db.StudentAttendanceTables.Find(id);
            db.StudentAttendanceTables.Remove(studentAttendanceTable);
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
