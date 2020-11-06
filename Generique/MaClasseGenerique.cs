using System;
using System.Collections.Generic;
using System.Text;

namespace Generique
{
    public class MaClasseGenerique<T>
    {
        private int capacite;
        private int nbElements;
        private T[] tableau;

        public MaClasseGenerique()
        {
            capacite = 10;
            nbElements = 0;
            tableau = new T[capacite];
        }

        public void Ajouter(T element)
        {
            if (nbElements >= capacite)
            {
                capacite *= 2;
                T[] copieTableau = new T[capacite];
                for (int i = 0; i < tableau.Length; i++)
                {
                    copieTableau[i] = tableau[i];
                }
                tableau = copieTableau;
            }
            tableau[nbElements] = element;
            nbElements++;
        }

        public T ObtenirElement(int indice)
        {
            if (indice < 0 || indice >= nbElements)
            {
                Console.WriteLine("L'indice n'est pas bon");
                return default(T);
            }
            return tableau[indice];
        }
    }
}
