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
    public class TimeTableTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: TimeTableTables
        public ActionResult Index()
        {
            var timeTableTables = db.TimeTableTables.Include(t => t.ClassSubjectTable).Include(t => t.StaffTable).Include(t => t.UserTable);
            return View(timeTableTables.ToList());
        }

        // GET: TimeTableTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTableTable timeTableTable = db.TimeTableTables.Find(id);
            if (timeTableTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTableTable);
        }

        // GET: TimeTableTables/Create
        public ActionResult Create()
        {
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name");
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: TimeTableTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeTableID,UserID,StaffID,StartTime,EndTime,Day,ClassSubjectID,IsActive")] TimeTableTable timeTableTable)
        {
            timeTableTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                db.TimeTableTables.Add(timeTableTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", timeTableTable.ClassSubjectID);
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", timeTableTable.StaffID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", timeTableTable.UserID);
            return View(timeTableTable);
        }

        // GET: TimeTableTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTableTable timeTableTable = db.TimeTableTables.Find(id);
            if (timeTableTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", timeTableTable.ClassSubjectID);
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", timeTableTable.StaffID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", timeTableTable.UserID);
            return View(timeTableTable);
        }

        // POST: TimeTableTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeTableID,UserID,StaffID,StartTime,EndTime,Day,ClassSubjectID,IsActive")] TimeTableTable timeTableTable)
        {
            timeTableTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                db.Entry(timeTableTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", timeTableTable.ClassSubjectID);
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", timeTableTable.StaffID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", timeTableTable.UserID);
            return View(timeTableTable);
        }

        // GET: TimeTableTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTableTable timeTableTable = db.TimeTableTables.Find(id);
            if (timeTableTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTableTable);
        }

        // POST: TimeTableTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeTableTable timeTableTable = db.TimeTableTables.Find(id);
            db.TimeTableTables.Remove(timeTableTable);
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
