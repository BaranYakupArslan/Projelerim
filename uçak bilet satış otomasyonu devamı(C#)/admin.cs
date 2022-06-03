using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=WIN-5D1N64KPPAU;Initial Catalog=proje_sifre;User ID=sa;Password=qwerT12/;");

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != comboBox2.SelectedItem) 
            {
                connection.Open();
                SqlCommand command2 = new SqlCommand("insert into ucak_kayit values('" + textBox1.Text + "','" + maskedTextBox1.Text.ToString() + "','" + maskedTextBox2.Text.ToString() + "','" + (comboBox1.SelectedIndex + 1) + "','" + (comboBox2.SelectedIndex + 1) + "','" + dateTimePicker1.Value.ToString() + "','" + dateTimePicker2.Value.ToString() + "')", connection);
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("uçak eklenmiştir");
                this.Close();
                Form1 giriş = new Form1();
                giriş.Show();
            }
            else
            {
                MessageBox.Show("Aynı güzergaha uçak eklenemez");
            }
            
        }

        private void admin_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select sehir_ad from sehir", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["sehir_ad"]);
                comboBox2.Items.Add(reader["sehir_ad"]);
            }
            connection.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
