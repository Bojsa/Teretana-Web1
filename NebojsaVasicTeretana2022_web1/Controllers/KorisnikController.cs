using NebojsaVasicTeretana2022_web1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NebojsaVasicTeretana2022_web1.Controllers
{
    public class KorisnikController : Controller
    {
        public List<Korisnik> RemoveKorisnik(string korisnik)
        {
            List<Korisnik> korisnici = KorisnikRepository.SviKorisnici();
            foreach (var k in korisnici)
                if (k.KorisnickoIme == korisnik)
                {
                    korisnici.Remove(k);
                    return korisnici;
                }
            return korisnici;
        }
        // GET: Korisnik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profil()
        {
            return View();
        }
        public ActionResult Izmeni(Korisnik noviKorisnik,string polKorisnika)
        {
            Korisnik stariKorisnik = (Korisnik)Session["kor"];
            List<Korisnik> korisnici = KorisnikRepository.SviKorisnici();
            korisnici = RemoveKorisnik(stariKorisnik.KorisnickoIme);
            if (noviKorisnik.Ime != null && noviKorisnik.Ime != "" && noviKorisnik.Ime != stariKorisnik.Ime)
                stariKorisnik.Ime = noviKorisnik.Ime;
            if (noviKorisnik.Prezime != null && noviKorisnik.Prezime != "" && noviKorisnik.Prezime != stariKorisnik.Prezime)
                stariKorisnik.Prezime = noviKorisnik.Prezime;
            if (noviKorisnik.Email != null && noviKorisnik.Email != "" && noviKorisnik.Email != stariKorisnik.Email)
                stariKorisnik.Email = noviKorisnik.Email;
            if (polKorisnika != null && polKorisnika != "")
            {
                if (polKorisnika == "zensko")
                    stariKorisnik.Pol = Pol.zensko;
                else
                    stariKorisnik.Pol = Pol.musko;
            }
            korisnici.Add(stariKorisnik);
            KorisnikRepository.UpisiKorisnike(korisnici);
            Session["kor"] = stariKorisnik;
            return RedirectToAction("Index","Fitnes");
        }
        public ActionResult KreirajTrenera()
        {
            return View();
        }
        public ActionResult Kreiraj(string polKorisnika, Korisnik korisnik,string fitnesCentar)
        {
            if (korisnik.Ime != "" && korisnik.Ime.Length > 3
                && korisnik.Prezime != "" && korisnik.Prezime.Length > 3
                && korisnik.Email != "" && korisnik.Email.Contains('@') && korisnik.Email.Length > 3
                && korisnik.Lozinka != "" && korisnik.Lozinka.Length > 3
                && korisnik.KorisnickoIme != "" && korisnik.KorisnickoIme.Length > 3
                && korisnik.DatumRodjenja < DateTime.Now
                && polKorisnika != "" && fitnesCentar!="")
            {
                List<Korisnik> sviKorisnici = KorisnikRepository.SviKorisnici();
                foreach (Korisnik k in sviKorisnici)
                    if (k.KorisnickoIme == korisnik.KorisnickoIme)
                    {
                        ViewBag.Greska = "Korisnicko ime postoji.";
                        return View();
                    }
                if (polKorisnika == "zensko")
                    korisnik.Pol = Pol.zensko;
                else
                    korisnik.Pol = Pol.musko;
                korisnik.RadiNa = new List<string>();
                korisnik.Treninzi = new List<string>();
                korisnik.Vlasnistvo = new List<string>();
                korisnik.Deleted = false;
                korisnik.Uloga = Uloga.trener;
                korisnik.RadnoMesto = fitnesCentar;
                sviKorisnici.Add(korisnik);
                KorisnikRepository.UpisiKorisnike(sviKorisnici);
                return RedirectToAction("Index","Fitnes");
            }
            ViewBag.Greska = "Unos nije validan.";
            return View("KreirajTrenera");
        }
        public ActionResult SviTreneri()
        {
            return View();
        }
        public ActionResult Block(string korisnickoIme)
        {
            List<Korisnik> sviKorisnici = KorisnikRepository.SviKorisnici();
            Korisnik k = new Korisnik();
            foreach(var kor in sviKorisnici)
            {
                if(kor.KorisnickoIme==korisnickoIme)
                {
                    sviKorisnici.Remove(kor);
                    kor.KorisnickoIme = korisnickoIme + "_Blokiran";
                    sviKorisnici.Add(kor);
                    break;
                }
            }
            return RedirectToAction("SviTreneri");
        }
    }
}