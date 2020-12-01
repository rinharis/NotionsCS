using System;
using System.Collections.Generic;
using System.Text;

namespace Generique
{
    public class TestClasseGenerique
    {
        public void Add_And_Get_With_Generic()
        {
            Console.WriteLine("\n_And_Get_With_Generic");
            MaClasseGenerique<int> maListe = new MaClasseGenerique<int>();
            maListe.Ajouter(25);
            maListe.Ajouter(30);
            maListe.Ajouter(5);

            Console.WriteLine(maListe.ObtenirElement(0));
            Console.WriteLine(maListe.ObtenirElement(1));
            Console.WriteLine(maListe.ObtenirElement(2));

            Console.WriteLine("Ajout d'element a l'indexe : ");
            for (int i = 0; i < 30; i++)
            {
                maListe.Ajouter(i);
                Console.Write(" {0} : {1}\t", i, maListe.ObtenirElement(i));
            }
            Console.WriteLine();
        }

        public void Add_And_Get_With_Enumerator()
        {
            Console.WriteLine("\nAdd_And_Get_With_Enumerator");
            ListeChainee<string> maListe = new ListeChainee<string>();
            maListe.Ajouter("one");
            maListe.Ajouter("two");
            maListe.Ajouter("three");
            maListe.Ajouter("four");
            maListe.Ajouter("five");
            Console.WriteLine("Get elements with different ways : ");
            int i = -1;
            while (maListe.GetEnumerator().MoveNext())
            {
                i++;
                switch (i)
                {
                    case 0:
                        Console.WriteLine("First element : " + maListe.Premier.Valeur);
                        break;
                    case 1:
                        Console.WriteLine("Focus on current : {0}", maListe.GetEnumerator().Current + "FIXIT : courrant is always null, new instance of ListeChaineeEnumerator is created when GetEnumerator is called");
                        break;
                    case 4:
                        Console.WriteLine("Last element : " + maListe.Dernier.Valeur);
                        break;
                    default:
                        Console.WriteLine(maListe.ObtenirElement(i).Valeur);
                        break;
                }
            }
            Console.WriteLine("\nNOT TESTED : dispose, reset");
        }

    }
}
