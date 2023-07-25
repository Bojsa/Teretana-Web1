using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace NebojsaVasicTeretana2022_web1.Models
{
    public static class FitnesRepository
    {
        public static List<FitnesCentar> SviCentri()
        {
           // UpisiFitnesCentre(new List<FitnesCentar>());
            List<FitnesCentar> centri;
            XmlSerializer ser = new XmlSerializer(typeof(List<FitnesCentar>));
            using (var sw = new StreamReader("C:/Users/Nebojsa Vasic/Desktop/Web1P/fitnesCentri.xml"))
            {
               return (List<FitnesCentar>)ser.Deserialize(sw);
            }
        }
        public static void UpisiFitnesCentre(List<FitnesCentar> centri)
        {
            FitnesCentar f1 = new FitnesCentar("Ahilej", "Brankova 13", 2013, "petarpetrovic", 2000, 20000, 500, 400, 1200);
            FitnesCentar f2 = new FitnesCentar("NonStop", "Tome Hadzica 22", 2002, "ivanivanovic", 2000, 30000, 500, 400, 2000);
            FitnesCentar f3 = new FitnesCentar("Gold", "Strazilovska 1", 2020, "markomarkovic", 2000, 18000, 500, 400, 800);
            //centri.Add(f1);
            //centri.Add(f2);
            //centri.Add(f3);
            XmlSerializer xs = new XmlSerializer(typeof(List<FitnesCentar>));
            using (var streamWriter = File.Create("C:/Users/Nebojsa Vasic/Desktop/Web1P/fitnesCentri.xml"))
            {
                xs.Serialize(streamWriter, centri);
            }
        }
        
    }
}