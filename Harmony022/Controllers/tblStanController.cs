using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Harmony022.Models;

namespace Harmony022.Controllers
{
    public class tblStanController : Controller
    {
        private Harmony022.Models.Harmony022ModelEntities db = new Harmony022.Models.Harmony022ModelEntities();

        // GET: tblStan
        public ActionResult Index()
        {
            return View(db.tblStan.ToList());
        }

        // GET: tblStan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStan tblStan = db.tblStan.Find(id);
            if (tblStan == null)
            {
                return HttpNotFound();
            }
            return View(tblStan);
        }

        // GET: tblStan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblStan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stan_Id,Sifra,Mesto,Lokacija,Povrsina_Placa,Kvadratura,Grejanje,Sobnost,Sprat,Terasa,Uknjizen,Cena,Azuriran,Slika,Vrsta_Nekretnine,Drzava,Slajder")] tblStan tblStan)
        {
            if (ModelState.IsValid)
            {
                tblStan.Slika = "Content/" + tblStan.Slika.ToString();
                db.tblStan.Add(tblStan);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblStan);
        }

        // GET: tblStan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStan tblStan = db.tblStan.Find(id);
            if (tblStan == null)
            {
                return HttpNotFound();
            }
            return View(tblStan);
        }

        // POST: tblStan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stan_Id,Sifra,Mesto,Lokacija,Povrsina_Placa,Kvadratura,Grejanje,Sobnost,Sprat,Terasa,UUknjizen,Cena,Azuriran,Slika,Vrsta_Nekretnine,Drzava,Slajder,Opis")] tblStan tblStan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblStan);
        }

        // GET: tblStan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStan tblStan = db.tblStan.Find(id);
            if (tblStan == null)
            {
                return HttpNotFound();
            }
            return View(tblStan);
        }

        // POST: tblStan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStan tblStan = db.tblStan.Find(id);

            tblSlike slike = new tblSlike();

            db.tblSlike.RemoveRange(db.tblSlike.Where(x => x.sifra== tblStan.Sifra));
            db.SaveChanges();

            db.tblStan.Remove(tblStan);
            db.SaveChanges();

            System.IO.DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Content/Nekretnine/StanoviProdaja/" + tblStan.Sifra.ToString()));

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            bool exists = System.IO.Directory.Exists(Server.MapPath("~/Content/Nekretnine/StanoviProdaja/" + tblStan.Sifra.ToString()));

            if (exists)
                Directory.Delete(Server.MapPath(@"~/Content/Nekretnine/StanoviProdaja/" + tblStan.Sifra.ToString()));

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

        public ActionResult prikaziNekretninuStan(int stan)
        {
            List<tblStan> listPretraga = new List<tblStan>();

            listPretraga = db.tblStan.ToList();

            var saljiStan = from c in listPretraga
                            where c.Stan_Id == stan
                            select c;
            return View("prikaziStanIzdavanje", saljiStan.ToList());
        }

        public ActionResult prikaziNekretninuStanProdaja(int stan)
        {
            List<tblStan> listPretraga = new List<tblStan>();

            listPretraga = db.tblStan.ToList();

            var saljiStan = from c in listPretraga
                            where c.Stan_Id == stan
                            select c;
            return View("prikaziStanProdaja", saljiStan.ToList());
        }
    }
}
