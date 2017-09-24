namespace PrimeTables.Computation
{
    using System.Collections.Generic;

    public class PrimeNumberGenerator
    {
        private readonly List<long> primeNumbers = new List<long>();

        public PrimeNumberGenerator(int upperBound)
        {
            UpperBound = upperBound;
        }

        public int UpperBound { get; }

        /// <summary>
        /// Initial generation of prime numbers using "trial by division"
        /// Requirements state not to use this algorithm
        /// TODO: Use different algorithm
        /// </summary>
        /// <returns></returns>
        public long[] GeneratePrimeNumbers()
        {
            if (UpperBound == 0)
            {
                return null;
            }

            primeNumbers.Add(2);
            var number = 3;
            var counter = 1;

            while (counter < UpperBound)
            {
                if (isPrime(number))
                {
                    primeNumbers.Add(number);
                    counter++;
                }

                number += 2;
            }

            return this.primeNumbers.ToArray();
        }

        private bool isPrime(long number)
        {
            foreach (long prime in primeNumbers)
                if (number % prime == 0)
                    return false;

            return true;
        }
    }
}