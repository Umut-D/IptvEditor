using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IptvEditorLibrary;

namespace IptvEditorUI
{
    public partial class FrmIpTvEditor : Form
    {
        private Dosya _dosya;
        private Aktar _aktar;
        private Islem _islem;

        public FrmIpTvEditor()
        {
            InitializeComponent();
        }

        private void TsmiAc_Click(object sender, EventArgs e)
        {
            if (ofdAc.ShowDialog() != DialogResult.OK)
                return;

            _dosya = new Dosya(ofdAc.FileName);
            _dosya.Ac();

            _aktar = new Aktar(_dosya);
            ListViewYukle(_aktar.Kanallar);

            KanalSayisi();

            tstBul.Text = null;
        }

        private void KanalSayisi()
        {
            tsslDurum.Text = $@"{listView.Items.Count} adet kanal yüklendi";
        }

        private void ListViewYukle(List<Kanal> islem)
        {
            listView.Items.Clear();
            listView.BeginUpdate();

            foreach (Kanal baslik in islem)
            {
                ListViewItem lvNesnesi = new ListViewItem((listView.Items.Count + 1).ToString());
                lvNesnesi.SubItems.Add(baslik.Ad);
                lvNesnesi.SubItems.Add(baslik.Grup);
                lvNesnesi.SubItems.Add(baslik.Link);
                listView.Items.Add(lvNesnesi);
            }

            listView.EndUpdate();
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count <= 0)
                return;

            string link = listView.SelectedItems[0].SubItems[3].Text.Trim();
            Izle izle = new Izle();
            izle.Oynat(link);
        }

        private void TstBul_TextChanged(object sender, EventArgs e)
        {
            if (_aktar == null)
                return;

            ListViewYukle(KanalBul());

            KanalSayisi();
        }

        private List<Kanal> KanalBul()
        {
            _islem = new Islem(_aktar);

            List<Kanal> bul;
            if (tstBul.Text.StartsWith("@"))
            {
                bul = _islem.GrubaGoreBul(new Kanal
                {
                    Grup = tstBul.Text.Remove(0, 1)
                });
            }
            else
            {
                bul = _islem.AdaGoreBul(new Kanal
                {
                    Ad = tstBul.Text
                });
            }

            return bul;
        }

        private void TstBul_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(tstBul.TextBox ?? throw new InvalidOperationException(), tstBul.ToolTipText);
        }

        private void CmsIzle_Click(object sender, EventArgs e)
        {
            ListView_DoubleClick(sender, e);
        }

        private void CmsSil_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count <= 0)
                return;

            int secilenNesneIndeksi = listView.SelectedItems[0].Index - 1;

            KanalSil();

            ListViewYukle(_aktar.Kanallar);

            SilmeSonrasiKalinanSatiriSec(secilenNesneIndeksi);

            KanalSayisi();
        }

        private void KanalSil()
        {
            _islem = new Islem(_aktar);

            for (int i = 0; i < listView.SelectedItems.Count; i++)
            {
                if (!listView.SelectedItems[i].Selected)
                    continue;

                int indeks = listView.SelectedItems[i].Index;
                string seciliKanal = listView.Items[indeks].SubItems[1].Text.Trim();
                _islem.Sil(new Kanal
                {
                    Ad = seciliKanal
                });
            }
        }

        private void SilmeSonrasiKalinanSatiriSec(int secilenNesneIndeksi)
        {
            if (secilenNesneIndeksi <= 0)
                return;

            listView.Items[secilenNesneIndeksi].Focused = true;
            listView.Items[secilenNesneIndeksi].Selected = true;
            listView.EnsureVisible(secilenNesneIndeksi);
        }

        private void TsmiKaydet_Click(object sender, EventArgs e)
        {
            if (sfdKaydet.ShowDialog() != DialogResult.OK)
                return;

            _dosya = new Dosya(sfdKaydet.FileName);
            _dosya.Kaydet(_aktar);
        }

        private void TsmGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle guncelle = new Guncelle();
            guncelle.VersiyonKontrol();
        }

        private void TsmBilgi_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Bu programı, kullandığım birkaç IPTV Editor programının çok yavaş olması yüzünden yazdım. Diğerlerine nazaran daha performanslı çalışmasının yanı sıra, basit ve kompakt (yalnız kanal adı, grup ve link alanları) olması temel hedefimdi. " + Environment.NewLine + Environment.NewLine + @"IPTV listelerini ayrıntılı biçimde düzeltmek isteyen uzmanlara hitap etmese de, ben gibi normal ve sadece işe yarayan kanalları IPTV listesinde görmek isteyen kullanıcıların işine yarayacağını tahmin ediyorum.", @"Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TsmCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}