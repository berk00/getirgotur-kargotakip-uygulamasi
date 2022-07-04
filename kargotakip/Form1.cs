using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kargotakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
           int sayac = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Cursor = Cursors.Hand;
            guna2HtmlLabel2.Cursor = Cursors.Hand;
            guna2HtmlLabel3.Cursor = Cursors.Hand;


            timer1.Start();


            guna2Transition1.HideSync(guna2PictureBox2);



        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Cursor = Cursors.Hand;

            Form3 sayfa3 = new Form3();
            sayfa3.Show();
            this.Hide();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            Form3 sayfa3 = new Form3();
            sayfa3.Show();
            this.Hide();
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {
            Form9 sayfa9 = new Form9();
            sayfa9.Show();
            this.Hide();
            
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {
            Form13 frm = new Form13();
            frm.Show();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            //if (!guna2PictureBox3.Visible) guna2Transition1.ShowSync(guna2PictureBox3);

            /*else*/

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            if (sayac==18)
            {
                if (guna2PictureBox2.Visible == false)
                {
                    guna2Transition1.ShowSync(guna2PictureBox2);
                }
                else guna2Transition1.HideSync(guna2PictureBox2);


                timer1.Stop();
            }

            
        }

        private void guna2HtmlLabel4_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void guna2HtmlLabel4_MouseHover(object sender, EventArgs e)
        {
            //guna2HtmlLabel4.Text = "Admin Panel";
            //guna2HtmlLabel4.Visible = true;
        }

        private void guna2HtmlLabel4_MouseEnter(object sender, EventArgs e)
        {
            //guna2HtmlLabel4.Text = "Admin Panel";
            //guna2HtmlLabel4.Visible = true;
        }

        private void guna2HtmlLabel4_KeyDown(object sender, KeyEventArgs e)
        {
            //guna2HtmlLabel4.Text = "Admin Panel";
            //guna2HtmlLabel4.Visible = true;
        }

        private void guna2HtmlLabel4_Leave(object sender, EventArgs e)
        {
            //guna2HtmlLabel4.Text = " ";
        }

        private void guna2HtmlLabel4_MouseLeave(object sender, EventArgs e)
        {
            //guna2HtmlLabel4.Text = " ";
        }

        private void guna2HtmlLabel4_MouseMove(object sender, MouseEventArgs e)
        {
            guna2HtmlLabel4.Text = "Admin Panel";
            guna2HtmlLabel4.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form10 frm = new Form10();
            frm.Show();
            this.Hide();
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {
            Form14 frm = new Form14();
            frm.Show();
            this.Hide();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
