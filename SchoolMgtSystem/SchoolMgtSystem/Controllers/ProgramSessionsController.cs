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
    public class ProgramSessionsController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: ProgramSessions
        public ActionResult Index()
        {
            var programSessions = db.ProgramSessions.Include(p => p.ProgramTable).Include(p => p.SessionTable).Include(p => p.UserTable);
            return View(programSessions.ToList());
        }

        // GET: ProgramSessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramSession programSession = db.ProgramSessions.Find(id);
            if (programSession == null)
            {
                return HttpNotFound();
            }
            return View(programSession);
        }

        // GET: ProgramSessions/Create
        public ActionResult Create()
        {
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name");
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: ProgramSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProgramSession programSession)
        {
            programSession.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                var sessionname = db.SessionTables.Where(s => s.SessionID == programSession.SessionID).SingleOrDefault();
                var programname = db.ProgramTables.Where(s => s.ProgramID == programSession.ProgramID).SingleOrDefault();
                if (sessionname != null)
                {
                    if (!programSession.Title.Contains(sessionname.Name))
                    {
                        var details = "(" + sessionname.Name + "-" + (programname != null ? programname.Name : "") + ") " + programSession.Title;
                        programSession.Title = details;
                    }
                }

                db.ProgramSessions.Add(programSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", programSession.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", programSession.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programSession.UserID);
            return View(programSession);
        }

        // GET: ProgramSessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramSession programSession = db.ProgramSessions.Find(id);
            if (programSession == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", programSession.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", programSession.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programSession.UserID);
            return View(programSession);
        }

        // POST: ProgramSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProgramSession programSession)
        {
            programSession.UserID = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            if (ModelState.IsValid)
            {
                var sessionname = db.SessionTables.Where(s => s.SessionID == programSession.SessionID).SingleOrDefault();
                var programname = db.ProgramTables.Where(s => s.ProgramID == programSession.ProgramID).SingleOrDefault();
                if (sessionname != null)
                {
                    if (!programSession.Title.Contains(sessionname.Name))
                    {
                        var details = "(" + sessionname.Name + "-" + (programname != null? programname.Name : "") + ") " + programSession.Title;
                        programSession.Title = details;
                    }
                }
                

                db.Entry(programSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", programSession.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", programSession.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programSession.UserID);
            return View(programSession);
        }

        // GET: ProgramSessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramSession programSession = db.ProgramSessions.Find(id);
            if (programSession == null)
            {
                return HttpNotFound();
            }
            return View(programSession);
        }

        // POST: ProgramSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramSession programSession = db.ProgramSessions.Find(id);
            db.ProgramSessions.Remove(programSession);
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
