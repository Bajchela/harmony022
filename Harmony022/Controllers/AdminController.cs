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
                return View("../tblStan/AppartmansView", pretrazeno.ToList());
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
            return View("Index");
        }

    }
}