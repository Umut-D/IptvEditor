using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using IptvEditorLibrary;

namespace IptvEditorUI
{
    public partial class FrmIpTvEditor : Form
    {
        private Dosya _dosya;
        private Aktar _aktar;
        private Ara _ara;
        private bool _silmeIslemiDevamEdiyor = false;

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

            Izle izle = new Izle();
            izle.Oynat(listView.SelectedItems[0].SubItems[3].Text.Trim());
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
            _ara = new Ara(_aktar);

            List<Kanal> bul;
            if (tstBul.Text.StartsWith("@"))
            {
                bul = _ara.GrubaGore(new Kanal
                {
                    Grup = tstBul.Text.Remove(0, 1)
                });
            }
            else
            {
                bul = _ara.AdaGore(new Kanal
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

        private void CmsKopyala_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count <= 0)
                return;

            Clipboard.SetText(listView.SelectedItems[0].SubItems[3].Text.Trim());
        }

        private async void CmsSil_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count <= 0 || _silmeIslemiDevamEdiyor)
                return;

            int secilenNesneIndeksi = listView.SelectedItems[0].Index - 1;

            await KanalSilAsync();

            SilmeSonrasiKalinanSatiriSec(secilenNesneIndeksi);
        }

        // İlerleme göstergesi ile çok hızlı async metod
        private async Task KanalSilAsync()
        {
            if (_silmeIslemiDevamEdiyor) return;

            _silmeIslemiDevamEdiyor = true;
            
            try
            {
                // Kullanıcıya işlem başladığını göster
                tsslDurum.Text = "Kanallar hazırlanıyor...";
                Cursor = Cursors.WaitCursor;
                
                // Seçili kanalların adlarını topla (UI thread'de)
                var silinecekKanalAdlari = new List<string>();
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    string kanalAdi = item.SubItems[1].Text.Trim();
                    if (!string.IsNullOrEmpty(kanalAdi))
                        silinecekKanalAdlari.Add(kanalAdi);
                }

                if (silinecekKanalAdlari.Count == 0) return;

                // Silme işlemini arka planda yap
                await Task.Run(() =>
                {
                    _ara = new Ara(_aktar);
                    
                    // Silinecek kanalları Kanal nesnesine çevir
                    var silinecekKanallar = silinecekKanalAdlari
                        .Select(ad => new Kanal { Ad = ad })
                        .ToList();
                    
                    // İlerleme callback'i ile toplu silme işlemi
                    _ara.KanalSil(silinecekKanallar, (islenen, toplam) =>
                    {
                        // UI thread'de ilerleme göster
                        this.Invoke((MethodInvoker)delegate
                        {
                            double yuzde = toplam > 0 ? (double)islenen / toplam * 100 : 0;
                            tsslDurum.Text = $"Kanallar siliniyor... {islenen}/{toplam} (%{yuzde:F0})";
                        });
                    });
                });

                // UI'yi güncelle (UI thread'de)
                tsslDurum.Text = "Liste güncelleniyor...";
                ListViewYukle(_aktar.Kanallar);
                KanalSayisi();
                
                // İşlem başarılı mesajı
                tsslDurum.Text = $"✅ {silinecekKanalAdlari.Count} kanal başarıyla silindi";
                
                // 3 saniye sonra normal duruma dön
                await Task.Delay(3000);
                if (!_silmeIslemiDevamEdiyor) // Başka işlem başlamamışsa
                    KanalSayisi();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi sırasında hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tsslDurum.Text = "❌ Silme işlemi başarısız";
            }
            finally
            {
                Cursor = Cursors.Default;
                _silmeIslemiDevamEdiyor = false;
            }
        }

        // Eski yavaş KanalSil metodu - artık kullanılmıyor
        private void KanalSil()
        {
            _ara = new Ara(_aktar);

            for (int i = 0; i < listView.SelectedItems.Count; i++)
            {
                if (!listView.SelectedItems[i].Selected)
                    continue;

                int indeks = listView.SelectedItems[i].Index;
                string seciliKanal = listView.Items[indeks].SubItems[1].Text.Trim();
                _ara.KanalSil(new Kanal
                {
                    Ad = seciliKanal
                });
            }
        }

        private void SilmeSonrasiKalinanSatiriSec(int secilenNesneIndeksi)
        {
            if (secilenNesneIndeksi <= 0 || secilenNesneIndeksi >= listView.Items.Count)
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
            _dosya.Kaydet(_aktar.Kanallar);
        }

        private void TsmiAramSonuclariniKaydet_Click(object sender, EventArgs e)
        {
            if (sfdKaydet.ShowDialog() != DialogResult.OK)
                return;

            _dosya = new Dosya(sfdKaydet.FileName);
            _dosya.Kaydet(KanalBul());
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