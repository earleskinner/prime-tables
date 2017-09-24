using NUnit.Framework;

namespace PrimeTables.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    using PrimeTables.Computation;

    [TestFixture]
    public class PrimeNumberTests
    {
        private static IEnumerable<TestCaseData> ExpectedPrimeNumbers
        {
            get
            {
                yield return new TestCaseData(new PrimeNumberGenerator(0), null);
                yield return new TestCaseData(new PrimeNumberGenerator(1), new long[] { 2 });
                yield return new TestCaseData(new PrimeNumberGenerator(3), new long[] { 2, 3, 5 });
            }
        }

        /// <summary>
        /// Test the amount of time the generator takes (in milliseconds)
        /// </summary>
        /// <remarks>
        /// The timeouts should be adjusted as code is optimised
        /// </remarks>
        private static IEnumerable<TestCaseData> Timeouts
        {
            get
            {
                yield return new TestCaseData(new PrimeNumberGenerator(0), 1);
                yield return new TestCaseData(new PrimeNumberGenerator(1), 1);
                yield return new TestCaseData(new PrimeNumberGenerator(3), 1);
                yield return new TestCaseData(new PrimeNumberGenerator(10000), 500);
                yield return new TestCaseData(new PrimeNumberGenerator(20000), 1000);
            }
        }

        [Test]
        [TestCaseSource(nameof(ExpectedPrimeNumbers))]
        public void Should_match_expected_prime_numbers(PrimeNumberGenerator generator, long[] expectedPrimeNumbers)
        {
            var actualPrimeNumbers = generator.GeneratePrimeNumbers();
            Assert.AreEqual(actualPrimeNumbers, expectedPrimeNumbers);
        }

        [Test]
        [TestCaseSource(nameof(Timeouts))]
        public void Should_not_timeout_when_generating_prime_numbers(PrimeNumberGenerator generator, int maximumTime)
        {
            var start = DateTime.Now;
            generator.GeneratePrimeNumbers();
            var timeTaken = (DateTime.Now - start).Milliseconds;
            Console.WriteLine($"Time taken: {timeTaken}ms to generate {generator.UpperBound} prime numbers");
            Assert.LessOrEqual(timeTaken, maximumTime);
        }
    }
}