using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NebojsaVasicTeretana2022_web1.Models
{
    public  class Komentar
    {
        public string Vezbac { get; set; }
        public string FitnesCentar{ get; set; }
        public int Ocena { get; set; }
        public string Tekst{ get; set; }
        public bool Odobren { get; set; }
        public bool Obradjen { get; set; }
    }
}
