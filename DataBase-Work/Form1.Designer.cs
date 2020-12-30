
namespace DataBase_Work
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yENİÜRÜNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yENİMALZEMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yENİELEMANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kAYITLARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sİLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.yENİÜRÜNToolStripMenuItem,
            this.yENİMALZEMEToolStripMenuItem,
            this.yENİELEMANToolStripMenuItem,
            this.kAYITLARToolStripMenuItem,
            this.sİLToolStripMenuItem,
            this.toolStripMenuItem2,
            this.eXITToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(937, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = " ";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // yENİÜRÜNToolStripMenuItem
            // 
            this.yENİÜRÜNToolStripMenuItem.Name = "yENİÜRÜNToolStripMenuItem";
            this.yENİÜRÜNToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.yENİÜRÜNToolStripMenuItem.Text = "YENİ ÜRÜN";
            this.yENİÜRÜNToolStripMenuItem.Click += new System.EventHandler(this.yENİÜRÜNToolStripMenuItem_Click);
            // 
            // yENİMALZEMEToolStripMenuItem
            // 
            this.yENİMALZEMEToolStripMenuItem.Name = "yENİMALZEMEToolStripMenuItem";
            this.yENİMALZEMEToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.yENİMALZEMEToolStripMenuItem.Text = "YENİ MALZEME";
            this.yENİMALZEMEToolStripMenuItem.Click += new System.EventHandler(this.yENİMALZEMEToolStripMenuItem_Click);
            // 
            // yENİELEMANToolStripMenuItem
            // 
            this.yENİELEMANToolStripMenuItem.Name = "yENİELEMANToolStripMenuItem";
            this.yENİELEMANToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.yENİELEMANToolStripMenuItem.Text = "YENİ ELEMAN";
            this.yENİELEMANToolStripMenuItem.Click += new System.EventHandler(this.yENİELEMANToolStripMenuItem_Click);
            // 
            // kAYITLARToolStripMenuItem
            // 
            this.kAYITLARToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
            this.kAYITLARToolStripMenuItem.Name = "kAYITLARToolStripMenuItem";
            this.kAYITLARToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.kAYITLARToolStripMenuItem.Text = "KAYITLAR";
            this.kAYITLARToolStripMenuItem.Click += new System.EventHandler(this.kAYITLARToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(57, 6);
            // 
            // sİLToolStripMenuItem
            // 
            this.sİLToolStripMenuItem.Name = "sİLToolStripMenuItem";
            this.sİLToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.sİLToolStripMenuItem.Text = "SİL";
            this.sİLToolStripMenuItem.Click += new System.EventHandler(this.sİLToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(83, 20);
            this.toolStripMenuItem2.Text = "GUNCELLEME";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DataBase_Work.Properties.Resources._04_chan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(937, 552);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yENİÜRÜNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yENİMALZEMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yENİELEMANToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kAYITLARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sİLToolStripMenuItem;
    }
}

