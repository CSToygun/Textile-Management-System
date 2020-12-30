using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Npgsql;

using System.Data.SqlClient; //veritabanı ilişkisi için atandı


namespace DataBase_Work
{
    public partial class newEleman : Form
    {
        string elemanpicture;
        public newEleman()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string elemanname = textBox1.Text;
            string elemansurname = textBox2.Text;
            string telefon = textBox4.Text;
            string cinsiyet;

            bool kontrol = radioButton1.Checked;
            if (kontrol)
            {
                cinsiyet = radioButton1.Text;

            }
            else
            {
                cinsiyet = radioButton2.Text;
            }
            string calissaat = comboBox1.Text;
            DateTime dogumtarih  = dateTimePicker1.Value;
            string aylikucret = textBox3.Text;
            string birim = comboBox2.Text;
            string mesaiucret = comboBox3.Text;
            string adress = richTextBox1.Text;

            
            var cs = "Host=localhost;Username=postgres;Password=toygun;Database=textildata";

            var con = new NpgsqlConnection(cs);
            con.Open();

            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "INSERT INTO  eleman(elemanname,elemansurname,telefon,cinsiyet,calissaat,dogumtarih,aylikucret,birim,mesaiucret,adress,elemanpicture) VALUES('" + elemanname + "','" + elemansurname + "','" + telefon + "','" + cinsiyet + "','" + calissaat + "','" + dogumtarih + "','" + aylikucret + "','" + birim + "','" + mesaiucret + "','" + adress + "','" + elemanpicture + "')";
            cmd.ExecuteNonQuery();

            MessageBox.Show("Veriler Kaydedildi ! ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();   
            textBox2.Clear();
            textBox4.Clear();
            radioButton1.Checked = false; 
            radioButton2.Checked = false;
            comboBox1.ResetText();
            dateTimePicker1.ResetText();
            textBox3.Clear();
            comboBox2.ResetText();
            comboBox3.ResetText();
            richTextBox1.Clear();
            
            MessageBox.Show("İşleminiz İptal Edildi Ana menüye Yönlendiriliyorsunuz ...");
            Thread.Sleep(1000);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Resim Dosyası |*.png";
            file.Title = "Urun Fotografini Seciniz..";
            if (file.ShowDialog() == DialogResult.OK)
            {
                elemanpicture = file.FileName;
            }
        }
    }
}
