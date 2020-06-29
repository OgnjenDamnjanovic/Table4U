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
        public IList<Recenzija> recenzije {get;set;} 
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
            recenzije = db.Recenzije.Where(x=>x.LokalId == Id).Include(x=>x.Korisnik).ToList();
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
            List<string> vremena1 = new List<string>();
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

            var lista = vremena.OrderBy(x=>x);
            
            foreach(var l in lista)
                vremena1.Add(l);

            return vremena1;
        }

        public ActionResult OnGetProveri(int sto, int id, String date)
        {
            //izvlacimo lokal i broj stolova sa zadatim brojem mesta
            var lokal1 = db.Lokali.Include(x=>x.listaStolova).Include(x=>x.listaRezervacija).Where(x=>x.Id==id).FirstOrDefault();
            var brstolova = lokal1.listaStolova.Where(x=>x.brojMesta==sto).ToList().Count();
            List<string> listakon = new List<string>();
            List<string> konacno = new List<string>();

            if(!date.Equals("Year-0-Day"))
            {
                //sva moguca vremena
                List<string> vremena=new List<string>();
                //vremena rezervacija u lokalu
                List<string> vremena2 = new List<string>();
                //svi moguci id-evi
                List<int> idStolova = new List<int>();
                //id-evi stolova koji su vezani za rezervacije
                List<int> idStolova2 = new List<int>();
                
                string[] datum = date.Split("-");
                int dan = Int32.Parse(datum[2]);
                int mesec = Int32.Parse(datum[1]);
                int godina = Int32.Parse(datum[0]);

                vremena=napuniListu();
                var rezervacije = lokal1.listaRezervacija.Where(x=>x.Sto.brojMesta==sto).
                Where(x=>x.Vreme.Year.Equals(godina) && x.Vreme.Month == mesec && x.Vreme.Day.Equals(dan)).ToList();
                
                foreach(var a in lokal1.listaStolova.Where(x=>x.brojMesta==sto).OrderBy(x=>x.Id).ToList())
                {
                    idStolova.Add(a.Id);
                }

                foreach(var r in rezervacije){
                    idStolova2.Add(r.Sto.Id);
                    if(r.Vreme.TimeOfDay.Minutes.Equals(0)){
                        vremena2.Add((r.Vreme.TimeOfDay.Hours + ":00").ToString());
                    }
                    else{
                        vremena2.Add((r.Vreme.TimeOfDay.Hours + ":" + r.Vreme.TimeOfDay.Minutes).ToString());
                    }
                }

                //kreira se matrica
                int[,] matrica = new int[vremena.Count,brstolova];
                for(var i=0;i<vremena.Count;i++){
                    for(var j=0;j<brstolova;j++){
                        matrica[i,j]=0;
                    }
                }

                //u matrici da se oznace elementi
                for(var i=0;i<vremena2.Count;i++){
                    for(var j=0;j<vremena.Count;j++){
                        if(vremena.ElementAt(j).Equals(vremena2[i]))
                        {
                            var index = idStolova.IndexOf(idStolova2[i]);
                            matrica[j,index]=1;
                        }
                    }
                }

                //2 sata unapred i unazad se provere termini
                for(var k=8;k<vremena.Count-9;k++){
                    List<int> lista4 = new List<int>();
                    var broj=0;
                    for(var i=k;i<k+8;i++){
                        for(var j=0;j<brstolova;j++){
                            if(matrica[i,j]==1){
                                broj++;
                                lista4.Add(idStolova[j]);
                            }
                        }
                    }
                    for(var i=k-1;i>k-8;i--){
                        for(var j=0;j<brstolova;j++){
                            if(matrica[i,j]==1){
                                broj++;
                                lista4.Add(idStolova[j]);
                            }
                        }
                    }
                    var lista5 = lista4.Distinct();
                    if(broj>=brstolova && lista5.Count()==brstolova)
                        listakon.Add(vremena.ElementAt(k));
                }
                List<string> listaZaRV = new List<string>();
                
                for(int i=0;i<8;i++)
                {
                    listaZaRV.Add(("0a:0"+i).ToString());
                }
                string time;
                string[] cetvrtSat = {"00","15","30","45"};
                for(int i=10;i<24;i++){
                    for(int j=0;j<4;j++){
                        time = (i+":"+cetvrtSat[j]).ToString();
                        listaZaRV.Add(time);
                    }
                }
                for(int i=0;i<2;i++){
                    for(int j=0;j<4;j++){
                        time = ("0"+i+":"+cetvrtSat[j]).ToString();
                        listaZaRV.Add(time);
                    }
                }
                for(int i=0;i<8;i++)
                {
                    listaZaRV.Add(("24:0"+i).ToString());
                }

                //da se izbace svi termini pre pocetka radnog vremena
                var start="";
                if(lokal1.openTime.Minute==0)
                {
                    start = (lokal1.openTime.Hour + ":00").ToString();
                }
                else
                {
                    start = (lokal1.openTime.Hour +":"+ lokal1.openTime.Minute).ToString();
                }

                var index1 = listaZaRV.IndexOf(start);
                if(index1!=-1)
                {
                    for(var i=index1-1;i>15;i--)
                    {
                        listakon.Add(listaZaRV[i]);
                    }
                }

                //da se izbace svi termini posle kraja radnog vremena
                var pomocniEnd="";
                if(lokal1.closeTime.Minute==0)
                {
                    pomocniEnd = (lokal1.closeTime.Hour + ":00").ToString();
                }
                else
                {
                    pomocniEnd = (lokal1.closeTime.Hour +":"+ lokal1.closeTime.Minute).ToString();
                }

                var end="";
                if(lokal1.closeTime.Hour<10)
                {
                    end=("0"+pomocniEnd).ToString();
                }
                else
                {
                    end=pomocniEnd;
                }

                var index2 = listaZaRV.IndexOf(end);
                if(index2!=-1)
                {
                    for(var i=index2;i>index2-8;i--)
                    {
                        listakon.Add(listaZaRV.ElementAt(i));
                    }
                    for(var i=index2;i<(listaZaRV.Count)-9;i++)
                    {
                        listakon.Add(listaZaRV.ElementAt(i));
                    }
                }

                //da se izbace svi termini pre trenutnog vremena i termini za naredna 2 sata
                DateTime d = new DateTime();
                d=DateTime.Now;
                if(d.Day.Equals(dan) && d.Month == mesec && d.Year.Equals(godina))
                {
                    string p="";
                    if(d.Minute>0 && d.Minute<15)
                        p="00";
                    else if(d.Minute>15 && d.Minute<30)
                        p="15";
                    else if(d.Minute>30 && d.Minute<45)
                        p="30";
                    else
                        p="45";
                    string vremeTrenutno = (d.Hour+":"+p).ToString();
                    var index3 = listaZaRV.IndexOf(vremeTrenutno);
                    if(index3!=-1)
                    {
                        for(int i=index3;i<index3+9;i++)
                        {
                            listakon.Add(listaZaRV.ElementAt(i));
                        }
                        for(int i=index3;i>15;i--)
                        {
                            listakon.Add(listaZaRV.ElementAt(i));
                        }
                    }
                }
                var konacnaLista=listakon.Distinct().OrderBy(x=>x);
                for(var i =0;i<konacnaLista.Count();i++)
                    konacno.Add(konacnaLista.ElementAt(i));
            }
            return new JsonResult(konacno);
        }

        public async Task<IActionResult> OnPostObrisiAsync(int id)
        {
            var rec = db.Recenzije.Where(x=>x.Id==id).FirstOrDefault();
            if(rec!=null)
            {
                db.Recenzije.Remove(rec);
                await db.SaveChangesAsync();
            }
            return Redirect(("/Object?Id="+idObj).ToString());
        }

        public async Task<IActionResult> OnPostObrisiLokalAsync(int id)
        {
            var lokal = db.Lokali.Where(x=>x.Id==id).Include(x=>x.listaDogadjaja).Include(x=>x.listaRecenzija)
            .Include(x=>x.listaRezervacija).Include(x=>x.listaStolova).FirstOrDefault();
            var recenzije = db.Recenzije.Where(x=>x.Lokal.Id==id).ToList();
            var dogadjaji = db.Dogadjaji.Where(x=>x.Lokal.Id==id).ToList();
            var rezervacije = db.Rezervacije.Where(x=>x.Lokal.Id==id).ToList();
            var stolovi = db.Stolovi.Where(x=>x.Lokal.Id==id).ToList();
            
            if(lokal!=null)
            {
                if(lokal.listaRecenzija.Count>0)
                {
                    foreach(var a in recenzije)
                    {
                        db.Recenzije.Remove(a);
                        await db.SaveChangesAsync();
                    }
                }
                if(lokal.listaRezervacija.Count>0)
                {
                    foreach(var b in rezervacije)
                    {
                        db.Rezervacije.Remove(b);
                        await db.SaveChangesAsync();
                    }
                }
                if(lokal.listaStolova.Count>0)
                {
                    foreach(var c in stolovi)
                    {
                        db.Stolovi.Remove(c);
                        await db.SaveChangesAsync();
                    }
                }
                if(lokal.listaDogadjaja.Count>0)
                {
                    foreach(var d in dogadjaji)
                    {
                        db.Dogadjaji.Remove(d);
                        await db.SaveChangesAsync();
                    }
                }
                var k = db.Korisnici.Where(x=>x.mojLokal.Id==id).FirstOrDefault();
                if(k!=null)
                {
                    db.Korisnici.Remove(k);
                    await db.SaveChangesAsync();
                }
                db.Lokali.Remove(lokal);
                await db.SaveChangesAsync();
            }
            return RedirectToPage("/Index");
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
            foreach(var a in lokal1.listaStolova.Where(x=>x.brojMesta==brMesta).OrderBy(x=>x.Id).ToList())
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
            
            if(idStolova.Count==0)
                return RedirectToPage(("/Object?Id="+idObj).ToString());

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
                var recenzija = db.Recenzije.Where(x=>x.LokalId==idObj && x.KorisnikId==TKorisnik.Id).FirstOrDefault();
                if(recenzija==null)
                {
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
                    float ukupno = 0;
                    for(var i =0;i<ocene.Count;i++)
                        ukupno = ukupno+ocene[i].Ocena;
                    float ocena = ukupno/(Lokal.brOcena+1);
                    float ocena1 = (float)Math.Round(ocena,2);
                    Lokal.Ocena=ocena1;
                    Lokal.brOcena=(Lokal.brOcena)+1;
                    db.Lokali.Update(Lokal);
                    await db.SaveChangesAsync();

                    return Redirect(("/Object?Id="+idObj).ToString());
                }
                else
                {
                    return Redirect(("/Object?Id="+idObj).ToString());
                }
            }
        }
    }
}
