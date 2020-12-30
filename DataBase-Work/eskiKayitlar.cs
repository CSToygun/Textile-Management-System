using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Npgsql;

using System.Data.SqlClient; //veritabanı ilişkisi için atandı

namespace DataBase_Work
{
    public partial class eskiKayitlar : Form
    {
        
        public eskiKayitlar()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=toygun;Database=textildata");
            NpgsqlCommand cmd = new NpgsqlCommand();
            string data = comboBox1.Text;
            con.Open();
            cmd.Connection = con;

            if ( data == "Urun")
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM urun";
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }      
            }
            else if(data == "Malzeme")
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM malzeme";
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
            }
            else if(data == "Eleman")
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM eleman";
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Aradığınız Veri Bulunamadı Lütfen Tekrar deneyiniz ! ");
                comboBox1.ResetText();
            }
            con.Close();
            cmd.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=toygun;Database=textildata");
            NpgsqlCommand cmd = new NpgsqlCommand();
            string data = comboBox1.Text;
            string data2 = textBox1.Text;
            con.Open();
            cmd.Connection = con;

            if (data == "Urun")
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM urun where urunname like '%"+ data2 + "%'";
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
            }
            else if (data == "Malzeme")
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM malzeme where malzemename like '%" + data2 + "%'";
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
            }
            else if (data == "Eleman")
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM eleman where elemanname like '%" + data2 + "%'";
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Aradığınız Veri Bulunamadı Lütfen Tekrar deneyiniz ! ");
                comboBox1.ResetText();
            }
            con.Close();
            cmd.Dispose();
        }

        private void eskiKayitlar_Load(object sender, EventArgs e)
        {
         
        }
    }
}
