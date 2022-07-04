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
    public partial class Form9 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=BERK;Initial Catalog=kargo;Integrated Security=True"); //Kendi veritabanı yolunuzu vermeniz gerekiyor

        public Form9()
        {
            InitializeComponent();
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



                for (int i = 0; i < 1; i++)
                {
                    //Label btn = new Label();
                    //btn.Location = new Point(300, 30 * i);
                    //btn.Name = i.ToString();
                    //btn.Text = "" + drr2["Gonderen_Ad"] + " " + "" + drr2["Gonderen_Soyad"].ToString().ToUpper();
                    //btn.Width = 100;
                    //btn.Height = 50;
                    //this.Controls.Add(btn); //bu şekilde form'a ekleme yapılırsa tüm butonlar üst üste çıkacaktır
                                            //flowLayoutPanel1.Controls.Add(btn); //oluşan butonlar üstüste binmez

                    guna2HtmlLabel1.Text= "" + drr2["Gonderen_Ad"] + " " + "" + drr2["Gonderen_Soyad"].ToString().ToUpper();
                    guna2HtmlLabel2.Text = "Teslimat Adresi: " + drr2["alici_ilce"]+" " + drr2["Alici_acikadres"]+" "+ drr2["Alici_AdresTarifi"].ToString();
                    guna2HtmlLabel3.Text = "Kargo Ağırlığı: " + drr2["KargoAgirlik"].ToString();

                    guna2HtmlLabel1.Visible = true;
                    guna2HtmlLabel2.Visible = true;
                    guna2HtmlLabel3.Visible = true;
                }



            }
            baglanti.Close();


            baglanti.Open();

            SqlCommand komut7 = new SqlCommand("select * from KargoDurum where KargoTakipNo=@p1", baglanti);
            komut7.Parameters.AddWithValue("@p1", guna2TextBox12.Text);



            SqlDataAdapter kmt7 = new SqlDataAdapter();
            kmt7.SelectCommand = komut7;

            DataTable tablo7 = new DataTable();

            kmt7.Fill(tablo7);
            SqlDataReader drr7 = komut7.ExecuteReader();
            if (drr7.Read())
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
                guna2HtmlLabel8.Visible = true;
                guna2HtmlLabel8.Text = "Kargonun Son Durumu: " + drr7["KargoDurumu"].ToString();
              


                //}



            }
            baglanti.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            guna2Transition1.ShowSync(guna2PictureBox1);

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            //guna2Transition1.HideSync(guna2PictureBox1);

        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //sayac++;

            //if (sayac == 18)
            //{
            //    if (guna2PictureBox1.Visible == false)
            //    {
            //        guna2Transition1.ShowSync(guna2PictureBox1);
            //    }
            //    else guna2Transition1.HideSync(guna2PictureBox1);


            //    timer1.Stop();
            //}
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            this.Hide();
            frm.Show();
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            this.Hide();
            frm.Show();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
