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
    public partial class kayitOlma : Form
    {
        public kayitOlma()
        {
            InitializeComponent();
        }
        
        SqlConnection connection = new SqlConnection("Data Source=WIN-5D1N64KPPAU;Initial Catalog=proje_sifre;User ID=sa;Password=qwerT12/;");


        private void kayitOlma_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select ulke_ad from ulke",connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox3.Items.Add(reader["ulke_ad"]);
                
            }
            connection.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            connection.Open();
            SqlCommand command = new SqlCommand("select sehir_ad from sehir as s inner join ulke as u on s.ulke_id=u.ulke_id where '"+comboBox3.SelectedItem+"'=ulke_ad  ", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader["sehir_ad"]);

            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             connection.Open();
            if (textBox8.Text == textBox9.Text) 
            {
                SqlCommand command = new SqlCommand("insert into kayit_bilgiler values('" + textBox1.Text + "','" + textBox3.Text + "'," + comboBox1.SelectedIndex + 1 + ",'" + maskedTextBox1.Text.ToString() + "','" + comboBox2.SelectedItem + "'," + comboBox3.SelectedIndex + 1 + "," + comboBox4.SelectedIndex + 1 + ",'" + maskedTextBox3.Text.ToString() + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox5.SelectedItem + "','" + maskedTextBox2.Text.ToString() + "','" + textBox8.Text + "')", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("kayıt başarılı olmuştur");
                
                this.Close();
            }
            else
            {
                textBox9.BackColor = Color.Yellow;
                MessageBox.Show("Şifreler aynı olmalıdır");
                textBox9.BackColor = Color.White;
            }
            connection.Close();

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
