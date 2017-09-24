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
            WritePrimeTable(primeTable);

            Console.WriteLine("Please any key to quit");
            Console.ReadKey();
        }

        private static void WritePrimeTable(long[][] table)
        {
            var builder = new StringBuilder();
            for (var i = 0; i <= table.Length - 1; i++)
            {
                for (var j = 0; j <= table[i].Length - 1; j++)
                {
                    builder.Append(j == 0 ? "|" : string.Empty);
                    builder.Append($" {table[i][j]} |");
                }
                Console.WriteLine(builder.ToString());
                builder.Clear();
            }
        }
    }
}
