using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrudSystem.Class
{
    public class Korzina : User
    {
        public string name2 { get; set; }
        public string cena2 { get; set; }
        public string kol2 { get; set; }
        public string opis2 { get; set; }
        public string img2 { get; set; }
        public string kat { get; set; }

        public Korzina(string login, string password, string name2, string cena2, string kol2, string opis2, string img2, string kat2) : base(login, password)
        {
            this.name2 = name2;
            this.cena2 = cena2;
            this.kol2 = kol2;
            this.opis2 = opis2;
            this.img2 = img2;
            kat = kat2;
        }
    }
}
