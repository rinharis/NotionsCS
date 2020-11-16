using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegate
{
    class TestGenericDelegate
    {
        private int[] tableau = { 0, 4, 6, 7, 3, 5, 2, 1};

        public TestGenericDelegate()
        {
            Demo_Generic_Delegate();
        }

        private void Demo_Generic_Delegate()
        {
            Console.WriteLine("\nDelegate.TestGenericDelegate - Test generic delegate.\n" +
                "Action has no return whereas Function does.");
            Thread.Sleep(3000);
            Console.WriteLine("Action :");
            ActionDelegate action = new ActionDelegate();
            action.DemoTri(tableau);

            Thread.Sleep(3000);
            Console.WriteLine("Function :");
            FunctionDelegate function = new FunctionDelegate();
            function.DemoOperations();
        }
    }

    public class ActionDelegate
    {
        public void DemoTri(int[] tableau)
        {
            //TrierEtAfficher(tableau, delegate (int[] leTableau)
            //{
            //    Array.Sort(leTableau);
            //});

            //With lambda expression it would be :
            TrierEtAfficher(tableau, tab => { Array.Sort(tab); } );

            Console.WriteLine();

            TrierEtAfficher(tableau, delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
                Array.Reverse(leTableau);
            });

        }

        private void TrierEtAfficher(int[] tableau, Action<int[]> methodeDeTri)
        {
            methodeDeTri(tableau);
            foreach (int i in tableau)
                Console.WriteLine(i);
        }
    }

    public class FunctionDelegate
    {
        public void DemoOperations()
        {
            //delegate : third param type is implicit : same as his return type
            double division = Calcul(delegate (int a, int b)
            {
                return (double)a / (double)b;
            }, 4, 5);

            double puissance = Calcul(delegate (int a, int b)
            {
                return Math.Pow((double)a, (double)b);
            }, 4, 5);

            Console.WriteLine("Division : " + division);
            Console.WriteLine("Puissance : " + puissance);
        }

        //Func parameters : int, int, and double is the return type of the function
        private double Calcul(Func<int, int, double> methodeDeCalcul, int a, int b)
        {
            return methodeDeCalcul(a, b);
        }
    }

}
