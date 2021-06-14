using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunu
{
    class bilgisayarKartAtma
    {
        public static void KartAt(string[] BilgiKartlar, string BilgiOyuncu)
        {


             
        bool pcUygunKart = false, rdVarMi = false;
            int rdIndis = 0;
            if (Global.YerdekiKart == "- ")
            {
                for (int i = 0; i < 6; i++)
                {
                    if (BilgiKartlar[i] != "RD")
                    {
                        Console.WriteLine(BilgiOyuncu + " " + BilgiKartlar[i]);
                        Global.YerdekiKart = BilgiKartlar[i];
                        BilgiKartlar[i] = "- ";
                        break;
                    }
                }
            }
            
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    if (BilgiKartlar[i].Substring(0, 1).ToUpper() == Global.YerdekiKart.Substring(0, 1).ToUpper() || BilgiKartlar[i].Substring(1, 1).ToUpper() == Global.YerdekiKart.Substring(1, 1).ToUpper())
                    {
                        pcUygunKart = true;
                        Console.WriteLine(BilgiOyuncu + " " + BilgiKartlar[i]);
                        Global.YerdekiKart = BilgiKartlar[i];
                        BilgiKartlar[i] = "- ";
                        break;
                    }
                }
                if (pcUygunKart == false)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (BilgiKartlar[i] == "RD")  
                        {                             
                            rdIndis = i;              
                            rdVarMi = true;
                            break;
                        }
                    }
                    if (rdVarMi == true)
                    {
                        bool eldeRenkliKartYok = false;
                        for (int i = 0; i < 6; i++)
                        {
                            if (BilgiKartlar[i].Substring(0, 1).ToUpper() == "K")
                            {
                                Global.YerdekiKart = "K" + Global.YerdekiKart.Substring(1, 1);
                                Console.WriteLine(BilgiOyuncu + " use RD card and make new card  " + Global.YerdekiKart);
                                BilgiKartlar[rdIndis] = "- ";
                                eldeRenkliKartYok = true;
                                break;
                            }
                            else if (BilgiKartlar[i].Substring(0, 1).ToUpper() == "M")
                            {
                                Global.YerdekiKart = "M" + Global.YerdekiKart.Substring(1, 1);
                                Console.WriteLine(BilgiOyuncu + " use RD card and make new card " + Global.YerdekiKart);
                                BilgiKartlar[rdIndis] = "- ";
                                eldeRenkliKartYok = true;
                                break;
                            }
                            else if (BilgiKartlar[i].Substring(0, 1).ToUpper() == "S")
                            {
                                Global.YerdekiKart = "S" + Global.YerdekiKart.Substring(1, 1);
                                Console.WriteLine(BilgiOyuncu + " use RD card and make new card " + Global.YerdekiKart );
                                Global.PasSayisi = 0;
                                BilgiKartlar[rdIndis] = "- ";
                                eldeRenkliKartYok = true;
                                break;
                            }
                        }
                        if (eldeRenkliKartYok == false)
                        {
                            Random r = new Random();
                            int renkUret = r.Next(0, 3);
                            if (renkUret == 0)
                            {
                                Global.YerdekiKart = "m" + Global.YerdekiKart.Substring(1, 1);
                                Console.WriteLine(BilgiOyuncu + " use RD card and make new card " + Global.YerdekiKart);
                                Global.PasSayisi = 0;
                            }
                            else if (renkUret == 1)
                            {
                                Global.YerdekiKart = "k" + Global.YerdekiKart.Substring(1, 1);
                                Console.WriteLine(BilgiOyuncu + " use RD card and make new card " + Global.YerdekiKart);
                                Global.PasSayisi = 0;
                            }
                            else if (renkUret == 2)
                            {
                                Global.YerdekiKart = "s" + Global.YerdekiKart.Substring(1, 1);
                                Console.WriteLine(BilgiOyuncu + " use RD card and make new card " + Global.YerdekiKart);
                                Global.PasSayisi = 0;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(BilgiOyuncu + " Said PASS " + Global.YerdekiKart);
                        Global.PasSayisi++;
                    }
                }
            }
        }
    }
}
