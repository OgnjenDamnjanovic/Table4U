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
            TKorisnik=db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
            customers=db.Korisnici.Where(korisnik=>korisnik.tipKorisnika=="Gost"&&korisnik.validanNalog).ToList();
            managers=db.Korisnici.Where(Korisnik => Korisnik.tipKorisnika=="Menadzer"&&Korisnik.validanNalog).Include(x=>x.mojLokal).ToList();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {  
             Korisnik korisnikZaBrisanje=db.Korisnici.Where(korisnik => korisnik.Id==id).Include(x=>x.mojLokal).FirstOrDefault();
            if(korisnikZaBrisanje==null)
            return RedirectToPage();

            if(korisnikZaBrisanje.tipKorisnika=="Gost")
            {
               
                HttpContext.Session.SetString("adminShowManager","false");
            }
            else
            {
                
                HttpContext.Session.SetString("adminShowManager","true");

            }
            
            if(korisnikZaBrisanje.tipKorisnika=="Menadzer")
            {
                List<Dogadjaj> dogadjaji=await db.Dogadjaji.Where(dog =>dog.Lokal.Id==korisnikZaBrisanje.mojLokal.Id).ToListAsync();
                if(dogadjaji!=null)
                db.Dogadjaji.RemoveRange(dogadjaji);
                List<Recenzija> recenzije=await db.Recenzije.Where(rec => rec.LokalId==korisnikZaBrisanje.mojLokal.Id).ToListAsync();
                if(recenzije!=null)
                db.Recenzije.RemoveRange(recenzije);
                List<Rezervacija> rezervacije=await db.Rezervacije.Where(rez =>rez.LokalId==korisnikZaBrisanje.mojLokal.Id).ToListAsync();
                if(rezervacije!=null)
                foreach(Rezervacija rez in rezervacije)
                { {
                         
                 string sadrzajMejla=$"Dear {rez.Korisnik.Ime}, \n\n Your reservation at {rez.Lokal.Naziv} for {rez.Vreme} has been canceled. Sorry for inconvenience.\n\n Check out our website for other places to make reservations at.\n\n\n Table4U";
               RegisterModel.SendEmail("Table4U",rez.Korisnik.eMail,"Your reservation has been canceled",sadrzajMejla);
                }
                db.Rezervacije.RemoveRange(rezervacije);
                }
                db.Stolovi.RemoveRange(await db.Stolovi.Where(sto =>sto.Lokal.Id==korisnikZaBrisanje.mojLokal.Id).ToListAsync());
                int korId=korisnikZaBrisanje.mojLokal.Id;
                db.Korisnici.Remove(korisnikZaBrisanje);
                db.Lokali.Remove(db.Lokali.Where(lokal =>lokal.Id==korId).FirstOrDefault());
               
            }
            else
            if(korisnikZaBrisanje.tipKorisnika=="Gost")
            {
                db.Rezervacije.RemoveRange(await db.Rezervacije.Where(rez=>rez.KorisnikId==korisnikZaBrisanje.Id).ToListAsync());
                db.Recenzije.RemoveRange(await db.Recenzije.Where(rec =>rec.KorisnikId==korisnikZaBrisanje.Id).ToListAsync());
                db.Korisnici.Remove(korisnikZaBrisanje);
            }  
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
            public  string GetBaseUrl()
{
    var request = HttpContext.Request;

    var host = request.Host.ToUriComponent();

    var pathBase = request.PathBase.ToUriComponent();

    return $"{request.Scheme}://{host}{pathBase}";
}
        

    }
}
