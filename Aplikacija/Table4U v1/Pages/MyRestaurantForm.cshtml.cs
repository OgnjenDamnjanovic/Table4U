using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SWEProject.Models;

namespace MyApp.Namespace
{
    public class MyRestaurantFormModel : PageModel
    {
        private IWebHostEnvironment  _environment;
        public MyRestaurantFormModel(IWebHostEnvironment environment,Table4UContext _db)
        {
            _environment = environment;
            db=_db;
        }
        private Table4UContext db{get;set;}
        [BindProperty]
        public string glavnaSlika { get; set; }
        [BindProperty]
        public string slika1 { get; set; }
        [BindProperty]
        public string slika2 { get; set; }
        [BindProperty]
        public string slika3 { get; set; }
        [BindProperty]
        public string slika4 { get; set; }
        [BindProperty]
        public string slika5 { get; set; }
        [BindProperty]
        public string tableLayout { get; set; }
        [BindProperty]
        public Lokal noviLokal { get; set; }
        public string ErrorMessage { get; set; }
        [BindProperty(SupportsGet=true)]
        public string Message { get; set; }
   [BindProperty]
      public string email{get;set;}
      [BindProperty(SupportsGet=true)]
      public string guid{get;set;}
      public Korisnik TKorisnik { get; set; }
       
        public async Task<IActionResult> OnGetAsync(string mail, string hash)
        {  if(mail==null||hash==null)
        return RedirectToPage("/Index");
        Korisnik korisnik=db.Korisnici.Where(korisnik =>korisnik.hash==hash&&korisnik.eMail==mail&&korisnik.tipKorisnika=="Menadzer").FirstOrDefault();
          if(korisnik==null)           
            return RedirectToPage("/Index");
            else if(korisnik.validanNalog)
            {
               HttpContext.Session.SetString("email",korisnik.eMail);
              return RedirectToPage("/Success");
            }
            else
            {email=mail;
              guid=hash;
            return Page();
            }
            
            

        } 
        public async Task<IActionResult> OnPostCustomerAsync()
        {
          Korisnik zaAktivaciju=db.Korisnici.Where(Korisnik=>Korisnik.eMail==email&&Korisnik.hash==guid).FirstOrDefault();
          zaAktivaciju.validanNalog=true;
          zaAktivaciju.tipKorisnika="Gost";
         await db.SaveChangesAsync();
          HttpContext.Session.SetString("email",zaAktivaciju.eMail);
          return RedirectToPage("/Success");
         
          }
        public async Task<IActionResult> OnPostNextAsync()
        { 
            int validImageCount=0;
            if(!string.IsNullOrEmpty(slika1))
            validImageCount++;
              if(!string.IsNullOrEmpty(slika2))
            validImageCount++;
              if(!string.IsNullOrEmpty(slika3))
            validImageCount++;
              if(!string.IsNullOrEmpty(slika4))
            validImageCount++;
              if(!string.IsNullOrEmpty(slika5))
            validImageCount++;
          
            if(validImageCount<3||string.IsNullOrEmpty(glavnaSlika)||!validTableLayout(tableLayout)||!validNoviLokal())
            return RedirectToPage();

         string folderName=System.Guid.NewGuid().ToString();
         string fileName="";
         try
         {
              if(!string.IsNullOrEmpty(slika1))
              {
                fileName=saveBase64AsImage(slika1,folderName);
                noviLokal.slika1="images/"+folderName+"/"+fileName;
              }
                if(!string.IsNullOrEmpty(slika2))
              {
                fileName=saveBase64AsImage(slika2,folderName);
                noviLokal.slika2="images/"+folderName+"/"+fileName;
              }
                if(!string.IsNullOrEmpty(slika3))
              {
                fileName=saveBase64AsImage(slika3,folderName);
                noviLokal.slika3="images/"+folderName+"/"+fileName;
              }
                if(!string.IsNullOrEmpty(slika4))
              {
                fileName=saveBase64AsImage(slika4,folderName);
                noviLokal.slika4="images/"+folderName+"/"+fileName;
              }
                if(!string.IsNullOrEmpty(slika5))
              {
                fileName=saveBase64AsImage(slika5,folderName);
                noviLokal.slika5="images/"+folderName+"/"+fileName;
              }
                if(!string.IsNullOrEmpty(glavnaSlika))
              {
                fileName=saveBase64AsImage(glavnaSlika,folderName);
                noviLokal.nazivSlike="images/"+folderName+"/"+fileName;
              }
         }
         catch(FormatException fe)
         {
             RedirectToPage();
         }
         
         int counter=1;
         List<Sto> noviStolovi=new List<Sto>(tableLayout.Split('~').Length);
         int objectSeatsCount=0;
         Sto noviSto=new Sto();
        foreach(string num in tableLayout.Split(new char[]{'`','~'}))
        {
          if(counter==1)
          noviSto.gsX=int.Parse(num);
          else if(counter==2)
          noviSto.gsY=int.Parse(num);
          else if(counter==3)
          noviSto.gsWidth=int.Parse(num);
          else if(counter==4)
          noviSto.gsHeight=int.Parse(num);
          else if(counter==5)
         { noviSto.brojMesta=int.Parse(num);
          objectSeatsCount+=int.Parse(num);
         }
         else
         {
         noviSto.oznaka=num;
         noviStolovi.Add(noviSto);
         noviSto=new Sto();
         
         }
         counter=counter%6+1;
         

        

        }
        noviLokal.maxKapacitet=objectSeatsCount;
        noviLokal.listaStolova=noviStolovi;
        
        Korisnik noviKorisnik=db.Korisnici.Where(korisnik =>korisnik.hash==guid&&korisnik.eMail==email&&korisnik.tipKorisnika=="Menadzer"&&!korisnik.validanNalog).FirstOrDefault();
        if(noviKorisnik==null)
        return RedirectToPage("/Index");
        noviKorisnik.validanNalog=true;
        noviKorisnik.mojLokal=noviLokal;
       

        HttpContext.Session.SetString("email",noviKorisnik.eMail);
        await   db.SaveChangesAsync();
        return RedirectToPage("/Success");
        



        }

