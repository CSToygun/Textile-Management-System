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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cs = "Host=localhost;Username=postgres;Password=toygun;Database=textildata";
            var con = new NpgsqlConnection(cs);
            con.Open();
            var cmd = new NpgsqlCommand();
            string sql = null;
            cmd.Connection = con;

            try
            {
                sql = @"SELECT * from admin_giris(:user, :sifre)";
                cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("user", textBox1.Text);
                cmd.Parameters.AddWithValue("sifre", textBox2.Text);

                int result = (int)cmd.ExecuteScalar();

                con.Close();

                if (result == 1)
                {
                    login formKapa = new login();
                    formKapa.Close();
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.Show();
                }
                else
                {
                    MessageBox.Show("Bilgilerinizi kontrol edip tekrar giriş yapiniz!");
                }

                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();

                //MessageBox.Show("Hata!");
            }


        }
    }
}
