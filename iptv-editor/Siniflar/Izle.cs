using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Win32;

namespace iptv_editor.Siniflar
{
    public class Izle
    {
        private const string Vlc32BitRegistry = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        private const string Vlc64BitRegistry = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";

        public void Oynat(string kanalLinki)
        {
            if (!VlcYukluMu())
                return;

            Process proses = new Process
            {
                StartInfo =
                {
                    FileName = VlcYuklenmeDizini(),
                    Arguments = kanalLinki,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };

            proses.Start();
        }

        private bool VlcYukluMu()
        {
            RegistryKey anahtar = Registry.LocalMachine.OpenSubKey(Vlc32BitRegistry) ??
                                  Registry.LocalMachine.OpenSubKey(Vlc64BitRegistry);
            if (anahtar == null)
                return false;

            bool durum = anahtar.GetSubKeyNames().Select(a => anahtar.OpenSubKey(a))
                .Select(altAnahtar => altAnahtar?.GetValue("DisplayName") as string)
                .Any(ad => ad != null && ad.Contains("VLC"));

            return durum;
        }

        private string VlcYuklenmeDizini()
        {
            string vlcBit = Environment.Is64BitOperatingSystem ? Vlc32BitRegistry : Vlc64BitRegistry;
            string dizin = @"HKEY_LOCAL_MACHINE\" + vlcBit + @"\VLC media player";

            return (string) Registry.GetValue(dizin, "DisplayIcon", null);
        }
    }
}