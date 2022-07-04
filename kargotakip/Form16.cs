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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }
          public string kullaniciadi1;
        SqlConnection baglanti = new SqlConnection(@"Data Source=BERK;Initial Catalog=kargo;Integrated Security=True"); //Kendi veritabanı yolunuzu vermeniz gerekiyor

        private void Form16_Load(object sender, EventArgs e)
        {
            //baglanti.Open();

            guna2HtmlLabel8.Text = kullaniciadi1;
            //SqlCommand komut6 = new SqlCommand("select * from kullanici where eposta=@p1", baglanti);
            //komut6.Parameters.AddWithValue("@p1", guna2HtmlLabel8.Text);



            //SqlDataAdapter kmt = new SqlDataAdapter();
            //kmt.SelectCommand = komut6;

            //DataTable tablo = new DataTable();

            //kmt.Fill(tablo);
            //SqlDataReader drr2 = komut6.ExecuteReader();
            //if (drr2.Read())
            //{
            //    guna2TextBox12.Text = drr2["ad"].ToString();
            //    guna2TextBox1.Text = drr2["soyad"].ToString();
            //    guna2TextBox3.Text = drr2["eposta"].ToString();
            //    guna2TextBox3.Text = drr2["eposta"].ToString();
            //    guna2TextBox4.Text = drr2["sifre"].ToString();
            //    guna2TextBox14.Text = drr2["tel"].ToString();
            //}
            //baglanti.Close();

        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.outlook.com";
            sc.EnableSsl = true;

            string kime = guna2HtmlLabel9.Text;
            string konu = guna2TextBox1.Text;
            string icerik = guna2TextBox3.Text+" "+ guna2HtmlLabel8.Text;

            sc.Credentials = new NetworkCredential("mailadresiniz@outlook.com", "şifreniz");//Mail gönderirken kullanacağınız hesap bilgilerini girmeniz gerekiyor
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("getirgotur@outlook.com.tr", "Kullanıcı Destek");
            mail.To.Add(kime);
            //mail.To.Add("alici2@mail.com");
            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;

            sc.Send(mail);

           
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
