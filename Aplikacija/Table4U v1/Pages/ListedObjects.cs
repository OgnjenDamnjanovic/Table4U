using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWEProject.Models;

namespace MyApp.Namespace
{
    public class ListedObjectsModel : PageModel
    {
        public String Message {get; set;}
        private readonly Table4UContext db;
        public IList<String>  VrsteObjekata { get; set; }
        public IList<List<Lokal>> MatricaLokala {get; set;}
        public ListedObjectsModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public void OnGet(string city,string name)
        {
            //test=city+name;
            String eMail = HttpContext.Session.GetString("email");
            if (!string.IsNullOrEmpty(eMail))
            {
                var korisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
                Message = "Welcome, " + korisnik.Ime;
            }

            if(string.IsNullOrEmpty(city) && string.IsNullOrEmpty(name))
            {
                VrsteObjekata = db.Lokali.Select(x=>x.Tip).Distinct().ToList();
            }
            else if(string.IsNullOrEmpty(name))
            {
                VrsteObjekata = db.Lokali.Where(x=>x.Grad == city).Select(x=>x.Tip).Distinct().ToList();
            }
            else if(string.IsNullOrEmpty(city))
            {
                List<Lokal> lokali = db.Lokali.Where(x=>x.Naziv == name).ToList();
                if(lokali!=null)
                {
                    VrsteObjekata = lokali.Select(x=>x.Tip).Distinct().ToList();
                    MatricaLokala = new List<List<Lokal>>(VrsteObjekata.Count());
                    MatricaLokala.Add(lokali);
                }
                return;
            }
            else
            {
                Lokal lokal = db.Lokali.Where(x=>x.Naziv==name && x.Grad==city).FirstOrDefault();
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
            MatricaLokala = new List<List<Lokal>>(VrsteObjekata.Count());
            for(int i=0; i<VrsteObjekata.Count(); i++)
            {
                MatricaLokala.Add(db.Lokali.Where(x=>x.Tip == VrsteObjekata[i]).ToList());                
            }
        }

        public void OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            Message = null;
        }
    }
}
