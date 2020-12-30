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
    public partial class newmalzeme : Form
    {
        string pictureadress;
        public newmalzeme()
        {
            InitializeComponent();
        }

        private void newmalzeme_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string malzemename = textBox1.Text;
            string malzemecinsi = textBox2.Text;
            string miktarcinsi = comboBox2.Text;
            string malzememiktari = comboBox1.Text;
            DateTime tarih = dateTimePicker1.Value;
            string alisfiyat = textBox3.Text;
            string note = richTextBox1.Text;

            var cs = "Host=localhost;Username=postgres;Password=toygun;Database=textildata";

            var con = new NpgsqlConnection(cs);
            con.Open();

            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "INSERT INTO  Malzeme(malzemename,malzemecinsi,miktarcinsi,malzememiktari,tarih,alisfiyat,note,pictureadress) VALUES('" + malzemename + "','" + malzemecinsi + "','" + miktarcinsi + "','" + malzememiktari + "','" + tarih + "','" + alisfiyat + "','" + note + "','" + pictureadress + "')";
            cmd.ExecuteNonQuery();

            MessageBox.Show("Veriler Kaydedildi ! ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Resim Dosyası |*.png";
            file.Title = "Urun Fotografini Seciniz..";
            if (file.ShowDialog() == DialogResult.OK)
            {
                pictureadress = file.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox2.ResetText(); 
            comboBox1.ResetText();
            dateTimePicker1.ResetText();
            textBox3.Clear();
            richTextBox1.Clear();
            MessageBox.Show("İşleminiz İptal Edildi Ana menüye Yönlendiriliyorsunuz ...");
            Thread.Sleep(1000);
            this.Close();
        }
    }
}
