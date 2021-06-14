using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunu
{
    class OyunDurum
    {
        public static bool oyun(string[] kartDurum)
        {
            int PasSayisi = 0;
            bool Sonuc = false;
            int kartSayisi = 0;
            for (int i = 0; i < 6; i++)
            {
                if (kartDurum[i] == "- ")
                {
                    kartSayisi++;
                }
            }
            if (kartSayisi >= 6)
            {
                Sonuc = true;
            }
            if (PasSayisi >= 12)
            {
                Sonuc = true;
            }
            return Sonuc;
        }
    }
}
