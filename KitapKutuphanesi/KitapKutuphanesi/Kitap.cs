using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapKutuphanesi
{
    public class Kitap
    {
        public int KitapID { get; set; }
        public string KitapAdi { get; set; }
        public string YazarAdSoyad { get; set; }
        public double Fiyat { get; set; }

        public override string ToString()
        {
            return $"{KitapID} {KitapAdi} {YazarAdSoyad} {Fiyat}";
        }
    }
}
