using System;

namespace ClassLibraryUser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Need to add reference (ClassLibrary) to dependancies
            ClassLibrary.Client client = new ClassLibrary.Client("Nico", "12345");
            Console.WriteLine("Mot de passe : " + client.MotDePasse);

            Console.WriteLine("Obtenir id : " + ClassLibrary.Generateur.ObtenirIdentifiantUnique());

            //ClassLibrary.Encodage // belongs to another assembly so this internal class is not accessible here.

            ClassLibrary.Generateur.AForge_Math_Tool_PowerOf2();
        }
    }
}
