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
    public class StudentPromotionTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: StudentPromotionTables
        public ActionResult Index()
        {
            var studentPromotionTables = db.StudentPromotionTables.Include(s => s.ClassTable).Include(s => s.ProgramSession).Include(s => s.SectionTable).Include(s => s.StudentTable);
            return View(studentPromotionTables.ToList());
        }

        // GET: StudentPromotionTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPromotionTable studentPromotionTable = db.StudentPromotionTables.Find(id);
            if (studentPromotionTable == null)
            {
                return HttpNotFound();
            }
            return View(studentPromotionTable);
        }

        // GET: StudentPromotionTables/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name");
            ViewBag.ProgramSessionID = new SelectList(db.ProgramSessions, "ProgramSessionID", "Title");
            ViewBag.SectionID = new SelectList(db.SectionTables, "SectionID", "SectionName");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name");
            return View();
        }

        // POST: StudentPromotionTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( StudentPromotionTable studentPromotionTable)
        {
            if (ModelState.IsValid)
            {
                db.StudentPromotionTables.Add(studentPromotionTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentPromotionTable.ClassID);
            ViewBag.ProgramSessionID = new SelectList(db.ProgramSessions, "ProgramSessionID", "Title", studentPromotionTable.ProgramSessionID);
            ViewBag.SectionID = new SelectList(db.SectionTables, "SectionID", "SectionName", studentPromotionTable.SectionID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentPromotionTable.StudentID);
            return View(studentPromotionTable);
        }

        // GET: StudentPromotionTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPromotionTable studentPromotionTable = db.StudentPromotionTables.Find(id);
            if (studentPromotionTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentPromotionTable.ClassID);
            ViewBag.ProgramSessionID = new SelectList(db.ProgramSessions, "ProgramSessionID", "Title", studentPromotionTable.ProgramSessionID);
            ViewBag.SectionID = new SelectList(db.SectionTables, "SectionID", "SectionName", studentPromotionTable.SectionID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentPromotionTable.StudentID);
            return View(studentPromotionTable);
        }

        // POST: StudentPromotionTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentPromotionTable studentPromotionTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentPromotionTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentPromotionTable.ClassID);
            ViewBag.ProgramSessionID = new SelectList(db.ProgramSessions, "ProgramSessionID", "Title", studentPromotionTable.ProgramSessionID);
            ViewBag.SectionID = new SelectList(db.SectionTables, "SectionID", "SectionName", studentPromotionTable.SectionID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentPromotionTable.StudentID);
            return View(studentPromotionTable);
        }

        // GET: StudentPromotionTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPromotionTable studentPromotionTable = db.StudentPromotionTables.Find(id);
            if (studentPromotionTable == null)
            {
                return HttpNotFound();
            }
            return View(studentPromotionTable);
        }

        // POST: StudentPromotionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentPromotionTable studentPromotionTable = db.StudentPromotionTables.Find(id);
            db.StudentPromotionTables.Remove(studentPromotionTable);
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
