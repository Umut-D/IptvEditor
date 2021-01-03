using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace iptv_editor
{
    public class Guncelle
    {
        public void VersiyonKontrol()
        {
            try
            {
                XmlOku();
            }
            catch (Exception)
            {
                MessageBox.Show(@"Bağlantı sağlanırken istenmeyen bir hata meydana geldi. İnternet bağlantınızı kontrol etseniz iyi olur.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XmlOku()
        {
            string guncellemeLinki = @"https://raw.githubusercontent.com/Umut-D/umutd.com/master/assets/program-versions/iptv-editor.xml";

            WebClient webIstemcisi = new WebClient();
            XmlReader xmlOku = XmlReader.Create(webIstemcisi.OpenRead(guncellemeLinki) ?? throw new InvalidOperationException());

            while (xmlOku.Read())
            {
                if (xmlOku.NodeType != XmlNodeType.Element || xmlOku.Name != "iptv" || !xmlOku.HasAttributes)
                    continue;

                VersiyonKarsilastir(xmlOku);
            }
        }

        private void VersiyonKarsilastir(XmlReader xmlOku)
        {
            // TODO Her yeni versiyonda bu alan ve sunucudaki XML dosyası güncellecek
            string versiyon = "1.00";
            string sunucudakiVersiyon = xmlOku.GetAttribute("version");

            if (sunucudakiVersiyon == versiyon)
                MessageBox.Show(@"Program günceldir. Yeni versiyon çıkana kadar şimdilik en iyisi bu.", @"Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult guncelleDiyalog = MessageBox.Show(@"Yeni bir güncelleme var. Programı " + sunucudakiVersiyon + @" versiyonuna yükselttim. Yenilikler var. Web sayfasına girip indirmek ister misiniz?",
                    @"Güncelle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (guncelleDiyalog == DialogResult.OK)
                    Process.Start("http://www.umutd.com/programlar/iptv-editor");
            }
        }
    }
}