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
    public class EmailSentModel : PageModel
    {
          public Korisnik TKorisnik {get; set;}
        public String Message {get; set;}
        private Table4UContext db;
        [BindProperty]
        public string txt { get; set; }="";
        [BindProperty]
         public string email { get; set; }
        public EmailSentModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public IActionResult OnGetAsync()
        {
          string emailNew= HttpContext.Session.GetString("newAccEmail");
          if(emailNew==null)
          return RedirectToPage("/Index");
          Korisnik noviKorisnik=db.Korisnici.Where(korisnik =>korisnik.eMail==emailNew).FirstOrDefault();
          if(noviKorisnik==null||noviKorisnik.validanNalog)
          return RedirectToPage("/Index");
          if(noviKorisnik.tipKorisnika=="Gost")
          txt ="After activation, you can pick Table4Urself :)";
          email=noviKorisnik.eMail;
          return Page();


          
        }
        public IActionResult OnPostAsync()
        {  string emailNew= HttpContext.Session.GetString("newAccEmail");
         if(emailNew==null)
          return RedirectToPage("/Index");
             Korisnik NoviKorisnik=db.Korisnici.Where(korisni =>korisni.eMail==emailNew).FirstOrDefault();
                if(NoviKorisnik==null)
                return RedirectToPage("/Index");
                string link=GetBaseUrl();
                link+=NoviKorisnik.tipKorisnika=="Gost"?"/Register?mail=":"/MyRestaurantForm?mail=";
                link+=NoviKorisnik.eMail+"&hash="+NoviKorisnik.hash;          
            string sadrzajMejla=$"Dear {NoviKorisnik.Ime} \n\n In order to verify your Table4U account, please click on the link below\n {link} \n\n Thank you for using our website.";
               RegisterModel.SendEmail("Table4U",NoviKorisnik.eMail,"Finish Registration Process",sadrzajMejla);
               return RedirectToPage();
           
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
