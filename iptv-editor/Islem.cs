using System;
using System.Collections.Generic;
using System.Linq;

namespace iptv_editor
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

        public void Sil(Kanal kanal)
        {
            Kanal silinenKanal = _aktar.Kanallar.FirstOrDefault(k => string.Equals(k.Ad, kanal.Ad, StringComparison.CurrentCultureIgnoreCase));

            if (silinenKanal != null)
                _aktar.Kanallar.Remove(silinenKanal);
        }
    }
}