namespace PrimeTables.Computation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Sieve of Eratosthenes
    /// A simple, ancient algorithm for finding all prime numbers up to any given limit.
    /// https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
    /// </summary>
    /// <remarks>
    /// Thanks to https://stackoverflow.com/questions/1042902/most-elegant-way-to-generate-prime-numbers/1042969
    /// </remarks>
    public class SieveOfEratosthenes : IGenerator
    {
        /// <summary>
        /// Generate a given number of prime numbers using the Sieve of Eratosthenes algorithm.
        /// </summary>
        /// <typeparam name="T">
        /// Implementation of IOutput
        /// </typeparam>
        /// <param name="input">
        /// Implementation of IInput
        /// </param>
        /// <returns>
        /// A list of prime numbers
        /// </returns>
        public T GeneratePrimeNumbers<T>(IInput input) where T : IOutput
        {
            var instance = (IOutput)Activator.CreateInstance<T>();

            if (input.UpperBound < 1)
            {
                return (T)instance;
            }

            instance.Multipler = input.UpperBound;
            instance.PrimeNumbers = GeneratePrimeNumbers(input.UpperBound);

            return (T)instance;
        }

        /// <summary>
        /// Find the approximate nth prime number
        /// </summary>
        /// <param name="uppperbound">
        /// The upper bound limit
        /// </param>
        /// <returns>
        /// The nth prime number <see cref="int"/>
        /// </returns>
        private static int ApproximateNthPrime(int uppperbound)
        {
            var n = (double)uppperbound;
            double nth;
            if (uppperbound >= 7022)
            {
                nth = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            }
            else if (uppperbound >= 6)
            {
                nth = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            }
            else if (uppperbound > 0)
            {
                nth = new[] { 2, 3, 5, 7, 11 }[uppperbound - 1];
            }
            else
            {
                nth = 0;
            }

            return (int)nth;
        }

        /// <summary>
        /// Create an bit array for every number up to the nth prime number
        /// Once a prime number is found, begin to sieve out non prime numbers
        /// </summary>
        /// <param name="uppperbound">
        /// The upper bound limit
        /// </param>
        /// <returns>
        /// The array of sieved prime numbers <see cref="BitArray"/>.
        /// </returns>
        private static BitArray DeterminePrimeNumbers(int uppperbound)
        {
            var bitArray = new BitArray(uppperbound + 1, true)
                               {
                                   [0] = false,
                                   [1] = false
                               };
            for (var i = 0; i * i <= uppperbound; i++)
            {
                if (!bitArray[i])
                {
                    continue;
                }

                for (var j = i * i; j <= uppperbound; j += i)
                {
                    bitArray[j] = false;
                }
            }

            return bitArray;
        }

        /// <summary>
        /// Generate list of prime numbers
        /// </summary>
        /// <param name="upperbound">
        /// The upper bound limit
        /// </param>
        /// <returns>
        /// A list of only prime numbers up to the specified limit <see cref="IEnumerable"/>.
        /// </returns>
        private static IEnumerable<long> GeneratePrimeNumbers(int upperbound)
        {
            var approx = ApproximateNthPrime(upperbound);
            var bitArray = DeterminePrimeNumbers(approx);
            var primes = new List<long>();
            for (int i = 0, found = 0; i <= approx && found <= upperbound; i++)
            {
                if (!bitArray[i])
                {
                    continue;
                }

                primes.Add(i);
                found++;
            }

            return primes;
        }
    }
}