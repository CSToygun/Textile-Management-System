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
    public partial class deletedata : Form
    {
        public deletedata()
        {
            InitializeComponent();
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
                cmd.CommandText = "SELECT * FROM urun where urunname like '%" + data2 + "%'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=toygun;Database=textildata");
            NpgsqlCommand cmd = new NpgsqlCommand();
            string data = comboBox1.Text;
            string data2 = textBox1.Text;
            string sql;
            con.Open();
            cmd.Connection = con;

            if(MessageBox.Show("veriyi Silmek istediğinize eminmizini ? ", "Delete Data" , MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (data == "Urun")
                {
                    /*cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE  FROM urun where urunname = '" + data2 + "'";
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                    }
                    MessageBox.Show("Veriniz Silindi ! Lütfen Yenileyiniz ...");*/
                    try
                    {
                        sql = @"SELECT*from urun_sil(:urunname)";
                        cmd = new NpgsqlCommand(sql, con);

                        cmd.Parameters.AddWithValue("urunname", textBox1.Text);

                        int result = (int)cmd.ExecuteScalar();

                        con.Close();

                        if (result == 1)
                        {
                            MessageBox.Show("Veriniz Silindi ! Lütfen Yenileyiniz ...");
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
                else if (data == "Malzeme")
                {
                    /*cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE  FROM malzeme where malzemename = '" + data2 + "'";
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                    }
                    MessageBox.Show("Veriniz Silindi ! Lütfen Yenileyiniz ...");*/

                    try
                    {
                        sql = @"SELECT*from malzeme_sil(:malzemename)";
                        cmd = new NpgsqlCommand(sql, con);

                        cmd.Parameters.AddWithValue("malzemename", textBox1.Text);

                        int result = (int)cmd.ExecuteScalar();

                        con.Close();

                        if (result == 1)
                        {
                            MessageBox.Show("Veriniz Silindi ! Lütfen Yenileyiniz ...");
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
                else if (data == "Eleman")
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE  FROM eleman where elemanname = '" + data2 + "'";
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                    }
                    MessageBox.Show("Veriniz Silindi ! Lütfen Yenileyiniz ...");
                }
                else
                {
                    MessageBox.Show("Aradığınız Veri Bulunamadı Lütfen Tekrar deneyiniz ! ");
                    comboBox1.ResetText();
                }
            }
            else
            {
                
            }
            con.Close();
            cmd.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
