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
    public class tblGradjevinskoZemljistesController : Controller
    {
        private Harmony022ModelEntities db = new Harmony022ModelEntities();

        // GET: tblGradjevinskoZemljistes
        public ActionResult Index()
        {
            return View(db.tblGradjevinskoZemljiste.ToList());
        }

        // GET: tblGradjevinskoZemljistes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGradjevinskoZemljiste tblGradjevinskoZemljiste = db.tblGradjevinskoZemljiste.Find(id);
            if (tblGradjevinskoZemljiste == null)
            {
                return HttpNotFound();
            }
            return View(tblGradjevinskoZemljiste);
        }

        // GET: tblGradjevinskoZemljistes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblGradjevinskoZemljistes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gradj_Id,Povrsina,Cena,Opis,Uknjizen,Slajder,PocetnaStrana,Azuriran,Vrsta_Nekretnine,Mesto,Lokacija")] tblGradjevinskoZemljiste tblGradjevinskoZemljiste)
        {
            if (ModelState.IsValid)
            {
                db.tblGradjevinskoZemljiste.Add(tblGradjevinskoZemljiste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblGradjevinskoZemljiste);
        }

        // GET: tblGradjevinskoZemljistes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGradjevinskoZemljiste tblGradjevinskoZemljiste = db.tblGradjevinskoZemljiste.Find(id);
            if (tblGradjevinskoZemljiste == null)
            {
                return HttpNotFound();
            }
            return View(tblGradjevinskoZemljiste);
        }

        // POST: tblGradjevinskoZemljistes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gradj_Id,Povrsina,Cena,Opis,Uknjizen,Slajder,PocetnaStrana,Azuriran,Vrsta_Nekretnine,Mesto,Lokacija")] tblGradjevinskoZemljiste tblGradjevinskoZemljiste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGradjevinskoZemljiste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblGradjevinskoZemljiste);
        }

        // GET: tblGradjevinskoZemljistes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGradjevinskoZemljiste tblGradjevinskoZemljiste = db.tblGradjevinskoZemljiste.Find(id);
            if (tblGradjevinskoZemljiste == null)
            {
                return HttpNotFound();
            }
            return View(tblGradjevinskoZemljiste);
        }

        // POST: tblGradjevinskoZemljistes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblGradjevinskoZemljiste tblGradjevinskoZemljiste = db.tblGradjevinskoZemljiste.Find(id);
            db.tblGradjevinskoZemljiste.Remove(tblGradjevinskoZemljiste);
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
        public ActionResult prikaziNekretninuGradjZemljisteRent(int zemlja)
        {
            List<tblGradjevinskoZemljiste> listPretraga = new List<tblGradjevinskoZemljiste>();

            listPretraga = db.tblGradjevinskoZemljiste.ToList();

            var saljiZemljiste = from c in listPretraga
                                 where c.Gradj_Id == zemlja
                                 select c;
            return View("showConstructionLand", saljiZemljiste.ToList());
        }

        public ActionResult prikaziNekretninuGradjZemljisteSell(int zemlja)
        {
            List<tblGradjevinskoZemljiste> listPretraga = new List<tblGradjevinskoZemljiste>();

            listPretraga = db.tblGradjevinskoZemljiste.ToList();

            var saljiZemljiste = from c in listPretraga
                                 where c.Gradj_Id == zemlja
                                 select c;
            return View("showConstructionLand", saljiZemljiste.ToList());
        }
    }
}
