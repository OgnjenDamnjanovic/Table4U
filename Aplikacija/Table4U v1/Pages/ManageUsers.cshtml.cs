using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public void OnGet()
        {
            customers=db.Korisnici.Where(korisnik=>korisnik.tipKorisnika=="Gost").ToList();
            managers=db.Korisnici.Where(Korisnik => Korisnik.tipKorisnika=="Menadzer").ToList();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            db.Korisnici.Remove(db.Korisnici.Where(korisnik => korisnik.Id==id).FirstOrDefault());
          await  db.SaveChangesAsync();
           return RedirectToPage();
            
        }



        

    }
}
