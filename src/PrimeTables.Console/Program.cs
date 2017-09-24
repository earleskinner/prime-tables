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
            var generator = new PrimeNumberGenerator(input.UpperBound);
            Console.WriteLine("Generating prime numbers...");
            var primeNumbers = generator.GeneratePrimeNumbers();
            var output = new ConsoleOutput(input.UpperBound, primeNumbers);

            var primeTable = output.CreatePrimeTable();
            // TODO
            // Write to console

            Console.ReadKey();
        }
    }
}
