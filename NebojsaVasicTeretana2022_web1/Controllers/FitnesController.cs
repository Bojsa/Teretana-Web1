using NebojsaVasicTeretana2022_web1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NebojsaVasicTeretana2022_web1.Controllers
{
    public class FitnesController : Controller
    {
        // GET: Fitnes
        public ActionResult Index()
        {
            return View("FitnesCentri", FitnesRepository.SviCentri());
        }
        public ActionResult CentarPoNazivu(string naziv)
        {
            foreach(var c in FitnesRepository.SviCentri())
                if(c.Naziv==naziv)
                    return View("FitnesCentar", c);
            return View("FitnesCentar",null);
        }
       
        public ActionResult Trazi(FitnesCentar centar, string godina1, string godina2)
        {
            List<FitnesCentar> centri = FitnesRepository.SviCentri();
            List<FitnesCentar> centri2 = new List<FitnesCentar>();
            if (centar.Naziv == null && centar.Adresa == null && godina1 == "" && godina2 == "")
                return View("FitnesCentri", centri);
            int pom;
            foreach (var c in centri)
            {

                if (centar.Naziv != null && !c.Naziv.ToLower().Contains(centar.Naziv.ToLower()))
                    continue;
                if (godina1 != "" && int.TryParse(godina1, out pom) && c.Godina < int.Parse(godina1))
                    continue;
                if (godina2 != "" && int.TryParse(godina2, out pom) && c.Godina > int.Parse(godina2))
                    continue;
                if (centar.Adresa != null && !c.Adresa.ToLower().Contains(centar.Adresa.ToLower()))
                    continue;
                centri2.Add(c);
            }
            return View("FitnesCentri", centri2);
        }
        public ActionResult Sort(string sortirajPo, string smerSortiranja)
        {
            List<FitnesCentar> sviCentri = FitnesRepository.SviCentri();
            if (sortirajPo == "")
                return View("FitnesCentri", sviCentri);
            if (smerSortiranja == "" || smerSortiranja == "rastuce")
            {
                if (sortirajPo == "naziv")
                    sviCentri.Sort(delegate (FitnesCentar x, FitnesCentar y) { return x.Naziv.CompareTo(y.Naziv); });
                else if (sortirajPo == "godina")
                    sviCentri.Sort(delegate (FitnesCentar x, FitnesCentar y) { return x.Godina.CompareTo(y.Godina); });
                else if (sortirajPo == "adresa")
                    sviCentri.Sort(delegate (FitnesCentar x, FitnesCentar y) { return x.Adresa.CompareTo(y.Adresa); });
            }
            else
            {
                if (sortirajPo == "nazvi")
                    sviCentri.Sort(delegate (FitnesCentar x, FitnesCentar y) { return y.Naziv.CompareTo(x.Naziv);});
                else if (sortirajPo == "godina")
                    sviCentri.Sort(delegate (FitnesCentar x, FitnesCentar y) { return y.Godina.CompareTo(x.Godina);});
                else if (sortirajPo == "adresa")
                    sviCentri.Sort(delegate (FitnesCentar x, FitnesCentar y) { return y.Adresa.CompareTo(x.Adresa);});

            }
            return View("FitnesCentri", sviCentri);
        }
        public ActionResult MojiFitnesCentri()
        {
            List<FitnesCentar> fitnesCentri = new List<FitnesCentar>();
            foreach(var f in FitnesRepository.SviCentri())
            {
                if (((Korisnik)Session["kor"]).KorisnickoIme==f.Vlasnik)
                    fitnesCentri.Add(f);
            }
            return View(fitnesCentri);
        }
        public ActionResult KreirajFitnesCentar()
        {
            return View();
        }
        public ActionResult Kreiraj(FitnesCentar fitnesCentar)
        {
            if(fitnesCentar.Naziv!=null
                &&fitnesCentar.Mesecna!=0
                && fitnesCentar.Godisnja!=0
                && fitnesCentar.Godina!=0
                && fitnesCentar.Trening!=0
                && fitnesCentar.GrupniTrening!=0
                && fitnesCentar.PersonalniTrening!=0
                && fitnesCentar.Adresa!=null)
            {
                fitnesCentar.Vlasnik = ((Korisnik)Session["kor"]).KorisnickoIme;
                fitnesCentar.Deleted = false;
                List<FitnesCentar> fitnesCentarList = FitnesRepository.SviCentri();
                fitnesCentarList.Add(fitnesCentar);
                FitnesRepository.UpisiFitnesCentre(fitnesCentarList);
                List<Korisnik> korisnici = KorisnikRepository.SviKorisnici();
                Korisnik kkk=new Korisnik();
                foreach(var kor in korisnici)
                {
                    if(kor.KorisnickoIme== ((Korisnik)Session["kor"]).KorisnickoIme)
                    {
                        kkk = kor;
                        korisnici.Remove(kor);
                        break;
                    }
                }
                kkk.Vlasnistvo.Add(fitnesCentar.Naziv);
                korisnici.Add(kkk);
                KorisnikRepository.UpisiKorisnike(korisnici);
                return RedirectToAction("MojiFitnesCentri");
            }
            ViewBag.Greska = "Nevalidan unos";
            return View("KreirajFitnesCentar");
        }
        public ActionResult IzmeniFitnes(string naziv)
        {
            List<FitnesCentar> fitnesCentri = FitnesRepository.SviCentri();
            foreach(var f in fitnesCentri)
                if(f.Naziv==naziv)
                    return View(f);
            return View(new FitnesCentar());
        }
        public ActionResult Izmeni(FitnesCentar fitnesCentar)
        {
            FitnesCentar stariFitnesCentar=new FitnesCentar();
            List<FitnesCentar> fitnesCentri = FitnesRepository.SviCentri();
            foreach (var f in fitnesCentri)
                if (f.Naziv == fitnesCentar.Naziv)
                    stariFitnesCentar = f;
            fitnesCentri.Remove(stariFitnesCentar);
            if (fitnesCentar.Mesecna != 0)
                stariFitnesCentar.Mesecna = fitnesCentar.Mesecna;
            if (fitnesCentar.Godisnja != 0)
                stariFitnesCentar.Godisnja = fitnesCentar.Godisnja;
            if (fitnesCentar.Trening != 0)
                stariFitnesCentar.Trening = fitnesCentar.Trening;
            if (fitnesCentar.PersonalniTrening != 0)
                stariFitnesCentar.PersonalniTrening = fitnesCentar.PersonalniTrening;
            if (fitnesCentar.GrupniTrening != 0)
                stariFitnesCentar.GrupniTrening = fitnesCentar.GrupniTrening;
            if (fitnesCentar.Adresa != null)
                stariFitnesCentar.Adresa = fitnesCentar.Adresa;
            fitnesCentri.Add(stariFitnesCentar);
            FitnesRepository.UpisiFitnesCentre(fitnesCentri);
            
            return RedirectToAction("MojiFitnesCentri");
            
          
        }
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
        public ActionResult SviKomentari()
        {
            return View();
        }
        public ActionResult Odobri(string vezbac, string centar)
        {
            List<Komentar> komentari = KomentarRepository.SviKomentari();
            Komentar k = new Komentar();
            foreach(var kom in komentari)
            {
                if(kom.Vezbac== vezbac && kom.FitnesCentar == centar)
                {
                    k = kom;
                    break;
                }
            }
            komentari.Remove(k);
            k.Obradjen = true;
            k.Odobren = true;
            komentari.Add(k);
            KomentarRepository.UpisiKomentare(komentari);
            return RedirectToAction("SviKomentari");
        }
        public ActionResult Odbij(string vezbac, string centar)
        {
            List<Komentar> komentari = KomentarRepository.SviKomentari();
            Komentar k = new Komentar();
            foreach (var kom in komentari)
            {
                if (kom.Vezbac == vezbac && kom.FitnesCentar==centar)
                {
                    k = kom;
                    break;
                }
            }
            komentari.Remove(k);
            k.Obradjen = true;
            k.Odobren = false;
            komentari.Add(k);
            KomentarRepository.UpisiKomentare(komentari);
            return RedirectToAction("SviKomentari");
        }
        public ActionResult UkloniFitnes(string naziv)
        {
            List<Trening> treninzi = GrupniRepository.SviTreninzi();
            foreach (Trening t in treninzi)
            {
                if(t.FitnesCentar==naziv && t.VremeOdrzavanja>DateTime.Now)
                {
                    ViewBag.Greska = "Ne moze se ukloniti fitnes centar koji ima zakazane treninge.";
                    List<FitnesCentar> mojiFitnesCentri = new List<FitnesCentar>();
                    foreach (var f in FitnesRepository.SviCentri())
                    {
                        if (((Korisnik)Session["kor"]).Vlasnistvo.Contains(f.Naziv))
                            mojiFitnesCentri.Add(f);
                    }
                    return View("MojiFitnesCentri",mojiFitnesCentri);
                }
            }
            List<FitnesCentar> fitnesCentri = FitnesRepository.SviCentri();
            foreach (var f in fitnesCentri)
            {
                if(f.Naziv==naziv)
                {
                    fitnesCentri.Remove(f);
                    f.Deleted = true;
                    fitnesCentri.Add(f);
                    break;
                }
            }
            FitnesRepository.UpisiFitnesCentre(fitnesCentri);
            List<Korisnik> korisnici = KorisnikRepository.SviKorisnici();
            foreach(var k in korisnici)
            {
                if (k.Uloga == Uloga.trener && k.RadnoMesto == naziv)
                    k.KorisnickoIme += "_Blokiran";
            }
            KorisnikRepository.UpisiKorisnike(korisnici);
            return RedirectToAction("MojiFitnesCentri");
        }
        public ActionResult OstaviKomentar(Komentar komentar)
        {
            Korisnik k = (Korisnik)Session["kor"];
            if(komentar.Tekst=="" || komentar.Ocena>5 || komentar.Ocena<=0)
            {
                ViewBag.Greska = "Popunite sva polja";
                List<FitnesCentar> fc = FitnesRepository.SviCentri();
                foreach (var f in fc)
                    if (f.Naziv == komentar.FitnesCentar)
                        return View("FitnesCentar", f);
                return View("FitnesCentar", null);
            }
            komentar.Vezbac = k.KorisnickoIme;
            komentar.Obradjen = false;
            komentar.Odobren = false;
            List<Komentar> komentari = KomentarRepository.SviKomentari();
            komentari.Add(komentar);
            KomentarRepository.UpisiKomentare(komentari);
            return RedirectToAction("Index");
        }
    }
}