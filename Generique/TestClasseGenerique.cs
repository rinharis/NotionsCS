using System;
using System.Collections.Generic;
using System.Text;

namespace Generique
{
    
    public class TestClasseGenerique
    {
        public void CreationDeClasseGenerique()
        {
            MaClasseGenerique<int> maListe = new MaClasseGenerique<int>();
            maListe.Ajouter(25);
            maListe.Ajouter(30);
            maListe.Ajouter(5);

            Console.WriteLine(maListe.ObtenirElement(0));
            Console.WriteLine(maListe.ObtenirElement(1));
            Console.WriteLine(maListe.ObtenirElement(2));

            for (int i = 0; i < 30; i++)
            {
                maListe.Ajouter(i);
                Console.WriteLine("Ajout d'element a l'indexe {0} : {1}", i, maListe.ObtenirElement(i));
            }
        }
    }
}
