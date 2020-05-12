using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SWEProject.Models;

namespace MyApp.Namespace
{
    public class ObjectModel : PageModel
    {   
        [BindProperty]
        public int idObj{get;set;}
        [BindProperty]
        public int day {get;set;}
        [BindProperty]
        public int month {get;set;}
        [BindProperty]
        public int year {get;set;} 
        [BindProperty]
        public int brMesta {get;set;}
        [BindProperty]
        public string vreme {get;set;}
        [BindProperty]
        public int rejting {get;set;}
        [BindProperty]
        public string komentar {get;set;}
        public string ErrorM {get;set;}
        public Rezervacija NovaRezervacija {get;set;}
        public Recenzija NovaRecenzija {get;set;}
        public Korisnik TKorisnik {get; set;}
        public List<int> listabrMesta {get;set;}
        public IList<Lokal> slicniLokali {get;set;}
        public Lokal lokal {get;set;}
        public String Message {get; set;}
        public List<string> listaSlika {get;set;}
        private readonly Table4UContext db;
        
        public ObjectModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        
        public void OnGet(int Id)
        {
            listaSlika=new List<string>();
            List<Lokal> ListaLokala = new List<Lokal>();
            ListaLokala = db.Lokali.Include(x=>x.listaStolova)
                                .Include(x=>x.listaDogadjaja).Include(x=>x.listaRezervacija)
                                .Include(x=>x.listaRecenzija).ToList();
            lokal = ListaLokala.Where(x=>x.Id==Id).FirstOrDefault();
            if(lokal.slika1!=null)
                listaSlika.Add(lokal.slika1);
            if(lokal.slika2!=null)
                listaSlika.Add(lokal.slika2);
            if(lokal.slika3!=null)    
                listaSlika.Add(lokal.slika3);
            if(lokal.slika4!=null)    
                listaSlika.Add(lokal.slika4);
            if(lokal.slika5!=null)    
                listaSlika.Add(lokal.slika5);
            
            List<int> listaSt=new List<int>();
            listabrMesta=new List<int>();
            int i=0;
            var lista = lokal.listaStolova.OrderBy(x=>x.brojMesta);
            for(i=0;i<lista.Count();i++)
            {
                listaSt.Add(lista.ElementAt(i).brojMesta);
            }
            var lista1 = listaSt.Distinct();
            for(i=0;i<lista1.Count();i++)
            {
                listabrMesta.Add(lista1.ElementAt(i));
            }

            slicniLokali=db.Lokali.Where(x=>x.Tip.Equals(lokal.Tip)).ToList();
            slicniLokali.Remove(lokal);

            String eMail = HttpContext.Session.GetString("email");
            TKorisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
            if (!string.IsNullOrEmpty(eMail))
            {
                if(TKorisnik.tipKorisnika=="Menadzer")
                {
                    Message=null;
                }
                else
                {
                    var korisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
                    Message = "Welcome, " + korisnik.Ime;
                }
            }
        }

        public void OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            Message = null;
        }

        public List<string> napuniListu()
        {
            List<string> vremena = new List<string>();
            string time;
            string[] cetvrtSat = {"00","15","30","45"};
            for(int i=12;i<24;i++){
                for(int j=0;j<4;j++){
                    time = (i+":"+cetvrtSat[j]).ToString();
                    vremena.Add(time);
                }
            }

            for(int i=0;i<8;i++)
            {
                vremena.Add(("00:0"+i).ToString());
                vremena.Add(("24:0"+i).ToString());
            }

            return vremena;
        }

