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
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace kargotakip
{
    public partial class Form14 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=BERK;Initial Catalog=kargo;Integrated Security=True"); //Kendi veritabanı yolunuzu vermeniz gerekiyor

        public Form14()
        {
            InitializeComponent();
        }
        int sayac;
        private void Form14_Load(object sender, EventArgs e)
        {
            guna2Transition1.HideSync(guna2PictureBox2);
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            if (sayac == 18)
            {
                if (guna2PictureBox2.Visible == false)
                {
                    guna2Transition1.ShowSync(guna2PictureBox2);
                }
                else guna2Transition1.HideSync(guna2PictureBox2);


                timer1.Stop();
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            if (guna2TextBox1.Text=="admin"&& guna2TextBox2.Text=="123")
            {
                Form10 frm1 = new Form10();
                frm1.Show();
                this.Hide();
            }
            

            
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from calisan where sistemMail=@p1 and sifre=@p2 ", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2TextBox1.Text);
            komut.Parameters.AddWithValue("@p2", guna2TextBox2.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                //MessageBox.Show("Giriş Başarılı");
                //kullaniciadi = guna2TextBox1.Text;
                Form13 frm1 = new Form13();
                frm1.kullaniciadi = guna2TextBox1.Text;
                frm1.Show();
                this.Hide();

            }
            else
            {
                Form5 sayfa5 = new Form5();
                sayfa5.Show();
                //MessageBox.Show("Bilgilerinizi doğru Girdiğinizden Emin Olun", "Uyarı");
            }
            baglanti.Close();
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }
}
