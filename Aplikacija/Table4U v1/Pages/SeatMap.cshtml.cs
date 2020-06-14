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
    
    public class SeatMapModel : PageModel
    {
        public String Message {get; set;}
        public List<Sto> ListaStolova {get; set;}
        public Korisnik TKorisnik {get; set;}
        public Lokal lokal {get; set;}
        private readonly Table4UContext db;
        public SeatMapModel(Table4UContext dataBase)
        {
            db = dataBase;
        }
        public IActionResult OnGet()
        {
            String eMail = HttpContext.Session.GetString("email");
            if(eMail==null)
                return RedirectToPage("/Login");
            Message = "Manager";
            TKorisnik = db.Korisnici.Include(x=>x.mojLokal).Where(x=>x.eMail == eMail).FirstOrDefault();
            //TKorisnik = db.Korisnici.Include(kor=>kor.mojLokal).Where(x=>x.Id==3).FirstOrDefault();
            lokal = db.Lokali.Where(x=>x.Id == TKorisnik.mojLokal.Id).Include(x=>x.listaStolova).Include(x=>x.listaRezervacija).ThenInclude(x=>x.Sto).FirstOrDefault();

            DateTime sad = DateTime.Now;
            ListaStolova = lokal.listaStolova.ToList();
            foreach (Sto s in ListaStolova)
            {
                List<Rezervacija> stoRez = lokal.listaRezervacija.Where(x=>x.Sto.Id == s.Id && x.Vreme.ToString("yyyyMMdd") == sad.ToString("yyyyMMdd")).ToList();
                s.Slobodan = true;
                foreach (Rezervacija rez in stoRez)
                {
                    DateTime krajRezervacije = rez.Vreme.AddHours(2);
                    if(sad >= rez.Vreme && sad< krajRezervacije)
                        s.Slobodan = false; 
                }

            }
            return Page();
        }

        public ActionResult OnGetProveri(int Id)
        {
            String eMail = HttpContext.Session.GetString("email");
            Message = "Manager";
            TKorisnik = db.Korisnici.Include(x=>x.mojLokal).Where(x=>x.eMail == eMail).FirstOrDefault();
            //TKorisnik = db.Korisnici.Include(kor=>kor.mojLokal).Where(x=>x.Id==3).FirstOrDefault();
            lokal = db.Lokali.Where(x=>x.Id == TKorisnik.mojLokal.Id).Include(x=>x.listaStolova).Include(x=>x.listaRezervacija).ThenInclude(x=>x.Sto).FirstOrDefault();
        
            List<Rezervacija> stoRez = lokal.listaRezervacija.Where(x=>x.Sto.Id == Id && x.Vreme.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd")).ToList();
            List<String> rezultat = new List<String>();
            foreach (Rezervacija rez in stoRez)
            {
                Rezervacija r = db.Rezervacije.Include(x=>x.Sto).Include(x=>x.Korisnik).Where(x=>x.Id == rez.Id).FirstOrDefault();
                rezultat.Add(r.Korisnik.Ime + " " + r.Korisnik.Prezime + ", " + r.Korisnik.eMail + ", date/time: " + r.Vreme.ToString("dd.MM.yyyy, HH:mm"));
            }
            return new JsonResult(rezultat);
        }

        public ActionResult OnGetRef()
        {
            List<String> rezultat = new List<string>();
            String eMail = HttpContext.Session.GetString("email");
            Message = "Manager";
            TKorisnik = db.Korisnici.Include(x=>x.mojLokal).Where(x=>x.eMail == eMail).FirstOrDefault();
            //TKorisnik = db.Korisnici.Include(kor=>kor.mojLokal).Where(x=>x.Id==3).FirstOrDefault();
            lokal = db.Lokali.Where(x=>x.Id == TKorisnik.mojLokal.Id).Include(x=>x.listaStolova).Include(x=>x.listaRezervacija).ThenInclude(x=>x.Sto).FirstOrDefault();

            DateTime sad = DateTime.Now;
            ListaStolova = lokal.listaStolova.ToList();
            foreach (Sto s in ListaStolova)
            {
                List<Rezervacija> stoRez = lokal.listaRezervacija.Where(x=>x.Sto.Id == s.Id && x.Vreme.ToString("yyyyMMdd") == sad.ToString("yyyyMMdd")).ToList();
                foreach (Rezervacija rez in stoRez)
                {
                    DateTime krajRezervacije = rez.Vreme.AddHours(2);
                    if(sad >= rez.Vreme && sad< krajRezervacije)
                        rezultat.Add(s.Id.ToString());
                }

            }
            return  new JsonResult(rezultat);
        }

        public IActionResult OnGetReserve(int id)
        {
            Rezervacija r = new Rezervacija();
            r.Vreme = DateTime.Now;
            r.VremeKreiranja = DateTime.Now;
            String eMail = HttpContext.Session.GetString("email");
            Message = "Manager";
            TKorisnik = db.Korisnici.Include(x=>x.mojLokal).Where(x=>x.eMail == eMail).FirstOrDefault();
            //TKorisnik = db.Korisnici.Include(kor=>kor.mojLokal).Where(x=>x.Id==3).FirstOrDefault();
            r.Korisnik = TKorisnik;
            r.Lokal = TKorisnik.mojLokal;
            r.Sto = db.Stolovi.Where(x=>x.Id == id).FirstOrDefault();
            db.Rezervacije.Add(r);
            db.SaveChanges();
            return RedirectToPage();
            //da li postoji rezervacija u narednih 2h
        }

        public IActionResult OnGetRelease(int id)
        {
            
            String eMail = HttpContext.Session.GetString("email");
            Message = "Manager";
            TKorisnik = db.Korisnici.Include(x=>x.mojLokal).Where(x=>x.eMail == eMail).FirstOrDefault();
            //TKorisnik = db.Korisnici.Include(kor=>kor.mojLokal).Where(x=>x.Id==3).FirstOrDefault();
            lokal = db.Lokali.Where(x=>x.Id == TKorisnik.mojLokal.Id).Include(x=>x.listaStolova).Include(x=>x.listaRezervacija).ThenInclude(x=>x.Sto).FirstOrDefault();

            Rezervacija r = lokal.listaRezervacija.Where(x=>x.Sto.Id == id && x.Vreme<DateTime.Now && x.Vreme>DateTime.Now.AddHours(-2)).FirstOrDefault();
            if(r!=null)
            {
                db.Rezervacije.Remove(r);
                db.SaveChanges();
            }


            return RedirectToPage();
        }
    }
}
