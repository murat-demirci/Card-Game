using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunu
{
    class EldeKalanKartlar
    {
        public static void kalan(string[] kart1, string[] kart2, string[] kart3)
        {
            Console.WriteLine("\nYour Cards");
            foreach (string kartlar in kart1)
            {
                Console.Write(kartlar + "  ");
            }
            Console.WriteLine("\nPlayer 2 Cards");
            foreach (string kartlar in kart2)
            {
                Console.Write(kartlar + " ");
            }
            Console.WriteLine("\nPlayer 3 Cards");
            foreach (string item in kart3)
            {
                Console.Write(item + " ");
            }
        }


    }
}

