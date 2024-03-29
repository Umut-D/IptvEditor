﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IptvEditorLibrary
{
    public class Dosya
    {
        public string Veri { get; private set; }
        private readonly string _konum;

        public Dosya(string konum)
        {
            _konum = konum;
        }

        public void Ac()
        {
            using (FileStream akis = new FileStream(_konum, FileMode.Open))
            {
                using (StreamReader oku = new StreamReader(akis, Encoding.UTF8))
                {
                    while (oku.Peek() >= 0)
                    {
                        if (!oku.ReadLine()?.StartsWith("#EXTM3U") == true)
                            throw new FormatException("#EXTM3U başlığı bulunmuyor.");

                        Veri = oku.ReadToEnd();
                    }
                }
            }
        }

        public void Kaydet(List<Kanal> kanalBul)
        {
            using (FileStream akis = new FileStream(_konum, FileMode.Create))
            {
                using (StreamWriter yaz = new StreamWriter(akis, Encoding.UTF8))
                {
                    yaz.WriteLine("#EXTM3U");

                    foreach (Kanal kanal in kanalBul)
                    {
                        string satir = $"#EXTINF:-1 tvg-name=\"{kanal.Ad}\" group-title=\"{kanal.Grup}\",{kanal.Ad} {kanal.Link}";
                        yaz.WriteLine(satir);
                    }
                }
            }
        }
    }
}