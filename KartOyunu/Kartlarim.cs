using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunu
{
    class Kartlarim
    {
        public static void BenimKartlarım(string[] kart)
        {
            foreach (string kartlarim in kart)
            {
                Console.Write(kartlarim + "  ");
            }
        }
    }
}
