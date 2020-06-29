using System.Collections.Generic;

namespace SWEProject.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string tipKorisnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string eMail { get; set; }
        public string Sifra { get; set; }
        public IList<Rezervacija> mojeRezervacije { get; set; }
        //public IList<Lokal> favRestorani { get; set; }
        public Lokal mojLokal { get; set; }
        //public IList<Recenzija> listaRecenzija {get; set;}
        public int brojPrijava { get; set; }=0;
        public bool validanNalog { get; set; }
        public string hash { get; set; }
        public string passwordHash{get;set;}
        


    }



}