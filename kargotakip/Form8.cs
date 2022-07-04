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

namespace kargotakip
{

    public partial class Form8 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=BERK;Initial Catalog=kargo;Integrated Security=True"); //Kendi veritabanı yolunuzu vermeniz gerekiyor

        public Form8()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox12_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select * from kargoGonder where KargoTakipNo=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", guna2TextBox12.Text);



            SqlDataAdapter kmt = new SqlDataAdapter();
            kmt.SelectCommand = komut6;

            DataTable tablo = new DataTable();

            kmt.Fill(tablo);
            SqlDataReader drr2 = komut6.ExecuteReader();
            if (drr2.Read())
            {



                //for (int i = 0; i < 1; i++)
                //{
                    //Label btn = new Label();
                    //btn.Location = new Point(300, 30 * i);
                    //btn.Name = i.ToString();
                    //btn.Text = "Gönderen Adı: " + drr2["Gonderen_Ad"] + " " + "Gönderen Soyadı: " + drr2["Gonderen_Soyad"].ToString();
                    //btn.Width = 100;
                    //btn.Height = 50;
                    //this.Controls.Add(btn); //bu şekilde form'a ekleme yapılırsa tüm butonlar üst üste çıkacaktır
                                            //flowLayoutPanel1.Controls.Add(btn); //oluşan butonlar üstüste binmez

                    guna2HtmlLabel1.Text= "Gönderen: " + drr2["Gonderen_Ad"] + " " + drr2["Gonderen_Soyad"].ToString().ToUpper();
                    guna2HtmlLabel2.Text = "Teslimat Adresi: " + drr2["Alici_acikadres"].ToString();
                    guna2HtmlLabel3.Text = "Kargo Ağırlığı: " + drr2["KargoAgirlik"].ToString();


                //}

                

            }
            baglanti.Close();


            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("select * from KargoDurum where KargoTakipNo=@p1", baglanti);
            komut8.Parameters.AddWithValue("@p1", guna2TextBox12.Text);



            SqlDataAdapter kmt2 = new SqlDataAdapter();
            kmt2.SelectCommand = komut8;

            DataTable tablo2 = new DataTable();

