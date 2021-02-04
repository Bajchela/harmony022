﻿using Harmony022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Harmony.Controllers
{
    public class PretraziController : Controller
    {

        private Harmony022.Models.Harmony022ModelEntities db = new Harmony022.Models.Harmony022ModelEntities();
        // GET: Pretraga
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public ActionResult prikaziSortiranjeKuce(string Sort)
        {
            List<tblKuca> listPretraga = new List<tblKuca>();

            listPretraga = db.tblKuca.ToList();

            var pretrazeno = from c in listPretraga                      
                             select c;

            if (Sort == "Cena rastuća")
            {
                var pretrazenoCenaRastuca = db.tblKuca.ToList();

                var pretrazenoCA = from c in pretrazenoCenaRastuca
                                   orderby c.Cena ascending
                                   select c;

                return View("sellHome", pretrazeno.ToList());
            }
            else if (Sort == "Cena opadajuća")
            {
                var pretrazenoCenaOpadajuca = db.tblKuca.ToList();

                var pretrazenoCD = from c in pretrazenoCenaOpadajuca
                                   orderby c.Cena descending
                                   select c;

                return View("sellHome", pretrazeno.ToList());
            }
            else if (Sort == "Šifri rastućoj")
            {
                var pretrazenoSifraRastuca= db.tblKuca.ToList();

                var pretrazenoSR = from c in pretrazenoSifraRastuca
                                   orderby c.Sifra ascending
                                   select c;

                return View("sellHome", pretrazeno.ToList());
            }
            else if (Sort == "Šifri opadajućoj")
            {
                var pretrazenoSifraOpadajuca = db.tblKuca.ToList();

                var pretrazenoSO = from c in listPretraga
                                   orderby c.Sifra descending
                                   select c;

                return View("sellHome", pretrazeno.ToList());
            }


            return View("sellHome", pretrazeno.ToList());
        }


        [HttpPost]

        public ActionResult showSearch(string sort, string Mesto, string VrstaLokacije,string TipLokacije, int? txtCenaOd, int? txtCenaDo , int? txtKvadraturaDo, int? txtKvadraturaOd)
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

                if (sort == "opadajućoj ceni")
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
                else if (sort == "rastućoj ceni")
                {
                    listPretraga = db.prikaziPretragaHarmony.ToList();
                    var pretrazeno = from c in listPretraga
                                     where c.Vrsta_Nekretnine == TipLokacije &&
                                           c.Cena > txtCenaOd &&
                                           c.Cena <= txtCenaDo &&
                                           c.Kvadratura > txtKvadraturaOd &&
                                           c.Kvadratura <= txtKvadraturaDo
                                     orderby c.Cena ascending
                                     select c;

                    return View("pretragaView", pretrazeno.ToList());
                }
                else if (sort == "rastućoj kvadraturi")
                {
                    listPretraga = db.prikaziPretragaHarmony.ToList();
                    var pretrazeno = from c in listPretraga
                                     where c.Vrsta_Nekretnine == TipLokacije &&
                                           c.Cena > txtCenaOd &&
                                           c.Cena <= txtCenaDo &&
                                           c.Kvadratura > txtKvadraturaOd &&
                                           c.Kvadratura <= txtKvadraturaDo
                                     orderby c.Kvadratura descending
                                     select c;

                    return View("pretragaView", pretrazeno.ToList());
                }
                else if (sort == "opadajućoj kvadraturi")
                {
                    listPretraga = db.prikaziPretragaHarmony.ToList();
                    var pretrazeno = from c in listPretraga
                                     where c.Vrsta_Nekretnine == TipLokacije &&
                                           c.Cena > txtCenaOd &&
                                           c.Cena <= txtCenaDo &&
                                           c.Kvadratura > txtKvadraturaOd &&
                                           c.Kvadratura <= txtKvadraturaDo
                                     orderby c.Kvadratura descending
                                     select c;

                    return View("pretragaView", pretrazeno.ToList());
                }
                return View("pretragaView");

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
        [HttpPost]
        public ActionResult showSearchSort(string Sort, string Mesto, string VrstaLokacije, string TipLokacije, int? txtCenaOd, int? txtCenaDo, int? txtKvadraturaDo, int? txtKvadraturaOd)
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

                if (Sort == "opadajućoj ceni")
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
                else if (Sort == "rastuća cena")
                {
                    listPretraga = db.prikaziPretragaHarmony.ToList();
                    var pretrazeno = from c in listPretraga
                                     where c.Vrsta_Nekretnine == TipLokacije &&
                                           c.Cena > txtCenaOd &&
                                           c.Cena <= txtCenaDo &&
                                           c.Kvadratura > txtKvadraturaOd &&
                                           c.Kvadratura <= txtKvadraturaDo
                                     orderby c.Cena ascending
                                     select c;
                    return View("pretragaView", pretrazeno.ToList());
                }
                else if (Sort == "rastuća kvadratura")
                {
                    listPretraga = db.prikaziPretragaHarmony.ToList();
                    var pretrazeno = from c in listPretraga
                                     where c.Vrsta_Nekretnine == TipLokacije &&
                                           c.Cena > txtCenaOd &&
                                           c.Cena <= txtCenaDo &&
                                           c.Kvadratura > txtKvadraturaOd &&
                                           c.Kvadratura <= txtKvadraturaDo
                                     orderby c.Kvadratura ascending
                                     select c;
                    return View("pretragaView", pretrazeno.ToList());
                }
                else if (Sort == "opadajuća kvadratura")
                {
                    listPretraga = db.prikaziPretragaHarmony.ToList();
                    var pretrazeno = from c in listPretraga
                                     where c.Vrsta_Nekretnine == TipLokacije &&
                                           c.Cena > txtCenaOd &&
                                           c.Cena <= txtCenaDo &&
                                           c.Kvadratura > txtKvadraturaOd &&
                                           c.Kvadratura <= txtKvadraturaDo
                                     orderby c.Kvadratura descending
                                     select c;
                    return View("pretragaView", pretrazeno.ToList());
                }
            }
            else
            {
                if (Sort == "opadajućoj ceni")
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
                else if (Sort == "rastućoj ceni")
                {
                    listPretraga = db.prikaziPretragaHarmony.ToList();
                    var pretrazeno = from c in listPretraga

                                     where c.Mesto == Mesto &&
                                           c.Vrsta_Nekretnine == TipLokacije &&
                                           c.Cena > txtCenaOd &&
                                           c.Cena < txtCenaDo &&
                                           c.Kvadratura > txtKvadraturaOd &&
                                           c.Kvadratura < txtKvadraturaDo
                                     orderby c.Cena ascending
                                     select c;

                    return View("pretragaView", pretrazeno.ToList());
                }
                else if (Sort == "rastućoj kvadraturi")
                {
                    listPretraga = db.prikaziPretragaHarmony.ToList();
                    var pretrazeno = from c in listPretraga

                                     where c.Mesto == Mesto &&
                                           c.Vrsta_Nekretnine == TipLokacije &&
                                           c.Cena > txtCenaOd &&
                                           c.Cena < txtCenaDo &&
                                           c.Kvadratura > txtKvadraturaOd &&
                                           c.Kvadratura < txtKvadraturaDo
                                     orderby c.Kvadratura ascending
                                     select c;

                    return View("pretragaView", pretrazeno.ToList());
                }
                else if (Sort == "opadaćujoj kvadraturi")
                {
                    listPretraga = db.prikaziPretragaHarmony.ToList();
                    var pretrazeno = from c in listPretraga

                                     where c.Mesto == Mesto &&
                                           c.Vrsta_Nekretnine == TipLokacije &&
                                           c.Cena > txtCenaOd &&
                                           c.Cena < txtCenaDo &&
                                           c.Kvadratura > txtKvadraturaOd &&
                                           c.Kvadratura < txtKvadraturaDo
                                     orderby c.Kvadratura descending
                                     select c;

                    return View("pretragaView", pretrazeno.ToList());
                }
            }
            return View("pretragaView");
        }
    }
} 