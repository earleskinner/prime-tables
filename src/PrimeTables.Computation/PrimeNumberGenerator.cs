namespace PrimeTables.Computation
{
    using System;
    using System.Collections.Generic;

    public class PrimeNumberGenerator : IGenerator
    {
        private readonly List<long> primeNumbers = new List<long>();

        /// <summary>
        /// Initial generation of prime numbers using "trial by division"
        /// Requirements state not to use this algorithm
        /// TODO: Use different algorithm
        /// </summary>
        /// <returns></returns>
        public T GeneratePrimeNumbers<T>(IInput input) where T : IOutput
        {
            if (input.UpperBound == 0)
            {
                return default(T);
            }

            primeNumbers.Add(2);
            var number = 3;
            var counter = 1;

            while (counter < input.UpperBound)
            {
                if (isPrime(number))
                {
                    primeNumbers.Add(number);
                    counter++;
                }

                number += 2;
            }

            var instance = (IOutput)Activator.CreateInstance<T>();
            instance.Multipler = input.UpperBound;
            instance.PrimeNumbers = this.primeNumbers.ToArray();

            return (T)instance;
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