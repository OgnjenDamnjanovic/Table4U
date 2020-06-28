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
    public class ListedReservationsModel : PageModel
    {

        public String Message1 {get; set;}
        public IList<Rezervacija> ListaRez {get; set;}
        public Korisnik TKorisnik {get; set;}
        public String Message {get; set;}
        public List<String> ListaImena {get; set;}
        public List<String> ListaAdresa {get; set;}
        public List<String> ListaDatuma {get; set;}
        public List<String> ListaBrojMesta {get; set;}
        public List<String> ListaStolova {get; set;}
        public List<String> ListaVremena {get; set;}
        public List<Sto> ListaStolova2 {get; set;}

        public string ErrorMessage {get; set;}
        [BindProperty]
        public string eMailAddress {get; set;}

        public List<List<String>> matOznaka {get; set;}
        
        private readonly Table4UContext db;
        
        public ListedReservationsModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public IActionResult OnGet()
        {
            String eMail = HttpContext.Session.GetString("email");
            //String eMail = "nikola.vidanovic@elfak.rs";
            if(eMail==null)
                return RedirectToPage("/Login");
            Message = "Manager";
            TKorisnik = db.Korisnici.Include(x=>x.mojLokal).Where(x=>x.eMail == eMail).FirstOrDefault();
            //TKorisnik = db.Korisnici.Include(kor=>kor.mojLokal).Where(x=>x.Id==2).FirstOrDefault();
            Lokal lokal = db.Lokali.Where(x=>x.Id == TKorisnik.mojLokal.Id).Include(x=>x.listaStolova).Include(x=>x.listaRezervacija).ThenInclude(x=>x.Sto).FirstOrDefault();

            DateTime danas = DateTime.Now;            
            ListaRez = db.Rezervacije.Include(x=>x.Sto).Include(x=>x.Korisnik).Include(x=>x.Lokal).Where(x=>x.LokalId == TKorisnik.mojLokal.Id && x.Vreme >= danas).ToList();
            

            /*json = Newtonsoft.Json.JsonConvert.SerializeObject(ListaRez, Formatting.Indented,
                    new JsonSerializerSettings() {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore}
            );*/
            //json = Newtonsoft.Json.JsonConvert.SerializeObject(ListaRez); 

            ListaImena = new List<string>();
            ListaAdresa = new List<string>();
            ListaDatuma = new List<string>();
            ListaBrojMesta = new List<string>();
            ListaStolova = new List<string>();
            foreach(Rezervacija r in ListaRez)
            {
                ListaImena.Add(r.Korisnik.Ime + " " + r.Korisnik.Prezime);
                ListaAdresa.Add(r.Korisnik.eMail);
                ListaDatuma.Add(r.Vreme.ToString("dd.MM.yyyy, HH:mm"));
                ListaBrojMesta.Add(r.Sto.brojMesta.ToString());
                ListaStolova.Add(r.Sto.oznaka.ToString());
            }                   

            DateTime i = TKorisnik.mojLokal.openTime;
            DateTime kraj = TKorisnik.mojLokal.closeTime;
            ListaVremena = new List<string>();
            ListaVremena.Add("Table/Hour");
            if(kraj<i)
                kraj = kraj.AddDays(1);
            while(i < kraj)
            {
                ListaVremena.Add(i.ToString("HH:mm"));
                i=i.AddHours(1);
            }
            ListaStolova2 = db.Stolovi.Include(x=>x.Lokal).Where(x=>x.Lokal.Id == TKorisnik.mojLokal.Id).OrderBy(x=>x.oznaka).ToList();
            //var stoRez = db.Rezervacije.Include(x=>x.Lokal).Include(x=>x.Sto).Where(x=>x.Vreme.ToString("dd.MM.yyyy") == DateTime.Now.ToString("dd.MM.yyyy") && x.LokalId == TKorisnik.mojLokal.Id).ToList();
            //bool postoji;
            Rezervacija rez;
            
            matOznaka = new List<List<string>>(ListaStolova2.Count());
            foreach (Sto s in ListaStolova2)
            {
                List<Rezervacija> stoRez = lokal.listaRezervacija.Where(x=>x.Sto.Id == s.Id && x.Vreme.ToString("yyyyMMdd") == danas.ToString("yyyyMMdd")).ToList();
                List<string> pom = new List<string>();
                pom.Add(s.oznaka);
                i = TKorisnik.mojLokal.openTime;
                while(i < kraj)
                {
                    rez=null;
                    //postoji = false;
                    foreach(Rezervacija r in stoRez)
                    {
                        if(r.Vreme.ToString("HH:mm") == i.ToString("HH:mm"))
                            rez=r;
                            //postoji=true;
                    }

                    if(rez!=null)
                    {
                        Korisnik k = db.Rezervacije.Include(x=>x.Korisnik).Where(x=>x.Id == rez.Id).Select(x=>x.Korisnik).FirstOrDefault();
                        pom.Add(k.Ime + " " + k.Prezime + ", " + k.eMail);
                        i=i.AddHours(2);
                    }
                    else
                    {
                        pom.Add("-");
                        i=i.AddMinutes(15);
                    }
                }
                matOznaka.Add(pom);
            }

            return Page();

        }

        public void OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            Message = null;
        }

        /*public IActionResult OnGetPrijavi(string email)
        {
            Korisnik k = db.Korisnici.Where(x=>x.eMail == email).FirstOrDefault();
            if(k!=null && k.tipKorisnika=="Gost")
            {
                k.brojPrijava++;
                db.Attach(k).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToPage();
            }
            else
            {
                ErrorMessage = "The entered email address is invalid!";
                return RedirectToPage();
            }
        }*/

        public IActionResult OnPostPrijavi()
        {
            Korisnik k = db.Korisnici.Where(x=>x.eMail == eMailAddress).FirstOrDefault();
            if(k!=null && k.tipKorisnika=="Gost")
            {
                k.brojPrijava++;
                db.Attach(k).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToPage();
            }
            else
            {
                ErrorMessage = "The entered email address is invalid!";
                return RedirectToPage();
            }
        }


    }
}
