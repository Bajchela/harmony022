using Harmony022.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Harmony022.Controllers
{
    public class UploadFilesController : Controller


    {
        private Harmony022.Models.Harmony022ModelEntities db = new Harmony022.Models.Harmony022ModelEntities();

        // GET: UploadFiles
        public ActionResult Index()
        {
            return View();
        }

        #region prodajaStanova

        [HttpPost]
        public ActionResult DodajStan(HttpPostedFileBase file)
            {
            tblStan tabelaStan = new tblStan();

            try
            {
                if (file.ContentLength > 0)
                {

                    string filename = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString()), filename);

                    

                    bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("~/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString()));

                    if (!exists)
                        System.IO.Directory.CreateDirectory(HttpContext.Server.MapPath("~/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString()));

                    tabelaStan.Vrsta_Nekretnine = Request.Form["VrstaNekretnine"];
                    tabelaStan.Sifra = Request.Form["Šifra"];
                    tabelaStan.Mesto = Request.Form["Mesto"];
                    tabelaStan.Lokacija = Request.Form["Lokacija"];
                    tabelaStan.Sobnost = Request.Form["Sobnost"];
                    tabelaStan.Sprat = Request.Form["Sprat"];
                    tabelaStan.Kvadratura = int.Parse(Request.Form["Kvadratura"].ToString());
                    tabelaStan.Uknjizen = Request.Form["Uknjižen"];
                    tabelaStan.Grejanje = Request.Form["Grejanje"];
                    tabelaStan.Terasa = Request.Form["Terasa"];
                    tabelaStan.Parking = Request.Form["Parking"];
                    tabelaStan.Cena = int.Parse(Request.Form["Cena"].ToString());
                    tabelaStan.Azuriran = DateTime.Parse(Request.Form["Ažurirano"].ToString());
                    tabelaStan.Drzava = Request.Form["Drzava"];
                    if (Request.Form["Slajder"].ToString() == "DA" || Request.Form["Slajder"].ToString() == "da")
                    {
                        tabelaStan.Slajder = true;

                    }
                    else
                    {
                        tabelaStan.Slajder = false;
                    }
                    tabelaStan.Slika = "/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString()+ "/" + filename;
                    db.tblStan.Add(tabelaStan);

                    db.SaveChanges();
                    file.SaveAs(filePath);

                }
                ViewBag.Mesasage = "Uploaded files Saved successfully in a folder !";
                return View("../tblStan/Details",tabelaStan);
            }
            catch(Exception e1)
            {
                string strGlupopst = e1.ToString();
                ViewBag.Mesasage = "Uploaded files Saved unsuccessfully in a folder !";
                return View("../tblStan/Index");
            }
            
        }

        public ActionResult DodajSlikeStana(HttpPostedFileBase[] files)
        {
            tblSlike slikeStana = new tblSlike();
            //Ensure model state is valid  
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {

                    //Checking file is available to save.  
                    if (file != null)
                    {
                        string pathString = Server.MapPath("/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString());

                        bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString()));

                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                        }
                        var InputFileName = Path.GetFileName(file.FileName);

                        var ServerSavePath = Path.Combine(Server.MapPath("/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString()), InputFileName);
                        //Save file to server folder  
                        slikeStana.sifra = Request.Form["Šifra"].ToString();
                        slikeStana.referenca = "/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString() +"/" + InputFileName;
                        file.SaveAs(ServerSavePath);

                        try
                        {
                            db.tblSlike.Add(slikeStana);
                            db.SaveChanges();

                        }
                        catch (Exception e1)
                        {
                            Console.WriteLine(e1.ToString());
                        }
                        
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                    }

                }
            }
            return View("../tblStan/Index", db.tblStan);
        }
        #endregion

        #region prodajaKuce
        [HttpPost]
        public ActionResult dodajKucu(HttpPostedFileBase file)
        {
            tblKuca tableHome = new tblKuca();

            try
            {
                if (file.ContentLength > 0)
                {

                    string filename = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/Nekretnine/KuceProdaja/" + Request.Form["Šifra"].ToString()), filename);



                    bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("~/Content/Nekretnine/KuceProdaja/" + Request.Form["Šifra"].ToString()));

                    if (!exists)
                        System.IO.Directory.CreateDirectory(HttpContext.Server.MapPath("~/Content/Nekretnine/KuceProdaja/" + Request.Form["Šifra"].ToString()));

                    tableHome.Vrsta_Nekretnine = Request.Form["VrstaNekretnine"];
                    tableHome.Sifra = Request.Form["Šifra"];
                    tableHome.Mesto = Request.Form["Mesto"];
                    tableHome.Lokacija = Request.Form["Lokacija"];
                    tableHome.Sobnost = Request.Form["Sobnost"];
                    tableHome.Sprat = Request.Form["Sprat"];
                    tableHome.Kvadratura = int.Parse(Request.Form["Kvadratura"].ToString());
                    tableHome.Uknjizen = Request.Form["Uknjižen"];
                    tableHome.Grejanje = Request.Form["Grejanje"];
                    tableHome.Terasa = Request.Form["Terasa"];
                    tableHome.Parking = Request.Form["Parking"];
                    tableHome.Cena = int.Parse(Request.Form["Cena"].ToString());
                    tableHome.Azuriran = DateTime.Parse(Request.Form["Ažurirano"].ToString());
                    tableHome.Drzava = Request.Form["Drzava"];
                    if (Request.Form["Slajder"].ToString() == "DA" || Request.Form["Slajder"].ToString() == "da")
                    {
                        tableHome.Slajder = true;

                    }
                    else
                    {
                        tableHome.Slajder = false;
                    }
                    tableHome.Slika = "/Content/Nekretnine/KuceProdaja/" + Request.Form["Šifra"].ToString() + "/" + filename;
                    db.tblKuca.Add(tableHome);

                    db.SaveChanges();
                    file.SaveAs(filePath);

                }
                ViewBag.Mesasage = "Uploaded files Saved successfully in a folder !";
                return View("../tblKucas/Details", tableHome);
            }
            catch (Exception e1)
            {
                string strGlupopst = e1.ToString();
                ViewBag.Mesasage = "Uploaded files Saved unsuccessfully in a folder !";
                return View("../tblKucas/Index", tableHome);
            }

        }

        public ActionResult DodajSlikeKuce(HttpPostedFileBase[] files)
        {
            tblSlike slikeKuce = new tblSlike();
            //Ensure model state is valid  
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {

                    //Checking file is available to save.  
                    if (file != null)
                    {
                        string pathString = Server.MapPath("/Content/Nekretnine/KuceProdaja/" + Request.Form["Šifra"].ToString());

                        bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("/Content/Nekretnine/KuceProdaja/" + Request.Form["Šifra"].ToString()));

                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                        }
                        var InputFileName = Path.GetFileName(file.FileName);

                        var ServerSavePath = Path.Combine(Server.MapPath("/Content/Nekretnine/KuceProdaja/" + Request.Form["Šifra"].ToString()), InputFileName);
                        //Save file to server folder  
                        slikeKuce.sifra = Request.Form["Šifra"].ToString();
                        slikeKuce.referenca = "/Content/Nekretnine/KuceProdaja/" + Request.Form["Šifra"].ToString() + "/" + InputFileName;
                        file.SaveAs(ServerSavePath);

                        try
                        {
                            db.tblSlike.Add(slikeKuce);
                            db.SaveChanges();

                        }
                        catch (Exception e1)
                        {
                            Console.WriteLine(e1.ToString());
                        }

                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                    }

                }
            }
            return View("../tblKucas/Index", db.tblKuca);
        }
        #endregion
    }
}