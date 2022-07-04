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

using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace kargotakip
{
    public partial class Form3 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=BERK;Initial Catalog=kargo;Integrated Security=True"); //Kendi veritabanı yolunuzu vermeniz gerekiyor
        public string kullaniciadi;
        public Form3()
        {
            InitializeComponent();
        }
      

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

           


            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kullanici where eposta=@p1 and sifre=@p2 ", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2TextBox1.Text);
            komut.Parameters.AddWithValue("@p2", guna2TextBox2.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                //MessageBox.Show("Giriş Başarılı");
                //kullaniciadi = guna2TextBox1.Text;
                Form8 frm1 = new Form8();
                frm1.kullaniciadi=guna2TextBox1.Text;
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2ShadowPanel1.Visible = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2ShadowPanel1.Visible = false;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            guna2HtmlLabel10.Text = "+9"+guna2TextBox7.Text;
            try
            {
                baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into kullanici(eposta,ad,soyad,sifre,tel,hesapolusturmatarihi,aktiflikdurumu,onaykodu) Values (@p1,@p2,@p3,@p4,@p5,@p7,@p8,@p9)", baglanti);
            komut2.Parameters.AddWithValue("@p1", guna2TextBox6.Text);
            komut2.Parameters.AddWithValue("@p2", guna2TextBox4.Text);

            komut2.Parameters.AddWithValue("@p3", guna2TextBox3.Text);
            komut2.Parameters.AddWithValue("@p4", guna2TextBox5.Text);

            komut2.Parameters.AddWithValue("@p5", guna2HtmlLabel10.Text);
            

            komut2.Parameters.AddWithValue("@p7", DateTime.Now);
            komut2.Parameters.AddWithValue("@p8", "aktif");
            komut2.Parameters.AddWithValue("@p9", label1.Text);


            komut2.ExecuteNonQuery();
            //MessageBox.Show("Kayıt Başarılı");
          


            baglanti.Close();

 SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.outlook.com";
                sc.EnableSsl = true;

                string kime = guna2TextBox6.Text;
                string konu = "Onay Kodunuz: " + label1.Text;
                string icerik = " " + label1.Text + " ";

                sc.Credentials = new NetworkCredential("mailadresiniz@outlook.com", "şifreniz");//Mail gönderirken kullanacağınız hesap bilgilerini girmeniz gerekiyor
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mail adresiniz", "Gönderen kişi başlığı");
                mail.To.Add(kime);
                //mail.To.Add("alici2@mail.com");
                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = icerik;

                sc.Send(mail); 
                
                guna2ShadowPanel1.Visible = false;
                guna2ShadowPanel2.Visible = true;

                try
                {
                    var accountSid = "123123123"; //twilio hesabınızdan ulaşabileceğiniz Account SID kodunuzu buraya yazınız 
                    var authToken = "123123";    //twilio hesabınızdan ulaşabileceğiniz Auth Token kodunuzu buraya yazınız 

                    TwilioClient.Init(accountSid, authToken);

                    var message = MessageResource.Create(
                           to: new Twilio.Types.PhoneNumber(guna2HtmlLabel10.Text),
                           from: new Twilio.Types.PhoneNumber("+123213123"),//twilio hesabınızdan ulaşabileceğiniz My Twilio phone number kodunuzu buraya yazınız 
                           body: "Onay Kodunuz: " + label1.Text);
                    guna2ShadowPanel1.Visible = false;
                    guna2ShadowPanel2.Visible = true;
                }
                catch
                {
                    guna2ShadowPanel1.Visible = false;
                    guna2ShadowPanel2.Visible = true;
                }

                

               



               
                
                

            }
            catch (Exception)
            {
                Form7 sayfa7 = new Form7();
                  sayfa7.Show();

                guna2HtmlLabel8.Text = "Mail adresi yanlış";
                guna2GradientButton2.Enabled = false;


            }


              

            

        }
       
       

        private void Form3_Load(object sender, EventArgs e)
        {

          


            Random random = new Random();
            int number = random.Next(1000, 10000);
            label1.Text = number.ToString();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox12.Text==label1.Text)
            {
               guna2HtmlLabel6.Visible=true;
                guna2ShadowPanel1.Visible = false;
                guna2ShadowPanel2.Visible = false;

                Form4 sayfa4 = new Form4();
                sayfa4.Show();
            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox5.PasswordChar = '*';
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kullanici where eposta=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2TextBox6.Text);




            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form6 sayfa6 = new Form6();
                sayfa6.Show();
                //MessageBox.Show("Mail adresi kullanılıyor");
                guna2GradientButton2.Enabled = false;
                guna2HtmlLabel8.Visible = true;


            }
            else
            {
                guna2GradientButton2.Enabled = true;
                guna2HtmlLabel8.Visible = false;
            }
            baglanti.Close();
        }
        public static class TelefonNumara
        {
            //Telefon numarasını ayrıştırmak için regex kullanıyoruz.
            public const string motif = @"^(0(\d{3})(\d{3})(\d{2})(\d{2}))$";

            public static bool TelefonKontrol(string numara)
            {
                if (numara != null) return Regex.IsMatch(numara, motif);
                else return false;
            }
        }
        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
          

           
            string telefon = guna2TextBox7.Text;

            Console.WriteLine(TelefonNumara.TelefonKontrol("05052555555")); //TRUE;
            bool a = (TelefonNumara.TelefonKontrol(telefon)); //FALSE;
            if (a == true)
            {


                guna2TextBox7.MaxLength = 11;
                if (guna2TextBox7.MaxLength < 11)
                {
                    guna2HtmlLabel7.Visible = true;
                    guna2Button2.Enabled = false;
                }
                else if (guna2TextBox7.MaxLength == 11)
                {
                    guna2Button2.Enabled = true;
                    guna2HtmlLabel7.Visible = false;
                }
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2ShadowPanel1.Visible = false;
            guna2ShadowPanel2.Visible = false;
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox4.MaxLength = 50;
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox3.MaxLength = 50;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
           





        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
