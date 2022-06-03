using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mayinÖdev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList mayin = new ArrayList();

        
        int puan = 0;
        
        private void But_Click(object sender, EventArgs e)
        {
            Button tiklanan = (Button)sender;//senderin buton olduğunu belirtiyoruz
            if (tiklanan.Text == "")
            {
                if (Convert.ToInt32(tiklanan.Tag) == -1)
                {
                    for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
                    {
                        tableLayoutPanel1.Controls[i].Enabled = false;
                        if (Convert.ToInt32(tableLayoutPanel1.Controls[i].Tag) == -1)
                        {
                            tableLayoutPanel1.Controls[i].BackColor = Color.Red;
                            tableLayoutPanel1.Controls[i].Enabled = false;

                        }
                        else
                        {
                            tableLayoutPanel1.Controls[i].Text = tableLayoutPanel1.Controls[i].Tag.ToString();//ne kadar puan vereceğini yazacak
                        }
                    }
                }
                else
                {
                    puan += Convert.ToInt32(tiklanan.Tag);
                    tiklanan.Text = tiklanan.Tag.ToString();
                    label2.Text = "puan = " + puan;//puan sayımızı toplayıp arttıtıcak 
                    tiklanan.Enabled = false;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            puan = 0;//puanı 0 lanıyor
            mayin.Clear();//mayınları temizliyoruz
            tableLayoutPanel1.Controls.Clear();//kontrolleri temizliyoruz
            int mayinsa = 15;
            int tarla = 100;
            int sayi = 0;
            label3.Text = "Boyut = " + "10 x10";
            tableLayoutPanel1.ColumnCount = 10;
            Random r = new Random();
                for (int i = 0; i < mayinsa; i++)
                {
                uret:
                    sayi = r.Next(0, tarla);
                    if (mayin.Contains(sayi) == true)
                    {
                        goto uret;
                    }
                    else
                    {
                        mayin.Add(sayi);
                    }
                }
                for (int i = 0; i < tarla; i++)
                {
                    Button but = new Button();
                    but.Size = new Size(50, 50);
                    if (mayin.Contains(i))
                    {
                        but.Tag = -1;//mayın olarak ayarlanırsa -1 yapıyor
                    }
                    else
                    {
                        but.Tag = r.Next(1, 20);//mayın olarak ayarlanmadıysa puan saklıyor
                    }
                    but.Click += But_Click;//olay oluşturuyoruz 
                    tableLayoutPanel1.Controls.Add(but);//kontrol ekliyoruz
                }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            puan = 0;//puanı 0 lıyor
            mayin.Clear();//mayınları temizliyoruz
            tableLayoutPanel1.Controls.Clear();//kontrolleri temizliyoruz
            int mayinsa = 25;
            int tarla = 100;
            int sayi = 0;
            label3.Text = "Boyut = " + "10 x10";
            tableLayoutPanel1.ColumnCount = 10;
            Random r = new Random();
            for (int i = 0; i < mayinsa; i++)
            {
            uret:
                sayi = r.Next(0, tarla);
                if (mayin.Contains(sayi) == true)
                {
                    goto uret;
                }
                else
                {
                    mayin.Add(sayi);
                }
            }
            for (int i = 0; i < tarla; i++)
            {
                Button but = new Button();
                but.Size = new Size(50, 50);
                if (mayin.Contains(i))
                {
                    but.Tag = -1;//mayın olarak ayarlanırsa -1 yapıyor
                }
                else
                {
                    but.Tag = r.Next(1, 20);//mayın olarak ayarlanmadıysa puan saklıyor
                }
                but.Click += But_Click;//olay oluşturuyoruz 
                tableLayoutPanel1.Controls.Add(but);//kontrol ekliyoruz
            }
        }
    }
}
