//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Harmony022.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblZemljiste
    {
        public int Zemljiste_Id { get; set; }
        public string Sifra { get; set; }
        public string Mesto { get; set; }
        public string Lokacija { get; set; }
        public Nullable<int> Povrsina { get; set; }
        public string Uknjizen { get; set; }
        public string Slika { get; set; }
        public string Vrsta_Nekretnine { get; set; }
        public Nullable<bool> Slajder { get; set; }
        public string Opis { get; set; }
        public string Drzava { get; set; }
        public Nullable<bool> PocetnaStrana { get; set; }
        public Nullable<int> Cena { get; set; }
        public Nullable<System.DateTime> Azuriran { get; set; }
    }
}
