using System;
using System.Text.Json.Serialization;

namespace SWEProject.Models
{
    public class Dogadjaj 
    {
        public int Id { get; set; }
        public string Vrsta { get; set; }
        public string Opis { get; set; }
        public DateTime Datum { get; set; }
        [JsonIgnore]
        public Lokal Lokal { get; set; }

    }
}