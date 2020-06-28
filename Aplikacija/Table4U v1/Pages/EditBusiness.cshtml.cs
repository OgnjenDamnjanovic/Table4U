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
using Microsoft.EntityFrameworkCore;
using SWEProject.Models;

namespace MyApp.Namespace
{
    public class EditBusinessModel : PageModel
    {
        private IWebHostEnvironment  _environment;
        public EditBusinessModel(IWebHostEnvironment environment,Table4UContext _db)
        {
            _environment = environment;
            db=_db;
        }
        [BindProperty]
        public string folder { get; set; }
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

      public Korisnik TKorisnik { get; set; }
       
        public async Task<IActionResult> OnGetAsync()
        {
           
            string email=HttpContext.Session.GetString("email");
            if(email==null)
            return RedirectToPage("/Index");
            Korisnik menadzer=await db.Korisnici.Where(k =>k.eMail==email&&k.tipKorisnika=="Menadzer"&&k.validanNalog).Include(x=>x.mojLokal).AsNoTracking().FirstOrDefaultAsync();

            if(menadzer==null)
            return RedirectToPage("/Index");
             noviLokal=db.Lokali.Where(lok =>lok.Id==menadzer.mojLokal.Id).Include(s =>s.listaStolova).AsNoTracking().FirstOrDefault();
             TKorisnik=menadzer;
             Message = "Manager";
             tableLayout="";
            for (int i=0;i<noviLokal.listaStolova.Count;i++)
            {
                tableLayout=tableLayout+noviLokal.listaStolova[i].gsX+"`"+noviLokal.listaStolova[i].gsY+"`"+noviLokal.listaStolova[i].gsWidth+"`"+noviLokal.listaStolova[i].gsHeight+"`"+noviLokal.listaStolova[i].oznaka+"`"+noviLokal.listaStolova[i].brojMesta;

                if(i!=noviLokal.listaStolova.Count-1)
                tableLayout=tableLayout+"~";
            }

            glavnaSlika="data:image/jpeg;base64,";
            glavnaSlika+=Convert.ToBase64String(System.IO.File.ReadAllBytes(Path.Combine(_environment.ContentRootPath, "wwwroot/"+noviLokal.nazivSlike)));
            if(noviLokal.slika1!=null)
            {
             slika1="data:image/jpeg;base64,";
            slika1+=Convert.ToBase64String(System.IO.File.ReadAllBytes(Path.Combine(_environment.ContentRootPath, "wwwroot/"+noviLokal.slika1)));
            }
            if(noviLokal.slika2!=null)
            {
             slika2="data:image/jpeg;base64,";
            slika2+=Convert.ToBase64String(System.IO.File.ReadAllBytes(Path.Combine(_environment.ContentRootPath, "wwwroot/"+noviLokal.slika2)));
            }
            if(noviLokal.slika3!=null)
            {
             slika3="data:image/jpeg;base64,";
            slika3+=Convert.ToBase64String(System.IO.File.ReadAllBytes(Path.Combine(_environment.ContentRootPath, "wwwroot/"+noviLokal.slika3)));
            }
            if(noviLokal.slika4!=null)
            {
             slika4="data:image/jpeg;base64,";
            slika4+=Convert.ToBase64String(System.IO.File.ReadAllBytes(Path.Combine(_environment.ContentRootPath, "wwwroot/"+noviLokal.slika4)));
            }
            if(noviLokal.slika5!=null)
            {
             slika5="data:image/jpeg;base64,";
            slika5+=Convert.ToBase64String(System.IO.File.ReadAllBytes(Path.Combine(_environment.ContentRootPath, "wwwroot/"+noviLokal.slika5)));
            }
          folder=noviLokal.nazivSlike.Split("/")[1];



            return Page();
            

        } 
     public IActionResult OnPostCancel()
     {
       return RedirectToPage("/User");
     }
        public async Task<IActionResult> OnPostNextAsync()
        { 
          
          
          string email=HttpContext.Session.GetString("email");
            if(email==null)
            return RedirectToPage("/Index");
            Korisnik korisnik=db.Korisnici.Where(kor=>kor.eMail==email&&kor.tipKorisnika=="Menadzer"&&kor.validanNalog==true).FirstOrDefault();
            if(korisnik==null)
            return RedirectToPage("/Index");
            Korisnik korBaza=db.Korisnici.Where(korisnik=>korisnik.eMail==email).Include(x=>x.mojLokal).AsNoTracking().FirstOrDefault();
            if(korBaza==null)
            return RedirectToPage("/Index");
            if(noviLokal.Id!=korBaza.mojLokal.Id)
            return RedirectToPage("/Index");
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
          System.IO.DirectoryInfo di = new DirectoryInfo( Path.Combine(_environment.ContentRootPath, "wwwroot/images/"+folder));

          foreach (FileInfo file in di.GetFiles())
          {
                file.Delete(); 
          }
         string folderName=folder;
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
             RedirectToPage("/Error?errorCode="+fe);
         }
          
         string stariLayout="";
          List<Sto> stariStolovi=db.Stolovi.Where(sto => sto.Lokal.Id==noviLokal.Id).ToList();
            for (int i=0;i<stariStolovi.Count;i++)
            {
                stariLayout=stariLayout+stariStolovi[i].gsX+"`"+stariStolovi[i].gsY+"`"+stariStolovi[i].gsWidth+"`"+stariStolovi[i].gsHeight+"`"+stariStolovi[i].brojMesta+"`"+stariStolovi[i].oznaka;

                if(i!=stariStolovi.Count-1)
                stariLayout=stariLayout+"~";
            }
            if(String.Compare(stariLayout,tableLayout)!=0)
            {
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
                  
                  
                  foreach(Sto sto in stariStolovi)
                  { 
                      foreach(Rezervacija rez in db.Rezervacije.Where(rezer => rezer.Sto.Id==sto.Id).ToList())
                     {  if(rez.Vreme>DateTime.Now)
                        {
                          string sadrzajMejla=$"Dear {rez.Korisnik.Ime}, \n\n Your reservation at {rez.Lokal.Naziv} for {rez.Vreme} has been canceled. Sorry for inconvenience.\n\n Check out our website for other places to make reservations at.\n\n\n Table4U";
                          RegisterModel.SendEmail("Table4U",rez.Korisnik.eMail,"Reservation calceled",sadrzajMejla);
                        }
                        db.Remove(rez);
                     }

                      
                    db.Stolovi.Remove(sto);
                  }
                  noviLokal.listaStolova=noviStolovi;
            }
        korisnik.mojLokal=noviLokal;
      
      
      await db.SaveChangesAsync();
        return RedirectToPage("/Index");
        



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
