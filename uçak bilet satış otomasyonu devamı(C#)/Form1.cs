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

namespace proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=WIN-5D1N64KPPAU;Initial Catalog=proje_sifre;User ID=sa;Password=qwerT12/;");

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            kayitOlma kayit = new kayitOlma();
            kayit.Show();
        }
        bool move;
        int mouse;
        int mouse2;
        bool oradami;
        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici_ad = textBox3.Text;
            string sifre = textBox2.Text;
            connection.Open();
            SqlCommand command = new SqlCommand($"select * from kayit_bilgiler where adi = '{kullanici_ad}' and sifre = '{sifre}' ", connection);
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                if (kullanici_ad == reader["adi"].ToString().TrimEnd() && sifre == reader["sifre"].ToString().TrimEnd()) 
                {
                    oradami = true;
                    break;
                }
                else
                {
                    oradami = false;
                }
            }

            if (textBox3.Text == "admin" && textBox2.Text == "1234")
            {
                this.Hide();
                admin admin = new admin();
                admin.Show();
            }

            else if (oradami == true)
            {
                Properties.Settings.Default["adi"] = textBox3.Text;
                Properties.Settings.Default.Save();
                this.Hide();
                ucakBilet ucak = new ucakBilet(reader["yolcu_id"].ToString());
                ucak.Show();
            }
            connection.Close();

            if (oradami)
            {
                MessageBox.Show("başarıyla giriş yaptınız", "Sistem");
            }
            else if (oradami == false)
            {
                MessageBox.Show("kullanıcı adı veya şifre yanlış lütfen tekrar deneyiniz", "Sistem");
            }
            else if (textBox3.Text == "" && textBox2.Text == "") 
            {
                MessageBox.Show("kullanıcı adı veya şifre boş bırakılamaz lütfen tekrar deneyiniz", "Sistem");
            }
           
            
            
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse = e.X;
            mouse2 = e.Y;
            

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse, MousePosition.Y - mouse2);
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text=="Kullanıcı adı")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text=="")
            {
                textBox3.Text = "Kullanıcı adı";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text =="")
            {
                textBox2.Text = "Şifre";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
