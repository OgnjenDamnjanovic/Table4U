using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
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
      
        private Table4UContext dbContext;
        public RegisterModel(Table4UContext db)
        {
            dbContext = db;
        }
        public IActionResult OnGetAsync(string mail, string hash)
        {   
           
            ErrorMessage="";
            if(mail!=null &&hash!=null)
            {
                Korisnik zaAktivaciju=dbContext.Korisnici.Where(korisnik =>korisnik.eMail==mail&&korisnik.hash==hash).FirstOrDefault();
                if(zaAktivaciju==null||zaAktivaciju.tipKorisnika!="Gost")
                return RedirectToPage("/Index");
                else if(zaAktivaciju.validanNalog)
                {
                     HttpContext.Session.SetString("email", zaAktivaciju.eMail);
                     
                     return RedirectToPage("/Success");
                }
                else
                {
                    zaAktivaciju.validanNalog=true;
                    HttpContext.Session.SetString("email", zaAktivaciju.eMail);
                    dbContext.SaveChangesAsync();
                  
                    return RedirectToPage("/Success");
                    
                }
            }
            else
            {
            string mejl=HttpContext.Session.GetString("email");
            if(mejl!=null)
            return RedirectToPage("/Index");
            return Page();
            
            }
            

            
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
                TKorisnik=null;
                ErrorMessage = "This email address is already used";
                return Page();
            }
         
            NoviKorisnik.tipKorisnika=(wantBusiness.Count==1)?"Menadzer":"Gost";
            NoviKorisnik.Ime =firstname;
            NoviKorisnik.Prezime = lastname;
            NoviKorisnik.eMail = email;
            NoviKorisnik.Sifra = password;
            NoviKorisnik.validanNalog=false;
            NoviKorisnik.hash=Guid.NewGuid().ToString();
            

                dbContext.Korisnici.Add(NoviKorisnik);
                await dbContext.SaveChangesAsync();
                string link=GetBaseUrl();
                link+=NoviKorisnik.tipKorisnika=="Gost"?"/Register?mail=":"/MyRestaurantForm?mail=";
                link+=NoviKorisnik.eMail+"&hash="+NoviKorisnik.hash;
                string sadrzajMejla=$"Dear {NoviKorisnik.Ime}, \n\n In order to verify your Table4U account, please click on the link down below\n {link} \n Thank you for using our website.";
                SendEmail("Table4U",NoviKorisnik.eMail,"Finish Registration Process",sadrzajMejla);
             
                 HttpContext.Session.SetString("newAccEmail",NoviKorisnik.eMail);
                 return RedirectToPage("/EmailSent");
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

public static void SendEmail(string from, string to, string subject, string body)
{
    var fromAddress = new MailAddress("Table4U.Register@gmail.com");
var fromPassword = "elfak1234";
var toAddress = new MailAddress(to);



System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
{
    Host = "smtp.gmail.com",
    Port = 587,
    EnableSsl = true,
    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
    UseDefaultCredentials = false,
    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)       
};

using (var message = new MailMessage(fromAddress, toAddress)
{
    Subject = subject,
    Body = body
})

smtp.Send(message);
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
