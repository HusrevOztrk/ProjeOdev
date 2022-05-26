using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapKutuphanesi
{
    public class Dosya
    {
        public void DosyayaYaz(Kitap kitap)
        {
            StreamWriter writer = new StreamWriter("kitap.data",true);

            string strKitap = $"{kitap.KitapID};{kitap.KitapAdi};{kitap.YazarAdSoyad};{kitap.Fiyat}";
            writer.WriteLine(strKitap);
            writer.Close();
        }

        public List<Kitap> DosyadanOku()
        {
            StreamReader reader = new StreamReader("kitap.data");
            List<Kitap> kitaplar = new List<Kitap>();
            while (!reader.EndOfStream)
            {
                string strKitap = reader.ReadLine();
                var data = strKitap.Split(";");

                Kitap kitap = new Kitap();
                kitap.KitapID = Convert.ToInt32(data[0]);
                kitap.KitapAdi = data[1];
                kitap.YazarAdSoyad = data[2];
                kitap.Fiyat = Convert.ToDouble(data[3]);

                kitaplar.Add(kitap);
            }         
            reader.Close();

            return kitaplar;
        }
    }
}
