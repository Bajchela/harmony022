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
        private harmony022Model db = new harmony022Model();

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
            return View("Index");
        }

    }
}