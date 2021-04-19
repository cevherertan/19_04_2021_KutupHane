using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication73
{
    class Db
    {
       public SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0HLJ5NJ\SQLEXPRESS;Initial Catalog=KutuphaneDb;Integrated Security=True");
       public void ac()
        {
            baglanti.Open();
        }
        public void kapat()
        {
            baglanti.Close();
        }
        public DataTable yazarliste()
        {
            ac();
            DataTable liste = new DataTable();
            SqlCommand komut = new SqlCommand("select * from Yazar", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            liste.Load(dr);
            kapat();
            return liste;
        }
        public DataTable kitapliste()
        {
            ac();
            DataTable liste = new DataTable();
            SqlCommand komut = new SqlCommand("select * from Kitaplar",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            liste.Load(dr);
            kapat();
            return liste;
        }
    }
}
