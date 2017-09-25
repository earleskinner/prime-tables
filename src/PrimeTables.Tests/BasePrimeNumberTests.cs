namespace PrimeTables.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    using PrimeTables.Computation;

    [TestFixture]
    public class BasePrimeNumberTests<T> where T : IGenerator
    {
        private readonly IGenerator generator = Activator.CreateInstance<T>();

        public class PrimeNumberInput : IInput
        {
            public PrimeNumberInput(int upperbound)
            {
                UpperBound = upperbound;
            }
            public int UpperBound { get; set; }
        }

        public class PrimeNumberOutput : IOutput
        {
            public int Multipler { get; set; }

            public IEnumerable<long> PrimeNumbers { get; set; }
        }

        public static IEnumerable<TestCaseData> ExpectedPrimeNumbers
        {
            get
            {
                yield return new TestCaseData(0, null);
                yield return new TestCaseData(1, new long[] { 2 });
                yield return new TestCaseData(3, new long[] { 2, 3, 5 });
            }
        }

        /// <summary>
        /// Test the amount of time the generator takes (in milliseconds)
        /// </summary>
        /// <remarks>
        /// The timeouts should be adjusted as code is optimised
        /// </remarks>
        public static IEnumerable<TestCaseData> Timeouts
        {
            get
            {
                yield return new TestCaseData(0, 5);
                yield return new TestCaseData(1, 5);
                yield return new TestCaseData(3, 5);
                yield return new TestCaseData(10000, 100);
                yield return new TestCaseData(20000, 200);
                yield return new TestCaseData(100000, 1000);
                yield return new TestCaseData(1000000, 2000);
            }
        }

        [Test]
        [TestCaseSource(nameof(ExpectedPrimeNumbers))]
        public void Should_match_expected_prime_numbers(int upperbound, long[] expectedPrimeNumbers)
        {
            var input = new PrimeNumberInput(upperbound);
            var output = this.generator.GeneratePrimeNumbers<PrimeNumberOutput>(input);
            Assert.AreEqual(output.PrimeNumbers, expectedPrimeNumbers);
        }

        [Test]
        [TestCaseSource(nameof(Timeouts))]
        public void Should_not_timeout_when_generating_prime_numbers(int upperbound, int maximumTime)
        {
            var start = DateTime.Now;
            var input = new PrimeNumberInput(upperbound);
            this.generator.GeneratePrimeNumbers<PrimeNumberOutput>(input);
            var timeTaken = (DateTime.Now - start).Milliseconds;
            Console.WriteLine($"Time taken: {timeTaken}ms to generate {input.UpperBound} prime numbers");
            Assert.LessOrEqual(timeTaken, maximumTime);
        }
    }
}