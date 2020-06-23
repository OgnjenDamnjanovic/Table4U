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
        public Korisnik TKorisnik {get; set;}
        [BindProperty]
        public String eMail {get; set;}
        [BindProperty]
        public String Sifra {get; set;}
        [BindProperty]
        public String ErrorMessage {get; set;}="";
        public String Message {get; set;}
        private Table4UContext db;
     
        public LoginModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public IActionResult OnGet()
        {
          //  string mejl=HttpContext.Session.GetString("email");
            //if(mejl!=null)
            //return RedirectToPage("/Index");
            //else
            return Page();
        }

        public IActionResult OnPostLogin()
        {
            //TKorisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
            
            Korisnik korisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
            if(korisnik==null)
            {
                ErrorMessage="Invalid email adress.";
                return Page();
            }
            else if(korisnik.Sifra!=Sifra)
            {
                ErrorMessage="Invalid password.";
                return Page();
            }
            else if(!korisnik.validanNalog)
            {
                 string link=GetBaseUrl();
                link+=korisnik.tipKorisnika=="Gost"?"/Register?mail=":"/MyRestaurantForm?mail=";
                link+=korisnik.eMail+"&hash="+korisnik.hash;          
            string sadrzajMejla=$"Dear {korisnik.Ime} \n\n In order to verify your Table4U account, please click on the link below\n {link} \n\n Thank you for using our website.";
               RegisterModel.SendEmail("Table4U",korisnik.eMail,"Finish Registration Process",sadrzajMejla);

                ErrorMessage="Your account is not yet activated. An activation link has just been sent to your email address.";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("email", eMail);
                if(korisnik.tipKorisnika=="Menadzer")
                    return RedirectToPage("/Manager");
                else 
                    return RedirectToPage("/Index");
            }
          
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
