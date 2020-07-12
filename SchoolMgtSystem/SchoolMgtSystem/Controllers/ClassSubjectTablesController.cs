﻿using System;
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
    public class ClassSubjectTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: ClassSubjectTables
        public ActionResult Index()
        {
            var classSubjectTables = db.ClassSubjectTables.Include(c => c.ClassTable).Include(c => c.SubjectTable);
            return View(classSubjectTables.ToList());
        }

        // GET: ClassSubjectTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSubjectTable classSubjectTable = db.ClassSubjectTables.Find(id);
            if (classSubjectTable == null)
            {
                return HttpNotFound();
            }
            return View(classSubjectTable);
        }

        // GET: ClassSubjectTables/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name");
            ViewBag.SubjectID = new SelectList(db.SubjectTables, "SubjectID", "Name");
            return View();
        }

        // POST: ClassSubjectTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ClassSubjectTable classSubjectTable)
        {
            if (ModelState.IsValid)
            {
                var classname = db.ClassTables.Where(s => s.ClassID == classSubjectTable.ClassID).SingleOrDefault();
                var subjectname = db.SubjectTables.Where(s => s.SubjectID == classSubjectTable.SubjectID).SingleOrDefault();
                if (classname != null)
                {
                    
                        var details = classname.Name + "-" + (subjectname != null ? subjectname.Name : "");
                        classSubjectTable.Name = details;
                   
                }
                db.ClassSubjectTables.Add(classSubjectTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", classSubjectTable.ClassID);
            ViewBag.SubjectID = new SelectList(db.SubjectTables, "SubjectID", "Name", classSubjectTable.SubjectID);
            return View(classSubjectTable);
        }

        // GET: ClassSubjectTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSubjectTable classSubjectTable = db.ClassSubjectTables.Find(id);
            if (classSubjectTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", classSubjectTable.ClassID);
            ViewBag.SubjectID = new SelectList(db.SubjectTables, "SubjectID", "Name", classSubjectTable.SubjectID);
            return View(classSubjectTable);
        }

        // POST: ClassSubjectTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassSubjectID,ClassID,SubjectID,Name,IsActive")] ClassSubjectTable classSubjectTable)
        {
            if (ModelState.IsValid)
            {
                var classname = db.ClassTables.Where(s => s.ClassID == classSubjectTable.ClassID).SingleOrDefault();
                var subjectname = db.SubjectTables.Where(s => s.SubjectID == classSubjectTable.SubjectID).SingleOrDefault();
                if (classname != null)
                {
                    
                        var details = classname.Name + "-" + (subjectname != null ? subjectname.Name : "");
                        classSubjectTable.Name = details;
                    
                }
                db.Entry(classSubjectTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", classSubjectTable.ClassID);
            ViewBag.SubjectID = new SelectList(db.SubjectTables, "SubjectID", "Name", classSubjectTable.SubjectID);
            return View(classSubjectTable);
        }

        // GET: ClassSubjectTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSubjectTable classSubjectTable = db.ClassSubjectTables.Find(id);
            if (classSubjectTable == null)
            {
                return HttpNotFound();
            }
            return View(classSubjectTable);
        }

        // POST: ClassSubjectTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassSubjectTable classSubjectTable = db.ClassSubjectTables.Find(id);
            db.ClassSubjectTables.Remove(classSubjectTable);
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
