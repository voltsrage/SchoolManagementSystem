using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolDBAccess;

namespace SchoolMgtSystem.Controllers
{
    public class StaffAttendanceTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: StaffAttendanceTables
        public ActionResult Index()
        {
            var staffAttendanceTables = db.StaffAttendanceTables.Include(s => s.StaffTable);
            return View(staffAttendanceTables.ToList());
        }

        // GET: StaffAttendanceTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffAttendanceTable staffAttendanceTable = db.StaffAttendanceTables.Find(id);
            if (staffAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(staffAttendanceTable);
        }

        // GET: StaffAttendanceTables/Create
        public ActionResult Create()
        {
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name");
            return View();
        }

        // POST: StaffAttendanceTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffAttendanceID,StaffID,AttendDate,Arrival,LeavingTime")] StaffAttendanceTable staffAttendanceTable)
        {
            if (ModelState.IsValid)
            {
                db.StaffAttendanceTables.Add(staffAttendanceTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", staffAttendanceTable.StaffID);
            return View(staffAttendanceTable);
        }

        // GET: StaffAttendanceTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffAttendanceTable staffAttendanceTable = db.StaffAttendanceTables.Find(id);
            if (staffAttendanceTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", staffAttendanceTable.StaffID);
            return View(staffAttendanceTable);
        }

        // POST: StaffAttendanceTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffAttendanceID,StaffID,AttendDate,Arrival,LeavingTime")] StaffAttendanceTable staffAttendanceTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffAttendanceTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", staffAttendanceTable.StaffID);
            return View(staffAttendanceTable);
        }

        // GET: StaffAttendanceTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffAttendanceTable staffAttendanceTable = db.StaffAttendanceTables.Find(id);
            if (staffAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(staffAttendanceTable);
        }

        // POST: StaffAttendanceTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffAttendanceTable staffAttendanceTable = db.StaffAttendanceTables.Find(id);
            db.StaffAttendanceTables.Remove(staffAttendanceTable);
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
