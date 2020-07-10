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
    public class DesignationTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: DesignationTables
       
        public ActionResult Index()
        {
            var designationTables = db.DesignationTables.Include(d => d.UserTable);
            return View(designationTables.ToList());
        }

        // GET: DesignationTables/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationTable designationTable = db.DesignationTables.Find(id);
            if (designationTable == null)
            {
                return HttpNotFound();
            }
            return View(designationTable);
        }

        // GET: DesignationTables/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: DesignationTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DesignationID,UserID,Title,IsActive")] DesignationTable designationTable)
        {
            if (ModelState.IsValid)
            {
                db.DesignationTables.Add(designationTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", designationTable.UserID);
            return View(designationTable);
        }

        // GET: DesignationTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationTable designationTable = db.DesignationTables.Find(id);
            if (designationTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", designationTable.UserID);
            return View(designationTable);
        }

        // POST: DesignationTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DesignationID,UserID,Title,IsActive")] DesignationTable designationTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designationTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", designationTable.UserID);
            return View(designationTable);
        }

        // GET: DesignationTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationTable designationTable = db.DesignationTables.Find(id);
            if (designationTable == null)
            {
                return HttpNotFound();
            }
            return View(designationTable);
        }

        // POST: DesignationTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesignationTable designationTable = db.DesignationTables.Find(id);
            db.DesignationTables.Remove(designationTable);
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