            kmt2.Fill(tablo2);
            SqlDataReader drr4 = komut8.ExecuteReader();
            if (drr4.Read())
            {
                //guna2HtmlLabel6.Text = drr4["KargoDurumu"].ToString();
                guna2HtmlLabel27.Text = drr4["KargoDurumu"].ToString();
               
            }
            baglanti.Close();



        }
        public string kullaniciadi;
        private void Form8_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel5.Visible = false;

            guna2HtmlLabel4.Text = kullaniciadi;
            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select * from kullanici where eposta=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", guna2HtmlLabel4.Text);



            SqlDataAdapter kmt = new SqlDataAdapter();
            kmt.SelectCommand = komut6;

            DataTable tablo = new DataTable();

            kmt.Fill(tablo);
            SqlDataReader drr2 = komut6.ExecuteReader();
            if (drr2.Read())
            {
                guna2HtmlLabel5.Text = drr2["ad"] + " " +drr2["soyad"];
                guna2HtmlLabel36.Text = drr2["ad"].ToString();
                guna2HtmlLabel37.Text = drr2["kullaniciID"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("select * from KargoGonder where AliciMail=@p1", baglanti);
            komut7.Parameters.AddWithValue("@p1", guna2HtmlLabel4.Text);



            SqlDataAdapter kmt1 = new SqlDataAdapter();
            kmt1.SelectCommand = komut7;

            DataTable tablo1 = new DataTable();

            kmt1.Fill(tablo1);
            SqlDataReader drr3 = komut7.ExecuteReader();
            if (drr3.Read())
            {
                guna2HtmlLabel7.Text = drr3["KargoTakipNo"].ToString();
            }
            baglanti.Close();


            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("select * from KargoDurum where KargoTakipNo=@p1", baglanti);
            komut8.Parameters.AddWithValue("@p1", guna2HtmlLabel7.Text);



            SqlDataAdapter kmt2 = new SqlDataAdapter();
            kmt2.SelectCommand = komut8;

            DataTable tablo2 = new DataTable();

            kmt2.Fill(tablo2);
            SqlDataReader drr4 = komut8.ExecuteReader();
            if (drr4.Read())
            {
                guna2HtmlLabel27.Text = drr4["KargoDurumu"].ToString();
                //guna2HtmlLabel1.Text = drr4["KargoDurumu"].ToString();
                //guna2HtmlLabel2.Text = "Gönderen Adı: " + drr4["Gonderen_Ad"] + " " + "Gönderen Soyadı: " + drr4["Gonderen_Soyad"].ToString();
            }
            baglanti.Close();

            baglanti.Open();

            SqlCommand komut16 = new SqlCommand("select * from kargoGonder where KargoTakipNo=@p1", baglanti);
            komut16.Parameters.AddWithValue("@p1", guna2HtmlLabel7.Text);



            SqlDataAdapter kmt23 = new SqlDataAdapter();
            kmt23.SelectCommand = komut6;

            DataTable tablo22 = new DataTable();

            kmt23.Fill(tablo22);
            SqlDataReader drr22 = komut16.ExecuteReader();
            while (drr22.Read())
            {



                //for (int i = 0; i < 1; i++)
                //{
                //Label btn = new Label();
                //btn.Location = new Point(300, 30 * i);
                //btn.Name = i.ToString();
                //btn.Text = "Gönderen Adı: " + drr2["Gonderen_Ad"] + " " + "Gönderen Soyadı: " + drr2["Gonderen_Soyad"].ToString();
                //btn.Width = 100;
                //btn.Height = 50;
                //this.Controls.Add(btn); //bu şekilde form'a ekleme yapılırsa tüm butonlar üst üste çıkacaktır
                //flowLayoutPanel1.Controls.Add(btn); //oluşan butonlar üstüste binmez

                guna2HtmlLabel1.Text = "Gönderen Adı: " + drr22["Gonderen_Ad"] + " " + drr22["Gonderen_Soyad"].ToString().ToUpper();
                guna2HtmlLabel2.Text = "Teslimat Adresi: " + drr22["Alici_acikadres"].ToString()+" "+ drr22["Alici_AdresTarifi"].ToString();
                guna2HtmlLabel3.Text = "Kargo Ağırlığı: " + drr22["KargoAgirlik"].ToString();


                //}



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
                guna2HtmlLabel20.Text = dr2["kargoucreti"].ToString();
            }
            baglanti.Close();




            baglanti.Open();
            SqlCommand komut81 = new SqlCommand("select * from KargoGonder where Gonderen_Mail=@p1", baglanti);
            komut81.Parameters.AddWithValue("@p1", guna2HtmlLabel4.Text);



            SqlDataAdapter kmt21 = new SqlDataAdapter();
            kmt21.SelectCommand = komut81;

            DataTable tablo11 = new DataTable();

            kmt21.Fill(tablo11);
            SqlDataReader drr31 = komut7.ExecuteReader();
            if (drr31.Read())
            {
                guna2HtmlLabel26.Text = drr31["KargoTakipNo"].ToString();
                //guna2HtmlLabel25.Text = drr31["KargoTakipNo"].ToString();
            }
            baglanti.Close();







            baglanti.Open();

            SqlCommand komut = new SqlCommand("select * from kargoGonder where KargoTakipNo=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2HtmlLabel26.Text);



            SqlDataAdapter kmt0 = new SqlDataAdapter();
            kmt0.SelectCommand = komut;

            DataTable tablo0 = new DataTable();

            kmt0.Fill(tablo0);
            SqlDataReader drr0 = komut.ExecuteReader();
            while (drr0.Read())
            {



                //for (int i = 0; i < 1; i++)
                //{
                //Label btn = new Label();
                //btn.Location = new Point(300, 30 * i);
                //btn.Name = i.ToString();
                //btn.Text = "Gönderen Adı: " + drr2["Gonderen_Ad"] + " " + "Gönderen Soyadı: " + drr2["Gonderen_Soyad"].ToString();
                //btn.Width = 100;
                //btn.Height = 50;
                //this.Controls.Add(btn); //bu şekilde form'a ekleme yapılırsa tüm butonlar üst üste çıkacaktır
                //flowLayoutPanel1.Controls.Add(btn); //oluşan butonlar üstüste binmez

                guna2HtmlLabel25.Text = "Alıcı Adı: " + drr0["AliciAd"] + " " + drr0["AliciSoyad"].ToString().ToUpper();
                guna2HtmlLabel2.Text = "Teslimat Adresi: " + drr0["Alici_acikadres"].ToString() + " " + drr0["Alici_AdresTarifi"].ToString();
                guna2HtmlLabel3.Text = "Kargo Ağırlığı: " + drr0["KargoAgirlik"].ToString();


                //}



            }
            baglanti.Close();




            baglanti.Open();
            SqlCommand komut55 = new SqlCommand("select * from KargoDurum where KargoTakipNo=@p1", baglanti);
            komut55.Parameters.AddWithValue("@p1", guna2HtmlLabel7.Text);



            SqlDataAdapter kmt55 = new SqlDataAdapter();
            kmt55.SelectCommand = komut55;

            DataTable tablo55 = new DataTable();

            kmt55.Fill(tablo55);
            SqlDataReader drr55 = komut55.ExecuteReader();
            if (drr55.Read())
            {
                guna2HtmlLabel24.Text = drr55["KargoDurumu"]+" "+ drr55["SonGuncellenmeTarihi"].ToString();
                guna2HtmlLabel32.Text = drr55["KargoDurumu"].ToString();
                //guna2HtmlLabel25.Text = drr31["KargoTakipNo"].ToString();
            }
            baglanti.Close();
            guna2HtmlLabel32.Visible = false;
            if (guna2HtmlLabel32.Text== "Yola Çıkmak İçin Hazır")
            {
                guna2HtmlLabel28.Text = "Yola Çıkmak Üzere Hazırlanıyor...";
                guna2PictureBox4.Visible = false;
                guna2PictureBox8.Visible = false;
                guna2PictureBox9.Visible = false;
                guna2HtmlLabel28.Visible = false;
                guna2HtmlLabel30.Visible = false;
                guna2HtmlLabel31.Visible = false;
                panel1.Visible = false;

                guna2HtmlLabel28.Visible = true;
                guna2PictureBox3.Visible = true;
                guna2PictureBox5.Visible = false;
                guna2PictureBox6.Visible = false;
                guna2PictureBox7.Visible = false;
            }
            else if (guna2HtmlLabel32.Text == "Size Ulaştırılmak Üzere Yolda")
            {
                guna2HtmlLabel29.Text = "Size Ulaştırılmak Üzere Yolda";
                guna2PictureBox3.Visible = false;
                guna2PictureBox8.Visible = false;
                guna2PictureBox9.Visible = false;
                guna2HtmlLabel28.Visible = false;
                guna2HtmlLabel30.Visible = false;
                guna2HtmlLabel31.Visible = false;
                guna2PictureBox6.Visible = false;
                guna2PictureBox7.Visible = false;

                guna2HtmlLabel29.Visible = true;
                guna2PictureBox4.Visible = true;
                guna2PictureBox5.Visible = true;
                panel1.Visible = false;
            }
            else if (guna2HtmlLabel32.Text == "Size Ulaştırılmak Üzere Dağıtıma Çıktı") 
            {
                guna2HtmlLabel30.Text = "Dağıtıma Çıktı";
                guna2PictureBox3.Visible = false;
                guna2PictureBox8.Visible = true;
                guna2PictureBox9.Visible = false;
                guna2HtmlLabel28.Visible = false;
                guna2HtmlLabel30.Visible = true;
                guna2HtmlLabel31.Visible = false;
                guna2PictureBox7.Visible = false;
                panel1.Visible = false;
                guna2PictureBox6.Visible = true;

                guna2HtmlLabel29.Visible = false;
                guna2PictureBox4.Visible = false;
                guna2PictureBox5.Visible = false;
            }
             else if (guna2HtmlLabel32.Text == "Kargonuz Teslim Edildi") 
            {
                guna2HtmlLabel31.Text = "Kargo Teslim Edildi";
                guna2PictureBox3.Visible = true;
                guna2PictureBox8.Visible = false;
                guna2PictureBox9.Visible = true;
                guna2HtmlLabel28.Visible = false;
                guna2HtmlLabel30.Visible = false;
                guna2HtmlLabel31.Visible = true;
                guna2PictureBox6.Visible = true;
                panel1.Visible = false;
                guna2PictureBox7.Visible = true;

                guna2HtmlLabel29.Visible = false;
                guna2PictureBox4.Visible = false;
                guna2PictureBox5.Visible = true;


                baglanti.Open();

                SqlCommand komut9 = new SqlCommand("select * from KargoDurum where KargoTakipNo=@p1", baglanti);
                komut9.Parameters.AddWithValue("@p1", guna2HtmlLabel7.Text);



                SqlDataAdapter kmt9 = new SqlDataAdapter();
                kmt9.SelectCommand = komut9;

                DataTable tablo9 = new DataTable();

                kmt9.Fill(tablo9);
                SqlDataReader drr9 = komut9.ExecuteReader();
                while (drr9.Read())
                {



                    //for (int i = 0; i < 1; i++)
                    //{
                    //Label btn = new Label();
                    //btn.Location = new Point(300, 30 * i);
                    //btn.Name = i.ToString();
                    //btn.Text = "Gönderen Adı: " + drr2["Gonderen_Ad"] + " " + "Gönderen Soyadı: " + drr2["Gonderen_Soyad"].ToString();
                    //btn.Width = 100;
                    //btn.Height = 50;
                    //this.Controls.Add(btn); //bu şekilde form'a ekleme yapılırsa tüm butonlar üst üste çıkacaktır
                    //flowLayoutPanel1.Controls.Add(btn); //oluşan butonlar üstüste binmez

                    guna2HtmlLabel38.Text = drr9["teslimalan"] + " " + drr9["SonGuncellenmeTarihi"].ToString();
                    //guna2HtmlLabel2.Text = "Teslimat Adresi: " + drr22["Alici_acikadres"].ToString() + " " + drr22["Alici_AdresTarifi"].ToString();
                    //guna2HtmlLabel3.Text = "Kargo Ağırlığı: " + drr22["KargoAgirlik"].ToString();


                    //}



                }
                baglanti.Close();





            }
            else if (guna2HtmlLabel32.Text == "Aktif Sorgu Yok")
            {
                guna2HtmlLabel30.Text = "Dağıtıma Çıktı";
                guna2HtmlLabel1.Visible = false;
                guna2HtmlLabel2.Visible = false;
                guna2HtmlLabel3.Visible = false;
                guna2HtmlLabel27.Visible = false;

                guna2Panel2.Visible = false;
                panel1.Visible = true;

                guna2PictureBox8.Visible = true;
                guna2PictureBox9.Visible = false;
                guna2HtmlLabel28.Visible = false;
                guna2HtmlLabel30.Visible = false;
                guna2HtmlLabel31.Visible = false;
                guna2PictureBox7.Visible = false;

                guna2PictureBox6.Visible = true;

                guna2HtmlLabel29.Visible = false;
                guna2PictureBox4.Visible = false;
                guna2PictureBox5.Visible = false;
            }
           




            baglanti.Open();
            SqlCommand komut21 = new SqlCommand("select * from adres where mail=@p1", baglanti);
            komut21.Parameters.AddWithValue("@p1", guna2HtmlLabel4.Text);



            SqlDataAdapter kmt25 = new SqlDataAdapter();
            kmt25.SelectCommand = komut21;

            DataTable tablo21 = new DataTable();

            kmt25.Fill(tablo21);
            SqlDataReader drr21 = komut21.ExecuteReader();
            while (drr21.Read())
            {
                guna2HtmlLabel33.Text = drr21["sehir"].ToString();
            }
            baglanti.Close();


            string district ="";
            string province = guna2HtmlLabel2.Text;
            //string country = txtBox3.text;
            StringBuilder location = new StringBuilder("http://maps.google.com/maps?q=&#8221");
            if (district != " ")
            {
                location.Append(district+",");
            }
            if (province !=" "){
                location.Append(province);
            }
            //if (country !=” ”){
            //    location.Append(country + ”,” + ”+”);
            //}
            webBrowser1.Navigate(location.ToString());


        }

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {
           


            if (guna2GradientTileButton2.Checked==true)
            {
                guna2Transition1.ShowSync(guna2CustomGradientPanel2);

                guna2CustomGradientPanel2.Visible = true;

                guna2CustomGradientPanel1.Visible = false;
                guna2CustomGradientPanel4.Visible = false;
                guna2CustomGradientPanel3.Visible = false;
            }
           
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {

           
            if (guna2GradientTileButton1.Checked == true)
            {
                //guna2Transition2.ShowSync(guna2CustomGradientPanel1);
                guna2Transition1.HideSync(guna2CustomGradientPanel1);
                guna2CustomGradientPanel1.Visible = true;

                guna2CustomGradientPanel2.Visible = false;
                guna2CustomGradientPanel4.Visible = false;
                guna2CustomGradientPanel3.Visible = false;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select * from kargoGonder where KargoTakipNo=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", guna2TextBox12.Text);



            SqlDataAdapter kmt = new SqlDataAdapter();
            kmt.SelectCommand = komut6;

            DataTable tablo = new DataTable();

            kmt.Fill(tablo);
            SqlDataReader drr2 = komut6.ExecuteReader();
            if (drr2.Read())
            {



                //for (int i = 0; i < 1; i++)
                //{
                    //Label btn = new Label();
                    //btn.Location = new Point(300, 30 * i);
                    //btn.Name = i.ToString();
                    //btn.Text = "" + drr2["Gonderen_Ad"] + " " + "" + drr2["Gonderen_Soyad"].ToString().ToUpper();
                    //btn.Width = 100;
                    //btn.Height = 50;
                    //this.Controls.Add(btn); //bu şekilde form'a ekleme yapılırsa tüm butonlar üst üste çıkacaktır
                    //                        //flowLayoutPanel1.Controls.Add(btn); //oluşan butonlar üstüste binmez

                    guna2HtmlLabel25.Text = "Alıcı Adı: " + drr2["AliciAd"] + " " + drr2["AliciSoyad"].ToString().ToUpper();
                    guna2HtmlLabel2.Text = "Teslimat Adresi: " + drr2["Alici_acikadres"].ToString() + " " + drr2["Alici_AdresTarifi"].ToString();
                    guna2HtmlLabel3.Text = "Kargo Ağırlığı: " + drr2["KargoAgirlik"].ToString();

                    guna2HtmlLabel9.Visible = true;
                    guna2HtmlLabel10.Visible = true;

                //}



            }
            baglanti.Close();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            int a, b;
            b = Convert.ToInt32(guna2TextBox26.Text);
            a = Convert.ToInt32(guna2HtmlLabel20.Text);

            if (b <= 5)
            {
                guna2HtmlLabel18.Text = "30";
                guna2HtmlLabel19.Text = "30";
            }

            int islem;
            islem = a * b;
            guna2HtmlLabel18.Text = islem.ToString();
            guna2HtmlLabel19.Text = islem.ToString();

            int islem2;
            islem2 = islem - 5;
            guna2HtmlLabel17.Text = islem2.ToString();

            guna2ShadowPanel3.Visible = true;
        }

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            if (true)
            {

            }

            guna2CustomGradientPanel3.Visible = true;
            guna2CustomGradientPanel2.Visible = false;
            guna2CustomGradientPanel1.Visible = false;
            guna2CustomGradientPanel4.Visible = false;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select * from kargoGonder where KargoTakipNo=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", guna2TextBox2.Text);



            SqlDataAdapter kmt = new SqlDataAdapter();
            kmt.SelectCommand = komut6;

            DataTable tablo = new DataTable();

            kmt.Fill(tablo);
            SqlDataReader drr2 = komut6.ExecuteReader();
            if (drr2.Read())
            {



                //for (int i = 0; i < 1; i++)
                //{
                //Label btn = new Label();
                //btn.Location = new Point(300, 30 * i);
                //btn.Name = i.ToString();
                //btn.Text = "Gönderen Adı: " + drr2["Gonderen_Ad"] + " " + "Gönderen Soyadı: " + drr2["Gonderen_Soyad"].ToString();
                //btn.Width = 100;
                //btn.Height = 50;
                //this.Controls.Add(btn); //bu şekilde form'a ekleme yapılırsa tüm butonlar üst üste çıkacaktır
                //flowLayoutPanel1.Controls.Add(btn); //oluşan butonlar üstüste binmez

                guna2HtmlLabel1.Text = "Gönderen Adı: " + drr2["Gonderen_Ad"] + " " + "Gönderen Soyadı: " + drr2["Gonderen_Soyad"].ToString();
                guna2HtmlLabel2.Text = "Teslimat Adresi: " + drr2["AliciAdres"].ToString();
                guna2HtmlLabel3.Text = "Kargo Ağırlığı: " + drr2["KargoAgirlik"].ToString();


                //}



            }
            baglanti.Close();
        }

        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {
            guna2CustomGradientPanel4.Visible = true;
            guna2CustomGradientPanel3.Visible = false;
            guna2CustomGradientPanel2.Visible = true;
            guna2CustomGradientPanel1.Visible = false;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           
        }

        private void guna2TextBox47_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void guna2HtmlLabel36_Click(object sender, EventArgs e)
        {

            Form15 frm= new Form15();
            frm.kullaniciadi1 = guna2HtmlLabel4.Text;
            this.Hide();
            frm.Show();



        }

        private void guna2HtmlLabel36_Click_1(object sender, EventArgs e)
        {
            Form15 frm = new Form15();
            frm.kullaniciadi1 = guna2HtmlLabel4.Text;
         
            frm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
