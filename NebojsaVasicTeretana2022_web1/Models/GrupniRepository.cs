using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace NebojsaVasicTeretana2022_web1.Models
{
    public class GrupniRepository
    {
        public static List<Trening> SviTreninzi()
        {
            //UpisiTrenineg(new List<Trening> { new Trening() });
            XmlSerializer ser = new XmlSerializer(typeof(List<Trening>));
            using (var sw = new StreamReader("C:/Users/Nebojsa Vasic/Desktop/Web1P/treninzi.xml"))
            {
                return (List<Trening>)ser.Deserialize(sw);
            }
        }
        public static void UpisiTrenineg(List<Trening> trening)
        {
            Trening t1 = new Trening("trening1", Tip.kickBox, "Ahilej", 50, DateTime.Now, 5);
            Trening t2 = new Trening("trening2", Tip.interval, "Ahilej", 50, DateTime.Now, 20);
            Trening t3 = new Trening("trening3", Tip.aerobik, "Gold", 50, DateTime.Now, 15);
            //trening.Add(t1);
            //trening.Add(t2);
            ///trening.Add(t3);
            XmlSerializer ser = new XmlSerializer(typeof(List<Trening>));
            using (var sw = File.Create("C:/Users/Nebojsa Vasic/Desktop/Web1P/treninzi.xml"))
            {
                ser.Serialize(sw, trening);
            }
        }
    }
}