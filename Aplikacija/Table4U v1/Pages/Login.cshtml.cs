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
    public class LoginModel : PageModel
    {
        [BindProperty]
        public String eMail {get; set;}
        [BindProperty]
        public String Sifra {get; set;}
        [BindProperty]
        public String ErrorMessage {get; set;}
        public String Message {get; set;}

        private Table4UContext dbContext;

        public LoginModel(Table4UContext db)
        {
            dbContext = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostLogin()
        {
            
            var korisnici = dbContext.Korisnici.ToList();
            Korisnik k = korisnici.Where(x=>x.eMail == eMail && x.Sifra == Sifra).FirstOrDefault();
            if(k!=null)
            {
                HttpContext.Session.SetString("email", eMail);
                return RedirectToPage("/Index");
            }
            else
            {   
                ErrorMessage = "The username or password you have entered is invalid.";
                return Page();
            }
        }
    }
}
