using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Harmony022.Models;
using PagedList.Mvc;
using PagedList;
namespace Harmony022.Controllers
{
    public class vidiNekretnineController : Controller
    {
        private Harmony022.Models.Harmony022ModelEntities db = new Harmony022.Models.Harmony022ModelEntities();

        // GET: vidiNekretnine
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult prikaziStanove(int? page)
        {
            List<tblStan> listaStanova = new List<tblStan>();

            var listStan = db.tblStan.ToList();
          
                var pretrazeno = from c in listStan
                                 where c.Vrsta_Nekretnine == "Prodaja"
                                 orderby c.Cena descending
                                 select c;
                return View("sellApartmans", pretrazeno.ToList());                      
        }

        public ActionResult prikaziStanoveRenta(int? page = 1)
        {
            List<tblStan> listaStanova = new List<tblStan>();

            var listStan = db.tblStan.ToList();

            var pretrazeno = from c in listStan
                             where c.Vrsta_Nekretnine == "Izdavanje"
                             orderby c.Cena descending
                             select c;

            return View("rentApartmans", pretrazeno.ToList().ToPagedList(page ?? 5, 8));
        }
        public ActionResult prikaziStanoveProdaja(int? page=1)
        {
            List<tblStan> listaStanova = new List<tblStan>();

            var listStan = db.tblStan.ToList();

            var pretrazeno = from c in listStan
                             where c.Vrsta_Nekretnine == "Prodaja"
                             orderby c.Cena descending
                             select c;

            return View("sellApartmans", pretrazeno.ToList().ToPagedList(page ?? 5, 8));
        }

        public ActionResult showHomeSell(int? page = 1)
        {
            List<tblKuca> listaKuca = new List<tblKuca>();

            var listHome = db.tblKuca.ToList();

            var pretrazeno = from c in listHome
                             where c.Vrsta_Nekretnine == "Prodaja"
                             orderby c.Cena descending
                             select c;

            return View("sellHome", pretrazeno.ToList().ToPagedList(page ?? 5, 8));
        }

        public ActionResult showHomeRent(int? page = 1)
        {
            List<tblKuca> listaHome = new List<tblKuca>();

            var listHome = db.tblKuca.ToList();

            var pretrazeno = from c in listHome
                             where c.Vrsta_Nekretnine == "Izdavanje"
                             orderby c.Cena descending
                             select c;

            return View("rentHome", pretrazeno.ToList().ToPagedList(page ?? 5, 8));
        }


        public ActionResult showCottageSell(int? page = 1)
        {
            List<tblVikendica> listaKuca = new List<tblVikendica>();

            var listHome = db.tblVikendica.ToList();

            var pretrazeno = from c in listHome
                             where c.Vrsta_Nekretnine == "Prodaja"
                             orderby c.Cena descending
                             select c;

            return View("sellCottage", pretrazeno.ToList().ToPagedList(page ?? 5, 8));
        }
        public ActionResult showCottageRent(int? page = 1)
        {
            List<tblVikendica> listaKuca = new List<tblVikendica>();

            var listHome = db.tblVikendica.ToList();

            var pretrazeno = from c in listHome
                             where c.Vrsta_Nekretnine == "Izdavanje"
                             orderby c.Cena descending
                             select c;

            return View("rentCottage", pretrazeno.ToList().ToPagedList(page ?? 5, 8));
        }

        public ActionResult showBSSell(int? page = 1)
        {
            List<tblPoslovniProstor> listaPoslovnIProstor = new List<tblPoslovniProstor>();

            var listBS = db.tblPoslovniProstor.ToList();

            var pretrazeno = from c in listBS
                             where c.Vrsta_Nekretnine == "Prodaja"
                             orderby c.Cena descending
                             select c;

            return View("sellBS", pretrazeno.ToList().ToPagedList(page ?? 5, 8));
        }
        public ActionResult showBSRent(int? page = 1)
        {
            List<tblPoslovniProstor> listaPoslovnIProstor = new List<tblPoslovniProstor>();

            var listBS = db.tblPoslovniProstor.ToList();

            var pretrazeno = from c in listBS
                             where c.Vrsta_Nekretnine == "Izdavanje"
                             orderby c.Cena descending
                             select c;

            return View("rentBS", pretrazeno.ToList().ToPagedList(page ?? 5, 8));
        }

    }

}