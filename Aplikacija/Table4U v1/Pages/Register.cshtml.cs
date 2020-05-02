using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWEProject.Models;

namespace MyApp.Namespace
{
    public class RegisterModel : PageModel
    {
       
        [BindProperty]
        public Korisnik TKorisnik { get; set; }
        
        [BindProperty(Name="firstname")]
        public String firstname {get; set;}
        [BindProperty(Name="lastname")]
        public String lastname {get; set;}
        [BindProperty(Name="email")]
        public String email {get; set;}
        [BindProperty(Name="password")]
        public String password {get; set;}
        [BindProperty]
        public List<string> wantBusiness { get; set; }
        [BindProperty(Name="confirm_password")]
        public String confirmPassword { get; set; }
        [BindProperty]
        public string ErrorMessage {get; set;} 
        [BindProperty]
        public string  Message { get; set; }
        [BindProperty]
        public string loginSuccessful { get; set; }="-";
        private Table4UContext dbContext;
        public RegisterModel(Table4UContext db)
        {
            dbContext = db;
        }
        public async Task OnGetAsync()
        {   
            ErrorMessage="";
            
        }

        public async Task<IActionResult> OnPostAsync()
        {  
                      
            if(!IsValidEmail(email)||invalidInput(firstname)||invalidInput(lastname)||String.IsNullOrEmpty(password)||string.IsNullOrEmpty(confirmPassword)||String.Compare(password,confirmPassword)!=0||password.Length<5)
              {
                return Page();
           }         
            
              Korisnik NoviKorisnik = new Korisnik();
            var postojeciKorisnik = dbContext.Korisnici.Where(kor =>kor.eMail==email).FirstOrDefault();
            if(postojeciKorisnik!=null)
            {
                ErrorMessage = "This email address is already used";
                return Page();
            }
         
            NoviKorisnik.tipKorisnika="Gost";
            NoviKorisnik.Ime =firstname;
            NoviKorisnik.Prezime = lastname;
            NoviKorisnik.eMail = email;
            NoviKorisnik.Sifra = password;
            

           
            if(wantBusiness.Count==1)
            {
                HttpContext.Session.SetString("p_firstname", NoviKorisnik.Ime);
                HttpContext.Session.SetString("p_lastname", NoviKorisnik.Prezime);
                HttpContext.Session.SetString("p_email", NoviKorisnik.eMail);
                HttpContext.Session.SetString("p_password", NoviKorisnik.Sifra);
               
                 return RedirectToPage("/MyRestaurantForm");
            }
            else
            {
                dbContext.Korisnici.Add(NoviKorisnik);
                await dbContext.SaveChangesAsync();
                 HttpContext.Session.SetString("email", NoviKorisnik.eMail);
                 loginSuccessful="success";
                 return Page();
            }
        }
        public bool IsValidEmail(string emailaddress)
{
    try
    {
        MailAddress m = new MailAddress(emailaddress);
        return true;
    }
    catch (FormatException)
    {
        return false;
    }
}


    public bool invalidInput(string input)
    {
        return String.IsNullOrEmpty(input)||String.IsNullOrWhiteSpace(input);
    }

    }
}
