using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Harmony022.Models;

namespace Harmony022.Controllers
{
    public class HomeController : Controller
    {
        private Harmony022.Models.Harmony022ModelEntities db = new Harmony022.Models.Harmony022ModelEntities();

        public ActionResult prikaziONamaStranicu()
        {
            return View("ONama");
        }
        public ActionResult prikaziGeometarStranicu()
        {
            return View("Geometar");
        }
        public ActionResult prikaziProjektantStranicu()
        {
            return View("Projektant");
        }

        public ActionResult PrikaziSlajder()
        {
                      
            List<prikaziPretragaHarmony> listPretraga = new List<prikaziPretragaHarmony>();
            
                listPretraga = db.prikaziPretragaHarmony.ToList();
                var pretrazeno = from c in listPretraga
                                 where c.Slajder == true
                                 select c;
                return PartialView("slajderHomeView", pretrazeno.ToList());
  
        }

            public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}