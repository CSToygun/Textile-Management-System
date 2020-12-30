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
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=toygun;Database=textildata");
            NpgsqlCommand cmd = new NpgsqlCommand();
            string data = comboBox1.Text;
            con.Open();
            cmd.Connection = con;

            if (data == "Urun")
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM urun";
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
                cmd.CommandText = "SELECT * FROM malzeme";
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

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=toygun;Database=textildata");
            NpgsqlCommand cmd = new NpgsqlCommand();
            string data = textBox1.Text;
            string sql;
            con.Open();
            cmd.Connection = con;

            if (data == "stok")
            {
                try
                {
                    sql = @"SELECT*from public.urun_guncelle(:yenielestok, :degisyer )";
                    cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("yenielestok", textBox2.Text);
                    cmd.Parameters.AddWithValue("degisyer", textBox3.Text);

                    int result = (int)cmd.ExecuteScalar();

                    con.Close();

                    if (result == 1)
                    {
                        MessageBox.Show("Veriniz Güncellendi! Lütfen Yenileyiniz ...");
                    }
                    else
                    {
                        MessageBox.Show("Hata!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else if (data == "malzememiktari")
            {
                try
                {
                    sql = @"SELECT*from public.malzeme_guncelle(:yenielemiktar  , :degisyer )";
                    cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("yenielemiktar", Convert.ToInt32(textBox2.Text));
                    cmd.Parameters.AddWithValue("degisyer", textBox3.Text);

                    int result = (int)cmd.ExecuteScalar();  

                    con.Close();

                    if (result == 1)
                    {
                        MessageBox.Show("Veriniz Güncellendi! Lütfen Yenileyiniz ...");
                    }
                    else
                    {
                        MessageBox.Show("Hata!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else if (data == "elemanname")
            {
                try
                {
                    sql = @"SELECT*from public.eleman_guncelle(:yenieleman,:data)";
                    cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("yenieleman", textBox2.Text);
                    cmd.Parameters.AddWithValue("data", textBox3.Text);

                    int result = (int)cmd.ExecuteScalar();

                    con.Close();

                    if (result == 1)
                    {
                        MessageBox.Show("Veriniz Güncellendi! Lütfen Yenileyiniz ...");
                    }
                    else
                    {
                        MessageBox.Show("Hata!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show("Error: " + ex.Message);
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
    }
}
