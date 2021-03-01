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
    public class tblKucasController : Controller
    {
        private Harmony022.Models.Harmony022ModelEntities db = new Harmony022.Models.Harmony022ModelEntities();

  

        // GET: tblKucas
        public ActionResult Index()
        {
            return View(db.tblKuca.ToList());
        }

        // GET: tblKucas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKuca tblKuca = db.tblKuca.Find(id);
            if (tblKuca == null)
            {
                return HttpNotFound();
            }
            return View(tblKuca);
        }

        // GET: tblKucas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblKucas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kuca_Id,Sifra,Mesto,Lokacija,Povrsina_Placa,Kvadratura,Grejanje,Sobnost,Sprat,Terasa,Uknjizen,Azuriran,Slika,Vrsta_Nekretnine,Slajder,Parking,Opis,Drzava,PocetnaStrana")] tblKuca tblKuca)
        {
            if (ModelState.IsValid)
            {
                db.tblKuca.Add(tblKuca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblKuca);
        }

        // GET: tblKucas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKuca tblKuca = db.tblKuca.Find(id);
            if (tblKuca == null)
            {
                return HttpNotFound();
            }
            return View(tblKuca);
        }

        // POST: tblKucas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kuca_Id,Sifra,Mesto,Cena,Lokacija,Povrsina_Placa,Kvadratura,Grejanje,Sobnost,Sprat,Terasa,Uknjizen,Azuriran,Slika,Vrsta_Nekretnine,Slajder,Parking,Opis,Drzava,PocetnaStrana")] tblKuca tblKuca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKuca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblKuca);
        }

        // GET: tblKucas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKuca tblKuca = db.tblKuca.Find(id);
            if (tblKuca == null)
            {
                return HttpNotFound();
            }
            return View(tblKuca);
        }

        // POST: tblKucas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblKuca tblKuca = db.tblKuca.Find(id);
            db.tblKuca.Remove(tblKuca);
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

        public ActionResult showRentHome(int kuca)
        {
            List<tblKuca> listPretraga = new List<tblKuca>();

            listPretraga = db.tblKuca.ToList();

            var saljiKucu = from c in listPretraga
                            where c.Kuca_Id == kuca
                            select c;
            return View("showHomeSellView", saljiKucu.ToList());
        }
        public ActionResult showSellHome(int kuca)
        {
            List<tblKuca> listPretraga = new List<tblKuca>();

            listPretraga = db.tblKuca.ToList();

            var saljiKucu = from c in listPretraga
                            where c.Kuca_Id == kuca
                            select c;
            return View("showHomeSellView", saljiKucu.ToList());
        }
    }
}
