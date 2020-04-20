using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SWEProject.Models;

namespace MyApp.Namespace
{
    public class ListedObjectsModel : PageModel
    {
        public Korisnik TKorisnik {get; set;}
        public String Message {get; set;}
        private readonly Table4UContext db;
        public IList<String>  VrsteObjekata { get; set; }
        public IList<List<Lokal>> MatricaLokala {get; set;}
        [BindProperty(SupportsGet=true)]
        public String IzabranaVrsta {get; set;}
        public SelectList Lista {get; set;}
        public String City {get; set;}
        public String Name {get; set;}

        public ListedObjectsModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public void OnGet(string city,string name)
        {
            City = city;
            Name = name;

            //test=City+Name;
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
            
            IQueryable<String> qLista = db.Lokali.Select(x=>x.Tip).Distinct();
            //VrsteObjekata = db.Lokali.Select(x=>x.Tip).Distinct().ToList();
            Lista = new SelectList(qLista.ToList());
            if(string.IsNullOrEmpty(City) && string.IsNullOrEmpty(Name))
            { 
                VrsteObjekata = qLista.ToList();
                if(!string.IsNullOrEmpty(IzabranaVrsta) && IzabranaVrsta!="0")
                {
                    VrsteObjekata.Clear();
                    VrsteObjekata.Add(IzabranaVrsta);
                }
                MatricaLokala = new List<List<Lokal>>(VrsteObjekata.Count());
                for(int i=0; i<VrsteObjekata.Count(); i++)
                {
                    MatricaLokala.Add(db.Lokali.Where(x=>x.Tip == VrsteObjekata[i]).ToList());                
                }
            }
            else if(string.IsNullOrEmpty(Name))
            {
                VrsteObjekata = db.Lokali.Where(x=>x.Grad == City).Select(x=>x.Tip).Distinct().ToList();
                if(!string.IsNullOrEmpty(IzabranaVrsta) && IzabranaVrsta!="0")
                {
                    VrsteObjekata.Clear();
                    VrsteObjekata.Add(IzabranaVrsta);
                }
                MatricaLokala = new List<List<Lokal>>(VrsteObjekata.Count());
                for(int i=0; i<VrsteObjekata.Count(); i++)
                {
                    //var lokali = db.Lokali.Where(x=>x.Grad == City && x.T)
                    MatricaLokala.Add(db.Lokali.Where(x=>x.Grad == City && x.Tip == VrsteObjekata[i]).ToList());                
                }
            }
            else if(string.IsNullOrEmpty(City))
            {
                List<Lokal> lokali = db.Lokali.Where(x=>x.Naziv == Name).ToList();
                if(lokali!=null)
                {
                    VrsteObjekata = lokali.Select(x=>x.Tip).Distinct().ToList();
                    if(!string.IsNullOrEmpty(IzabranaVrsta) && IzabranaVrsta!="0")
                    {
                        VrsteObjekata.Clear();
                        VrsteObjekata.Add(IzabranaVrsta);
                        lokali = lokali.Where(x=>x.Tip == IzabranaVrsta).ToList();
                    }
                    MatricaLokala = new List<List<Lokal>>(VrsteObjekata.Count());
                    MatricaLokala.Add(lokali);
                }
                return;
            }
            else
            {
                Lokal lokal = db.Lokali.Where(x=>x.Naziv==Name && x.Grad==City).FirstOrDefault();
                if(lokal!=null)
                {
                    VrsteObjekata = new List<String>();
                    VrsteObjekata.Add(lokal.Tip);
                    MatricaLokala = new List<List<Lokal>>();
                    MatricaLokala.Add(new List<Lokal>());
                    MatricaLokala[0].Add(lokal);
                }
                return;
            }
            
        }

        public void OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            Message = null;
        }
    }
}
