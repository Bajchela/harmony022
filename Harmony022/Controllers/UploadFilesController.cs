using Harmony022.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Harmony022.Controllers
{
    public class UploadFilesController : Controller


    {
        private harmony022Model db = new harmony022Model();

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
                    string filePath = Path.Combine(Server.MapPath("~/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString()), filename);

                    

                    bool exists = System.IO.Directory.Exists(Server.MapPath("~/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString()));

                    if (!exists)
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString()));

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

                        bool exists = System.IO.Directory.Exists(Server.MapPath("~/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString()));  

                        var InputFileName = Path.GetFileName(file.FileName);

                        var ServerSavePath = Path.Combine(Server.MapPath("~/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString()), InputFileName);
                        //Save file to server folder  
                        slikeStana.sifra = Request.Form["Šifra"].ToString();
                        slikeStana.referenca = "~/Content/Nekretnine/StanoviProdaja/" + Request.Form["Šifra"].ToString() +"/" + InputFileName;
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

    }
}