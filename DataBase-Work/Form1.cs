using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_Work
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripMenuItem1.Image = Image.FromFile(@"C:\Users\Toygun\source\repos\DataBase-Work\Pictures\downpng.png");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        Boolean b = true;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (b == true)
            {

                menuStrip1.Dock = DockStyle.Left;
                b = false;
                toolStripMenuItem1.Image = Image.FromFile(@"C:\Users\Toygun\source\repos\DataBase-Work\Pictures\rightpng.png");


            }
            else
            {
                menuStrip1.Dock = DockStyle.Top;
                b = true;
                toolStripMenuItem1.Image = Image.FromFile(@"C:\Users\Toygun\source\repos\DataBase-Work\Pictures\downpng.png");
            }
        }

        private void yENİÜRÜNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newurun nm = new newurun();
            nm.Show();
        }

        private void yENİMALZEMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newmalzeme nm = new newmalzeme();
            nm.Show();
        }

        private void yENİELEMANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newEleman nm = new newEleman();
            nm.Show();
        }

        private void kAYITLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eskiKayitlar nm = new eskiKayitlar();
            nm.Show();
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deletedata nm = new deletedata();
            nm.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programı kapatmak İstediğinizden Eminmisiniz ? ", "CLOSE", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show(" Tekrar Hoşgeldiniz :)  ", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
