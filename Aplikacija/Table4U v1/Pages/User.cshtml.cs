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
    public class UserModel : PageModel
    {
        [BindProperty]
        public string firstname {get;set;}
        [BindProperty]
        public string lastname {get;set;}
        [BindProperty]
        public string email {get;set;}
        [BindProperty]
        public string password {get;set;}
        [BindProperty]
        public string newPassword {get;set;}
        public IList<Rezervacija> ListaRez {get;set;}
        public List<string> ListaNaziva {get;set;}
        public List<string> ListaAdresa {get;set;}
        public List<string> ListaPocetak {get;set;}
        public List<string> ListaDatuma {get; set;}
        public List<string> ListaBrMesta {get;set;}
        public Korisnik TKorisnik {get; set;}
        public string ErrorM {get;set;}
        public String Message {get; set;}
        private readonly Table4UContext db;

        public UserModel(Table4UContext dataBase)
        {
            db = dataBase;
        }

        public IActionResult OnGet()
        {
            String eMail = HttpContext.Session.GetString("email");
            if(eMail==null)
                return RedirectToPage("/Login");
            TKorisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
            if (!string.IsNullOrEmpty(eMail))
            {
                if(TKorisnik.tipKorisnika=="Menadzer")
                {
                    Message = "Manager";
                }
                else
                {
                    var korisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
                    Message = "Welcome, " + korisnik.Ime;
                }
            }

            /*ListaNaziva = new List<string>();
            ListaAdresa = new List<string>();
            ListaDatuma = new List<string>();
            ListaBrMesta = new List<string>();
            ListaPocetak = new List<string>();*/

            DateTime danas = DateTime.Now;
            ListaRez=db.Rezervacije.Where(x=>x.Korisnik.Id==TKorisnik.Id && x.Vreme>=danas).Include(x=>x.Lokal).Include(x=>x.Sto).OrderBy(x=>x.Vreme).ToList();

            /*if(ListaRez.Count>0)
            {
                foreach(Rezervacija r in ListaRez)
                {
                    ListaNaziva.Add(r.Lokal.Naziv);
                    ListaAdresa.Add(r.Lokal.Adresa);
                    ListaDatuma.Add(r.Vreme.ToString("dd.MM.yyyy."));
                    ListaBrMesta.Add(r.Sto.brojMesta.ToString());
                    ListaPocetak.Add((r.Vreme.Hour+":"+r.Vreme.Minute).ToString());
                }
            }*/
            return Page();
        }

        public async Task<IActionResult> OnPostSacuvajAsync()
        {
            String eMail = HttpContext.Session.GetString("email");
            TKorisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
            var k = db.Korisnici.Where(x=>x.Id==TKorisnik.Id).FirstOrDefault();
            k.Ime=firstname;
            k.Prezime=lastname;
            k.eMail=email;
            if(newPassword!=null && !newPassword.Equals(""))
                k.Sifra=newPassword;
            db.Update(k);
            await db.SaveChangesAsync();
            return Redirect("./Login");
        }

        public async Task<IActionResult> OnPostObrisiRez(int id)
        {
            var r = db.Rezervacije.Where(x=>x.Id==id).FirstOrDefault();
            if(r!=null)
                db.Remove(r);
            await db.SaveChangesAsync();
            return RedirectToPage();
        }

        public void OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            Message = null;
        }
    }
}
