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
    public class ManageUsersModel : PageModel
    {
        public String Message {get; set;}
        public Korisnik TKorisnik {get; set;}
        
        [BindProperty]
        public IList<Korisnik> customers { get; set; }

        [BindProperty]
          public IList<Korisnik> managers { get; set; }
 
        private readonly Table4UContext db;
        public ManageUsersModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public IActionResult OnGet()
        {
            String eMail = HttpContext.Session.GetString("email");
            
            if (string.IsNullOrEmpty(eMail)||db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault().tipKorisnika!="Admin")
            {
                return RedirectToPage("/Login");
            }
            customers=db.Korisnici.Where(korisnik=>korisnik.tipKorisnika=="Gost"&&korisnik.validanNalog).ToList();
            managers=db.Korisnici.Where(Korisnik => Korisnik.tipKorisnika=="Menadzer"&&Korisnik.validanNalog).Include(x=>x.mojLokal).ToList();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if(db.Korisnici.Where(Korisnik=>Korisnik.Id==id).FirstOrDefault().tipKorisnika=="Gost")
            {
               
                HttpContext.Session.SetString("adminShowManager","false");
            }
            else
            {
                
                HttpContext.Session.SetString("adminShowManager","true");

            }
            Korisnik korisnikZaBrisanje=db.Korisnici.Where(korisnik => korisnik.Id==id).FirstOrDefault();
            if(korisnikZaBrisanje.tipKorisnika=="Menadzer")
            {
                db.Lokali.Remove(db.Lokali.Where(lokal =>lokal.Id==korisnikZaBrisanje.mojLokal.Id).FirstOrDefault());
            }
            db.Korisnici.Remove(korisnikZaBrisanje);
          await  db.SaveChangesAsync();

           return RedirectToPage();
            
        }
        public string GetHttpContextTypeShown()
        {
            return HttpContext.Session.GetString("adminShowManager");
        }

        public string GetObjectLink(int id)
        {
            return "Object?Id="+id.ToString();
        }

        

    }
}
