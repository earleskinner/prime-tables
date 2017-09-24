namespace PrimeTables.Console
{
    using System;

    public class ConsoleOutput
    {
        public ConsoleOutput(int multipler, long[] primeNumbers)
        {
            Multipler = multipler;
            PrimeNumbers = primeNumbers;
        }

        public int Multipler { get; }

        public long[] PrimeNumbers { get; }

        public long[,] CreatePrimeTable()
        {
            if (Multipler == 0 || PrimeNumbers == null || PrimeNumbers.Length < 1)
            {
                return null;
            }

            var table = new long[Multipler,PrimeNumbers.Length];

            for (var i = 0; i <= Multipler-1; i++)
            {
                for (var j = 0; j <= PrimeNumbers.Length - 1; j++)
                {
                    table[i, j] = PrimeNumbers[j] * (i + 1);
                }
            }

            return table;
        }
    }
}