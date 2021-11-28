using System.Collections.Generic;

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
            return _aktar.Kanallar.FindAll(a => a.Ad.ToLower().Contains(kanal.Ad.ToLower()));
        }

        public List<Kanal> GrubaGore(Kanal kanal)
        {
            return _aktar.Kanallar.FindAll(g => g.Grup.ToLower().Contains(kanal.Grup.ToLower()));
        }

        private Kanal Kanal(Kanal kanal)
        {
            return _aktar.Kanallar.Find(k => k.Ad.Equals(kanal.Ad));
        }

        public void KanailSil(Kanal kanal)
        {
            _aktar.Kanallar.Remove(Kanal(kanal));
        }
    }
}