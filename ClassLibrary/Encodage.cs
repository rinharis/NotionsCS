using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal static class Encodage
    {
        //methode d'extension (static - this), internal : accessible uniquement dans la meme assembly
        internal static string Crypte(this string chaine)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(chaine));
        }

        internal static string Decrypte(this string chaine)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(chaine));
        }
    }
}