        public ActionResult OnGetProveri(int sto, int id, String date)
        {
            var lokal1 = db.Lokali.Include(x=>x.listaStolova).Include(x=>x.listaRezervacija).Where(x=>x.Id==id).FirstOrDefault();
            var brstolova = lokal1.listaStolova.Where(x=>x.brojMesta==sto).ToList().Count();

            List<string> listakon = new List<string>();
            List<string> vremena=new List<string>();

            if(!date.Equals("Year-0-Day"))
            {
                string[] datum = date.Split("-");
                int dan = Int32.Parse(datum[2]);
                int mesec = Int32.Parse(datum[1]);
                int godina = Int32.Parse(datum[0]);

                vremena=napuniListu();
                var rezervacije = lokal1.listaRezervacija.Where(x=>x.Sto.brojMesta==sto).
                Where(x=>x.Vreme.Year.Equals(godina) && x.Vreme.Month == mesec && x.Vreme.Day.Equals(dan)).ToList();

                foreach(var r in rezervacije)
                {
                    if(r.Vreme.TimeOfDay.Minutes.Equals(0))
                        vremena.Add((r.Vreme.TimeOfDay.Hours + ":00").ToString());
                    else
                        vremena.Add((r.Vreme.TimeOfDay.Hours + ":" + r.Vreme.TimeOfDay.Minutes).ToString());
                }
                
                var grupisano = vremena.GroupBy(x=>x).Select(group => new { 
                             Count = group.Count(),
                             Key = group.Key
                        }).OrderBy(x=>x.Key);
                
                for(int k=8;k<=grupisano.Count()-9;k++)
                {
                    int broj=0;
                    for(int i=k;i<=k+7;i++)
                        broj=broj+((grupisano.ElementAt(i).Count)-1);
                    for(int j=k-1;j>=k-7;j--)
                       broj=broj+((grupisano.ElementAt(j).Count)-1);
                    if(broj>=brstolova)
                        listakon.Add(grupisano.ElementAt(k).Key);
                }
            }
            return new JsonResult(listakon);
        }

        public async Task<IActionResult> OnPostRez()
        {
            var lokal1 = db.Lokali.Include(x=>x.listaStolova).Include(x=>x.listaRezervacija).Where(x=>x.Id==idObj).FirstOrDefault();
            var brstolova = lokal1.listaStolova.Where(x=>x.brojMesta==brMesta).ToList().Count();
            var rezervacije = lokal1.listaRezervacija.Where(x=>x.Sto.brojMesta==brMesta).
            Where(x=>x.Vreme.Year.Equals(year) && x.Vreme.Month==month && x.Vreme.Day.Equals(day)).ToList();
            String eMail = HttpContext.Session.GetString("email");
            TKorisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
            List<string> vremena = new List<string>();
            List<int> idStolova = new List<int>();
            vremena=napuniListu();

            var niz = vreme.Split(":");
            if(niz[1].Equals("00"))
                niz[1]="0";

            //prikupljamo Id-eve svih stolova sa istim brojem mesta
            foreach(var a in lokal1.listaStolova.Where(x=>x.brojMesta==brMesta).ToList())
            {
                idStolova.Add(a.Id);
            }

            //vreme svake rezervacije smestamo u listu vremena
            foreach(var r in rezervacije)
            {
                if(r.Vreme.TimeOfDay.Minutes.Equals(0))
                    vremena.Add((r.Vreme.TimeOfDay.Hours + ":00").ToString());
                else
                    vremena.Add((r.Vreme.TimeOfDay.Hours + ":" + r.Vreme.TimeOfDay.Minutes).ToString());
            }

            //grupisemo vremena u listi
            var grupisano = vremena.GroupBy(x=>x).Select(group => new { 
                             Count = group.Count(),
                             Key = group.Key
                        }).OrderBy(x=>x.Key);   

            //trazimo prosledjeno vreme
            var nadjen = 0;
            var i = 0;
            while(nadjen!=1)
            {
                if(grupisano.ElementAt(i).Key.Equals(vreme))
                    nadjen=1;
                else
                    i++;
            }

            //prolazimo kroz susedne elemente da napravimo spisak vremena za postojece rezervacije
            List<string> listavr = new List<string>();
            for(int l=i;l<=i+7;l++)
            {
                if(grupisano.ElementAt(l).Count>1)
                    listavr.Add(grupisano.ElementAt(l).Key);
            }
            for(int j=i-1;j>=i-7;j--)
            {
                if(grupisano.ElementAt(j).Count>1)
                    listavr.Add(grupisano.ElementAt(j).Key);
            }

            //pronalazimo rezervacije i Id stola izbacujemo iz liste Id-eva 
            for(var j=0;j<listavr.Count;j++)
            {
                for(var k=0;k<rezervacije.Count;k++)
                    if(rezervacije.ElementAt(k).Vreme.TimeOfDay.ToString().Contains(listavr.ElementAt(j)))
                        idStolova.Remove(rezervacije.ElementAt(k).Sto.Id);
            }
            
            /*if(idStolova.Count==0)
                neko je u medjuvremenu rezervisao*/

            if(TKorisnik==null)
                return RedirectToPage("./Login");
            else
            {   
                NovaRezervacija = new Rezervacija();
                DateTime datum = new DateTime(year,month,day,Int32.Parse(niz[0]),Int32.Parse(niz[1]),0);
                NovaRezervacija.Vreme=datum;
                NovaRezervacija.LokalId=idObj;
                NovaRezervacija.Lokal=db.Lokali.Where(x=>x.Id.Equals(idObj)).FirstOrDefault();
                NovaRezervacija.Sto=db.Stolovi.Where(x=>x.Id.Equals(idStolova[0])).FirstOrDefault();
                NovaRezervacija.Korisnik=db.Korisnici.Where(x=>x.Id.Equals(TKorisnik.Id)).FirstOrDefault();
                NovaRezervacija.VremeKreiranja=DateTime.Now;
                NovaRezervacija.KorisnikId=TKorisnik.Id;
                db.Rezervacije.Add(NovaRezervacija);
                await db.SaveChangesAsync();
                return Redirect(("/Object?Id="+idObj).ToString());
            }
        }

