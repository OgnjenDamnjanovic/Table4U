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
    public class ListedEventsModel : PageModel
    {
        public String Message {get; set;}
        public Korisnik TKorisnik {get; set;}
        //public Lokal lokal {get; set;}
        public List<Dogadjaj> listaDogadjaja {get; set;}
        [BindProperty]
        public Dogadjaj trDogadjaj {get; set;}
        private readonly Table4UContext db;
        public ListedEventsModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public IActionResult OnGet()
        {
            String eMail = HttpContext.Session.GetString("email");
            if(eMail==null)
                return RedirectToPage("/Login");
            Message = "Manager";
            TKorisnik = db.Korisnici.Include(x=>x.mojLokal).Where(x=>x.eMail == eMail).FirstOrDefault();
            //TKorisnik = db.Korisnici.Include(kor=>kor.mojLokal).Where(x=>x.Id==3).FirstOrDefault();
            Lokal lokal = db.Lokali.Where(x=>x.Id == TKorisnik.mojLokal.Id).Include(x=>x.listaStolova).Include(x=>x.listaDogadjaja).Include(x=>x.listaRezervacija).ThenInclude(x=>x.Sto).FirstOrDefault();
            listaDogadjaja = lokal.listaDogadjaja.Where(x=>x.Datum > DateTime.Now).ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if(trDogadjaj.Id==0)
            {
                String eMail = HttpContext.Session.GetString("email");
                Message = "Manager";
                TKorisnik = db.Korisnici.Include(x=>x.mojLokal).Where(x=>x.eMail == eMail).FirstOrDefault();
                //TKorisnik = db.Korisnici.Include(kor=>kor.mojLokal).Where(x=>x.Id==3).FirstOrDefault();
                trDogadjaj.Lokal = TKorisnik.mojLokal;
                db.Dogadjaji.Add(trDogadjaj);
                db.SaveChanges();
                return RedirectToPage();
            }
            else
            {
                db.Attach(trDogadjaj).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToPage();
            }
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var dog = await db.Dogadjaji.FindAsync(id);
            if(dog!=null)
            {
                db.Dogadjaji.Remove(dog);
                await db.SaveChangesAsync();
            }
            return RedirectToPage();
        }


    }
}
