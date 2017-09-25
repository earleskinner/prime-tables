using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTables.Console
{
    using PrimeTables.Computation;

    using Console = System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleInput(args);
            var generator = new SieveOfEratosthenes();
            Console.WriteLine("Generating prime numbers...");
            var output = generator.GeneratePrimeNumbers<ConsoleOutput>(input);

            output.WritePrimeTable();

            Console.WriteLine("Please any key to quit");
            Console.ReadKey();
        }
    }
}
