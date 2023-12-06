using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrudSystem.Class
{
    public class MyItem
    {
        List<MyItem> items = new List<MyItem> { };
        public string name2 { get; set; }
        public string cena2 { get; set; }
        public string kol2 { get; set; }
        public string opis2 { get; set; }
        public string img2 { get; set; }
        public string cat { get; set; }

        public MyItem(string name2, string cena2, string kol2, string opis2, string img2, string cat)
        {
            this.name2 = name2;
            this.cena2 = cena2;
            this.kol2 = kol2;
            this.opis2 = opis2;
            this.img2 = img2;
            this.cat = cat;
        }
        public void list(MyItem item)
        {
            if (item != null)
            {
                items.Add(item);
            }
        }
        public void clerar()
        {
            items.Clear();
        }

    }
}
