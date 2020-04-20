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
    public class HelpModel : PageModel
    {
        public Korisnik TKorisnik {get; set;}
        public String Message {get; set;}
        private readonly Table4UContext db;
        
        public HelpModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public void OnGet()
        {
            String eMail = HttpContext.Session.GetString("email");
            if (!string.IsNullOrEmpty(eMail))
            {
                var korisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
                Message = "Welcome, " + korisnik.Ime;
            }
            TKorisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
        }

        public void OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            Message = null;
        }
    }
}
