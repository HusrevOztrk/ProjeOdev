using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapKutuphanesi
{
    public class Secim
    {
        string sec = null;
        Veritabani vt = new Veritabani();
        public void SecimYap()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("**************Alan Secimi***************");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1-Database");
            Console.WriteLine("2-Dosya");
            Console.Write("Kullanacağınız alanı seçiniz: ");           

            sec = Console.ReadLine();
            if (sec == "1")
            {                                               
                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("*************Islem Secimi***************");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("1-Tüm Kayıtları Listele");
                    Console.WriteLine("2-Yeni Kitap Ekle");
                    Console.WriteLine("3-Id Ile Kitap Bul");
                    Console.WriteLine("Çıkmak için x'e basınız");
                    Console.Write("Yapmak istediğiniz işlemi seçiniz: ");                   
                    var userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("");
                            foreach (Kitap kitap in vt.Listele())
                                Console.WriteLine(kitap);
                            break;
                         case "2":
                            Console.WriteLine("");
                            Console.Write("Kitap Adını Giriniz: ");
                            var kitapadi = Console.ReadLine();                           
                            Console.Write("Yazar Adını Soyadını Giriniz: ");
                            var yazaradisoyadi = Console.ReadLine();
                            Console.Write("Fiyat Giriniz: ");
                            var fiyat = Console.ReadLine();
                            Console.WriteLine("");
                            Kitap yeniKitapSql = new Kitap { KitapAdi = kitapadi, YazarAdSoyad = yazaradisoyadi, Fiyat = Convert.ToDouble(fiyat) };
                            vt.Ekle(yeniKitapSql);
                            Console.WriteLine("Yeni kitap eklendi.");

                            break;
                        case "3":
                            Console.WriteLine("");
                            Console.Write("Bulmak Istediğiniz Kitap Id'sini Giriniz: ");
                            var id = Console.ReadLine();
                            Kitap ktp = vt.Bul(Convert.ToInt32(id));
                            if (ktp.KitapID > 0)
                            {
                                Console.WriteLine(ktp);
                            }
                            else
                                Console.WriteLine("Aradığınız kitap bulunamadı.Doğru ID girdiğinizden emin olunuz.");
                            break;
                        case "x":
                            return;
                    }
                }
            }
            else if(sec == "2")
            {
                while (true)
                {
                    Dosya dosya = new Dosya();
                    Console.WriteLine("");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("*************Islem Secimi***************");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("1-Dosyadan Oku");
                    Console.WriteLine("2-Dosyaya Yaz");                    
                    Console.WriteLine("Çıkmak için x'e basınız");
                    Console.Write("Yapmak istediğiniz işlemi seçiniz: ");
                    var userInputDosya = Console.ReadLine();
                    switch (userInputDosya)
                    {
                        case "1":
                            Console.WriteLine("");
                            foreach (Kitap kitap in dosya.DosyadanOku())
                                Console.WriteLine(kitap);
                            break;

                        case "2":
                            
                            Console.WriteLine("");
                            Console.Write("Vermek Istediğiniz Id'yi Giriniz: ");
                            var id = Console.ReadLine();
                            Console.Write("Kitap Adını Giriniz: ");
                            var kitapadi = Console.ReadLine();
                            Console.Write("Yazar Adını Soyadını Giriniz: ");
                            var yazaradisoyadi = Console.ReadLine();
                            Console.Write("Fiyat Giriniz: ");
                            var fiyat = Console.ReadLine();
                            Console.WriteLine("");
                            Kitap yeniKitapData = new Kitap { KitapID = Convert.ToInt32(id), KitapAdi = kitapadi, YazarAdSoyad = yazaradisoyadi, Fiyat = Convert.ToDouble(fiyat) };
                            dosya.DosyayaYaz(yeniKitapData);
                            break;
                                               
                        case "x":
                            return;
                    }
                    
                }
                
            }
            else
            {
                Console.WriteLine("Hatalı seçim yaptınız. Lütfen tekrar deneyiniz.");
            }
        }
    }
}
