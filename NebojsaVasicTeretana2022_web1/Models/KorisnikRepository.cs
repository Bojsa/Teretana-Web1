using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace NebojsaVasicTeretana2022_web1.Models
{
    public class KorisnikRepository
    {
        public static List<Korisnik> SviKorisnici()
        {
            List<Korisnik> korisnici;
            //UpisiKorisnike(new List<Korisnik>());
            XmlSerializer ser = new XmlSerializer(typeof(List<Korisnik>));
            using (var sw = new StreamReader("C:/Users/Nebojsa Vasic/Desktop/Web1P/korisnici.xml"))
            {
                return (List<Korisnik>)ser.Deserialize(sw);
            }
        }
        public static void UpisiKorisnike(List<Korisnik> korisnici)
        {
            Korisnik k1 = new Korisnik("lazar", "lazar", "lazar", "lazarevic", Pol.musko, "lazar@gmail.com", DateTime.Now, Uloga.posetilac, "");
            Korisnik k2 = new Korisnik("stefan", "stefan", "stefan", "stefanovic", Pol.musko, "stefan@gmail.com", DateTime.Now, Uloga.posetilac, "");


            //korisnici.Add(k1);
            //korisnici.Add(k2);
            XmlSerializer ser = new XmlSerializer(typeof(List<Korisnik>));
            using (var sw = File.Create("C:/Users/Nebojsa Vasic/Desktop/Web1P/korisnici.xml"))
            {
                ser.Serialize(sw, korisnici);
            }
        }
       
    }
}