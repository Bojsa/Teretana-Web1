using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NebojsaVasicTeretana2022_web1.Models
{
    [Serializable()]
    public class FitnesCentar
    {
        public FitnesCentar() { }
        public FitnesCentar(string naziv, string adresa, int godina, string vlasnik, int mesecna, int godisnja, int trening, int grupniTrening, int personalniTrening)
        {
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.Godina = godina;
            this.Vlasnik = vlasnik;
            this.Mesecna = mesecna;
            this.Godisnja = godisnja;
            this.Trening = trening;
            this.GrupniTrening = grupniTrening;
            this.PersonalniTrening = personalniTrening;
            Deleted = false;
        }

        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int Godina { get; set; }
        public string Vlasnik { get; set; }
        public int Mesecna { get; set; }
        public int Godisnja { get; set; }
        public int Trening { get; set; }
        public int GrupniTrening { get; set; }
        public int PersonalniTrening { get; set; }
        public bool Deleted { get; set; }
    }
}