using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace KartOyunu
{
   
   
    class Program
    {

        static void Main(string[] args)
        {
            

            Random sayiGen = new Random();

            string[] Kartlar = { "S1", "S2", "S3", "S4", "S5",
                                "M1", "M2", "M3", "M4", "M5",
                                 "K1", "K2", "K3", "K4", "K5",
                                 "RD", "RD", "RD" };
            string[] O1Kart = new string[6];
            string[] O2Kart = new string[6];
            string[] O3Kart = new string[6];
            int O1eKartVer = 0, O2yeKartVer = 0, O3eKartVer = 0, KacıntıTur = 1;
            Console.WriteLine("\n\n   !!! Cant use RD or Pass first round !!!\n\n");

            while (true)
            {
                if (O1eKartVer < 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int random = sayiGen.Next(0, 18);
                        if (Kartlar[random] != "")
                        {
                            O1Kart[O1eKartVer] = Kartlar[random];
                            Kartlar[random] = "";
                            O1eKartVer++;
                        }
                        else
                        {
                            i -= 1;
                        }
                    }
                }
                else if (O2yeKartVer < 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int uretilen = sayiGen.Next(0, 18);
                        if (Kartlar[uretilen] != "")
                        {
                            O2Kart[O2yeKartVer] = Kartlar[uretilen];
                            Kartlar[uretilen] = "";
                            O2yeKartVer++;
                        }
                        else
                        {
                            i = i - 1;
                        }
                    }
                }
                else if (O3eKartVer < 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int uretilen = sayiGen.Next(0, 18);
                        if (Kartlar[uretilen] != "")
                        {
                            O3Kart[O3eKartVer] = Kartlar[uretilen];
                            Kartlar[uretilen] = "";
                            O3eKartVer++;
                        }
                        else
                        {
                            i = i - 1;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            bool KartIste = true;
            Console.WriteLine("##> You are starting game <##\n");
            Console.WriteLine("first round\n");

            while (KartIste == true)
            {
                Kartlarim.BenimKartlarım(O1Kart);
                Console.Write(" <--> pick your card = ");
                string Kartım = Console.ReadLine().ToUpper(); ;
                if ((Kartım == "PAS" || Kartım == "RD") && Global.TurSayisi <= 0)
                {
                    Console.WriteLine("Cant use RD or Pass first round !!!");
                    Global.Pcsirasi = false;
                }
                else if (Kartım == "PAS")
                {
                    Console.WriteLine("you pick PAS your card = " + Global.YerdekiKart);
                    Global.PasSayisi++;
                    Global.Pcsirasi = true;
                }
                else if (Kartım == "RD")
                {
                    int rdNerde = 0;
                    bool RdVar = false;
                    for (int rd = 0; rd < 6; rd++)
                    {
                        if (O1Kart[rd].ToUpper() == "RD")
                        {
                            rdNerde = rd;
                            RdVar = true;
                        }
                    }
                    if (RdVar == true)
                    {
                        while (true)
                        {
                            Console.Write("Pick color : ");
                            string yeniRenk = Console.ReadLine();
                            if (yeniRenk.ToUpper() == "M")
                            {
                                Global.YerdekiKart = "M" + Global.YerdekiKart.Substring(1, 1);
                                Console.WriteLine("Current card = " + Global.YerdekiKart);
                                O1Kart[rdNerde] = "- ";
                                Global.Pcsirasi = true;
                                break;
                            }
                            else if (yeniRenk.ToUpper() == "K")
                            {
                                Global.YerdekiKart = "K" + Global.YerdekiKart.Substring(1, 1);
                                Console.WriteLine("Current card = " + Global.YerdekiKart);
                                O1Kart[rdNerde] = "- ";
                                Global.Pcsirasi = true;
                                break;
                            }
                            else if (yeniRenk.ToUpper() == "S")
                            {
                                Global.YerdekiKart = "S" + Global.YerdekiKart.Substring(1, 1);
                                Console.WriteLine("Current card = " + Global.YerdekiKart);
                                O1Kart[rdNerde] = "- ";
                                Global.Pcsirasi = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter valuable color !");
                                Global.Pcsirasi = false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have no RD." + " Current card = " + Global.YerdekiKart);
                        Global.Pcsirasi= false;
                    }
                }
                else
                {
                    if (Global.TurSayisi > 0)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (O1Kart[j] == Kartım)
                            {
                                if (O1Kart[j].Substring(0, 1) == Global.YerdekiKart.Substring(0, 1) || O1Kart[j].Substring(1, 1) == Global.YerdekiKart.Substring(1, 1))
                                {
                                    Global.TurSayisi++;
                                    Global.YerdekiKart = Kartım;
                                    O1Kart[j] = "- ";
                                    Global.Pcsirasi = true;
                                    break;
                                }
                            }
                        }
                        if (Global.Pcsirasi == false)
                        {
                            Console.WriteLine("You have no this card or you pick unvaluable card.\nPlease try again." + "" +
                                              "\nCurrent Card =" + Global.YerdekiKart);
                            Global.Pcsirasi = false;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 6; j++)
                        {

                            if (O1Kart[j] == Kartım)
                            {
                                Global.TurSayisi++;
                                Global.YerdekiKart = Kartım;
                                O1Kart[j] = "- ";
                                Global.Pcsirasi = true;
                                break;
                            }
                        }
                    }
                }
                bool kontrol = false;
                kontrol = OyunDurum.oyun(O1Kart);
                if (kontrol == true)
                {
                    if (Global.PasSayisi >= 12)
                    {
                        Console.WriteLine("\nGame is in loop.*** EVEN-STEVEN ***");
                        EldeKalanKartlar.kalan(O1Kart, O2Kart, O3Kart);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nGame over, YOU WON !!!");
                        EldeKalanKartlar.kalan(O1Kart, O2Kart, O3Kart);
                        break;
                    }
                }
                if (Global.Pcsirasi == true)
                {
                    bilgisayarKartAtma.KartAt(O2Kart, "Player 2");
                    bool kontrol2 = false;
                    kontrol2 = OyunDurum.oyun(O2Kart);
                    if (Global.PasSayisi >= 12)
                    {
                        Console.WriteLine("\nGame is in loop.*** EVEN-STEVEN ***");
                        EldeKalanKartlar.kalan(O1Kart, O2Kart, O3Kart);
                        break;
                    }
                    if (kontrol2 == true)
                    {
                        Console.WriteLine("\nGame over, PLAYER 2 WON!!!");
                        EldeKalanKartlar.kalan(O1Kart, O2Kart, O3Kart);
                        break;
                    }
                    bilgisayarKartAtma.KartAt(O3Kart, "Player 3");
                    bool kontrol3 = false;
                    kontrol3 = OyunDurum.oyun(O3Kart);
                    if (kontrol3 == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Game over,PLAYER 3 WON!!!");
                        EldeKalanKartlar.kalan(O1Kart, O2Kart, O3Kart);
                        break;
                    }
                    Global.Pcsirasi = false;
                    Console.WriteLine();
                    KacıntıTur++;
                    Console.WriteLine((KacıntıTur) + ".Round");
                }
            }
            Console.ReadLine();
        }


    }
}