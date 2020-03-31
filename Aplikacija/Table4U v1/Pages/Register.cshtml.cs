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
    public class RegisterModel : PageModel
    {
        public Korisnik NoviKorisnik {get; set;}
        
        [BindProperty(Name="firstname")]
        public String firstname {get; set;}
        [BindProperty(Name="lastname")]
        public String lastname {get; set;}
        [BindProperty(Name="email")]
        public String email {get; set;}
        [BindProperty(Name="password")]
        public String password {get; set;}
        

        public String ErrorMessage {get; set;} 
        public String Message {get; set;}
        private Table4UContext dbContext;
        public RegisterModel(Table4UContext db)
        {
            dbContext = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            NoviKorisnik = new Korisnik();
            var korisnici = dbContext.Korisnici.ToList();
            var k = korisnici.Where(x=>x.eMail == email).FirstOrDefault();
            if(k!=null)
            {
                ErrorMessage = "This email address is already used";
                return Page();
            }
            /*if(NoviKorisnik.Sifra != ConfSifra)
            {
                return Page();
            }*/
            NoviKorisnik.tipKorisnika = "Gost";
            NoviKorisnik.Ime =firstname;
            NoviKorisnik.Prezime = lastname;
            NoviKorisnik.eMail = email;
            NoviKorisnik.Sifra = password;
            dbContext.Korisnici.Add(NoviKorisnik);
            await dbContext.SaveChangesAsync();

            HttpContext.Session.SetString("email", NoviKorisnik.eMail);
            return RedirectToPage("/Index");
        }
    }
}
