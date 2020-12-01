using System;

namespace Generique
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClasseGenerique classeGenerique = new TestClasseGenerique();
            classeGenerique.Add_And_Get_With_Generic();
            classeGenerique.Add_And_Get_With_Enumerator();
        }
    }    
}
