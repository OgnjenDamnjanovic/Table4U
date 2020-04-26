using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SWEProject.Models;

namespace MyApp.Namespace
{
    public class ManagerModel : PageModel
    {
        public String Message {get; set;}
        private readonly Table4UContext db;

        public Korisnik TKorisnik {get; set;}
        public int BrRezervacija {get; set;}
        public int BrDogadjaja {get; set;}
        public Lokal MojLokal {get; set;}
        public List<String> Lista {get; set;}
        public List<int> ListaPodataka {get; set;}
        public List<Rezervacija> NajnovijeRez {get; set;}
        
        public ManagerModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public void OnGet()
        {
            String eMail = HttpContext.Session.GetString("email");
            Message = "Manager";
            TKorisnik = db.Korisnici.Include(x=>x.mojLokal).Where(x=>x.eMail == eMail).FirstOrDefault();
            var id = TKorisnik.mojLokal.Id;
            MojLokal = db.Lokali.Include(x=>x.listaRecenzija).Include(x=>x.listaStolova).Include(x=>x.listaRezervacija)
                                .ThenInclude(x=>x.Korisnik).Where(x=>x.Id == id).FirstOrDefault();

            if(MojLokal.listaRezervacija!=null)
                BrRezervacija = MojLokal.listaRezervacija.Count();
            else BrRezervacija = 0;
            if(MojLokal.listaDogadjaja!=null)
                BrDogadjaja = MojLokal.listaDogadjaja.Count();
            else BrDogadjaja = 0;

            Lista = new List<String>();
            ListaPodataka = new List<int>();
            DateTime danas = DateTime.Now;

            for(int i=0; i<7; i++)
            {
                Lista.Add(danas.ToString("dd.MM"));
                ListaPodataka.Add(MojLokal.listaRezervacija.Where(x=>x.Vreme.ToString("yyyyMMdd") == danas.ToString("yyyyMMdd")).Count());
                //ListaPodataka.Add(i+1);
                danas = danas.AddDays(1);
            }

            NajnovijeRez = MojLokal.listaRezervacija.OrderByDescending(x=>x.VremeKreiranja).Take(3).ToList();
        }

        public void OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            Message = null;
        }
    }
}
