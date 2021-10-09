using System;

namespace Richargh.Sandbox.ContractTests.Library
{
    class Program
    {
        static void Main(string[] args)
        {
            var greeter = new Greeater();
            Console.WriteLine(greeter.greet("World"));
        }
    }
}
