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
    public class tblZemljistesController : Controller
    {
        private Harmony022ModelEntities db = new Harmony022ModelEntities();

        // GET: tblZemljistes
        public ActionResult Index()
        {
            return View(db.tblZemljiste.ToList());
        }

        // GET: tblZemljistes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblZemljiste tblZemljiste = db.tblZemljiste.Find(id);
            if (tblZemljiste == null)
            {
                return HttpNotFound();
            }
            return View(tblZemljiste);
        }

        // GET: tblZemljistes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblZemljistes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Zemljiste_Id,Sifra,Mesto,Lokacija,Povrsina,Sobnost,Uknjizen,Slika,Vrsta_Nekretnine,Slajder,Opis,Drzava,PocetnaStrana,Cena,Azuriran")] tblZemljiste tblZemljiste)
        {
            if (ModelState.IsValid)
            {
                db.tblZemljiste.Add(tblZemljiste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblZemljiste);
        }

        // GET: tblZemljistes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblZemljiste tblZemljiste = db.tblZemljiste.Find(id);
            if (tblZemljiste == null)
            {
                return HttpNotFound();
            }
            return View(tblZemljiste);
        }

        // POST: tblZemljistes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Zemljiste_Id,Sifra,Mesto,Lokacija,Povrsina,Sobnost,Uknjizen,Slika,Vrsta_Nekretnine,Slajder,Opis,Drzava,PocetnaStrana,Cena,Azuriran")] tblZemljiste tblZemljiste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblZemljiste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblZemljiste);
        }

        // GET: tblZemljistes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblZemljiste tblZemljiste = db.tblZemljiste.Find(id);
            if (tblZemljiste == null)
            {
                return HttpNotFound();
            }
            return View(tblZemljiste);
        }

        // POST: tblZemljistes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblZemljiste tblZemljiste = db.tblZemljiste.Find(id);
            db.tblZemljiste.Remove(tblZemljiste);
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
        public ActionResult prikaziNekretninuZemljisteRent(int zemlja)
        {
            List<tblZemljiste> listPretraga = new List<tblZemljiste>();

            listPretraga = db.tblZemljiste.ToList();

            var saljiZemljiste = from c in listPretraga
                            where c.Zemljiste_Id == zemlja
                            select c;
            return View("showLand", saljiZemljiste.ToList());
        }

        public ActionResult prikaziNekretninuZemljisteSell(int zemlja)
        {
            List<tblZemljiste> listPretraga = new List<tblZemljiste>();

            listPretraga = db.tblZemljiste.ToList();

            var saljiZemljiste = from c in listPretraga
                            where c.Zemljiste_Id == zemlja
                                 select c;
            return View("showLand", saljiZemljiste.ToList());
        }

    }
}
