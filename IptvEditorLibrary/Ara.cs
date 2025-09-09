using System.Collections.Generic;
using System;
using System.Linq;

namespace IptvEditorLibrary
{
    public class Ara
    {
        private readonly Aktar _aktar;

        public Ara(Aktar aktar)
        {
            _aktar = aktar;
        }

        public List<Kanal> AdaGore(Kanal kanal)
        {
            return _aktar.Kanallar.FindAll(a => a.Ad != null && kanal.Ad != null && a.Ad.ToLower().Contains(kanal.Ad.ToLower()));
        }

        public List<Kanal> GrubaGore(Kanal kanal)
        {
            return _aktar.Kanallar.FindAll(g => g.Grup != null && kanal.Grup != null && g.Grup.ToLower().Contains(kanal.Grup.ToLower()));
        }

        private Kanal Kanal(Kanal kanal)
        {
            return _aktar.Kanallar.Find(k => k.Ad == kanal.Ad);
        }

        // Tekli silme için optimize
        public void KanalSil(Kanal kanal)
        {
            _aktar.Kanallar.RemoveAll(k => k.Ad == kanal.Ad);
        }

        // Çoklu silme için yüksek performanslı yöntem
        public void KanalSil(List<Kanal> kanallar)
        {
            var adSet = new HashSet<string>(kanallar.Where(k => k.Ad != null).Select(k => k.Ad));
            _aktar.Kanallar = _aktar.Kanallar.Where(k => k.Ad == null || !adSet.Contains(k.Ad)).ToList();
        }

        // İlerleme bilgisi ile çoklu silme
        public void KanalSil(List<Kanal> kanallar, Action<int, int> ilerlemeBilgisi = null)
        {
            if (kanallar == null || kanallar.Count == 0)
                return;

            int toplamKanal = kanallar.Count;
            int islenenKanal = 0;

            // İlerleme bilgisi gönder
            ilerlemeBilgisi?.Invoke(islenenKanal, toplamKanal);

            // Silinecek kanal adlarını topla
            var adSet = new HashSet<string>();
            foreach (var kanal in kanallar)
            {
                if (kanal.Ad != null)
                {
                    adSet.Add(kanal.Ad);
                }
                
                islenenKanal++;
                
                // Her 100 kanalde bir ilerleme bilgisi gönder
                if (islenenKanal % 100 == 0 || islenenKanal == toplamKanal)
                {
                    ilerlemeBilgisi?.Invoke(islenenKanal, toplamKanal);
                }
            }

            // Filtreleme işlemi
            ilerlemeBilgisi?.Invoke(toplamKanal, toplamKanal);
            _aktar.Kanallar = _aktar.Kanallar.Where(k => k.Ad == null || !adSet.Contains(k.Ad)).ToList();
        }
    }
}