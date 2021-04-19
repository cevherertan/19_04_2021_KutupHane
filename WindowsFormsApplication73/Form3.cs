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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Db db = new Db();
        public void listele()
        {
            db.ac();
            DataTable dt = new DataTable();
            SqlCommand komut = new SqlCommand("Select * from Kitaplar", db.baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            db.kapat();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            listele();
            Db yükle = new Db();
            DataTable tbl = new DataTable();
            tbl = yükle.kitapliste();
            comboBox1.DataSource = tbl;
            comboBox1.ValueMember = "YazarKodu";
            comboBox1.DisplayMember = "YazarAdSoyad";
            tbl = yükle.yazarliste();
            comboBox1.DataSource = tbl;
            comboBox1.DisplayMember = "YazarAdSoyad";
            comboBox1.ValueMember = "YazarKodu";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            db.ac();
            if(textBox1.Text != "")
            {
                DataTable dt = new DataTable();
                SqlCommand komut = new SqlCommand("select * from Kitaplar Where KitapKodu like '"+textBox1.Text+"'",db.baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                dt.Load(dr);
                if(dt.Rows.Count>0)
                {
                    dataGridView1.DataSource = dt;
                    textBox3.Text = dt.Rows[0]["KitapAdi"].ToString();
                    textBox2.Text = dt.Rows[0]["SayfaSayisi"].ToString();
                }
                else
                {
                    
                }
            }
            db.kapat();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            db.ac();
            SqlCommand komut = new SqlCommand("Update Kitaplar Set KitapAdi=@p1,SayfaSayisi=@p2,YazarKodu=@p3 Where KitapKodu=@p4", db.baglanti);
            komut.Parameters.AddWithValue("@p1", textBox3.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.SelectedValue);
            komut.Parameters.AddWithValue("@p4", textBox1.Text);
            int durum = komut.ExecuteNonQuery();
            if (durum != 0)
            {
                MessageBox.Show("Güncelleme Yapıldı");
            }
            else
            {
                MessageBox.Show("Veri Tabanı Hatası!!");
            }
            panel1.Visible = false;

            textBox1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            db.kapat();
            listele();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button2.Enabled = false;
                panel1.Visible = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Eminmisiniz?", "ONAY", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {

                    db.ac();
                    SqlCommand komut = new SqlCommand("Delete From Kitaplar Where KitapKodu=@p1", db.baglanti);
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    int durum = komut.ExecuteNonQuery();
                    if (durum != 0)
                    {
                        MessageBox.Show("Silme İşlemi Yapıldı");
                    }
                    else
                    {
                        MessageBox.Show("Silme İşlemi Başarısız");
                    }
                    db.kapat();

                }
                else
                {
                    MessageBox.Show("Kayıt Silinmedi");
                }
                listele();
            }
        }
    }
}
