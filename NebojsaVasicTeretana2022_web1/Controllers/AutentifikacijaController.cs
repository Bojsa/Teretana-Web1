using NebojsaVasicTeretana2022_web1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NebojsaVasicTeretana2022_web1.Controllers
{
    public class AutentifikacijaController : Controller
    {
        // GET: Autentifikacija
        public ActionResult PrijaviSe()
        {
            return View("Prijavljivanje");
        }
        public ActionResult RegistrujSe()
        {
            return View("Registracija");
        }
        public ActionResult Registracija(string polKorisnika,Korisnik korisnik)
        {
            if(korisnik.Ime!="" && korisnik.Ime.Length > 3
                && korisnik.Prezime!="" && korisnik.Prezime.Length > 3
                && korisnik.Email!="" && korisnik.Email.Contains('@') && korisnik.Email.Length > 3
                && korisnik.Lozinka!="" && korisnik.Lozinka.Length>3
                && korisnik.KorisnickoIme!="" && korisnik.KorisnickoIme.Length>3
                && korisnik.DatumRodjenja<DateTime.Now
                && polKorisnika!="")
            {
                List<Korisnik> sviKorisnici = KorisnikRepository.SviKorisnici();
                foreach(Korisnik k in sviKorisnici)
                    if(k.KorisnickoIme==korisnik.KorisnickoIme)
                    {
                        ViewBag.Greska = "Korisnicko ime postoji.";
                        return View();
                    }
                if (polKorisnika == "zensko")
                    korisnik.Pol = Pol.zensko;
                else
                    korisnik.Pol = Pol.musko;
                korisnik.Uloga = Uloga.posetilac;
                korisnik.RadiNa = new List<string>();
                korisnik.Treninzi = new List<string>();
                korisnik.Vlasnistvo = new List<string>();
                korisnik.Deleted = false;
                sviKorisnici.Add(korisnik);
                KorisnikRepository.UpisiKorisnike(sviKorisnici);
                return View("Prijavljivanje");
            }
            ViewBag.Greska = "Unos nije validan.";
            return View();
        }
        public ActionResult Prijavljivanje(Korisnik korisnik)
        {
            List<Korisnik> korisnici = KorisnikRepository.SviKorisnici();
            Korisnik k = null;
            foreach(var kor in korisnici)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme && kor.Lozinka==korisnik.Lozinka && !kor.Deleted)
                    k = kor;
            }

            if (k == null)
            {
                ViewBag.Greska = "Doslo je do greske";
                return View("Prijavljivanje");
            }
            Session["kor"] = k;
            return RedirectToAction("Index", "Fitnes");
        }
        public ActionResult OdjaviSe()
        {
            Session["kor"] = null;
            return View("Prijavljivanje");
        }
    }
}