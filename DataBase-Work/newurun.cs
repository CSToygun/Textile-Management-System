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
    public partial class newurun : Form
    {
        string pictureadress;
        public newurun()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            string urunname = txturunadi.Text;
            string kategori = combocategory.Text;
            string malzeme = textmalzeme.Text;
            string stok;
            bool kontrol = radioButton1.Checked;
            if(kontrol)
            {
                stok = radioButton1.Text;

            }
            else
            {
                stok = radioButton2.Text;
            }

            DateTime tarih = dateTimePicker1.Value;
            string price = textfiyat.Text;
            string adet = comboadet.Text;
            string note = richTextBox1.Text;

            var cs = "Host=localhost;Username=postgres;Password=toygun;Database=textildata";

            var con = new NpgsqlConnection(cs); 
            con.Open();

            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "INSERT INTO  Urun(urunname,price,kategori,malzeme,stok,adet,note,tarih) VALUES('" + urunname+ "','" + price + "','" + kategori+"','"+malzeme+"','"+stok+"','"+adet+"','"+note+ "','" + tarih + "')";
            cmd.ExecuteNonQuery();

            MessageBox.Show("Veriler Kaydedildi ! ");

        }

        private void button3_Click(object sender, EventArgs e)
        {
        txturunadi.Clear();
        combocategory.ResetText();
        textmalzeme.Clear();
        radioButton1.Checked = false;
        dateTimePicker1.ResetText();
        textfiyat.Clear();
        comboadet.ResetText();
        richTextBox1.Clear();
        MessageBox.Show("İşleminiz İptal Edildi Ana menüye Yönlendiriliyorsunuz ...");
        Thread.Sleep(1000);
         this.Close();
        }
    }
}
