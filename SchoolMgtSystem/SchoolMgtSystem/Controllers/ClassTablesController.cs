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
    public class ClassTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: ClassTables
        public ActionResult Index()
        {
            return View(db.ClassTables.ToList());
        }

        // GET: ClassTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTable classTable = db.ClassTables.Find(id);
            if (classTable == null)
            {
                return HttpNotFound();
            }
            return View(classTable);
        }

        // GET: ClassTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassID,Name,IsActive")] ClassTable classTable)
        {
            if (ModelState.IsValid)
            {
                db.ClassTables.Add(classTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classTable);
        }

        // GET: ClassTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTable classTable = db.ClassTables.Find(id);
            if (classTable == null)
            {
                return HttpNotFound();
            }
            return View(classTable);
        }

        // POST: ClassTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassID,Name,IsActive")] ClassTable classTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classTable);
        }

        // GET: ClassTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassTable classTable = db.ClassTables.Find(id);
            if (classTable == null)
            {
                return HttpNotFound();
            }
            return View(classTable);
        }

        // POST: ClassTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassTable classTable = db.ClassTables.Find(id);
            db.ClassTables.Remove(classTable);
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
