using Harmony022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Harmony022.Controllers
{
    public class AdminController : Controller
    {
        private Harmony022.Models.Harmony022ModelEntities db = new Harmony022.Models.Harmony022ModelEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult prikaziGlavnuStranicu()
        {
            return View("AdminPanelIndex");
        }

        public ActionResult prikaziUnosNekretnine(string strDugme)
        {
            if(strDugme == "Stan")
            {
                return View("addAppartmanAdmin");
            }
            if(strDugme == "Kuca")
            {
                return View("addAHomeAdmin");
            }
            if (strDugme == "Vikendica")
            {               
                return View("addCottageAdmin");
            }
            if (strDugme == "PoslovniProstor")
            {
                return View("addBSAdmin");
            }
            
            return View("Index");
        }

        public ActionResult prikaziIzmenuNekretnine(string strDugme)
        {
            if (strDugme == "Stan")
            {
                List<tblStan> listPretraga = new List<tblStan>();
                listPretraga = db.tblStan.ToList();
                var pretrazeno = from c in listPretraga
                                 select c;
                return View("../tblStan/Index", pretrazeno.ToList());
            }
            if (strDugme == "Kuća")
            {
                List<tblKuca> listPretraga = new List<tblKuca>();
                listPretraga = db.tblKuca.ToList();
                var pretrazeno = from c in listPretraga
                                 select c;
                return View("../tblKucas/Index", pretrazeno.ToList());
            }
            if (strDugme == "Vikendica")
            {
                List<tblVikendica> listPretraga = new List<tblVikendica>();
                listPretraga = db.tblVikendica.ToList();
                var pretrazeno = from c in listPretraga
                                 select c;
                return View("../tblVikendica/Index", pretrazeno.ToList());
            }
            if (strDugme == "PoslovniProstor")
            {
                List<tblPoslovniProstor> listPretraga = new List<tblPoslovniProstor>();
                listPretraga = db.tblPoslovniProstor.ToList();
                var pretrazeno = from c in listPretraga
                                 select c;
                return View("../tblPoslovniProstor/Index", pretrazeno.ToList());
            }
            if (strDugme == "Zemljiste")
            {
                List<tblZemljiste> listPretraga = new List<tblZemljiste>();
                listPretraga = db.tblZemljiste.ToList();
                var pretrazeno = from c in listPretraga
                                 select c;
                return View("../tblZemljistes/Index", pretrazeno.ToList());
            }

            if (strDugme == "Građevinskozemljište")
            {
                List<tblGradjevinskoZemljiste> listPretraga = new List<tblGradjevinskoZemljiste>();
                listPretraga = db.tblGradjevinskoZemljiste.ToList();
                var pretrazeno = from c in listPretraga
                                 select c;
                return View("../tblGradjevinskoZemljistes/Index", pretrazeno.ToList());
            }

            if (strDugme == "Slike")
            {
                List<tblSlike> listPretraga = new List<tblSlike>();
                listPretraga = db.tblSlike.ToList();
                var pretrazeno = from c in listPretraga
                                 select c;
                return View("../tblSlike/Index", pretrazeno.ToList());
            }

            if (strDugme == "Slike")
            {
                List<tblSlike> listPretraga = new List<tblSlike>();
                listPretraga = db.tblSlike.ToList();
                var pretrazeno = from c in listPretraga
                                 select c;
                return View("../tblSlike/Index", pretrazeno.ToList());
            }

            return View("Index");
        }

        public ActionResult prikaziPoPretraziSlike(string sifra)
        {

            List<tblSlike> listPretraga = new List<tblSlike>();
            listPretraga = db.tblSlike.ToList();
            var pretrazeno = from c in listPretraga
                             where c.sifra == sifra
                             select c;
            return View("../tblSlike/Index", pretrazeno.ToList());
        }
        public ActionResult prikaziPoPretraziGradjevinskogZemljista(string sifra)
        {

            List<tblGradjevinskoZemljiste> listPretraga = new List<tblGradjevinskoZemljiste>();
            listPretraga = db.tblGradjevinskoZemljiste.ToList();
            var pretrazeno = from c in listPretraga
                             where c.Sifra == sifra
                             select c;
            return View("../tblGradjevinskoZemljistes/Index", pretrazeno.ToList());
        }
        public ActionResult prikaziPoPretraziZemljiste(string sifra)
        {

            List<tblZemljiste> listPretraga = new List<tblZemljiste>();
            listPretraga = db.tblZemljiste.ToList();
            var pretrazeno = from c in listPretraga
                             where c.Sifra == sifra
                             select c;
            return View("../tblZemljistes/Index", pretrazeno.ToList());
        }
        public ActionResult prikaziPoPretraziStan(string sifra)
        {

            List<tblStan> listPretraga = new List<tblStan>();
            listPretraga = db.tblStan.ToList();
            var pretrazeno = from c in listPretraga
                             where c.Sifra == sifra
                             select c;
            return View("../tblStan/Index", pretrazeno.ToList());
        }
        public ActionResult prikaziPoPretraziKucu(string sifra)
        {

            List<tblKuca> listPretraga = new List<tblKuca>();
            listPretraga = db.tblKuca.ToList();
            var pretrazeno = from c in listPretraga
                             where c.Sifra == sifra
                             select c;
            return View("../tblKucas/Index", pretrazeno.ToList());
        }
        public ActionResult prikaziPoPretraziPP(string sifra)
        {

            List<tblPoslovniProstor> listPretraga = new List<tblPoslovniProstor>();
            listPretraga = db.tblPoslovniProstor.ToList();
            var pretrazeno = from c in listPretraga
                             where c.Sifra == sifra
                             select c;
            return View("../tblPoslovniProstor/Index", pretrazeno.ToList());
        }
        public ActionResult prikaziPoPretraziVikendicu(string sifra)
        {

            List<tblVikendica> listPretraga = new List<tblVikendica>();
            listPretraga = db.tblVikendica.ToList();
            var pretrazeno = from c in listPretraga
                             where c.Sifra == sifra
                             select c;
            return View("../tblVikendica/Index", pretrazeno.ToList());
        }
    }
}