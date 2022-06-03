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
    public partial class ucakBilet : Form
    {
        public ucakBilet(string yolcuİd)
        {
            InitializeComponent();
            yolcu_id = yolcuİd;
        }

        private string yolcu_id;

        SqlConnection connection = new SqlConnection("Data Source=WIN-5D1N64KPPAU;Initial Catalog=proje_sifre;User ID=sa;Password=qwerT12/;");
        public static bool business_mi;
        
        
        private void ucakBilet_Load(object sender, EventArgs e)
        {
            ekle();
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false; 
            dataGridView1.Visible = false;
            MessageBox.Show(yolcu_id);
            
        }

        private void Uçaklar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            dataGridView1.Visible = true;
            string aranan1 = comboBox1.SelectedItem.ToString();
            string aranan2 = comboBox2.SelectedItem.ToString();
            string aranan3 = dateTimePicker1.Value.Date.ToString();
            string aranan4 = dateTimePicker2.Value.Date.ToString();


            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {


                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == aranan1 && dataGridView1.Rows[i].Cells[4].Value.ToString() == aranan2 && dataGridView1.Rows[i].Cells[5].Value.ToString() == aranan3 && dataGridView1.Rows[i].Cells[6].Value.ToString() == aranan4) 
               {
                   dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkTurquoise;
               }
                           
            }
            
            
           

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            string gidis = dateTimePicker1.Value.Date.ToString();
            string gelis = dateTimePicker2.Value.Date.ToString();
            connection.Open();
            SqlCommand command = new SqlCommand("insert into rezervasyon (yolcu_id,gidis_sehir_id,gelis_sehir_id,gidis_tarihi,gelis_tarihi) values ("+yolcu_id+","+ (comboBox1.SelectedIndex + 1) + "," + (comboBox2.SelectedIndex + 1) + ",'" + gidis + "','" + gelis + "')", connection);
            
            
            command.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            SqlCommand command3 = new SqlCommand("select * from rezervasyon where gidis_sehir_id =" + (comboBox1.SelectedIndex + 1) + " and gelis_sehir_id=" + (comboBox2.SelectedIndex + 1) + " and gidis_tarihi='" + gidis + "' and gelis_tarihi='" + gelis + "'", connection);
            SqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                Properties.Settings.Default["rezerve_id"] = reader3["rezerve_id"];
                Properties.Settings.Default.Save();

            }
            connection.Close();



            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;

                }
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                MessageBox.Show("Bilet satın alınmıştır");
                koltuk koltuk = new koltuk();
                koltuk.Show();
                
            }
            else
            {
                MessageBox.Show("Lütfen bilet seçiniz");
            }
            
            
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ekle()
        {
            #region Varış Şehir
            dataGridView1.Rows.Clear();
            int sayac = 0;
            List<string> varissehir = new List<string>();
            connection.Open();
            SqlCommand command1 = new SqlCommand("select * from ucak_kayit as u inner join sehir as s on u.varis_sehir_id=s.sehir_id", connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                varissehir.Add(reader1["sehir_ad"].ToString());
            }
            connection.Close();
            #endregion

            connection.Open();
            SqlCommand command = new SqlCommand("select u.ucus_kodu,u.kalkis_saati,u.varis_saati,s.sehir_ad,u.gidis_tarihi,u.donus_tarihi from ucak_kayit as u " +
                "inner join sehir as s on u.kalkis_sehir_id=s.sehir_id ", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DateTime gidisTarih = Convert.ToDateTime(reader["gidis_tarihi"].ToString());
                DateTime donusTarih = Convert.ToDateTime(reader["donus_tarihi"].ToString());
                dataGridView1.Rows.Add(reader["ucus_kodu"].ToString(), reader["kalkis_saati"].ToString(), reader["varis_saati"].ToString(), reader["sehir_ad"].ToString(), varissehir[sayac].ToString(), gidisTarih.Date.ToString(),donusTarih.Date.ToString());
                sayac++;
            }
            
            connection.Close();
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void yonSecim(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = false;
            }
            else if (radioButton2.Checked == true)
            {
                dateTimePicker2.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Bilet_Türü_Secim(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                business_mi = false;
            }
            else
            {
                business_mi = true;
            }
        }
    }
}
