using System;

namespace Exceptions
{
    public class TestException
    {
        public TestException()
        {
            Catch_Multi_Exception();
            Catch_From_Detail_To_General();
            Catch_Nested_Exceptions();
            Catch_With_Finally();
            Rise_Exception_With_Through();
            Personalized_Exception();
        }

        private void Catch_Multi_Exception()
        {
            Console.WriteLine("\nCatch_Multi_Exception");
            try
            {
                string saisie;
                while (true)
                {
                    Console.WriteLine("Saisis autre chose qu'un entier : ");
                    saisie = Console.ReadLine();
                    int entier = Convert.ToInt32(saisie);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erreur de format : " + ex);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Erreur de référence nulle : " + ex);
            }
        }

        private void Catch_From_Detail_To_General()
        {
            Console.WriteLine("\nCatch_From_Detail_To_General");
            try
            {
                string saisie;
                while (true)
                {
                    Console.WriteLine("Saisis autre chose qu'un entier : ");
                    saisie = Console.ReadLine();
                    int entier = Convert.ToInt32(saisie);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erreur de format : " + ex);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Erreur de référence nulle : " + ex);
            }
            catch (SystemException ex)
            {
                Console.WriteLine("Erreur système autres que FormatException et NullReferenceException : " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Toutes les autres exceptions : " + ex);
            }
        }

        private void Catch_Nested_Exceptions()
        {
            Console.WriteLine("\nCatch_Nested_Exceptions");
            string saisie = null;
            try
            {
                while (true)
                {
                    Console.WriteLine("Saisis autre chose qu'un entier : ");
                    saisie = Console.ReadLine();
                    int entier = Convert.ToInt32(saisie);
                }
            }
            catch (FormatException)
            {
                try
                {
                    double d = Convert.ToDouble(saisie);
                    Console.WriteLine("La saisie est un double");
                }
                catch (FormatException)
                {
                    Console.WriteLine("La saisie n'est ni un entier, ni un double");
                }
            }
        }

        private void Catch_With_Finally()
        {
            Console.WriteLine("\nCatch_With_Finally");
            try
            {
                string saisie;
                while (true)
                {
                    Console.WriteLine("Saisis autre chose qu'un entier : ");
                    saisie = Console.ReadLine();
                    int entier = Convert.ToInt32(saisie);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Vous avez saisi autre chose qu'un entier");
            }
            finally
            {
                Console.WriteLine("Merci d'avoir saisi quelque chose");
            }
        }

        private void Rise_Exception_With_Through()
        {
            Console.WriteLine("\nRise_An_Exception_With_Trow");
            try
            {
                RacineCarree(2);
                RacineCarree(-2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception levée : " + e.Message);
            }
        }

        private double RacineCarree(double valeur)
        {
            if (valeur <= 0)
                throw new ArgumentOutOfRangeException("valeur", "Le paramètre doit être positif");
            double result = Math.Sqrt(valeur);
            Console.WriteLine("No exception met. Sqrt of {0} = {1}", valeur, result);
            return result;
        }

        private void Personalized_Exception()
        {
            Console.WriteLine("\nPersonalized_Exception");
            try
            {
                Produit produit = new Produit();
                produit.ChangerProduit("TV HD");
            }
            catch (EmptyStockException e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }
    }

    public class Produit
    {
        public int Stock { get; set; }
        public string NomProduit { get; set; }

        public Produit ChangerProduit(string nomProduit)
        {
            Produit produit = new Produit() { NomProduit = nomProduit };
            if (produit.Stock <= 0)
            {
                throw new EmptyStockException(nomProduit);
                throw new EmptyStockException();
            }
            return produit;
        }
    }

    public class EmptyStockException : Exception
    {
        public EmptyStockException() : base("Le produit n'est plus en stock")
        {
        }
        public EmptyStockException(string nomProduit) : base("Le produit " + nomProduit + " n'est plus en stock")
        {
        }
    }

}