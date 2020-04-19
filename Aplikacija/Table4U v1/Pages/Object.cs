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
    public class ObjectModel : PageModel
    {

        public String Message {get; set;}

        [BindProperty]
        public IList<Lokal> ListaLokala {get; set;}

        private readonly Table4UContext db;
        
        public ObjectModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public void OnGet()
        {
            ListaLokala = db.Lokali.ToList();
            String eMail = HttpContext.Session.GetString("email");
            if (!string.IsNullOrEmpty(eMail))
            {
                var korisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
                Message = "Welcome, " + korisnik.Ime;
            }
        }

        public void OnGetLogout()
        {
            ListaLokala = db.Lokali.ToList();
            HttpContext.Session.Remove("email");
            Message = null;
        }
    }
}
