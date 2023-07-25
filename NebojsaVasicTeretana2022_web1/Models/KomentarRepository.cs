using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NebojsaVasicTeretana2022_web1.Models
{
    public class KomentarRepository
    {
        public static List<Komentar> SviKomentari()
        {
          
            XmlSerializer ser = new XmlSerializer(typeof(List<Komentar>));
            using (var sw = new StreamReader("C:/Users/Nebojsa Vasic/Desktop/Web1P/komentari.xml"))
            {
                return (List<Komentar>)ser.Deserialize(sw);
            }
        }
        public static void UpisiKomentare(List<Komentar> komentari)
        {
          
            XmlSerializer ser = new XmlSerializer(typeof(List<Komentar>));
            using (var sw = File.Create("C:/Users/Nebojsa Vasic/Desktop/Web1P/komentari.xml"))
            {
                ser.Serialize(sw, komentari);
            }
        }
    }
}
