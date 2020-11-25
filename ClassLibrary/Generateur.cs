using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class Generateur
    {
        public static string ObtenirIdentifiantUnique()
        {
            Random r = new Random();
            string chaine = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                chaine += r.Next(0, 100);
            }
            return chaine.Crypte();
        }

        public static void AForge_Math_Tool_PowerOf2()
        {
            for(int i = 0; i < 10000; i++)
            {
                //Install AForge.Math throw Nugget Package Manager (in References)
                if (AForge.Math.Tools.IsPowerOf2(i))
                    Console.Write(i + ", ");
            }
            Console.WriteLine("are power of 2");
        }
    }
}
