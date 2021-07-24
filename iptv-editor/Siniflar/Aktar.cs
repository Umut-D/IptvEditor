using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace iptv_editor.Siniflar
{
    public class Aktar
    {
        public List<Kanal> Kanallar { get; set; }
        private readonly Dosya _dosya;

        public Aktar(Dosya dosya)
        {
            _dosya = dosya;
            Donustur();
        }

        private void Donustur()
        {
            using (StringReader reader = new StringReader(_dosya.Veri))
            {
                Kanallar = new List<Kanal>();

                string satir;
                while ((satir = reader.ReadLine()) != null)
                {
                    satir = satir + Environment.NewLine + reader.ReadLine();
                    KanallariEkle(satir);
                }
            }
        }

        private void KanallariEkle(string satir)
        {
            Kanal kanal = new Kanal
            {
                Ad = KanalAdRegex(satir),
                Grup = KanalGrupRegex(satir),
                Link = LinkRegex(satir)
            };

            Kanallar.Add(kanal);
        }

        private string KanalAdRegex(string satir)
        {
            string adDesen = @"tvg-name=\""(.+?)\""";
            if (satir.Contains("tvg-name="))
                return Regex.Match(satir, adDesen).Groups[1].Value;

            return Regex.Match(satir, @",(.*)").Groups[1].Value;
        }

        private string KanalGrupRegex(string satir)
        {
            string grupDesen = @"group-title=\""(.+?)\""";
            return Regex.Match(satir, grupDesen).Groups[1].Value;
        }

        private static string LinkRegex(string satir)
        {
            string linkDesen = @"\n^(.*)$";
            return Regex.Match(satir, linkDesen, RegexOptions.Multiline).Value;
        }
    }
}