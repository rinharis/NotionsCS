using System;
using System.Threading;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDelegate testDelegate = new TestDelegate();
            TestGenericDelegate testGenericDelegate = new TestGenericDelegate();
        }
    }
}
