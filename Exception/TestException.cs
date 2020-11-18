using System;

namespace Exception
{
    internal class TestException
    {
        public TestException()
        {
            Demo_Exception();
        }

        private void Demo_Exception()
        {
            try
            {
                string chaine = "dix";
                int valeur = Convert.ToInt32(chaine);
                Console.WriteLine("Ce code ne sera jamais affiché");
            }
            catch (Exception)
            {
                Console.WriteLine("Une erreur s'est produite dans la tentative de conversion");
            }
        }
    }
}