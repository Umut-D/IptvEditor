namespace IptvEditorUI
{
    partial class FrmIpTvEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIpTvEditor));
            this.ofdAc = new System.Windows.Forms.OpenFileDialog();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmDosya = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiKaydet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.tstBul = new System.Windows.Forms.ToolStripTextBox();
            this.tsmiHakkinda = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGuncelle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBilgi = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdKaydet = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.listView = new System.Windows.Forms.ListView();
            this.chSira = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chKanalAdi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chKanalGrup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsSagTik = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsIzle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSil = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.msMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.cmsSagTik.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdAc
            // 
            this.ofdAc.Filter = "M3U Dosyası|*.m3u";
            this.ofdAc.Title = "Dosya Aç";
            // 
            // msMenu
            // 
            this.msMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msMenu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDosya,
            this.tstBul,
            this.tsmiHakkinda});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.msMenu.Size = new System.Drawing.Size(1100, 41);
            this.msMenu.TabIndex = 1;
            this.msMenu.Text = "menu";
            // 
            // tsmDosya
            // 
            this.tsmDosya.AccessibleDescription = "Dosya menüsü";
            this.tsmDosya.AccessibleName = "Dosya";
            this.tsmDosya.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.tsmDosya.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAc,
            this.tsmiKaydet,
            this.tsmCikis});
            this.tsmDosya.Name = "tsmDosya";
            this.tsmDosya.Size = new System.Drawing.Size(79, 33);
            this.tsmDosya.Text = "Dosya";
            // 
            // tsmiAc
            // 
            this.tsmiAc.AccessibleDescription = "Var olan IPTV listesini açar";
            this.tsmiAc.AccessibleName = "Aç";
            this.tsmiAc.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.tsmiAc.Image = global::IptvEditorUI.Properties.Resources.Blank_Folder_icon;
            this.tsmiAc.Name = "tsmiAc";
            this.tsmiAc.Size = new System.Drawing.Size(252, 30);
            this.tsmiAc.Text = "Aç";
            this.tsmiAc.Click += new System.EventHandler(this.TsmiAc_Click);
            // 
            // tsmiKaydet
            // 
            this.tsmiKaydet.AccessibleDescription = "Düzenlenen IPTV listesini kaydeder";
            this.tsmiKaydet.AccessibleName = "Kaydet";
            this.tsmiKaydet.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.tsmiKaydet.Image = global::IptvEditorUI.Properties.Resources.Shortcuts_Folder_icon;
            this.tsmiKaydet.Name = "tsmiKaydet";
            this.tsmiKaydet.Size = new System.Drawing.Size(252, 30);
            this.tsmiKaydet.Text = "Kaydet";
            this.tsmiKaydet.Click += new System.EventHandler(this.TsmiKaydet_Click);
            // 
            // tsmCikis
            // 
            this.tsmCikis.AccessibleDescription = "Programdan çıkar";
            this.tsmCikis.AccessibleName = "Çıkış";
            this.tsmCikis.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.tsmCikis.Image = global::IptvEditorUI.Properties.Resources.Communicator_Mac_icon;
            this.tsmCikis.Name = "tsmCikis";
            this.tsmCikis.Size = new System.Drawing.Size(252, 30);
            this.tsmCikis.Text = "Çıkış";
            this.tsmCikis.Click += new System.EventHandler(this.TsmCikis_Click);
            // 
            // tstBul
            // 
            this.tstBul.AccessibleDescription = "Listede kanal arama kutusu. Aramanızın başına @ eklerseniz Grup alanında arama ya" +
    "pabilirsiniz";
            this.tstBul.AccessibleName = "Ara";
            this.tstBul.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tstBul.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstBul.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstBul.Font = new System.Drawing.Font("Segoe UI", 10.20895F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tstBul.Name = "tstBul";
            this.tstBul.Size = new System.Drawing.Size(230, 33);
            this.tstBul.ToolTipText = "Aramanızın başına @ eklerseniz,\r\nGrup alanında arama yapabilirsiniz.";
            this.tstBul.MouseEnter += new System.EventHandler(this.TstBul_MouseEnter);
            this.tstBul.TextChanged += new System.EventHandler(this.TstBul_TextChanged);
            // 
            // tsmiHakkinda
            // 
            this.tsmiHakkinda.AccessibleDescription = "Hakkında menüsü";
            this.tsmiHakkinda.AccessibleName = "Hakkında";
            this.tsmiHakkinda.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.tsmiHakkinda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGuncelle,
            this.tsmBilgi});
            this.tsmiHakkinda.Name = "tsmiHakkinda";
            this.tsmiHakkinda.Size = new System.Drawing.Size(106, 33);
            this.tsmiHakkinda.Text = "Hakkında";
            // 
            // tsmGuncelle
            // 
            this.tsmGuncelle.AccessibleDescription = "Programa dair yeni versiyon olup olmadığı kontrolü yapar";
            this.tsmGuncelle.AccessibleName = "Güncelle";
            this.tsmGuncelle.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.tsmGuncelle.Image = global::IptvEditorUI.Properties.Resources.Internet_Download_Manager_icon;
            this.tsmGuncelle.Name = "tsmGuncelle";
            this.tsmGuncelle.Size = new System.Drawing.Size(252, 30);
            this.tsmGuncelle.Text = "Guncelle";
            this.tsmGuncelle.Click += new System.EventHandler(this.TsmGuncelle_Click);
            // 
            // tsmBilgi
            // 
            this.tsmBilgi.AccessibleDescription = "Programa dair bilgi ver";
            this.tsmBilgi.AccessibleName = "Bilgi";
            this.tsmBilgi.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.tsmBilgi.Image = global::IptvEditorUI.Properties.Resources.Autodesk_Building_Design_Suite_icon;
            this.tsmBilgi.Name = "tsmBilgi";
            this.tsmBilgi.Size = new System.Drawing.Size(252, 30);
            this.tsmBilgi.Text = "Bilgi";
            this.tsmBilgi.Click += new System.EventHandler(this.TsmBilgi_Click);
            // 
            // sfdKaydet
            // 
            this.sfdKaydet.Filter = "M3U Dosyası|*.m3u";
            this.sfdKaydet.RestoreDirectory = true;
            this.sfdKaydet.Title = "Kaydet";
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslDurum});
            this.statusStrip.Location = new System.Drawing.Point(0, 626);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1100, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // tsslDurum
            // 
            this.tsslDurum.AccessibleDescription = "Toplam kaç adet kanal yüklendiğinin bilgisi";
            this.tsslDurum.AccessibleName = "Toplam Kanal";
            this.tsslDurum.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tsslDurum.Name = "tsslDurum";
            this.tsslDurum.Size = new System.Drawing.Size(0, 15);
            // 
            // listView
            // 
            this.listView.AllowColumnReorder = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSira,
            this.chKanalAdi,
            this.chKanalGrup,
            this.chLink});
            this.listView.ContextMenuStrip = this.cmsSagTik;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 41);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1100, 585);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.ListView_DoubleClick);
            // 
            // chSira
            // 
            this.chSira.Text = "Sira";
            this.chSira.Width = 65;
            // 
            // chKanalAdi
            // 
            this.chKanalAdi.Text = "Kanal Adı";
            this.chKanalAdi.Width = 460;
            // 
            // chKanalGrup
            // 
            this.chKanalGrup.Text = "Grup";
            this.chKanalGrup.Width = 230;
            // 
            // chLink
            // 
            this.chLink.Text = "Link";
            this.chLink.Width = 315;
            // 
            // cmsSagTik
            // 
            this.cmsSagTik.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmsSagTik.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.cmsSagTik.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsIzle,
            this.cmsSil});
            this.cmsSagTik.Name = "cmsSagTik";
            this.cmsSagTik.Size = new System.Drawing.Size(239, 64);
            // 
            // cmsIzle
            // 
            this.cmsIzle.AccessibleDescription = "VLC Player ile izle";
            this.cmsIzle.AccessibleName = "Izle";
            this.cmsIzle.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.cmsIzle.Image = global::IptvEditorUI.Properties.Resources.VLC_Media_Player_icon;
            this.cmsIzle.Name = "cmsIzle";
            this.cmsIzle.Size = new System.Drawing.Size(238, 30);
            this.cmsIzle.Text = "VLC Player ile Izle";
            this.cmsIzle.Click += new System.EventHandler(this.CmsIzle_Click);
            // 
            // cmsSil
            // 
            this.cmsSil.AccessibleDescription = "Listeden kanal veya kanalları sil";
            this.cmsSil.AccessibleName = "Sil";
            this.cmsSil.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.cmsSil.Image = global::IptvEditorUI.Properties.Resources.Security_Denied_icon;
            this.cmsSil.Name = "cmsSil";
            this.cmsSil.Size = new System.Drawing.Size(238, 30);
            this.cmsSil.Text = "Kanal(lar)ı Sil";
            this.cmsSil.Click += new System.EventHandler(this.CmsSil_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Bilgi";
            // 
            // FrmIpTvEditor
            // 
            this.AccessibleDescription = "Ana Ekran";
            this.AccessibleName = "IPTV Editör";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 648);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.msMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmIpTvEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPTV Editör";
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.cmsSagTik.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdAc;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmDosya;
        private System.Windows.Forms.ToolStripMenuItem tsmiAc;
        private System.Windows.Forms.ToolStripMenuItem tsmiKaydet;
        private System.Windows.Forms.ToolStripMenuItem tsmCikis;
        private System.Windows.Forms.SaveFileDialog sfdKaydet;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslDurum;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader chKanalAdi;
        private System.Windows.Forms.ColumnHeader chKanalGrup;
        private System.Windows.Forms.ColumnHeader chSira;
        private System.Windows.Forms.ColumnHeader chLink;
        private System.Windows.Forms.ToolStripTextBox tstBul;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip cmsSagTik;
        private System.Windows.Forms.ToolStripMenuItem cmsSil;
        private System.Windows.Forms.ToolStripMenuItem tsmiHakkinda;
        private System.Windows.Forms.ToolStripMenuItem tsmGuncelle;
        private System.Windows.Forms.ToolStripMenuItem tsmBilgi;
        private System.Windows.Forms.ToolStripMenuItem cmsIzle;
    }
}

