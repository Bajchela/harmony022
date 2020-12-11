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
    public class tblPoslovniProstorController : Controller
    {
        private Harmony022ModelEntities db = new Harmony022ModelEntities();

        // GET: tblPoslovniProstor
        public ActionResult Index()
        {
            return View(db.tblPoslovniProstor.ToList());
        }

        // GET: tblPoslovniProstor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPoslovniProstor tblPoslovniProstor = db.tblPoslovniProstor.Find(id);
            if (tblPoslovniProstor == null)
            {
                return HttpNotFound();
            }
            return View(tblPoslovniProstor);
        }

        // GET: tblPoslovniProstor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblPoslovniProstor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoslovniProstor_Id,Sifra,Mesto,Lokacija,Kvadratura,Grejanje,Sobnost,Sprat,Uknjizen,Slika,Vrsta_Nekretnine,Slajder,Opis,Drzava,PocetnaStrana,Cena,Azuriran")] tblPoslovniProstor tblPoslovniProstor)
        {
            if (ModelState.IsValid)
            {
                db.tblPoslovniProstor.Add(tblPoslovniProstor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPoslovniProstor);
        }

        // GET: tblPoslovniProstor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPoslovniProstor tblPoslovniProstor = db.tblPoslovniProstor.Find(id);
            if (tblPoslovniProstor == null)
            {
                return HttpNotFound();
            }
            return View(tblPoslovniProstor);
        }

        // POST: tblPoslovniProstor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoslovniProstor_Id,Sifra,Mesto,Lokacija,Kvadratura,Grejanje,Sobnost,Sprat,Uknjizen,Slika,Vrsta_Nekretnine,Slajder,Opis,Drzava,PocetnaStrana,Cena,Azuriran")] tblPoslovniProstor tblPoslovniProstor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPoslovniProstor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPoslovniProstor);
        }

        // GET: tblPoslovniProstor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPoslovniProstor tblPoslovniProstor = db.tblPoslovniProstor.Find(id);
            if (tblPoslovniProstor == null)
            {
                return HttpNotFound();
            }
            return View(tblPoslovniProstor);
        }

        // POST: tblPoslovniProstor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPoslovniProstor tblPoslovniProstor = db.tblPoslovniProstor.Find(id);
            db.tblPoslovniProstor.Remove(tblPoslovniProstor);
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
        public ActionResult prikaziNekretninuPoslovniProstor(int BS)
        {
            List<tblPoslovniProstor> listPretraga = new List<tblPoslovniProstor>();

            listPretraga = db.tblPoslovniProstor.ToList();

            var saljiBS = from c in listPretraga
                          where c.PoslovniProstor_Id == BS
                          select c;
            return View("showBSrent", saljiBS.ToList());
        }

        public ActionResult prikaziNekretninuPoslovniProstorProdaja(int BS)
        {
            List<tblPoslovniProstor> listPretraga = new List<tblPoslovniProstor>();

            listPretraga = db.tblPoslovniProstor.ToList();

            var saljiBS = from c in listPretraga
                          where c.PoslovniProstor_Id == BS
                          select c;
            return View("showBSsell", saljiBS.ToList());
        }

    }
}
