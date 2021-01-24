using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Harmony022.Models;
using System.Net.Mail;
using System.IO;
using System.Net;

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


        public ActionResult PosaljiMail(string Ime, string Email, string Sifra, string Poruka)
        {
            //strFajl = strAttFajl;
            //strFolder = strAttFolder;
            string strFromMail = "harmony022beska@gmail.com";
            string strToMail = "bajchela@gmail.com";
            string strSmtpserver = "smtp.gmail.com";
            string strPass = "harmonybeska022";
            string strSubject = "Poruka sa sajta";
            bool blssl = true;
            string strPort = "587";



            var client = new SmtpClient("smtp.gmail.com", 587)
            {
               UseDefaultCredentials = true,
              Credentials = new NetworkCredential("harmony022beska@gmail.com", "harmonybeska022"),
                EnableSsl = true
            };
            client.Send("harmony022beska@gmail.com", "harmony022beska@gmail.com", "Poruka sa sajta " + "Sifra: " + Sifra,"Poruku salje korisnikom sa mejlom "+ Email+ " \n"  + Poruka);


            return View("Index");
        }
        }

    }
