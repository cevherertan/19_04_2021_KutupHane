using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication73
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
            Db yukle = new Db();
            DataTable tbl = new DataTable();
            tbl = yukle.yazarliste();
            comboBox1.DataSource = tbl;
            comboBox1.DisplayMember = "YazarAdSoyad";
            comboBox1.ValueMember = "YazarKodu";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ks;
            Db db = new Db();
            db.ac();
            SqlCommand komut = new SqlCommand("Insert Into Kitaplar Values(@a,@b,@c)",db.baglanti);
            komut.Parameters.AddWithValue("@a",textBox1.Text);
            komut.Parameters.AddWithValue("@b", Convert.ToInt32(textBox2.Text));
            komut.Parameters.AddWithValue("@c", comboBox1.SelectedValue);
            ks=komut.ExecuteNonQuery();
            if (ks!=0)
            {
                MessageBox.Show("Kayıt Eklendi");
            }
            else
            {
                MessageBox.Show("Kayıt Eklenmedi");
            }
            db.kapat();
        }
    }
}
