using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Harmony022.Models;

namespace Harmony022.Controllers
{
    public class tblSlikeController : Controller
    {
        private Harmony022ModelEntities db = new Harmony022ModelEntities();

        // GET: tblSlike
        public ActionResult Index()
        {
            return View(db.tblSlike.ToList());
        }

        // GET: tblSlike/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSlike tblSlike = db.tblSlike.Find(id);
            if (tblSlike == null)
            {
                return HttpNotFound();
            }
            return View(tblSlike);
        }

        // GET: tblSlike/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblSlike/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "slikeId,nekretnina,sifra,referenca")] tblSlike tblSlike)
        {
            if (ModelState.IsValid)
            {
                db.tblSlike.Add(tblSlike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSlike);
        }

        // GET: tblSlike/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSlike tblSlike = db.tblSlike.Find(id);
            if (tblSlike == null)
            {
                return HttpNotFound();
            }
            return View(tblSlike);
        }

        // POST: tblSlike/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "slikeId,nekretnina,sifra,referenca")] tblSlike tblSlike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSlike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSlike);
        }

        // GET: tblSlike/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSlike tblSlike = db.tblSlike.Find(id);
            if (tblSlike == null)
            {
                return HttpNotFound();
            }
            return View(tblSlike);
        }

        // POST: tblSlike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSlike tblSlike = db.tblSlike.Find(id);
            db.tblSlike.Remove(tblSlike);
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
