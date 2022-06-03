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
    public partial class koltuk : Form
    {
        public koltuk()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=WIN-5D1N64KPPAU;Initial Catalog=proje_sifre;User ID=sa;Password=qwerT12/;");
        string uye_ad;
        int uye_id;
        List<int> list = new List<int>();

        private void koltuk_Load(object sender, EventArgs e)
        {
           

            connection.Open();
            uye_ad = Properties.Settings.Default["adi"].ToString();
            SqlCommand command = new SqlCommand("select * from kayit_bilgiler where adi ='" + uye_ad + "'", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                uye_id = Convert.ToInt32(reader["yolcu_id"]);
            }
            connection.Close();
            int x =21, y = 41;

            if (ucakBilet.business_mi)
            {
                flowLayoutPanel1.Size = new Size(282, 128);
                flowLayoutPanel2.Size = new Size(282,128);
                x = 7;
                y = 27;
                for (int i = 1; i < x; i++)
                {
                    Button btn = new Button();
                    btn.Name = i.ToString();
                    btn.Text = i.ToString();
                    btn.Width = 80;
                    btn.Height = 50;
                    btn.Click += button1_Click;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.Black;
                    flowLayoutPanel1.Controls.Add(btn);
                }
                for (int i = 21; i < y; i++)
                {
                    Button btn = new Button();
                    btn.Name = i.ToString();
                    btn.Text = i.ToString();
                    btn.Width = 80;
                    btn.Height = 50;
                    btn.Click += button1_Click;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.Black;
                    flowLayoutPanel2.Controls.Add(btn);
                }
                
            }
            else
            {
                for (int i = 7; i < x; i++)
                {
                    Button btn = new Button();
                    btn.Name = i.ToString();
                    btn.Text = i.ToString();
                    btn.Width = 80;
                    btn.Height = 50;
                    btn.Click += button1_Click;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.Black;
                    flowLayoutPanel1.Controls.Add(btn);
                }
                for (int i = 27; i < y; i++)
                {
                    Button btn = new Button();
                    btn.Name = i.ToString();
                    btn.Text = i.ToString();
                    btn.Width = 80;
                    btn.Height = 50;
                    btn.Click += button1_Click;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.Black;
                    flowLayoutPanel2.Controls.Add(btn);
                }
            }

            



        }
       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        int koltuk_id1;
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.Black;
            btn.BackColor = Color.White;

            koltuk_id1 += Convert.ToInt32(btn.Text);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //insert into rezervasyon(yolcu_id, koltuk_id) values(" + uye_id + ", " +  koltuk_id1 + ")", connection
            connection.Open();
            SqlCommand command = new SqlCommand("update rezervasyon set yolcu_id = " + uye_id + ", koltuk_id =" + koltuk_id1 + " where rezerve_id=" + Properties.Settings.Default["rezerve_id"], connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show(koltuk_id1 + " Numaralı Koltuk Alınmıştır","Sistem");
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