        public ActionResult OnGetNabavi(int id, string date)
        {
            var lokal1 = db.Lokali.Include(x=>x.listaDogadjaja).Where(x=>x.Id==id).FirstOrDefault();
            var dogadjaji = lokal1.listaDogadjaja.Where(x=>(x.Datum.ToString("MMMM")).Equals(date)).OrderBy(x=>x.Datum).ToList();
            List<string> info = new List<string>();
            foreach(var d in dogadjaji)
                info.Add((d.Datum.Day).ToString());
            info.Add("|");
            foreach(var o in dogadjaji)
                info.Add(o.Vrsta);
            info.Add("|");
            foreach(var g in dogadjaji)
                info.Add(g.Opis);
            info.Add("|");
            foreach(var a in dogadjaji){
                if(a.Datum.Minute==0)
                    info.Add((a.Datum.Hour + ":00").ToString());
                else    
                    info.Add((a.Datum.Hour + ":" + a.Datum.Minute).ToString());
            }
            info.Add("|");
            
            return new JsonResult(info);
        }

        public async Task<IActionResult> OnPostRec()
        {
            String eMail = HttpContext.Session.GetString("email");
            TKorisnik = db.Korisnici.Where(x=>x.eMail == eMail).FirstOrDefault();
            if(TKorisnik==null)
            {
                return RedirectToPage("./Login");
            }
            else
            {
                Lokal Lokal = db.Lokali.Where(x=>x.Id==idObj).FirstOrDefault();
                NovaRecenzija = new Recenzija();
                NovaRecenzija.Komentar=komentar;
                NovaRecenzija.Datum=DateTime.Now;
                NovaRecenzija.Ocena=rejting;
                NovaRecenzija.LokalId=idObj;
                NovaRecenzija.Lokal=Lokal;
                NovaRecenzija.KorisnikId=TKorisnik.Id;
                NovaRecenzija.Korisnik=db.Korisnici.Where(x=>x.Id==TKorisnik.Id).FirstOrDefault();
            
                db.Recenzije.Add(NovaRecenzija);
                await db.SaveChangesAsync();

                var ocene = db.Recenzije.Where(x=>x.LokalId==idObj).ToList();
                var ukupno = 0;
                for(var i =0;i<ocene.Count;i++)
                    ukupno = ukupno+ocene[i].Ocena;
                float ocena = ukupno/(Lokal.brOcena+1);
                Lokal.Ocena=ocena;
                Lokal.brOcena=(Lokal.brOcena)+1;
                db.Lokali.Update(Lokal);
                await db.SaveChangesAsync();

                return Redirect(("/Object?Id="+idObj).ToString());
            }
        }
    }
}
