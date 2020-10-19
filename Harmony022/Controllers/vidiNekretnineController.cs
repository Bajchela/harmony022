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
        private harmony022Model db = new harmony022Model();

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
    }

}