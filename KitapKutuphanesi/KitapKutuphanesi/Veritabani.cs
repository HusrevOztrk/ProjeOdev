using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapKutuphanesi
{
    public class Veritabani
    {
        string strConn = "Data source=(localdb)\\Local;initial catalog=KitapDB; integrated security=true";

        public List<Kitap> Listele()
        {
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select*From Kitaplar", conn);

            SqlDataReader dr = cmd.ExecuteReader();
            //ExecuteReader -> select
            //ExecuteQuery() -> insert, update, delete
            //ExecuteScalar -> select (geriye sadece tek bir deger, tek satır tek sütun)

            List<Kitap> kitaplar = new List<Kitap>();   
            while (dr.Read())
            {
                Kitap kitap = new Kitap();
                kitap.KitapID = Convert.ToInt32(dr[0]);         //indis 
                kitap.KitapAdi = dr["KitapAdi"].ToString();     //column name
                kitap.YazarAdSoyad = dr.GetString(2);           //GetString(indis)
                kitap.Fiyat = Convert.ToDouble(dr[3]);

                kitaplar.Add(kitap);              
            }

            conn.Close();

            return kitaplar;
        }

        public void Ekle(Kitap kitap)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Kitaplar Values(@kitapadi, @yazaradsoyad, @fiyat)", conn);
            cmd.Parameters.AddWithValue("@kitapadi", kitap.KitapAdi);
            cmd.Parameters.AddWithValue("@yazaradsoyad", kitap.YazarAdSoyad);
            cmd.Parameters.AddWithValue("@fiyat", kitap.Fiyat);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public Kitap Bul(int kitapID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select*From Kitaplar where KitapID=@id", conn);
            cmd.Parameters.AddWithValue("@id", kitapID);
            SqlDataReader dr = cmd.ExecuteReader();
            Kitap kitap = new Kitap() { KitapID=-1};
            dr.Read();
            if (dr.HasRows)
            {
                kitap.KitapID = Convert.ToInt32(dr[0]);         
                kitap.KitapAdi = dr["KitapAdi"].ToString();    
                kitap.YazarAdSoyad = dr.GetString(2);
                kitap.Fiyat = Convert.ToDouble(dr[3]);
            }
            
            conn.Close();
            return kitap;
        }
    }
    
}
