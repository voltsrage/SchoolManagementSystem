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
    public class StaffTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: StaffTables
        public ActionResult Index()
        {
            var staffTables = db.StaffTables.Include(s => s.DesignationTable).Include(s => s.UserTable);
            return View(staffTables.ToList());
        }

        // GET: StaffTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffTable staffTable = db.StaffTables.Find(id);
            if (staffTable == null)
            {
                return HttpNotFound();
            }
            return View(staffTable);
        }

        // GET: StaffTables/Create
        public ActionResult Create()
        {
            ViewBag.DesignationID = new SelectList(db.DesignationTables, "DesignationID", "Title");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: StaffTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffTable staffTable)
        {
            staffTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            staffTable.RegistrationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.StaffTables.Add(staffTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DesignationID = new SelectList(db.DesignationTables, "DesignationID", "Title", staffTable.DesignationID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", staffTable.UserID);
            return View(staffTable);
        }

        // GET: StaffTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffTable staffTable = db.StaffTables.Find(id);
            if (staffTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignationID = new SelectList(db.DesignationTables, "DesignationID", "Title", staffTable.DesignationID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", staffTable.UserID);
            return View(staffTable);
        }

        // POST: StaffTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffTable staffTable)
        {
            staffTable.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            staffTable.RegistrationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(staffTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DesignationID = new SelectList(db.DesignationTables, "DesignationID", "Title", staffTable.DesignationID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", staffTable.UserID);
            return View(staffTable);
        }

        // GET: StaffTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffTable staffTable = db.StaffTables.Find(id);
            if (staffTable == null)
            {
                return HttpNotFound();
            }
            return View(staffTable);
        }

        // POST: StaffTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffTable staffTable = db.StaffTables.Find(id);
            db.StaffTables.Remove(staffTable);
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
