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
     public class ForgotPasswordModel : PageModel
    {
      [BindProperty]
      public string passwordHash { get; set; }
      [BindProperty]
      public string  SifraOpet { get; set; }
      [BindProperty]
      public string  Sifra { get; set; }
          public Korisnik TKorisnik {get; set;}
        public String Message {get; set;}
        private Table4UContext db;
        public string ErrorMessage { get; set; }
       
        [BindProperty]
         public string email { get; set; }
        public ForgotPasswordModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public IActionResult OnGetAsync(string mail, string hash)
        {
         
          Korisnik kor=db.Korisnici.Where(kor =>kor.eMail==mail&&kor.passwordHash==hash).FirstOrDefault();
        if(kor==null)
        return RedirectToPage("/Index");
        email=kor.eMail;
        passwordHash=kor.passwordHash;
        
          return Page();


          
        }
        public IActionResult OnPost()
        {
           if(Sifra!=SifraOpet)
             return RedirectToPage();
           if(Sifra.Length<5)
            return RedirectToPage();
            Korisnik kor=db.Korisnici.Where(kor =>kor.eMail==email&&kor.passwordHash==passwordHash).FirstOrDefault();
            if(kor==null)
            return RedirectToPage("/Index");
            kor.Sifra=Sifra;
            kor.passwordHash=null;
            HttpContext.Session.SetString("email",kor.eMail);
            db.SaveChanges();
            return RedirectToPage("/Index");
           
        }
    }
}
