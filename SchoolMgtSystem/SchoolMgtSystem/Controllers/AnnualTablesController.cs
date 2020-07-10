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
    public class AnnualTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: AnnualTables
        [UserAuthorizationFilter]
        public ActionResult Index()
        {
            var annualTables = db.AnnualTables.Include(a => a.ProgramTable).Include(a => a.UserTable);
            return View(annualTables.ToList());
        }

        // GET: AnnualTables/Details/5
        [UserAuthorizationFilter]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnualTable annualTable = db.AnnualTables.Find(id);
            if (annualTable == null)
            {
                return HttpNotFound();
            }
            return View(annualTable);
        }

        // GET: AnnualTables/Create
        [UserAuthorizationFilter]
        public ActionResult Create()
        {
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: AnnualTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult Create([Bind(Include = "AnnualID,UserID,ProgramID,Title,Fees,IsActive,Description")] AnnualTable annualTable)
        {
            if (ModelState.IsValid)
            {
                db.AnnualTables.Add(annualTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", annualTable.ProgramID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", annualTable.UserID);
            return View(annualTable);
        }

        // GET: AnnualTables/Edit/5
        [UserAuthorizationFilter]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnualTable annualTable = db.AnnualTables.Find(id);
            if (annualTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", annualTable.ProgramID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", annualTable.UserID);
            return View(annualTable);
        }

        // POST: AnnualTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult Edit([Bind(Include = "AnnualID,UserID,ProgramID,Title,Fees,IsActive,Description")] AnnualTable annualTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(annualTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", annualTable.ProgramID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", annualTable.UserID);
            return View(annualTable);
        }

        // GET: AnnualTables/Delete/5
        [UserAuthorizationFilter]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnnualTable annualTable = db.AnnualTables.Find(id);
            if (annualTable == null)
            {
                return HttpNotFound();
            }
            return View(annualTable);
        }

        // POST: AnnualTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult DeleteConfirmed(int id)
        {
            AnnualTable annualTable = db.AnnualTables.Find(id);
            db.AnnualTables.Remove(annualTable);
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
