using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication73
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int ks;
            Db db = new Db();
            db.ac();
            SqlCommand komut = new SqlCommand("Insert Into Yazar Values (@a)", db.baglanti);
            komut.Parameters.AddWithValue("@a", textBox1.Text);
            ks=komut.ExecuteNonQuery();
            if (ks!=0)
            {
                MessageBox.Show("Kayıt Başarılı");
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kayıt Başarısız");
            }
            db.kapat();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }
    }
}
