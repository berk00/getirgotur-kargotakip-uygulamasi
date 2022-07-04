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
    public partial class Form13 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=BERK;Initial Catalog=kargo;Integrated Security=True"); //Kendi veritabanı yolunuzu vermeniz gerekiyor
        private string mus_tel;
        public Form13()
        {
            InitializeComponent();
        }
        public string kullaniciadi;

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked == true)
            {
                guna2ComboBox2.Enabled = true;
            }
            else
            {
                guna2ComboBox2.Enabled = false;

            }


        }
        public static class TelefonNumara
        {
            //Telefon numarasını ayrıştırmak için regex kullanıyoruz.
            public const string motif = @"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$";

            public static bool TelefonKontrol(string numara)
            {
                if (numara != null) return Regex.IsMatch(numara, motif);
                else return false;
            }
        }

        private void guna2TextBox14_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox14.MaxLength = 14;

            string telefon = guna2TextBox14.Text;

            Console.WriteLine(TelefonNumara.TelefonKontrol("0505-255-55-55")); //TRUE;
            bool a = (TelefonNumara.TelefonKontrol(telefon)); //FALSE;
            if (a == true)
            {
                guna2HtmlLabel14.Visible = false;
                guna2GradientButton3.Enabled = true;
            }
            else
            {
                guna2HtmlLabel14.Visible = true;
                guna2GradientButton3.Enabled = false;
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox4.MaxLength = 14;

            string telefon = guna2TextBox4.Text;

            Console.WriteLine(TelefonNumara.TelefonKontrol("0505-255-55-55")); //TRUE;
            bool a = (TelefonNumara.TelefonKontrol(telefon)); //FALSE;
            if (a == true)
            {
                guna2HtmlLabel16.Visible = false;
                guna2GradientButton3.Enabled = true;
            }
            else
            {
                guna2HtmlLabel16.Visible = true;
                guna2GradientButton3.Enabled = false;
            }
        }
        Random rastgele = new Random();

        private void Form13_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kargoDataSet1.KargoDurum' table. You can move, or remove it, as needed.
           // this.kargoDurumTableAdapter1.Fill(this.kargoDataSet1.KargoDurum);
            // TODO: This line of code loads data into the 'kargoDataSet.KargoDurum' table. You can move, or remove it, as needed.
           // this.kargoDurumTableAdapter.Fill(this.kargoDataSet.KargoDurum);
            int sayi = rastgele.Next(0, 9000);
            int sayi2 = rastgele.Next(0, 9000);
            int sayi3 = rastgele.Next(0, 9000);
            int sayi4 = rastgele.Next(0, 9000);
            guna2TextBox25.Text = sayi.ToString() + " " + sayi2.ToString() + " " + sayi3.ToString() + " " + sayi4.ToString();


            guna2HtmlLabel21.Text = kullaniciadi;

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM subeler";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                guna2ComboBox2.Items.Add(dr["subeadi"]);
            }
            baglanti.Close();




            SqlCommand komut2 = new SqlCommand();
            komut2.CommandText = "SELECT *FROM kargoucreti";
            komut2.Connection = baglanti;
            komut2.CommandType = CommandType.Text;

            SqlDataReader dr2;
            baglanti.Open();
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                guna2HtmlLabel11.Text = dr2["kargoucreti"].ToString();
            }
            baglanti.Close();



            SqlCommand komuta = new SqlCommand();
            komuta.CommandText = "SELECT * FROM sehirler";
            komuta.Connection = baglanti;
            komuta.CommandType = CommandType.Text;

            SqlDataReader dra;
            baglanti.Open();
            dra = komuta.ExecuteReader();
            while (dra.Read())
            {
                guna2ComboBox1.Items.Add(dra["sehirler"]);
                guna2ComboBox5.Items.Add(dra["sehirler"]);
            }
            baglanti.Close();



            //baglanti.Open();

            //SqlCommand komut6 = new SqlCommand("select * from subeler where subeadres=@p1", baglanti);
            //komut6.Parameters.AddWithValue("@p1", guna2HtmlLabel24.Text);



            //SqlDataAdapter kmt = new SqlDataAdapter();
            //kmt.SelectCommand = komut6;

            //DataTable tablo = new DataTable();

            //kmt.Fill(tablo);
            //SqlDataReader drr2 = komut6.ExecuteReader();
            //while (drr2.Read())
            //{



            //    guna2ComboBox2.Items.Add(drr2["subeadi"]);



            //}
            //baglanti.Close();


            baglanti.Open();

            SqlCommand komuta6 = new SqlCommand("select * from calisan where calisanEposta=@p1", baglanti);
            komuta6.Parameters.AddWithValue("@p1", guna2HtmlLabel21.Text);
            SqlDataAdapter kmtaa = new SqlDataAdapter();
            kmtaa.SelectCommand = komuta6;

            DataTable tabloaa = new DataTable();

            kmtaa.Fill(tabloaa);
            SqlDataReader drra2 = komuta6.ExecuteReader();
            while (drra2.Read())
            {



                //guna2ComboBox2.Items.Add(drra2["subeadi"]);
                guna2HtmlLabel22.Text =drra2["calisanAd"].ToString();
                guna2HtmlLabel23.Text = drra2["calisanSoyad"].ToString();
                guna2HtmlLabel17.Text = drra2["calisanID"].ToString();
                guna2HtmlLabel32.Text = drra2["sube"].ToString();






            }
            baglanti.Close();





            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select * from KargoDurum where cikisSube=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", guna2HtmlLabel32.Text);
            SqlDataAdapter kmt1 = new SqlDataAdapter();
            kmt1.SelectCommand = komut1;

            DataTable tablo1 = new DataTable();

            kmt1.Fill(tablo1);
            SqlDataReader drr1 = komut1.ExecuteReader();
            while (drr1.Read())
            {



                guna2ComboBox6.Items.Add(drr1["kargoisim"]);
                //guna2HtmlLabel22.Text = drr1["calisanAd"].ToString();
                //guna2HtmlLabel23.Text = drr1["calisanSoyad"].ToString();
                //guna2HtmlLabel17.Text = drr1["calisanID"].ToString();
                //guna2HtmlLabel10.Text = drr1["sube"].ToString();






            }
            baglanti.Close();



        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

            guna2HtmlLabel7.Text = guna2ComboBox2.Text + " " + guna2TextBox6.Text + " " + guna2TextBox5.Text + " " + guna2TextBox7.Text + " " + guna2TextBox8.Text + " " + guna2TextBox9.Text + " " + guna2TextBox10.Text + " " + guna2TextBox11.Text;
            guna2HtmlLabel5.Text =  guna2TextBox19.Text + " " + guna2TextBox18.Text + " " + guna2TextBox17.Text + " " + guna2TextBox16.Text + " " + guna2TextBox15.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into kargoGonder(Gonderen_Ad,Gonderen_Soyad,Gonderen_TelNo,Gonderen_Mail,Gonderen_Adres,AliciAd,AliciSoyad,AliciTel,KargoTakipNo,AliciMail,KargoAgirlik,KargoUcret,Alicisehir,alici_ilce,Alici_acikadres,Alici_adresTarifi,cikisSube,varisSube) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18)", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2TextBox12.Text);
            komut.Parameters.AddWithValue("@p2", guna2TextBox1.Text);
            komut.Parameters.AddWithValue("@p3", guna2TextBox14.Text);
            komut.Parameters.AddWithValue("@p4", guna2TextBox3.Text);
            komut.Parameters.AddWithValue("@p5", guna2HtmlLabel7.Text);
            komut.Parameters.AddWithValue("@p6", guna2TextBox21.Text);
            komut.Parameters.AddWithValue("@p7", guna2TextBox23.Text);
            komut.Parameters.AddWithValue("@p8", guna2TextBox4.Text);
            komut.Parameters.AddWithValue("@p9", guna2TextBox25.Text);
            komut.Parameters.AddWithValue("@p10", guna2TextBox22.Text);
            komut.Parameters.AddWithValue("@p11", guna2TextBox26.Text);
            komut.Parameters.AddWithValue("@p12", guna2HtmlLabel4.Text);
            komut.Parameters.AddWithValue("@p13", guna2ComboBox5.Text);
            komut.Parameters.AddWithValue("@p14", guna2TextBox20.Text);
            komut.Parameters.AddWithValue("@p15", guna2HtmlLabel5.Text);
            komut.Parameters.AddWithValue("@p16", guna2TextBox13.Text);
            komut.Parameters.AddWithValue("@p17", guna2HtmlLabel10.Text);
            komut.Parameters.AddWithValue("@p18", guna2ComboBox2.Text);


            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı");
            baglanti.Close();


            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.outlook.com";
            sc.EnableSsl = true;



            string kime = guna2TextBox3.Text;
            string konu = "Kargonuz Yola Çıkmak Üzere Hazırlanıyor";
            string icerik = "Kargonuz Varış Adresine Ulaştırılmak Üzere Hazırlanıyor. Kargo Takip Kodunuz: "+ guna2TextBox25.Text;

            sc.Credentials = new NetworkCredential("mailadresiniz@outlook.com", "şifreniz");//Mail gönderirken kullanacağınız hesap bilgilerini girmeniz gerekiyor
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("getirgotur@outlook.com.tr", "Getir Götür"); // mail gönderdiğinizde gözükecek isim
            mail.To.Add(kime);
            //mail.To.Add(guna2TextBox3.Text);
            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;

            sc.Send(mail);





            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into KargoDurum(KargoTakipNo,KargoDurumu,KargoOlusturmaTarihi,cikisSube,varisSube,kargoisim) Values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut2.Parameters.AddWithValue("@p1", guna2TextBox25.Text);
            komut2.Parameters.AddWithValue("@p2", "Yola Çıkmak Üzere Hazırlanıyor...");
            komut2.Parameters.AddWithValue("@p3", DateTime.Now);
            komut2.Parameters.AddWithValue("@p4", guna2HtmlLabel10.Text);
            komut2.Parameters.AddWithValue("@p5", guna2ComboBox2.Text);
            komut2.Parameters.AddWithValue("@p6", guna2TextBox29.Text);


            komut2.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı");
            baglanti.Close();
        }

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            if (!guna2Panel1.Visible) guna2Transition1.ShowSync(guna2Panel1);
            else guna2Transition1.HideSync(guna2Panel1);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            


            int a,b;
            b = Convert.ToInt32(guna2TextBox26.Text);
            a =Convert.ToInt32(guna2HtmlLabel11.Text);

            if (b<=5)
            {
                guna2HtmlLabel4.Text = "30";
            }

            int islem;
            islem = a * b;
            guna2HtmlLabel4.Text = islem.ToString();
        }

        private void guna2TextBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox5.Text = guna2HtmlLabel24.Text;
        }

        private void guna2TextBox49_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void guna2TextBox48_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox2.Checked == true)
            {
                guna2TextBox49.Visible = true;
                guna2TextBox28.Visible = true;
                guna2ComboBox4.Visible = true;
                guna2TextBox27.Visible = true;
                guna2HtmlLabel26.Text = "Teslim Edildi";
                guna2GradientButton4.Enabled = true;
                guna2GradientButton2.Enabled = false;

            }
            else if (guna2CheckBox2.Checked == false)
            {
                guna2TextBox49.Visible = false;
                guna2TextBox28.Visible = false;
                guna2ComboBox4.Visible = false;
                guna2TextBox27.Visible = false;
                guna2HtmlLabel26.Text = "Yolda";
                guna2GradientButton4.Enabled = false;
                guna2GradientButton2.Enabled = true;

            }
        }

        private void guna2ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select * from KargoDurum where kargoisim=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", guna2ComboBox6.Text);
            SqlDataAdapter kmt1 = new SqlDataAdapter();
            kmt1.SelectCommand = komut1;

            DataTable tablo1 = new DataTable();

            kmt1.Fill(tablo1);
            SqlDataReader drr1 = komut1.ExecuteReader();
            while (drr1.Read())
            {



                //guna2ComboBox6.Items.Add(drr1["kargoisim"]);
                guna2TextBox48.Text = drr1["KargoTakipNo"].ToString();
                guna2TextBox47.Text = drr1["KargoDurumu"].ToString();
                //guna2HtmlLabel17.Text = drr1["calisanID"].ToString();
                //guna2HtmlLabel10.Text = drr1["sube"].ToString();






            }
            baglanti.Close();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select * from KargoGonder where KargoTakipNo=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", guna2TextBox48.Text);



            SqlDataAdapter kmt = new SqlDataAdapter();
            kmt.SelectCommand = komut6;

            DataTable tablo = new DataTable();

            kmt.Fill(tablo);
            SqlDataReader drr2 = komut6.ExecuteReader();
            while (drr2.Read())
            {



                guna2HtmlLabel29.Text=(drr2["AliciMail"]).ToString();



            }
            baglanti.Close();





            baglanti.Open();

            SqlCommand komut77 = new SqlCommand("select * from kullanici where eposta=@p1", baglanti);
            komut77.Parameters.AddWithValue("@p1", guna2HtmlLabel29.Text);



            SqlDataAdapter kmt77 = new SqlDataAdapter();
            kmt77.SelectCommand = komut77;

            DataTable tablo77 = new DataTable();

            kmt77.Fill(tablo77);
            SqlDataReader drr77 = komut77.ExecuteReader();
            while (drr77.Read())
            {



                guna2HtmlLabel31.Text = (drr77["tel"]).ToString();



            }
            baglanti.Close();


            //guna2ComboBox3.Text = guna2TextBox47.Text;
            guna2TextBox47.Text = guna2ComboBox3.Text;


            baglanti.Open();
            SqlCommand komut11 = new SqlCommand("Update KargoDurum set kargoDurumu=@p2, SonGuncellenmeTarihi=@p3 where KargoTakipNo=@p1", baglanti);
            komut11.Parameters.AddWithValue("@p1", guna2TextBox48.Text);
            komut11.Parameters.AddWithValue("@p2", guna2TextBox47.Text);
            komut11.Parameters.AddWithValue("@p3", DateTime.Now);




            komut11.ExecuteNonQuery();
            Form11 frm11 = new Form11();
            frm11.Show();
            baglanti.Close();

            try
            {

                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.outlook.com";
                sc.EnableSsl = true;



                string kime = guna2HtmlLabel29.Text;
                string konu = guna2ComboBox3.Text;
                string icerik = "Kargonuzun Son Durumu: " + guna2TextBox47.Text;

                sc.Credentials = new NetworkCredential("mailadresiniz@outlook.com", "şifreniz");//Mail gönderirken kullanacağınız hesap bilgilerini girmeniz gerekiyor
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("getirgotur@outlook.com.tr", "Getir Götür"); // mail gönderdiğinizde gözükecek isim
                mail.To.Add(kime);
                //mail.To.Add(guna2TextBox3.Text);
                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = icerik;

                sc.Send(mail);
            }
            catch
            {
                frm11.Show();
                baglanti.Close();
            }




            try
            {
                var accountSid = "123123123"; //twilio hesabınızdan ulaşabileceğiniz Account SID kodunuzu buraya yazınız 
                var authToken = "123123";    //twilio hesabınızdan ulaşabileceğiniz Auth Token kodunuzu buraya yazınız 

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                       to: new Twilio.Types.PhoneNumber(guna2HtmlLabel31.Text),
                       from: new Twilio.Types.PhoneNumber("+23423424234"),//twilio hesabınızdan ulaşabileceğiniz My Twilio phone number kodunuzu buraya yazınız
                       body: "Kargonuz Son Durumu: " + guna2TextBox48.Text + " getirgötür app");
            }
            catch {

                frm11.Show();
            }
            Form11 frm = new Form11();
            frm.Show();

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {

            guna2HtmlLabel20.Text = guna2TextBox49.Text + " " + guna2TextBox28.Text.ToUpper();
            baglanti.Open();
            SqlCommand komut11 = new SqlCommand("Update KargoDurum set kargoDurumu=@p2, SonGuncellenmeTarihi=@p3, teslimalan=@p4, durum=@p5 where KargoTakipNo=@p1", baglanti);
            komut11.Parameters.AddWithValue("@p1", guna2TextBox48.Text);
            komut11.Parameters.AddWithValue("@p2", guna2TextBox27.Text);
            komut11.Parameters.AddWithValue("@p3", DateTime.Now);
            komut11.Parameters.AddWithValue("@p4", guna2HtmlLabel20.Text);
            komut11.Parameters.AddWithValue("@p5", guna2HtmlLabel26.Text);




            komut11.ExecuteNonQuery();
            Form11 frm11 = new Form11();
            frm11.Show();
            baglanti.Close();

            string isim;
            isim = guna2TextBox49.Text + " " + guna2TextBox28.Text;
            try {

                var accountSid = "123123123"; //twilio hesabınızdan ulaşabileceğiniz Account SID kodunuzu buraya yazınız 
                var authToken = "123123";    //twilio hesabınızdan ulaşabileceğiniz Auth Token kodunuzu buraya yazınız 

                TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                   to: new Twilio.Types.PhoneNumber(guna2HtmlLabel31.Text),
                       from: new Twilio.Types.PhoneNumber("+23423424234"),//twilio hesabınızdan ulaşabileceğiniz My Twilio phone number kodunuzu buraya yazınız
                   body: "Kargonuz Teslim Edildi "+isim);
}
            catch
            {
               
                frm11.Show();
               

                MessageBox.Show("Telefon Numarası Bulunamadı");
            }



        }

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {
            guna2CustomGradientPanel2.Visible = false;
            guna2CustomGradientPanel1.Visible = true;
        }

        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {
            guna2CustomGradientPanel2.Visible = true;
            guna2CustomGradientPanel1.Visible = false;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox47_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox2.MaxLength = 11;

        }

        private void guna2TextBox24_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox24.MaxLength = 11;

        }

        private void guna2TextBox24_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