        public string saveBase64AsImage(string img,string folderName)
        {
            img=img.Substring(img.IndexOf(',') + 1);
            var imgConverted=Convert.FromBase64String(img);
            
            string imgName=System.Guid.NewGuid().ToString();

            var file = Path.Combine(_environment.ContentRootPath, "wwwroot/images/"+folderName+"/"+imgName+".jpg");
           Directory.CreateDirectory(Path.GetDirectoryName(file));
           

            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                fileStream.Write(imgConverted, 0, imgConverted.Length);
                    fileStream.Flush();
                
            }
            return imgName+".jpg";
        }
        public bool validTableLayout(string serializedTableLayout)
        {
          string[] splitted=serializedTableLayout.Split(new char[]{'`','~'});
          int counter=1;
          foreach(string tableInfo in splitted )
          {
            if(splitted.Length%6!=0||splitted.Length<6)
            return false;
            if(counter!=6)
            {
              if(!int.TryParse(tableInfo,out _))
              {
                return false;
              }
              if((counter==1||counter==3)&&(int.Parse(tableInfo)<0&&int.Parse(tableInfo)>11))
              {
                  return false;
              }
              if((counter==2||counter==4)&&(int.Parse(tableInfo)<0))
              {
                  return false;
              }
              if(counter==5&& (int.Parse(tableInfo)<1||int.Parse(tableInfo)>99999))
              {
                    return false;
              }


              counter++;

            }
            else
            {
              if(string.IsNullOrEmpty(tableInfo)||string.IsNullOrWhiteSpace(tableInfo)||tableInfo.Length>7||tableInfo.Contains("`")||tableInfo.Contains("~"))
              return false;
              counter=1;
            }

          }
          return true;

        }
        public bool validNoviLokal()
        {
          if(string.IsNullOrEmpty(noviLokal.Adresa)||(string.IsNullOrWhiteSpace(noviLokal.Adresa)))
          return false;
          if(string.IsNullOrEmpty(noviLokal.Grad)||(string.IsNullOrWhiteSpace(noviLokal.Grad)))
          return false;
          if(string.IsNullOrEmpty(noviLokal.opis)||(string.IsNullOrWhiteSpace(noviLokal.opis)))
          return false;
          if(string.IsNullOrEmpty(noviLokal.Naziv)||(string.IsNullOrWhiteSpace(noviLokal.Naziv)))
          return false;
          if(noviLokal.Tip!="Restaurant"&&noviLokal.Tip!="Cafe"&&noviLokal.Tip!="Club"&&noviLokal.Tip!="Tavern"&&noviLokal.Tip!="Bar"&&noviLokal.Tip!="Pub")
            {
              return false;
            }
            if(!IsValidEmail(noviLokal.email))
            return false;
            return true;

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
        
    }
}
