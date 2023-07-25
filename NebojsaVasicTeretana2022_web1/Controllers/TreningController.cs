using NebojsaVasicTeretana2022_web1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NebojsaVasicTeretana2022_web1.Controllers
{
    public class TreningController : Controller
    {
        // GET: Trening
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GrupniTreninzi(string centar)
        {
            List<Trening> treninzi=new List<Trening>();
            foreach (var c in GrupniRepository.SviTreninzi())
                if (c.FitnesCentar == centar)
                    treninzi.Add(c);
            return View(treninzi);
        }
        public ActionResult PrijaviSeZaTrening(string grupniTrening)
        {
            Korisnik k = (Korisnik)Session["kor"];
            
            Trening t = null;
            List<Trening> treninzi = GrupniRepository.SviTreninzi();
            List<Korisnik> korisnici = KorisnikRepository.SviKorisnici();
            if (k.Treninzi.Contains(grupniTrening))
            {
                ViewBag.Greska = "Vec ste prijavljeni na trening.";
                return View("GrupniTreninzi", treninzi);
            }
            foreach (var tr in treninzi)
                if (tr.Naziv == grupniTrening)
                    t = tr;

            treninzi.Remove(t);
            korisnici = RemoveKorisnik(k.KorisnickoIme);
            k.Treninzi.Add(t.Naziv);
            t.Vezbaci.Add(k.KorisnickoIme);
            treninzi.Add(t);
            korisnici.Add(k);
            KorisnikRepository.UpisiKorisnike(korisnici);
            GrupniRepository.UpisiTrenineg(treninzi);
            return RedirectToAction("Index", "Fitnes");
        }
        public ActionResult MojiTreninzi()
        {
            List<Trening> korisnikoviTreninzi = TreninziKorisnika();
            
            return View(korisnikoviTreninzi);
        }
        public ActionResult Trazi(Trening trening,string Tipp)
        {
            List<Trening> t2 = TreninziKorisnika();
            List<Trening> t3 = new List<Trening>();
            if (trening.Naziv == null && trening.FitnesCentar== null && Tipp == "" )
                return View("MojiTreninzi", t2);
            foreach (var c in t2)
            {
                if (trening.Naziv != null && !c.Naziv.ToLower().Contains(trening.Naziv.ToLower()))
                    continue;
                if (Tipp != "" && !c.Tip.ToString().ToLower().Contains(Tipp.ToLower()))
                    continue;
                if (trening.FitnesCentar != null && !c.FitnesCentar.ToLower().Contains(trening.FitnesCentar.ToLower()))
                    continue;
                t3.Add(c);
            }
            return View("MojiTreninzi", t3);
        }
        public ActionResult Sort(string sortirajPo, string smerSortiranja)
        {
            List<Trening> t = TreninziKorisnika();
            if (sortirajPo == "")
                return View("MojiTreninzi", t);
            if (smerSortiranja == "" || smerSortiranja == "rastuce")
            {
                if (sortirajPo == "naziv")
                    t.Sort(delegate (Trening x, Trening y) { return x.Naziv.CompareTo(y.Naziv); });
                else if (sortirajPo == "vreme")
                    t.Sort(delegate (Trening x, Trening y) { return x.VremeOdrzavanja.CompareTo(y.VremeOdrzavanja); });
                else if (sortirajPo == "tip")
                    t.Sort(delegate (Trening x, Trening y) { return x.Tip.CompareTo(y.Tip); });
            }
            else
            {
                if (sortirajPo == "nazvi")
                    t.Sort(delegate (Trening x, Trening y) { return y.Naziv.CompareTo(x.Naziv); });
                else if (sortirajPo == "vreme")
                    t.Sort(delegate (Trening x, Trening y) { return y.VremeOdrzavanja.CompareTo(x.VremeOdrzavanja); });
                else if (sortirajPo == "tip")
                    t.Sort(delegate (Trening x, Trening y) { return y.Tip.CompareTo(x.Tip); });

            }
            return View("MojiTreninzi", t);

        }
        public ActionResult KreirajTrening()
        {
            return View();
        }

        public ActionResult Kreiraj(Trening trening, string TipTreninga)
        {
            Korisnik k = (Korisnik)Session["kor"];
            if (trening.Naziv == null || trening.TrajanjeUMinutama == 0 || trening.BrOgranicenje == 0
                || trening.VremeOdrzavanja < DateTime.Now || TipTreninga == "")
            {
                ViewBag.Greska = "Popunite polja.";
                return View("KreirajTrening");
            }
            switch (TipTreninga)
            {
                case "pilates":
                    trening.Tip = Tip.pilates;
                    break;
                case "kickBox":
                    trening.Tip = Tip.kickBox; break;
                case "funkcionalni":
                    trening.Tip = Tip.funkcionalni; break;
                case "aerobik":
                    trening.Tip = Tip.aerobik; break;
                case "interval":
                    trening.Tip = Tip.interval; break;
            }
            trening.Vezbaci = new List<string>();
            trening.Deleted = false;
            trening.FitnesCentar = k.RadnoMesto;
            List<Trening> treninzi = GrupniRepository.SviTreninzi();
            foreach(var tt in treninzi)
            {
                if(tt.Naziv==trening.Naziv)
                {
                    ViewBag.Greska = "Naziv vec postoji";
                    return View("KreirajTrening");
                }
            }
            List<Korisnik> korisnici = KorisnikRepository.SviKorisnici();
            korisnici = RemoveKorisnik(k.KorisnickoIme);
            k.RadiNa.Add(trening.Naziv);
            korisnici.Add(k);
            KorisnikRepository.UpisiKorisnike(korisnici);
            treninzi.Add(trening);
            GrupniRepository.UpisiTrenineg(treninzi);
            return RedirectToAction("MojiTreninzi");
        }
        public ActionResult Ukloni(string naziv)
        {
            List<Trening> treninzi = GrupniRepository.SviTreninzi();
            Trening t = null;
            foreach (var tt in treninzi)
                if (tt.Naziv == naziv)
                    t = tt;
            treninzi.Remove(t);
            t.Deleted = true;
            treninzi.Add(t);
            GrupniRepository.UpisiTrenineg(treninzi);
            return RedirectToAction("MojiTreninzi");

        }
        public ActionResult Posetioci(string trening)
        {
            List<Korisnik> korisnici = KorisnikRepository.SviKorisnici();
            List<Korisnik> posetioci = new List<Korisnik>();
            foreach (var k in korisnici)
                if (k.Uloga == Uloga.posetilac && k.Treninzi.Contains(trening))
                    posetioci.Add(k);
            return View("Posetioci", posetioci);
        }
        private List<Trening> TreninziKorisnika()
        {
            Korisnik k = (Korisnik)Session["kor"];
            List<Trening> t1 = GrupniRepository.SviTreninzi();
            List<Trening> t2 = new List<Trening>();
            foreach (Trening t in t1)
            {
                if ((k.Uloga==Uloga.posetilac && k.Treninzi.Contains(t.Naziv))
                    || (k.Uloga==Uloga.trener && k.RadiNa.Contains(t.Naziv)))
                    t2.Add(t);
            }
            return t2;
        }
        public ActionResult Trening(string naziv)
        {
            List<Trening> treninzi = GrupniRepository.SviTreninzi();
            foreach (Trening t in treninzi)
                if (t.Naziv == naziv)
                    return View(t);
            return View(new Trening());
        }
        public ActionResult IzmeniTrening(Trening trening,string TipTreninga)
        {
            Trening stariTrening = new Models.Trening() ;
            List<Trening> treninzi = GrupniRepository.SviTreninzi();
            
            foreach (var t in treninzi)
            {
                if(t.Naziv==trening.Naziv)
                {
                    stariTrening = t;
                    treninzi.Remove(stariTrening);
                    break;
                }
            }
            if (trening.BrOgranicenje != 0)
                stariTrening.BrOgranicenje = trening.BrOgranicenje;
            if (trening.TrajanjeUMinutama != 0)
                stariTrening.TrajanjeUMinutama = trening.TrajanjeUMinutama;
            if (trening.VremeOdrzavanja.Year != 1 && trening.VremeOdrzavanja>DateTime.Now)
                stariTrening.VremeOdrzavanja = trening.VremeOdrzavanja;
            if(TipTreninga!="")
            switch (TipTreninga)
            {
                case "pilates":
                        stariTrening.Tip = Tip.pilates;
                    break;
                case "kickBox":
                        stariTrening.Tip = Tip.kickBox; break;
                case "funkcionalni":
                        stariTrening.Tip = Tip.funkcionalni; break;
                case "aerobik":
                        stariTrening.Tip = Tip.aerobik; break;
                case "interval":
                        stariTrening.Tip = Tip.interval; break;
            }
            treninzi.Add(stariTrening);
            GrupniRepository.UpisiTrenineg(treninzi);
            return RedirectToAction("MojiTreninzi");
        }
        public List<Korisnik> RemoveKorisnik(string korisnik)
        {
            List<Korisnik> korisnici = KorisnikRepository.SviKorisnici();
            foreach(var k in korisnici)
                if(k.KorisnickoIme==korisnik)
                {
                    korisnici.Remove(k);
                    return korisnici;
                }
            return korisnici;
        }
    }
}