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
    public class ObjectModel : PageModel
    {
        public Korisnik TKorisnik {get; set;}
        public List<DateTime> listaVremena {get;set;}
        public List<int> listabrMesta {get;set;}
        [BindProperty]
        public IList<Lokal> slicniLokali {get;set;}
        [BindProperty]
        public Lokal lokal {get;set;}
        public String Message {get; set;}
        [BindProperty]
        public IList<Lokal> ListaLokala {get; set;}
        private readonly Table4UContext db;
        
        public ObjectModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        
        public void OnGet(int Id)
        {
            ListaLokala = db.Lokali.Include(x=>x.listaStolova)
                                .Include(x=>x.listaDogadjaja).Include(x=>x.listaRezervacija)
                                .Include(x=>x.listaRecenzija).ToList();
            lokal = ListaLokala.Where(x=>x.Id==Id).FirstOrDefault();
            
            List<int> listaSt=new List<int>();
            listabrMesta=new List<int>();
            int i=0;
            var lista = lokal.listaStolova.OrderBy(x=>x.brojMesta);
            for(i=0;i<lista.Count();i++)
            {
                listaSt.Add(lista.ElementAt(i).brojMesta);
            }
            var lista1 = listaSt.Distinct();
            for(i=0;i<lista1.Count();i++)
            {
                listabrMesta.Add(lista1.ElementAt(i));
            }

            slicniLokali=db.Lokali.Where(x=>x.Tip.Equals(lokal.Tip)).ToList();
            slicniLokali.Remove(lokal);

            String eMail = HttpContext.Session.GetString("email");
            TKorisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
            if (!string.IsNullOrEmpty(eMail))
            {
                if(TKorisnik.tipKorisnika=="Manager")
                {
                    Message=null;
                }
                else
                {
                    var korisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
                    Message = "Welcome, " + korisnik.Ime;
                }
            }
        }

        public void OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            Message = null;
        }
    }
}
