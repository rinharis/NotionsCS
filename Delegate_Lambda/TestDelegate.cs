using System;

namespace Delegate
{
    public class TestDelegate
    {
        public TestDelegate()
        {
            Call_Methods_From_Delegate();
        }

        private void Call_Methods_From_Delegate()
        {
            Console.WriteLine("Delegate.TestDelegate - Call methods from delegate");
            int[] tableau = new int[] { 4, 1, 6, 10, 8, 5 };
            Console.WriteLine("V1 :");
            new TrieurDeTableau().DemoTri_V1(tableau);
            Console.WriteLine("\nV2 :");
            new TrieurDeTableau().DemoTri_V2(tableau);
            Console.WriteLine("\nV3 : with anonymous method");
            new TrieurDeTableau().DemoTri_V3(tableau);
            Console.WriteLine("\nV4 : multicast");
            new TrieurDeTableau().DemoTri_V4(tableau);
            Console.WriteLine("\nV5 : with another anonymous method");
            new TrieurDeTableau().DemoTri_V5(tableau);
        }
    }

    public class TrieurDeTableau
    {
        private delegate void DelegateTri(int[] tableau);
       
        public void DemoTri_V1(int[] tableau)
        {
            //delegate methode points toward TriAscendant();
            DelegateTri tri = TriAscendant;
            tri(tableau);
            foreach (int i in tableau)
                Console.WriteLine(i);
            Console.WriteLine();

            tri = TriDescendant;
            tri(tableau);
            foreach (int i in tableau)
                Console.WriteLine(i);
        }

        public void DemoTri_V2(int[] tableau)
        {
            //TriAscendant : delegated method from delegate method DelegateTri()
            TrierEtAfficher(tableau, TriAscendant);
            Console.WriteLine();
            TrierEtAfficher(tableau, TriDescendant);
        }

        public void DemoTri_V3(int[] tableau)
        {
            TrierEtAfficher(tableau, delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
            });
            Console.WriteLine();

            TrierEtAfficher(tableau, delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
                Array.Reverse(leTableau);
            });

        }
        
        public void DemoTri_V4(int[] tableau)
        {
            DelegateTri tri = TriAscendant_V2;
            tri += TriDescendant_V2;
            tri(tableau);
        }

        public void DemoTri_V5(int[] tableau)
        {
            DelegateTri tri = delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
                foreach (int i in leTableau)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
            };
            tri += delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
                Array.Reverse(leTableau);
                foreach (int i in leTableau)
                {
                    Console.WriteLine(i);
                }
            };
            tri(tableau);
        }

        private void TriAscendant(int[] tableau)
        {
            Array.Sort(tableau);
        }

        private void TriDescendant(int[] tableau)
        {
            Array.Sort(tableau);
            Array.Reverse(tableau);
        }

        //Parameter : methodeDeTri (delegate) points toward another method
        private void TrierEtAfficher(int[] tableau, DelegateTri methodeDeTri)
        {
            methodeDeTri(tableau);
            foreach (int i in tableau)
                Console.WriteLine(i);
        }

        private void TriAscendant_V2(int[] tableau)
        {
            Array.Sort(tableau);
            foreach (int i in tableau)
                Console.WriteLine(i);
            Console.WriteLine();
        }

        private void TriDescendant_V2(int[] tableau)
        {
            Array.Sort(tableau);
            Array.Reverse(tableau);
            foreach (int i in tableau)
                Console.WriteLine(i);
        }
    }
}
