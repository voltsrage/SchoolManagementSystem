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
    public class UserTypeTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: UserTypeTables
        [UserAuthorizationFilter]
        public ActionResult Index()
        {
            return View(db.UserTypeTables.ToList());
        }

        // GET: UserTypeTables/Details/5
        [UserAuthorizationFilter]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTypeTable userTypeTable = db.UserTypeTables.Find(id);
            if (userTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(userTypeTable);
        }

        // GET: UserTypeTables/Create
        [UserAuthorizationFilter]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTypeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult Create(UserTypeTable userTypeTable)
        {
            if (ModelState.IsValid)
            {
                db.UserTypeTables.Add(userTypeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userTypeTable);
        }

        // GET: UserTypeTables/Edit/5
        [UserAuthorizationFilter]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTypeTable userTypeTable = db.UserTypeTables.Find(id);
            if (userTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(userTypeTable);
        }

        // POST: UserTypeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult Edit( UserTypeTable userTypeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTypeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTypeTable);
        }

        // GET: UserTypeTables/Delete/5
        [UserAuthorizationFilter]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTypeTable userTypeTable = db.UserTypeTables.Find(id);
            if (userTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(userTypeTable);
        }

        // POST: UserTypeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTypeTable userTypeTable = db.UserTypeTables.Find(id);
            db.UserTypeTables.Remove(userTypeTable);
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
