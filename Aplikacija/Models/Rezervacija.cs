using System;

namespace SWEProject.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public int KorisnikId {get; set;}
        public Korisnik Korisnik { get; set; }
        public int LokalId {get; set;}
        public Lokal Lokal { get; set; }
        public DateTime Vreme { get; set; }
        public Sto Sto { get; set; }
    }


}