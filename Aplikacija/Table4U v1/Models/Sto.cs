using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SWEProject.Models
{
    public class Sto
    {
        public int Id { get; set; }
        public int brojMesta { get; set; }
        public bool Slobodan { get; set; }
        [JsonIgnore]
        public Lokal Lokal { get; set; }


    }
}