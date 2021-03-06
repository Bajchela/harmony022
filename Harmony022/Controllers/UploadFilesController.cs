﻿using Harmony022.Models;
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

        #region Stanovi
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
                    tabelaStan.Opis = Request.Form["Opis"];
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

        #region Kuce
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
                    tableHome.Povrsina_Placa = int.Parse(Request.Form["Površina placa"]);
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
                    tableHome.Opis = Request.Form["Opis"];

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

        #region Vikendica
        [HttpPost]
        public ActionResult DodajVikendicu(HttpPostedFileBase file)
        {
            tblVikendica tabelaVikendice = new tblVikendica();

            try
            {
                if (file.ContentLength > 0)
                {

                    string filename = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/Nekretnine/VikendiceProdaja/" + Request.Form["Šifra"].ToString()), filename);



                    bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("~/Content/Nekretnine/VikendiceProdaja/" + Request.Form["Šifra"].ToString()));

                    if (!exists)
                        System.IO.Directory.CreateDirectory(HttpContext.Server.MapPath("~/Content/Nekretnine/VikendiceProdaja/" + Request.Form["Šifra"].ToString()));

                    tabelaVikendice.Vrsta_Nekretnine = Request.Form["VrstaNekretnine"];
                    tabelaVikendice.Sifra = Request.Form["Šifra"];
                    tabelaVikendice.Mesto = Request.Form["Mesto"];
                    tabelaVikendice.Lokacija = Request.Form["Lokacija"];
                    tabelaVikendice.Sobnost = Request.Form["Sobnost"];
                    tabelaVikendice.Sprat = Request.Form["Sprat"];
                    tabelaVikendice.Kvadratura = int.Parse(Request.Form["Kvadratura"].ToString());
                    tabelaVikendice.Uknjizen = Request.Form["Uknjižen"];
                    tabelaVikendice.Grejanje = Request.Form["Grejanje"];
                    tabelaVikendice.Terasa = Request.Form["Terasa"];
                    tabelaVikendice.Cena = int.Parse(Request.Form["Cena"].ToString());
                    tabelaVikendice.Azuriran = DateTime.Parse(Request.Form["Ažurirano"].ToString());
                    tabelaVikendice.Drzava = Request.Form["Drzava"];
                    tabelaVikendice.Opis = Request.Form["Opis"];

                    if (Request.Form["Slajder"].ToString() == "DA" || Request.Form["Slajder"].ToString() == "da")
                    {
                        tabelaVikendice.Slajder = true;

                    }
                    else
                    {
                        tabelaVikendice.Slajder = false;
                    }
                    tabelaVikendice.Slika = "/Content/Nekretnine/VikendiceProdaja/" + Request.Form["Šifra"].ToString() + "/" + filename;
                    db.tblVikendica.Add(tabelaVikendice);

                    db.SaveChanges();
                    file.SaveAs(filePath);

                }
                ViewBag.Mesasage = "Uploaded files Saved successfully in a folder !";
                return View("../tblVikendica/Details", tabelaVikendice);
            }
            catch (Exception e1)
            {
                string strGlupopst = e1.ToString();
                ViewBag.Mesasage = "Uploaded files Saved unsuccessfully in a folder !";
                return View("../tblVikendica/Index", tabelaVikendice);
            }

        }
        public ActionResult DodajSlikeVikendicu(HttpPostedFileBase[] files)
        {
            tblSlike slike = new tblSlike();
            //Ensure model state is valid  
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {

                    //Checking file is available to save.  
                    if (file != null)
                    {
                        string pathString = Server.MapPath("/Content/Nekretnine/KuceProdaja/" + Request.Form["Šifra"].ToString());

                        bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("/Content/Nekretnine/VikendiceProdaja/" + Request.Form["Šifra"].ToString()));

                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                        }
                        var InputFileName = Path.GetFileName(file.FileName);

                        var ServerSavePath = Path.Combine(Server.MapPath("/Content/Nekretnine/VikendiceProdaja/" + Request.Form["Šifra"].ToString()), InputFileName);
                        //Save file to server folder  
                        slike.sifra = Request.Form["Šifra"].ToString();
                        slike.referenca = "/Content/Nekretnine/VikendiceProdaja/" + Request.Form["Šifra"].ToString() + "/" + InputFileName;
                        file.SaveAs(ServerSavePath);

                        try
                        {
                            db.tblSlike.Add(slike);
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
            return View("../tblVikendica/Index", db.tblVikendica);
        }
        #endregion

        #region PoslovniProstor
        [HttpPost]
        public ActionResult DodajBS(HttpPostedFileBase file)
        {
            tblPoslovniProstor tabelaBS = new tblPoslovniProstor();

            try
            {
                if (file.ContentLength > 0)
                {

                    string filename = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/Nekretnine/PoslovniProstorProdaja/" + Request.Form["Šifra"].ToString()), filename);



                    bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("~/Content/Nekretnine/PoslovniProstorProdaja/" + Request.Form["Šifra"].ToString()));

                    if (!exists)
                        System.IO.Directory.CreateDirectory(HttpContext.Server.MapPath("~/Content/Nekretnine/PoslovniProstorProdaja/" + Request.Form["Šifra"].ToString()));

                    tabelaBS.Vrsta_Nekretnine = Request.Form["VrstaNekretnine"];
                    tabelaBS.Sifra = Request.Form["Šifra"];
                    tabelaBS.Mesto = Request.Form["Mesto"];
                    tabelaBS.Lokacija = Request.Form["Lokacija"];
                    tabelaBS.Sobnost = Request.Form["Sobnost"];
                    tabelaBS.Sprat = Request.Form["Sprat"];
                    tabelaBS.Kvadratura = int.Parse(Request.Form["Kvadratura"].ToString());
                    tabelaBS.Uknjizen = Request.Form["Uknjižen"];
                    tabelaBS.Grejanje = Request.Form["Grejanje"];
                    tabelaBS.Cena = int.Parse(Request.Form["Cena"].ToString());
                    tabelaBS.Azuriran = DateTime.Parse(Request.Form["Ažurirano"].ToString());
                    tabelaBS.Drzava = Request.Form["Drzava"];
                    tabelaBS.Opis = Request.Form["Opis"];

                    if (Request.Form["Slajder"].ToString() == "DA" || Request.Form["Slajder"].ToString() == "da")
                    {
                        tabelaBS.Slajder = true;

                    }
                    else
                    {
                        tabelaBS.Slajder = false;
                    }
                    tabelaBS.Slika = "/Content/Nekretnine/PoslovniProstorProdaja/" + Request.Form["Šifra"].ToString() + "/" + filename;
                    db.tblPoslovniProstor.Add(tabelaBS);

                    db.SaveChanges();
                    file.SaveAs(filePath);
                }

                ViewBag.Mesasage = "Uspešno ste dodali novi poslovni prostor";
                return View("../tblPoslovniProstor/Details", tabelaBS);
            }
            catch (Exception e1)
            {
                string strGlupopst = e1.ToString();
                ViewBag.Mesasage = "Neuspesno dodavanje novog poslovni prostor !";
                return View("../tblPoslovniProstor/Index", tabelaBS);
            }

        }
        public ActionResult DodajSlikeBS(HttpPostedFileBase[] files)
        {
            tblSlike slike = new tblSlike();
            //Ensure model state is valid  
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {

                    //Checking file is available to save.  
                    if (file != null)
                    {
                        string pathString = Server.MapPath("/Content/Nekretnine/PoslovniProstorProdaja/" + Request.Form["Šifra"].ToString());

                        bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("/Content/Nekretnine/PoslovniProstorProdaja/" + Request.Form["Šifra"].ToString()));

                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                        }
                        var InputFileName = Path.GetFileName(file.FileName);

                        var ServerSavePath = Path.Combine(Server.MapPath("/Content/Nekretnine/PoslovniProstorProdaja/" + Request.Form["Šifra"].ToString()), InputFileName);
                        //Save file to server folder  
                        slike.sifra = Request.Form["Šifra"].ToString();
                        slike.referenca = "/Content/Nekretnine/PoslovniProstorProdaja/" + Request.Form["Šifra"].ToString() + "/" + InputFileName;
                        file.SaveAs(ServerSavePath);

                        try
                        {
                            db.tblSlike.Add(slike);
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
            return View("../tblPoslovniProstor/Index", db.tblPoslovniProstor);
        }
        #endregion

        #region Poljoprivredno Zemljiste
        [HttpPost]
        public ActionResult DodajLand(HttpPostedFileBase file)
        {
            tblZemljiste tabelaLand = new tblZemljiste();

            try
            {
                if (file.ContentLength > 0)
                {

                    string filename = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/Nekretnine/PoljoprivrednoZemljiste/" + Request.Form["Šifra"].ToString()), filename);

                    bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("~/Content/Nekretnine/PoljoprivrednoZemljiste/" + Request.Form["Šifra"].ToString()));

                    if (!exists)
                        System.IO.Directory.CreateDirectory(HttpContext.Server.MapPath("~/Content/Nekretnine/PoljoprivrednoZemljiste/" + Request.Form["Šifra"].ToString()));

                    tabelaLand.Vrsta_Nekretnine = Request.Form["VrstaNekretnine"];
                    tabelaLand.Sifra = Request.Form["Šifra"];
                    tabelaLand.Mesto = Request.Form["Mesto"];
                    tabelaLand.Lokacija = Request.Form["Lokacija"];
                    tabelaLand.Povrsina = int.Parse(Request.Form["Povrsina"].ToString());
                    tabelaLand.Uknjizen = Request.Form["Uknjižen"];
                    tabelaLand.Cena = int.Parse(Request.Form["Cena"].ToString());
                    tabelaLand.Azuriran = DateTime.Parse(Request.Form["Ažurirano"].ToString());
                    tabelaLand.Drzava = Request.Form["Drzava"];
                    tabelaLand.Opis = Request.Form["Opis"];

                    if (Request.Form["Slajder"].ToString() == "DA" || Request.Form["Slajder"].ToString() == "da")
                    {
                        tabelaLand.Slajder = true;

                    }
                    else
                    {
                        tabelaLand.Slajder = false;
                    }
                    tabelaLand.Slika = "/Content/Nekretnine/PoljoprivrednoZemljiste/" + Request.Form["Šifra"].ToString() + "/" + filename;
                    db.tblZemljiste.Add(tabelaLand);

                    db.SaveChanges();
                    file.SaveAs(filePath);
                }

                ViewBag.Mesasage = "Uspešno ste dodali novo zemljište";
                return View("../tblZemljistes/Details", tabelaLand);
            }
            catch (Exception e1)
            {
                string strGlupopst = e1.ToString();
                ViewBag.Mesasage = "Neuspesno dodavanje novog zemljišta !";
                return View("../tblZemljistes/Index", tabelaLand);
            }

        }
        public ActionResult DodajSlikeLand(HttpPostedFileBase[] files)
        {
            tblSlike slike = new tblSlike();
            //Ensure model state is valid  
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {

                    //Checking file is available to save.  
                    if (file != null)
                    {
                        string pathString = Server.MapPath("/Content/Nekretnine/PoljoprivrednoZemljiste/" + Request.Form["Šifra"].ToString());

                        bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("/Content/Nekretnine/PoljoprivrednoZemljiste/" + Request.Form["Šifra"].ToString()));

                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                        }
                        var InputFileName = Path.GetFileName(file.FileName);

                        var ServerSavePath = Path.Combine(Server.MapPath("/Content/Nekretnine/PoljoprivrednoZemljiste/" + Request.Form["Šifra"].ToString()), InputFileName);
                        //Save file to server folder  
                        slike.sifra = Request.Form["Šifra"].ToString();
                        slike.referenca = "/Content/Nekretnine/PoljoprivrednoZemljiste/" + Request.Form["Šifra"].ToString() + "/" + InputFileName;
                        file.SaveAs(ServerSavePath);

                        try
                        {
                            db.tblSlike.Add(slike);
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
            return View("../tblZemljistes/Index", db.tblZemljiste);
        }
        #endregion


        #region Poljoprivredno Zemljiste
        [HttpPost]
        public ActionResult DodajConstructionLand(HttpPostedFileBase file)
        {
            tblGradjevinskoZemljiste tabelaLand = new tblGradjevinskoZemljiste();

            try
            {
                if (file.ContentLength > 0)
                {

                    string filename = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/Nekretnine/GrađevinskoZemljiste/" + Request.Form["Šifra"].ToString()), filename);

                    bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("~/Content/Nekretnine/GrađevinskoZemljiste/" + Request.Form["Šifra"].ToString()));

                    if (!exists)
                        System.IO.Directory.CreateDirectory(HttpContext.Server.MapPath("~/Content/Nekretnine/GrađevinskoZemljiste/" + Request.Form["Šifra"].ToString()));

                    tabelaLand.Vrsta_Nekretnine = Request.Form["VrstaNekretnine"];
                    tabelaLand.Sifra = Request.Form["Šifra"];
                    tabelaLand.Mesto = Request.Form["Mesto"];
                    tabelaLand.Lokacija = Request.Form["Lokacija"];
                    tabelaLand.Povrsina = int.Parse(Request.Form["Povrsina"].ToString());
                    tabelaLand.Uknjizen = Request.Form["Uknjižen"];
                    tabelaLand.Cena = int.Parse(Request.Form["Cena"].ToString());
                    tabelaLand.Azuriran = DateTime.Parse(Request.Form["Ažurirano"].ToString());
                    tabelaLand.Drzava = Request.Form["Drzava"];
                    tabelaLand.Opis = Request.Form["Opis"];

                    if (Request.Form["Slajder"].ToString() == "DA" || Request.Form["Slajder"].ToString() == "da")
                    {
                        tabelaLand.Slajder = true;

                    }
                    else
                    {
                        tabelaLand.Slajder = false;
                    }
                    tabelaLand.Slika = "/Content/Nekretnine/GrađevinskoZemljiste/" + Request.Form["Šifra"].ToString() + "/" + filename;
                    db.tblGradjevinskoZemljiste.Add(tabelaLand);

                    db.SaveChanges();
                    file.SaveAs(filePath);
                }

                ViewBag.Mesasage = "Uspešno ste dodali novo građevinsko zemljište";
                return View("../tblGradjevinskoZemljistes/Details", tabelaLand);
            }
            catch (Exception e1)
            {
                string strGlupopst = e1.ToString();
                ViewBag.Mesasage = "Neuspesno dodavanje novog građevinskog zemljišta !";
                return View("../tblGradjevinskoZemljistes/Index", tabelaLand);
            }

        }
        public ActionResult DodajSlikeConstructionLand(HttpPostedFileBase[] files)
        {
            tblSlike slike = new tblSlike();
            //Ensure model state is valid  
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {

                    //Checking file is available to save.  
                    if (file != null)
                    {
                        string pathString = Server.MapPath("/Content/Nekretnine/GrađevinskoZemljiste/" + Request.Form["Šifra"].ToString());

                        bool exists = System.IO.Directory.Exists(HttpContext.Server.MapPath("/Content/Nekretnine/GrađevinskoZemljiste/" + Request.Form["Šifra"].ToString()));

                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(pathString);
                        }
                        var InputFileName = Path.GetFileName(file.FileName);

                        var ServerSavePath = Path.Combine(Server.MapPath("/Content/Nekretnine/GrađevinskoZemljiste/" + Request.Form["Šifra"].ToString()), InputFileName);
                        //Save file to server folder  
                        slike.sifra = Request.Form["Šifra"].ToString();
                        slike.referenca = "/Content/Nekretnine/GrađevinskoZemljiste/" + Request.Form["Šifra"].ToString() + "/" + InputFileName;
                        file.SaveAs(ServerSavePath);

                        try
                        {
                            db.tblSlike.Add(slike);
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
            return View("../PoljoprivrednoZemljiste/Index", db.tblGradjevinskoZemljiste);
        }
        #endregion

    }
}