using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NebojsaVasicTeretana2022_web1.Models
{ 
    public enum Pol { zensko, musko}
    public enum Uloga { posetilac, trener,  vlasnik}
    [Serializable()]
    public class Korisnik
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Pol Pol { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Uloga Uloga { get; set; }
        public List<string> Treninzi { get; set; }
        public List<string> RadiNa { get; set; }
        public bool Deleted { get; set; }
        public string RadnoMesto { get; set; }
        public List<string> Vlasnistvo { get; set; }
        public Korisnik() { }
        public Korisnik(string korisnickoIme, string lozinka, string ime, string prezime, Pol pol, string email, DateTime datumRodjenja, Uloga uloga, string radnoMesto)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Pol = pol;
            this.Email = email;
            this.DatumRodjenja = datumRodjenja;
            this.Uloga = uloga;
            Treninzi = new List<string>();
            RadiNa = new List<string>();
            Deleted = false;
            this.RadnoMesto = radnoMesto;
            this.Vlasnistvo = new List<string>();
        }
    }
}