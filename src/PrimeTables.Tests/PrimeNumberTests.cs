using NUnit.Framework;

namespace PrimeTables.Tests
{
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

        [Test]
        [TestCaseSource(nameof(ExpectedPrimeNumbers))]
        public void Should_match_expected_prime_numbers(PrimeNumberGenerator generator, long[] expectedPrimeNumbers)
        {
            var actualPrimeNumbers = generator.GeneratePrimeNumbers();
            Assert.AreEqual(actualPrimeNumbers, expectedPrimeNumbers);
        }
    }
}