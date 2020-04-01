using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SWEProject.Models;
using Microsoft.EntityFrameworkCore;


namespace Table4U.Pages
{
    public class IndexModel : PageModel
    {
        public String Message {get; set;}
        private readonly Table4UContext db;
        [BindProperty]
        public IList<Lokal> ListaLokala {get; set;}
        public IndexModel(Table4UContext dataBase)
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
        /*public async Task OnGetAsync()
        {
           ListaLokala = await db.Lokali.ToListAsync();
           String eMail = HttpContext.Session.GetString("email");
            if (!string.IsNullOrEmpty(eMail))
            {
                var korisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
                Message = "Welcome, " + korisnik.Ime;
            }
        }*/

        public void OnGetLogout()
        { 
            ListaLokala = db.Lokali.ToList();
            HttpContext.Session.Remove("email");
            Message = null;
        }
    }
}
