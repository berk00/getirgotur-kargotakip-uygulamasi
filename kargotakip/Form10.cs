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
using Twilio;//mesaj göndermenizi sağlayan kütüphane
using Twilio.Rest.Api.V2010.Account;//mesaj göndermenizi sağlayan 2. kütüphane

namespace kargotakip
{
    public partial class Form10 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=BERK;Initial Catalog=kargo;Integrated Security=True");//Kendi veritabanı yolunuzu vermeniz gerekiyor
        private string mus_tel;

        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT * FROM sehirler";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                guna2ComboBox2.Items.Add(dr["sehirler"]);
            }
            baglanti.Close();

          

            SqlCommand komutf = new SqlCommand();
            komutf.CommandText = "SELECT * FROM kargoucreti";
            komutf.Connection = baglanti;
            komutf.CommandType = CommandType.Text;

            SqlDataReader draf;
            baglanti.Open();
            draf = komutf.ExecuteReader();
            while (draf.Read())
            {
                //guna2ComboBox1.Items.Add(dra["kargoucreti"]);
                //guna2ComboBox5.Items.Add(dra["ID"]);

                guna2HtmlLabel20.Text = draf["ID"].ToString();
                guna2TextBox34.Text = draf["kargoucreti"].ToString();
            }
            baglanti.Close();


            SqlCommand komut2 = new SqlCommand();
            komut2.CommandText = "SELECT * FROM pozisyon";
            komut2.Connection = baglanti;
            komut2.CommandType = CommandType.Text;

            SqlDataReader dr2;
            baglanti.Open();
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                guna2ComboBox6.Items.Add(dr2["pozisyon"]);

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
            }
            baglanti.Close();


            SqlCommand komut1a = new SqlCommand();
            komut1a.CommandText = "SELECT * FROM sehirler";
            komut1a.Connection = baglanti;
            komut1a.CommandType = CommandType.Text;

            SqlDataReader dr1a;
            baglanti.Open();
            dr1a = komut1a.ExecuteReader();
            while (dr1a.Read())
            {
                guna2ComboBox5.Items.Add(dr1a["sehirler"]);
            }
            baglanti.Close();



            guna2HtmlLabel9.Text = DateTime.Now.ToString();


            SqlCommand komutq = new SqlCommand();
            komutq.CommandText = "SELECT * FROM sehirler";
            komutq.Connection = baglanti;
            komutq.CommandType = CommandType.Text;

            SqlDataReader drq;
            baglanti.Open();
            drq = komutq.ExecuteReader();
            while (drq.Read())
            {
                guna2ComboBox8.Items.Add(drq["sehirler"]);
            }
            baglanti.Close();

            SqlCommand komutc = new SqlCommand();
            komutc.CommandText = "SELECT * FROM sehirler";
            komutc.Connection = baglanti;
            komutc.CommandType = CommandType.Text;

            SqlDataReader drc;
            baglanti.Open();
            drc = komutc.ExecuteReader();
            while (drc.Read())
            {
                guna2ComboBox7.Items.Add(drc["sehirler"]);
            }
            baglanti.Close();


            SqlCommand komut21 = new SqlCommand();
            komut21.CommandText = "SELECT * FROM pozisyon";
            komut21.Connection = baglanti;
            komut21.CommandType = CommandType.Text;

            SqlDataReader dr21;
            baglanti.Open();
            dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                guna2ComboBox5.Items.Add(dr21["pozisyon"]);

            }
            baglanti.Close();

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select * from subeler where subeadres=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", guna2ComboBox2.Text);



            SqlDataAdapter kmt = new SqlDataAdapter();
            kmt.SelectCommand = komut6;

            DataTable tablo = new DataTable();

            kmt.Fill(tablo);
            SqlDataReader drr2 = komut6.ExecuteReader();
            while (drr2.Read())
            {



                guna2ComboBox3.Items.Add(drr2["subeadi"]);



            }
            baglanti.Close();

            //baglanti.Open();

            //SqlCommand komut = new SqlCommand("select * from subeAdres where sehir=@p1", baglanti);
            //komut.Parameters.AddWithValue("@p1", guna2ComboBox2.Text);



            //SqlDataAdapter kmt5 = new SqlDataAdapter();
            //kmt5.SelectCommand = komut;

            //DataTable tablo5 = new DataTable();

            //kmt5.Fill(tablo5);
            //SqlDataReader drr5 = komut.ExecuteReader();
            //if (drr5.Read())
            //{



            //    guna2ComboBox4.Items.Add(drr5["ilce"]);




            //}
            //baglanti.Close();



        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select * from subeler where subeadi=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", guna2ComboBox3.Text);



            SqlDataAdapter kmt = new SqlDataAdapter();
            kmt.SelectCommand = komut6;

            DataTable tablo = new DataTable();

            kmt.Fill(tablo);
            SqlDataReader drr2 = komut6.ExecuteReader();
            if (drr2.Read())
            {



                guna2HtmlLabel2.Text = drr2["sube_no"].ToString();




            }
            baglanti.Close();


            baglanti.Open();

            SqlCommand komut7 = new SqlCommand("select * from subeAdres where subeID=@p1", baglanti);
            komut7.Parameters.AddWithValue("@p1", guna2HtmlLabel2.Text);



            SqlDataAdapter kmt2 = new SqlDataAdapter();
            kmt2.SelectCommand = komut7;

            DataTable tablo2 = new DataTable();

            kmt2.Fill(tablo2);
            SqlDataReader drr3 = komut7.ExecuteReader();
            if (drr3.Read())
            {



                guna2HtmlLabel3.Text = "İlçe:   " + drr3["ilce"] + "Mahalle:   " + drr3["mahalle"] + "Bina No:   " + drr3["binaNo"] + "Kat:   " + drr3["kat"] + "Kapı No:   " + drr3["kapiNo"] + "Açık Adres:   " + drr3["acikAdres"] + "Posta kodu:   " + drr3["postakodu"].ToString();




            }
            baglanti.Close();
        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //baglanti.Open();

            //SqlCommand komut = new SqlCommand("select * from subeAdres where sehir=@p1", baglanti);
            //komut.Parameters.AddWithValue("@p1", guna2ComboBox2.Text);



            //SqlDataAdapter kmt5 = new SqlDataAdapter();
            //kmt5.SelectCommand = komut;

            //DataTable tablo5 = new DataTable();

            //kmt5.Fill(tablo5);
            //SqlDataReader drr5 = komut.ExecuteReader();
            //if (drr5.Read())
            //{



            //    guna2ComboBox4.Items.Add(drr5["ilce"]);




            //}
            //baglanti.Close();







        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(0, 9000);
            int sayi2 = rastgele.Next(0, 9000);
            int sayi3 = rastgele.Next(0, 9000);
            int sayi4 = rastgele.Next(0, 9000);

            Random rastgele1 = new Random();
            string harfler = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZabcçdefgğhıijklmnoöprsştuüvyz";
            string uret = "";
            for (int i = 0; i < 6; i++)
            {
                uret += harfler[rastgele1.Next(harfler.Length)];
            }



            guna2TextBox4.Text = sayi.ToString() + "" + uret + "" + sayi3.ToString() + "" + sayi4.ToString() + uret + sayi4.ToString();


        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            guna2HtmlLabel21.Text = "+9" + guna2TextBox14.Text;

            if (guna2TextBox12.Text == "" && guna2TextBox1.Text == "" && guna2TextBox3.Text == "" &&
                 guna2ComboBox6.Text == "" && guna2TextBox2.Text == "" && guna2TextBox13.Text == ""
                 && guna2TextBox14.Text == "" && guna2TextBox2.Text == "" && guna2TextBox6.Text == "" && guna2TextBox5.Text == ""
                 && guna2TextBox7.Text == "" && guna2ComboBox1.Text == "" && guna2TextBox8.Text == "" && guna2TextBox9.Text == "" && guna2TextBox10.Text == ""
                && guna2TextBox11.Text == ""

                 )


            {

                Form12 frm = new Form12();
                frm.Show();

            }
            else
            {






                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO calisan(calisanAd,calisanSoyad,calisanEposta,sifre,calismaDurumu,songiristarihi,tc,SubeID,hesapolusturma,sistemMail,tel,pozisyon,sube) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)", baglanti);
                komut.Parameters.AddWithValue("@p1", guna2TextBox12.Text);
                komut.Parameters.AddWithValue("@p2", guna2TextBox1.Text);
                komut.Parameters.AddWithValue("@p3", guna2TextBox3.Text);
                komut.Parameters.AddWithValue("@p4", guna2TextBox4.Text);
                komut.Parameters.AddWithValue("@p5", guna2HtmlLabel8.Text);
                komut.Parameters.AddWithValue("@p6", guna2HtmlLabel9.Text);
                komut.Parameters.AddWithValue("@p7", guna2TextBox2.Text);
                komut.Parameters.AddWithValue("@p8", guna2HtmlLabel2.Text);
                komut.Parameters.AddWithValue("@p9", guna2HtmlLabel9.Text);
                komut.Parameters.AddWithValue("@p10", guna2TextBox13.Text);
                komut.Parameters.AddWithValue("@p11", guna2TextBox14.Text);
                komut.Parameters.AddWithValue("@p12", guna2ComboBox6.Text);
                komut.Parameters.AddWithValue("@p13", guna2ComboBox3.Text);


                komut.ExecuteNonQuery();
                //MessageBox.Show("Kayıt Başarılı");
                baglanti.Close();

                try
                {





                    baglanti.Open();

                    SqlCommand komut6 = new SqlCommand("select * from calisan where calisanEposta=@p1", baglanti);
                    komut6.Parameters.AddWithValue("@p1", guna2TextBox3.Text);



                    SqlDataAdapter kmt = new SqlDataAdapter();
                    kmt.SelectCommand = komut6;

                    DataTable tablo = new DataTable();

                    kmt.Fill(tablo);
                    SqlDataReader drr2 = komut6.ExecuteReader();
                    if (drr2.Read())
                    {


                        guna2HtmlLabel17.Text = drr2["calisanID"].ToString();
                        //guna2ComboBox3.Items.Add(drr2["subeadi"]);



                    }
                    baglanti.Close();







                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("insert into calisanAdres(sehir,ilce,mahalle,sokak,binano,kat,daire,adrestarifi,eposta,calisanID) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", baglanti);
                    komut2.Parameters.AddWithValue("@p1", guna2ComboBox1.Text);
                    komut2.Parameters.AddWithValue("@p2", guna2TextBox6.Text);
                    komut2.Parameters.AddWithValue("@p3", guna2TextBox5.Text);
                    komut2.Parameters.AddWithValue("@p4", guna2TextBox7.Text);
                    komut2.Parameters.AddWithValue("@p5", guna2TextBox8.Text);
                    komut2.Parameters.AddWithValue("@p6", guna2TextBox9.Text);
                    komut2.Parameters.AddWithValue("@p7", guna2TextBox10.Text);
                    komut2.Parameters.AddWithValue("@p8", guna2TextBox11.Text);
                    komut2.Parameters.AddWithValue("@p9", guna2TextBox3.Text);
                    komut2.Parameters.AddWithValue("@p10", guna2HtmlLabel17.Text);


                    komut2.ExecuteNonQuery();
                    //MessageBox.Show("Kayıt Başarılı");
                    Form11 frm11 = new Form11();
                    frm11.Show();


                    baglanti.Close();







                    SmtpClient sc = new SmtpClient();
                    sc.Port = 587;
                    sc.Host = "smtp.outlook.com";
                    sc.EnableSsl = true;



                    string kime = guna2TextBox3.Text;
                    string konu = "Sisteme Giriş Bilgileriniz ";
                    string icerik = "Merhaba, aramıza hoş geldin " + guna2TextBox12.Text + " getir götür kargo sistemi masaüstü uygulamasını kullanman için gerekli bilgileri seninle paylaştık lütfen kullanıcı mailini ve şifreni kimseyle paylaşma unutma istediğin zaman şifreni değiştirebiirsin." + "\n" + "Kullanıcı Mail: " + guna2TextBox13.Text + "\n" + "\n" + "Şifre: " + guna2TextBox4.Text;

                    sc.Credentials = new NetworkCredential("mailadresiniz@outlook.com", "şifreniz");//Mail gönderirken kullanacağınız hesap bilgilerini girmeniz gerekiyor
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("getirgotur@outlook.com.tr", "Getir Götür"); // mail gönderdiğinizde gözükecek isim
                    mail.To.Add(kime);
                    //mail.To.Add(guna2TextBox3.Text);
                    mail.Subject = konu;
                    mail.IsBodyHtml = true;
                    mail.Body = icerik;

                    sc.Send(mail);




                    //var accountSid = "123123123"; //twilio hesabınızdan ulaşabileceğiniz Account SID kodunuzu buraya yazınız 
                    //var authToken = "123123";    //twilio hesabınızdan ulaşabileceğiniz Auth Token kodunuzu buraya yazınız 

                    //TwilioClient.Init(accountSid, authToken);

                    //var message = MessageResource.Create(
                    //       to: new Twilio.Types.PhoneNumber(guna2TextBox14.Text),
                    //       from: new Twilio.Types.PhoneNumber("+2342342342"), //twilio hesabınızdan ulaşabileceğiniz My Twilio phone number kodunuzu buraya yazınız 
                    //       body: "Sisteme Giriş Bilgileriniz "+ "Kullanıcı Mail: " + guna2TextBox13.Text +  "Şifre: " + guna2TextBox4.Text);



                }

                catch (Exception)
                {
                    Form7 sayfa7 = new Form7();
                    sayfa7.Show();

                    ////guna2HtmlLabel8.Text = "Mail adresi yanlış";
                    ///




                }
            }






        }

        private void guna2ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select * from pozisyon where pozisyon=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", guna2ComboBox6.Text);



            SqlDataAdapter kmt = new SqlDataAdapter();
            kmt.SelectCommand = komut6;

            DataTable tablo = new DataTable();

            kmt.Fill(tablo);
            SqlDataReader drr2 = komut6.ExecuteReader();
            if (drr2.Read())
            {


                guna2HtmlLabel10.Text = drr2["pozisyonID"].ToString();
                //guna2ComboBox3.Items.Add(drr2["subeadi"]);



            }
            baglanti.Close();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox14_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox14.MaxLength = 11;

            string telefon = guna2TextBox14.Text;

            Console.WriteLine(TelefonNumara.TelefonKontrol("05052555555")); //TRUE;
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

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox2.MaxLength = 11;

        }

        private void guna2TextBox12_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox12.MaxLength = 25;

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox1.MaxLength = 25;

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox6.MaxLength = 25;

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox5.MaxLength = 25;

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox7.MaxLength = 25;

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox8.MaxLength = 10;

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox9.MaxLength = 10;

        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox10.MaxLength = 10;

        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox11.MaxLength = 35;

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            if (!guna2Panel1.Visible) guna2Transition1.ShowSync(guna2Panel1);
            else guna2Transition1.HideSync(guna2Panel1);

            
        }

        private void guna2ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //baglanti.Open();

            //SqlCommand komut6 = new SqlCommand("select * from pozisyon where pozisyon=@p1", baglanti);
            //komut6.Parameters.AddWithValue("@p1", guna2ComboBox5.Text);



            //SqlDataAdapter kmt = new SqlDataAdapter();
            //kmt.SelectCommand = komut6;

            //DataTable tablo = new DataTable();

            //kmt.Fill(tablo);
            //SqlDataReader drr2 = komut6.ExecuteReader();
            //if (drr2.Read())
            //{


            //    guna2HtmlLabel10.Text = drr2["pozisyonID"].ToString();
            //    //guna2ComboBox3.Items.Add(drr2["subeadi"]);



            //}
            //baglanti.Close();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into pozisyon(pozisyon) Values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", guna2TextBox18.Text);
           



            komut2.ExecuteNonQuery();
            //MessageBox.Show("Kayıt Başarılı");
            Form11 frm11 = new Form11();
            frm11.Show();
            baglanti.Close();
        }

        private void guna2TextBox18_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from pozisyon where pozisyon=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2TextBox18.Text);




            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form6 sayfa6 = new Form6();
                sayfa6.Show();
                //MessageBox.Show("Mail adresi kullanılıyor");
                guna2GradientButton1.Enabled = false;
                guna2HtmlLabel8.Visible = true;


            }
            else
            {
                guna2GradientButton1.Enabled = true;
                guna2HtmlLabel8.Visible = false;
            }
            baglanti.Close();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut11 = new SqlCommand("Update pozisyon set pozisyon=@p2 where pozisyonID=@p1", baglanti);
            komut11.Parameters.AddWithValue("@p1", guna2ComboBox5.Text);
            komut11.Parameters.AddWithValue("@p2", guna2HtmlLabel10.Text);





            komut11.ExecuteNonQuery();
            Form11 frm11 = new Form11();
            frm11.Show();
            baglanti.Close();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {

            if (guna2TextBox20.Text=="" && guna2TextBox17.Text=="" && guna2TextBox17.Text=="" &&
                 guna2ComboBox7.Text==""&& guna2TextBox25.Text=="" && guna2TextBox19.Text == "" 
                 && guna2TextBox24.Text == "" && guna2TextBox23.Text == "" && guna2TextBox22.Text == "" && guna2TextBox16.Text == ""
                 && guna2TextBox15.Text == ""
                )
            {

                Form12 frm = new Form12();
                frm.Show();

            }
            else { 



            int calisansayisi = 0;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO subeler(subeadi,subeadres,maksimumCalisansayisi,calisansayisi) VALUES (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2TextBox20.Text);
            komut.Parameters.AddWithValue("@p2", guna2ComboBox8.Text);
            komut.Parameters.AddWithValue("@p3", guna2TextBox17.Text);
            komut.Parameters.AddWithValue("@p4", calisansayisi);

            komut.ExecuteNonQuery();
            //MessageBox.Show("Kayıt Başarılı");
            baglanti.Close();

            try
            {

            
           

            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select * from subeler where subeadi=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", guna2TextBox20.Text);



            SqlDataAdapter kmt = new SqlDataAdapter();
            kmt.SelectCommand = komut6;

            DataTable tablo = new DataTable();

            kmt.Fill(tablo);
            SqlDataReader drr2 = komut6.ExecuteReader();
            if (drr2.Read())
            {


                guna2HtmlLabel18.Text = drr2["sube_no"].ToString();
                //guna2ComboBox3.Items.Add(drr2["subeadi"]);



            }
            baglanti.Close();


            baglanti.Open();
                SqlCommand komut2 = new SqlCommand("insert into subeAdres(sehir,ilce,mahalle,sokak,binaNo,kat,kapiNo,acikAdres,subeID) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", baglanti);
                komut2.Parameters.AddWithValue("@p1", guna2ComboBox7.Text);
                komut2.Parameters.AddWithValue("@p2", guna2TextBox25.Text);
                komut2.Parameters.AddWithValue("@p3", guna2TextBox24.Text);
                komut2.Parameters.AddWithValue("@p4", guna2TextBox23.Text);
                komut2.Parameters.AddWithValue("@p5", guna2TextBox22.Text);
                komut2.Parameters.AddWithValue("@p6", guna2TextBox19.Text);
                komut2.Parameters.AddWithValue("@p7", guna2TextBox16.Text);
                komut2.Parameters.AddWithValue("@p8", guna2TextBox15.Text);
                komut2.Parameters.AddWithValue("@p9", guna2HtmlLabel18.Text);



            komut2.ExecuteNonQuery();
                Form11 frm11 = new Form11();
                frm11.Show();

                baglanti.Close();
            }
            catch (Exception)
            {

                throw;
            }
            }


        }

        private void guna2ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void guna2TextBox17_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox17.MaxLength = 2;
        }

        private void guna2ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {
            if (guna2GradientTileButton2.Checked == true)
            {
                //guna2Transition2.ShowSync(guna2CustomGradientPanel1);
                guna2Transition2.HideSync(guna2Panel2);

                guna2Panel3.Visible = false;
                guna2Panel2.Visible = false;
            }
        }

        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {

            if (guna2GradientTileButton4.Checked == true)
            {
                guna2Transition2.ShowSync(guna2Panel2);

                guna2CustomGradientPanel1.Visible = false;
                guna2Panel2.Visible = false;
                guna2Panel3.Visible = false;
            }
        }

        private void guna2TextBox20_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from subeler where subeadi=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2TextBox20.Text);




            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
               
                //MessageBox.Show("Mail adresi kullanılıyor");
              
                guna2HtmlLabel19.Visible = true;
                guna2GradientButton4.Enabled = false;


            }
            else
            {
                guna2HtmlLabel19.Visible = false;
                guna2GradientButton4.Enabled = true;
            }
            baglanti.Close();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox4.PasswordChar = '*';
        }

        private void guna2TextBox34_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut11 = new SqlCommand("Update kargoucreti set kargoucreti=@p2 where ID=@p1", baglanti);
            komut11.Parameters.AddWithValue("@p2", guna2TextBox26.Text);
            komut11.Parameters.AddWithValue("@p1", guna2HtmlLabel20.Text);





            komut11.ExecuteNonQuery();
            Form11 frm11 = new Form11();
            frm11.Show();
            baglanti.Close();
        }

        private void guna2GradientTileButton5_Click(object sender, EventArgs e)
        {
            guna2Panel3.Visible = true;
            guna2Panel2.Visible = false;
            guna2CustomGradientPanel1.Visible = true;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
