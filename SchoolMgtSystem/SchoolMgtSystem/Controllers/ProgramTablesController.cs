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
    public class ProgramTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: ProgramTables
        public ActionResult Index()
        {
            var programTables = db.ProgramTables.Include(p => p.UserTable);
            return View(programTables.ToList());
        }

        // GET: ProgramTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramTable programTable = db.ProgramTables.Find(id);
            if (programTable == null)
            {
                return HttpNotFound();
            }
            return View(programTable);
        }

        // GET: ProgramTables/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: ProgramTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgramID,UserID,Name,StartDate,EndDate")] ProgramTable programTable)
        {
            if (ModelState.IsValid)
            {
                db.ProgramTables.Add(programTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programTable.UserID);
            return View(programTable);
        }

        // GET: ProgramTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramTable programTable = db.ProgramTables.Find(id);
            if (programTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programTable.UserID);
            return View(programTable);
        }

        // POST: ProgramTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgramID,UserID,Name,StartDate,EndDate")] ProgramTable programTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programTable.UserID);
            return View(programTable);
        }

        // GET: ProgramTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramTable programTable = db.ProgramTables.Find(id);
            if (programTable == null)
            {
                return HttpNotFound();
            }
            return View(programTable);
        }

        // POST: ProgramTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramTable programTable = db.ProgramTables.Find(id);
            db.ProgramTables.Remove(programTable);
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
