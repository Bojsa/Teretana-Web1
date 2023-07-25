using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NebojsaVasicTeretana2022_web1.Models
{
    public enum Tip { pilates, kickBox, interval, funkcionalni, aerobik}
    [Serializable()]
    public class Trening
    {
        public Trening() { }
        public Trening(string naziv, Tip tip, string fitnesCentar, int trajanjeUMinutama, DateTime vremeOdrzavanja, int brOgranicenje)
        {
            this.Naziv = naziv;
            this.Tip = tip;
            this.FitnesCentar = fitnesCentar;
            this.TrajanjeUMinutama = trajanjeUMinutama;
            this.VremeOdrzavanja = vremeOdrzavanja;
            this.BrOgranicenje = brOgranicenje;
            Deleted = false;
            this.Vezbaci = new List<string>();
        }

        public string Naziv { get; set; }
        public Tip Tip { get; set; }
        public string FitnesCentar { get; set; }
        public int TrajanjeUMinutama { get; set; }
        public DateTime VremeOdrzavanja { get; set; }
        public int BrOgranicenje { get; set; }
        public List<string> Vezbaci { get; set; }
        public bool Deleted { get; set; }
    }
}