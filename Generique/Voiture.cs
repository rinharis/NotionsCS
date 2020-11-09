using System;
using System.Collections.Generic;
using System.Text;

namespace Generique
{
    public class Voiture : IComparable<Voiture>
    {
        public string Couleur { get; set; }
        public string Marque { get; set; }
        public int Vitesse { get; set; }

        public int CompareTo(Voiture obj)
        {
            return Vitesse.CompareTo(obj.Couleur);
        }
    }
}
