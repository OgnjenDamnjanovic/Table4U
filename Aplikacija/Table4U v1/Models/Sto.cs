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
        public string oznaka { get; set; }
        public int gsX { get; set; }
        public int gsY { get; set; }
        public int gsHeight { get; set; }
        public int gsWidth { get; set; }


    }
}