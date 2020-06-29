using System;
using System.Text.Json.Serialization;

namespace SWEProject.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public int KorisnikId {get; set;}
        public Korisnik Korisnik { get; set; }
        [JsonIgnore]
        public int LokalId {get; set;}
        [JsonIgnore]
        public Lokal Lokal { get; set; }
        public DateTime Vreme { get; set; }
        public DateTime VremeKreiranja { get; set; }
        public Sto Sto { get; set; }
    }


}