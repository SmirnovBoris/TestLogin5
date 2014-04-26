using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestLogin5.Controllers
{
    public class ProblemController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Problem/

        public ActionResult Index()
        {
            return View(db.Problems.ToList());
        }

        //
        // GET: /Problem/Details/5

        public ActionResult Details(int id = 0)
        {
            Problems problems = db.Problems.Find(id);
            if (problems == null)
            {
                return HttpNotFound();
            }
            return View(problems);
        }

        //
        // GET: /Problem/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Problem/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Problems problems)
        {
            if (ModelState.IsValid)
            {
                db.Problems.Add(problems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(problems);
        }

        //
        // GET: /Problem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Problems problems = db.Problems.Find(id);
            if (problems == null)
            {
                return HttpNotFound();
            }
            return View(problems);
        }

        //
        // POST: /Problem/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Problems problems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(problems);
        }

        //
        // GET: /Problem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Problems problems = db.Problems.Find(id);
            if (problems == null)
            {
                return HttpNotFound();
            }
            return View(problems);
        }

        //
        // POST: /Problem/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Problems problems = db.Problems.Find(id);
            db.Problems.Remove(problems);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}