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
    public partial class Form15 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=BERK;Initial Catalog=kargo;Integrated Security=True");//Kendi veritabanı yolunuzu vermeniz gerekiyor

        public Form15()
        {
            InitializeComponent();
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }
        public string kullaniciadi1;
        private void Form15_Load(object sender, EventArgs e)
        {
            //SqlCommand komuta = new SqlCommand();
            //komuta.CommandText = "SELECT * FROM sehirler";
            //komuta.Connection = baglanti;
            //komuta.CommandType = CommandType.Text;

            //SqlDataReader dra;
            //baglanti.Open();
            //dra = komuta.ExecuteReader();
            //while (dra.Read())
            //{
            //    guna2ComboBox1.Items.Add(dra["sehirler"]);
            //}
            //baglanti.Close();


            baglanti.Open();

            guna2HtmlLabel8.Text = kullaniciadi1;
           SqlCommand komut6 = new SqlCommand("select * from kullanici where eposta=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", guna2HtmlLabel8.Text);



            SqlDataAdapter kmt = new SqlDataAdapter();
            kmt.SelectCommand = komut6;

            DataTable tablo = new DataTable();

            kmt.Fill(tablo);
            SqlDataReader drr2 = komut6.ExecuteReader();
            if (drr2.Read())
            {
                guna2TextBox12.Text = drr2["ad"].ToString();
                guna2TextBox1.Text = drr2["soyad"].ToString();
                guna2TextBox3.Text = drr2["eposta"].ToString();
                guna2TextBox3.Text = drr2["eposta"].ToString();
                guna2TextBox4.Text = drr2["sifre"].ToString();
                guna2TextBox14.Text = drr2["tel"].ToString();
            }
            baglanti.Close();




        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut11 = new SqlCommand("Update kullanici set ad=@p2, soyad=@p3, sifre=@p4 where eposta=@p1", baglanti);
            komut11.Parameters.AddWithValue("@p1", guna2HtmlLabel8.Text);
            komut11.Parameters.AddWithValue("@p2", guna2TextBox12.Text);
            komut11.Parameters.AddWithValue("@p3", guna2TextBox1.Text);
            komut11.Parameters.AddWithValue("@p4", guna2TextBox4.Text);





            komut11.ExecuteNonQuery();
            Form11 frm11 = new Form11();
            frm11.Show();
            baglanti.Close();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox4.PasswordChar = '*';
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                guna2TextBox4.PasswordChar = '\0';
            }
            else
            {
                guna2TextBox4.PasswordChar = '*';
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Form16 frm16 = new Form16();
            frm16.Show();
            
        }
    }
}
