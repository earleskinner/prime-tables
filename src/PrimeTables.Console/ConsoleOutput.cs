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
            throw new NotImplementedException();
        }
    }
}