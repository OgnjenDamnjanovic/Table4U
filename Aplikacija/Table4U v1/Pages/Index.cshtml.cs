using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SWEProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Table4U.Pages
{
    public class IndexModel : PageModel
    {
        public String Message {get; set;}
		public Korisnik TKorisnik {get; set;}

        private readonly Table4UContext db;
      
        [BindProperty]
        public IList<Dogadjaj> ListaDogadjaja {get; set;}

        [BindProperty]
        public List<Dogadjaj> ListaDog {get;set;}

        [BindProperty]
        public List<Lokal> ListaLok {get;set;}

        [BindProperty]
        public SelectList listaGradRestoranJSON { get; set; }

        [BindProperty]
        public SelectList listaGradova { get; set; }
        
        [BindProperty]
        public IList<Lokal> ListaLokala {get; set;}

        public IndexModel(Table4UContext dataBase)
        {
            db = dataBase;
        }

        public void OnGet()
        {
            var i=0;
            ListaDog = new List<Dogadjaj>();
            ListaLok = new List<Lokal>();
            ListaLokala = db.Lokali.ToList();
            ListaDogadjaja=db.Dogadjaji.ToList();
            var Lista = ListaDogadjaja.OrderBy(x=>x.Datum);
            var Lista2 = ListaLokala.OrderByDescending(x=>x.Ocena);
            ListaDogadjaja=Lista.ToList();
            ListaLokala=Lista2.ToList();
            if(ListaDogadjaja.Count>5)
            {
                for(i=0;i<5;i++)
                {
                    ListaDog.Add(ListaDogadjaja.ElementAt(i));
                }
            }
            else
            {
                for(i=0;i<ListaDogadjaja.Count;i++)
                {
                    ListaDog.Add(ListaDogadjaja.ElementAt(i));
                }
            }
            if(ListaLokala.Count>5)
            {
                for(i=0;i<5;i++)
                {
                    ListaLok.Add(ListaLokala.ElementAt(i));
                }
            }
            else
            {
                for(i=0;i<ListaLokala.Count;i++)
                {
                    ListaLok.Add(ListaLokala.ElementAt(i));
                }
            }

            String eMail = HttpContext.Session.GetString("email");
            TKorisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
            if (!string.IsNullOrEmpty(eMail))
            {
                if(TKorisnik.tipKorisnika=="Manager")
                {
                    Message = null;
                }
                else
                {
                    var korisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
                    Message = "Welcome, " + korisnik.Ime;
                }
            }
            var sviRestorani=db.Lokali.ToList();
            var listaGradRestoran=new List<string>();
            listaGradova=new SelectList(db.Lokali.Select(lokal =>lokal.Grad).Distinct().ToList());
            foreach(var restoran in sviRestorani)
            {
              
                listaGradRestoran.Add($"{{\"naziv\":\"{restoran.Naziv}\",\"grad\":\"{restoran.Grad}\"}}");
            }
            listaGradRestoranJSON=new SelectList(listaGradRestoran.ToList());
            
        }

        public void OnGetLogout()
        { 
            var i=0;
            ListaDog = new List<Dogadjaj>();
            ListaLok = new List<Lokal>();
            ListaLokala = db.Lokali.ToList();
            ListaDogadjaja=db.Dogadjaji.ToList();
            var Lista = ListaDogadjaja.OrderBy(x=>x.Datum);
            var Lista2 = ListaLokala.OrderBy(x=>x.Ocena);
            ListaDogadjaja=Lista.ToList();
            ListaLokala=Lista2.ToList();
            if(ListaDogadjaja.Count>5)
            {
                for(i=0;i<5;i++)
                {
                    ListaDog.Add(ListaDogadjaja.ElementAt(i));
                }
            }
            else
            {
                for(i=0;i<ListaDogadjaja.Count;i++)
                {
                    ListaDog.Add(ListaDogadjaja.ElementAt(i));
                }
            }  
            if(ListaLokala.Count>5)
            {
                for(i=0;i<5;i++)
                {
                    ListaLok.Add(ListaLokala.ElementAt(i));
                }
            }
            else
            {
                for(i=0;i<ListaLokala.Count;i++)
                {
                    ListaLok.Add(ListaLokala.ElementAt(i));
                }
            }     
            HttpContext.Session.Remove("email");
            Message = null;
        }
    }
}
