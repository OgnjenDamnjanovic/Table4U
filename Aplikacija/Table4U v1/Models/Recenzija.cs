using System;

namespace SWEProject.Models
{
    public class Recenzija
    {
        public int Id {get; set; }
        public int Ocena { get; set; }
        public string Komentar { get; set; }
        public int KorisnikId {get; set; }
        public Korisnik Korisnik { get; set; }
        public DateTime Datum { get; set; }
        public int LokalId {get; set;}
        public Lokal Lokal { get; set; }
        
    }
}