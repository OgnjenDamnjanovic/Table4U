using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWEProject.Models
{
    public class Lokal
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public string Naziv { get; set; }
        [DataType(DataType.Time)]
        public DateTime openTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime closeTime { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int maxKapacitet { get; set; }
        public int trenutniKapacitet { get; set; }
        public float Ocena {get; set;} = 0;
        public int brOcena {get; set;} = 0;
        public IList<Rezervacija> listaRezervacija { get; set; }
        public IList<Sto> listaStolova { get; set; }
        public IList<Dogadjaj> listaDogadjaja { get; set; }
        public IList<Recenzija> listaRecenzija {get; set;}
        public string nazivSlike { get; set; }
        public string email {get;set;}
        public string opis {get;set;}

    }

}