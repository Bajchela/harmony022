using Harmony022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Harmony.Controllers
{
    public class PretraziController : Controller
    {

        private harmony022Model db = new harmony022Model();
        // GET: Pretraga
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult showSearch(string Mesto, string VrstaLokacije,string TipLokacije, int? txtCenaOd, int? txtCenaDo , int? txtKvadraturaDo, int? txtKvadraturaOd)
        {
            List<prikaziPretragaHarmony> listPretraga = new List<prikaziPretragaHarmony>();
           
            if (txtCenaOd == null)
            {
                txtCenaOd = 0;
            }
            if (txtCenaDo == null)
            {
                listPretraga = db.prikaziPretragaHarmony.ToList();
                txtCenaDo = listPretraga.Select(x => x.Cena).Max();              
            }
            if (txtKvadraturaDo == null)
            {
                listPretraga = db.prikaziPretragaHarmony.ToList();
                txtKvadraturaDo = listPretraga.Select(x => x.Kvadratura).Max();                            
            }

            if (txtKvadraturaOd == null)
            {
                txtKvadraturaOd = 0;
            }

            if (Mesto == "Sve")
            {

                listPretraga = db.prikaziPretragaHarmony.ToList();
                var pretrazeno = from c in listPretraga
                                 where c.Vrsta_Nekretnine == TipLokacije &&
                                       c.Cena > txtCenaOd &&
                                       c.Cena <= txtCenaDo &&
                                       c.Kvadratura > txtKvadraturaOd &&
                                       c.Kvadratura <= txtKvadraturaDo
                                 orderby c.Cena descending
                                 select c;

                return View("pretragaView", pretrazeno.ToList());
            }
            else
            {
                listPretraga = db.prikaziPretragaHarmony.ToList();
                var pretrazeno = from c in listPretraga

                                 where c.Mesto == Mesto &&
                                       c.Vrsta_Nekretnine == TipLokacije &&
                                       c.Cena > txtCenaOd &&
                                       c.Cena < txtCenaDo &&
                                       c.Kvadratura > txtKvadraturaOd &&
                                       c.Kvadratura < txtKvadraturaDo
                                 orderby c.Cena descending
                                 select c;

                return View("pretragaView", pretrazeno.ToList());
            }
        }
    }
}