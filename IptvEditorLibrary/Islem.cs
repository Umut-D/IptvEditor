using System.Collections.Generic;

namespace IptvEditorLibrary
{
    public class Islem
    {
        private readonly Aktar _aktar;

        public Islem(Aktar aktar)
        {
            _aktar = aktar;
        }

        public List<Kanal> AdaGoreBul(Kanal kanal)
        {
            return _aktar.Kanallar.FindAll(a => a.Ad.ToLower().Contains(kanal.Ad.ToLower()));
        }

        public List<Kanal> GrubaGoreBul(Kanal kanal)
        {
            return _aktar.Kanallar.FindAll(g => g.Grup.ToLower().Contains(kanal.Grup.ToLower()));
        }

        private Kanal KanalBul(Kanal kanal)
        {
            return _aktar.Kanallar.Find(k => k.Ad.Equals(kanal.Ad));
        }

        public void Sil(Kanal kanal)
        {
            _aktar.Kanallar.Remove(KanalBul(kanal));
        }
    }
}