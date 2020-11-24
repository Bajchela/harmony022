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
    public class tblVikendicaController : Controller
    {
        private Harmony022ModelEntities db = new Harmony022ModelEntities();

        // GET: tblVikendica
        public ActionResult Index()
        {
            return View(db.tblVikendica.ToList());
        }

        // GET: tblVikendica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVikendica tblVikendica = db.tblVikendica.Find(id);
            if (tblVikendica == null)
            {
                return HttpNotFound();
            }
            return View(tblVikendica);
        }

        // GET: tblVikendica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblVikendica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vikendica_Id,Sifra,Mesto,Lokacija,Povrsina_Placa,Kvadratura,Grejanje,Sobnost,Sprat,Terasa,Uknjizen,Slika,Vrsta_Nekretnine,Slajder,Opis,Drzava,PocetnaStrana,Cena")] tblVikendica tblVikendica)
        {
            if (ModelState.IsValid)
            {
                db.tblVikendica.Add(tblVikendica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblVikendica);
        }

        // GET: tblVikendica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVikendica tblVikendica = db.tblVikendica.Find(id);
            if (tblVikendica == null)
            {
                return HttpNotFound();
            }
            return View(tblVikendica);
        }

        // POST: tblVikendica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vikendica_Id,Sifra,Mesto,Lokacija,Povrsina_Placa,Kvadratura,Grejanje,Sobnost,Sprat,Terasa,Uknjizen,Slika,Vrsta_Nekretnine,Slajder,Opis,Drzava,PocetnaStrana,Cena")] tblVikendica tblVikendica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVikendica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblVikendica);
        }

        // GET: tblVikendica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVikendica tblVikendica = db.tblVikendica.Find(id);
            if (tblVikendica == null)
            {
                return HttpNotFound();
            }
            return View(tblVikendica);
        }

        // POST: tblVikendica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVikendica tblVikendica = db.tblVikendica.Find(id);
            db.tblVikendica.Remove(tblVikendica);
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
